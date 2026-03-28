using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OSlab4
{
    public partial class Form1 : Form
    {
        // количество дочерних потоков
        private const int threadCount = 4;

        // константы для ожидания
        private const uint INFINITE = 0xFFFFFFFF;
        private const uint WAIT_OBJECT_0 = 0x00000000;

        // свое сообщение для обновления формы из потока
        private const int WM_APP = 0x8000; //специальная граница для своих сообщений: до 0x8000 — системные сообщения, после — можно свои делать
        private const int WM_UPDATE_THREAD = WM_APP + 1;

        // приоритеты потоков
        private const int THREAD_PRIORITY_LOWEST = -2; //самый низкий
        private const int THREAD_PRIORITY_BELOW_NORMAL = -1; //ниже обычного
        private const int THREAD_PRIORITY_NORMAL = 0; // обычный
        private const int THREAD_PRIORITY_ABOVE_NORMAL = 1; //выше обычного
        private const int THREAD_PRIORITY_HIGHEST = 2; // высокий

        // поток будет запускать функцию такого-то вида
        private delegate uint ThreadFunction(IntPtr param);

        // импорт win api для создания потока
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateThread( //возвращает тип IntPtr - дескриптор потока (ссылка на поток)
            IntPtr lpThreadAttributes, // (используем IntPtr.Zero = стандартно)
            uint dwStackSize, //размер памяти (стека) для потока (пишем 0 = возьми стандартный размер)
            ThreadFunction lpStartAddress, //функция, которую будет выполнять поток
            IntPtr lpParameter, //ее параметр (номер потока)
            uint dwCreationFlags, //флаги создания потока (пишем 0 = создать и сразу запустить)
            out uint lpThreadId); // сюда Windows записывает ID потока (просто получаем номер потока от системы)

        // импорт win api для создания события
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateEvent( //возвращает IntPtr - дескриптор события (ссылка на событие)
            IntPtr lpEventAttributes, //настройки безопасности (используем IntPtr.Zero = стандартно)
            bool bManualReset, //тип события (true = вручную сбрасываем, используем true чтобы управлять паузой потока)
            bool bInitialState, //начальное состояние (false = поток сначала остановлен)
            string lpName); //имя события (не используем, пишем null)


        // импорт win api для создания мьютекса
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateMutex( //возвращает IntPtr - дескриптор мьютекса (ссылка на мьютекс)
            IntPtr lpMutexAttributes, //настройки безопасности (используем IntPtr.Zero = стандартно)
            bool bInitialOwner, //захват мьютекса сразу (false = поток не захватывает сразу)
            string lpName); //имя мьютекса (не используем, пишем null)


        // импорт win api для ожидания объекта
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint WaitForSingleObject( //возвращает результат ожидания (например WAIT_OBJECT_0)
            IntPtr hHandle, //дескриптор объекта (событие или мьютекс, который ждем)
            uint dwMilliseconds); //сколько ждать (INFINITE = ждать бесконечно, 0 = не ждать)

        // импорт win api для установки события
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetEvent(IntPtr hEvent);

        // импорт win api для сброса события
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ResetEvent(IntPtr hEvent);

        // импорт win api для освобождения мьютекса
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReleaseMutex(IntPtr hMutex);

        // импорт win api для закрытия дескриптора
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        // импорт win api для изменения приоритета потока
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetThreadPriority(IntPtr hThread, int nPriority);

        // импорт win api для задержки
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void Sleep(uint dwMilliseconds);

        // импорт win api для отправки сообщения окну
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage( // удалось ли отправить сообщение
            IntPtr hWnd, //дескриптор окна (форма, куда отправляем сообщение)
            int msg, //код сообщения (например WM_UPDATE_THREAD = "обнови данные на форме")
            IntPtr wParam, //дополнительный параметр (передаем номер потока)
            IntPtr lParam); //дополнительный параметр (не используем, пишем IntPtr.Zero)

        // здесь храним дескрипторы потоков
        private IntPtr[] threadHandles = new IntPtr[threadCount];

        // здесь храним события пуск или пауза
        private IntPtr[] runEvents = new IntPtr[threadCount];

        // здесь храним события стоп
        private IntPtr[] stopEvents = new IntPtr[threadCount];

        // здесь храним делегаты, чтобы сборщик мусора их не удалил
        private ThreadFunction[] threadDelegates = new ThreadFunction[threadCount];

        // мьютекс для общей переменной
        private IntPtr dataMutex = IntPtr.Zero;

        // дескриптор формы для отправки сообщений
        private IntPtr formHandle = IntPtr.Zero;

        // общее значение, с которым работают все потоки
        private int sharedValue = 0;

        // что поток получил от главного
        private int[] receivedValues = new int[threadCount];

        // что поток вернул главному
        private int[] returnedValues = new int[threadCount];

        // ссылки на элементы формы для удобства
        private Label[] stateLabels;
        private TextBox[] receivedTextBoxes;
        private TextBox[] returnedTextBoxes;
        private ComboBox[] priorityComboBoxes;
        private Button[] startButtons;
        private Button[] pauseButtons;
        private Button[] stopButtons;

        public Form1()
        {
            InitializeComponent();

            // собираем элементы формы в массивы, чтобы можно было обращаться к ним по номеру потока
            stateLabels = new Label[]
            {
                labelStateValue1, labelStateValue2, labelStateValue3, labelStateValue4
            };

            receivedTextBoxes = new TextBox[]
            {
                txtReceived1, txtReceived2, txtReceived3, txtReceived4
            };

            returnedTextBoxes = new TextBox[]
            {
                txtReturned1, txtReturned2, txtReturned3, txtReturned4
            };

            priorityComboBoxes = new ComboBox[]
            {
                cmbPriority1, cmbPriority2, cmbPriority3, cmbPriority4
            };

            startButtons = new Button[]
            {
                btnStart1, btnStart2, btnStart3, btnStart4
            };

            pauseButtons = new Button[]
            {
                btnPause1, btnPause2, btnPause3, btnPause4
            };

            stopButtons = new Button[]
            {
                btnStop1, btnStop2, btnStop3, btnStop4
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // получаем ссылку на форму
            formHandle = this.Handle;

            // создаем мьютекс для защиты общей переменной
            dataMutex = CreateMutex(IntPtr.Zero, false, null);

            // создаем события для каждого потока
            for (int i = 0; i < threadCount; i++)
            {
                // событие для пуска и паузы
                runEvents[i] = CreateEvent(IntPtr.Zero, true, false, null);

                // событие для остановки
                stopEvents[i] = CreateEvent(IntPtr.Zero, true, false, null);
            }

            // читаем начальное значение из поля главного потока
            int number;
            if (int.TryParse(txtParentValue.Text, out number))
            {
                sharedValue = number;
                txtCommonCounter.Text = number.ToString();
            }
            else
            {
                // если введено не число, ставим 0
                sharedValue = 0;
                txtParentValue.Text = "0";
                txtCommonCounter.Text = "0";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // при закрытии формы останавливаем все потоки
            for (int i = 0; i < threadCount; i++)
            {
                StopThread(i);
            }

            // закрываем все события
            for (int i = 0; i < threadCount; i++)
            {
                if (runEvents[i] != IntPtr.Zero)
                {
                    CloseHandle(runEvents[i]);
                    runEvents[i] = IntPtr.Zero;
                }

                if (stopEvents[i] != IntPtr.Zero)
                {
                    CloseHandle(stopEvents[i]);
                    stopEvents[i] = IntPtr.Zero;
                }
            }

            // закрываем мьютекс
            if (dataMutex != IntPtr.Zero)
            {
                CloseHandle(dataMutex);
                dataMutex = IntPtr.Zero;
            }
        }

        private void txtParentValue_TextChanged(object sender, EventArgs e)
        {
            // проверяем, что введено число
            int number;
            if (!int.TryParse(txtParentValue.Text, out number))
            {
                return;
            }

            // безопасно записываем новое значение в общую переменную
            WaitForSingleObject(dataMutex, INFINITE);
            sharedValue = number;
            ReleaseMutex(dataMutex);

            // сразу показываем это значение в общем счетчике
            txtCommonCounter.Text = number.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // определяем номер потока по tag кнопки
            int index = GetIndexFromTag(sender);

            // если поток еще не создан, создаем его
            if (threadHandles[index] == IntPtr.Zero)
            {
                // сбрасываем стоп на всякий случай
                ResetEvent(stopEvents[index]);

                // разрешаем потоку работать
                SetEvent(runEvents[index]);

                // сохраняем делегат
                threadDelegates[index] = ThreadWork;

                // создаем поток
                uint threadId;
                threadHandles[index] = CreateThread(
                    IntPtr.Zero,
                    0,
                    threadDelegates[index],
                    new IntPtr(index),
                    0,
                    out threadId);

                // задаем приоритет потоку
                SetThreadPriority(threadHandles[index], GetPriorityFromCombo(index));
            }
            else
            {
                // если поток уже есть, просто снимаем паузу
                SetEvent(runEvents[index]);
            }

            // обновляем состояние на форме
            stateLabels[index].Text = "Работает";
            startButtons[index].Enabled = false;
            pauseButtons[index].Enabled = true;
            stopButtons[index].Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            // определяем номер потока по tag кнопки
            int index = GetIndexFromTag(sender);

            // если поток не создан, ничего не делаем
            if (threadHandles[index] == IntPtr.Zero)
            {
                return;
            }

            // переводим поток в паузу
            ResetEvent(runEvents[index]);

            // обновляем состояние на форме
            stateLabels[index].Text = "Пауза";
            startButtons[index].Enabled = true;
            pauseButtons[index].Enabled = false;
            stopButtons[index].Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // определяем номер потока по tag кнопки
            int index = GetIndexFromTag(sender);

            // останавливаем поток
            StopThread(index);
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // определяем номер потока по tag списка
            int index = GetIndexFromTag(sender);

            // если поток уже существует, меняем ему приоритет сразу
            if (threadHandles[index] != IntPtr.Zero)
            {
                SetThreadPriority(threadHandles[index], GetPriorityFromCombo(index));
            }
        }

        private uint ThreadWork(IntPtr param)
        {
            // получаем номер потока
            int index = param.ToInt32();

            // бесконечный цикл работы потока
            while (true)
            {
                // если нажали стоп, выходим
                if (WaitForSingleObject(stopEvents[index], 0) == WAIT_OBJECT_0)
                {
                    break;
                }

                // ждем, пока поток разрешат запустить
                WaitForSingleObject(runEvents[index], INFINITE);

                // после выхода из паузы еще раз проверяем стоп
                if (WaitForSingleObject(stopEvents[index], 0) == WAIT_OBJECT_0)
                {
                    break;
                }

                // захватываем мьютекс, чтобы только один поток менял общее значение
                WaitForSingleObject(dataMutex, INFINITE);

                // поток берет текущее значение от главного потока
                receivedValues[index] = sharedValue;

                // поток изменяет значение
                sharedValue = sharedValue + 1;

                // поток сохраняет, что он вернул обратно
                returnedValues[index] = sharedValue;

                // освобождаем мьютекс
                ReleaseMutex(dataMutex);

                // просим форму обновить данные этого потока
                PostMessage(formHandle, WM_UPDATE_THREAD, new IntPtr(index), IntPtr.Zero);

                // маленькая задержка, чтобы было видно работу
                Sleep(300);
            }

            return 0;
        }

        private void StopThread(int index)
        {
            // если потока нет, просто обновляем кнопки и надпись
            if (threadHandles[index] == IntPtr.Zero)
            {
                stateLabels[index].Text = "Остановлен";
                startButtons[index].Enabled = true;
                pauseButtons[index].Enabled = false;
                stopButtons[index].Enabled = false;
                return;
            }

            // подаем сигнал на остановку
            SetEvent(stopEvents[index]);

            // на всякий случай снимаем паузу, чтобы поток смог дойти до завершения
            SetEvent(runEvents[index]);

            // ждем завершения потока
            WaitForSingleObject(threadHandles[index], INFINITE);

            // закрываем дескриптор потока
            CloseHandle(threadHandles[index]);
            threadHandles[index] = IntPtr.Zero;

            // сбрасываем события для возможного нового запуска
            ResetEvent(runEvents[index]);
            ResetEvent(stopEvents[index]);

            // обновляем состояние на форме
            stateLabels[index].Text = "Остановлен";
            startButtons[index].Enabled = true;
            pauseButtons[index].Enabled = false;
            stopButtons[index].Enabled = false;
        }

        private int GetIndexFromTag(object sender)
        {
            // берем tag элемента и переводим его в индекс массива
            Control control = (Control)sender;
            return Convert.ToInt32(control.Tag) - 1;
        }

        private int GetPriorityFromCombo(int index)
        {
            // читаем русский текст из comboBox
            string text = priorityComboBoxes[index].Text;

            // переводим русский текст в константу win api
            switch (text)
            {
                case "Низкий":
                    return THREAD_PRIORITY_LOWEST;

                case "Ниже обычного":
                    return THREAD_PRIORITY_BELOW_NORMAL;

                case "Выше обычного":
                    return THREAD_PRIORITY_ABOVE_NORMAL;

                case "Высокий":
                    return THREAD_PRIORITY_HIGHEST;

                default:
                    return THREAD_PRIORITY_NORMAL;
            }
        }

        private void UpdateThreadData(int index)
        {
            int received;
            int returned;
            int currentValue;

            // читаем данные под мьютексом
            WaitForSingleObject(dataMutex, INFINITE);
            received = receivedValues[index];
            returned = returnedValues[index];
            currentValue = sharedValue;
            ReleaseMutex(dataMutex);

            // показываем на форме, что получил поток
            receivedTextBoxes[index].Text = received.ToString();

            // показываем на форме, что вернул поток
            returnedTextBoxes[index].Text = returned.ToString();

            // обновляем данные главного потока
            txtParentValue.Text = currentValue.ToString();
            txtCommonCounter.Text = currentValue.ToString();
        }

        protected override void WndProc(ref Message m)
        {
            // если пришло сообщение от потока, обновляем форму
            if (m.Msg == WM_UPDATE_THREAD)
            {
                int index = m.WParam.ToInt32();
                UpdateThreadData(index);
                return;
            }

            // все остальные сообщения обрабатываем как обычно
            base.WndProc(ref m);
        }
    }
}