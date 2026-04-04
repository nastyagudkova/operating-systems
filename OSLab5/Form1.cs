using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OSLab5
{
    public partial class Form1 : Form
    {
        // константа для сворачивания окна
        private const int SW_MINIMIZE = 6;

        // константа для разворачивания окна
        private const int SW_MAXIMIZE = 3;

        // константа для восстановления окна
        private const int SW_RESTORE = 9;

        // шаг перемещения окна по экрану
        private const int MOVE_STEP = 50;

        // дескриптор выбранного окна
        private IntPtr _selectedHandle = IntPtr.Zero;

        // генератор случайных координат для режима вируса
        private readonly Random _random = new Random();

        // флаг активности режима вируса
        private bool _virusModeEnabled = false;

        public Form1()
        {
            // инициализируем элементы формы
            InitializeComponent();
        }

        // загружаем список окон при старте формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // загружаем список окон
            LoadWindows();
        }

        #region winapi

        // делегат для перебора окон
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // перечисляем все верхнеуровневые окна
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        // получаем текст заголовка окна
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        // получаем длину текста заголовка окна
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        // получаем имя класса окна
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        // проверяем видимость окна
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        // получаем id процесса по дескриптору окна
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // изменяем заголовок окна
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        // изменяем состояние окна
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // получаем координаты и размеры окна
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // перемещаем и изменяем размер окна
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        // проверяем существование окна
        [DllImport("user32.dll")]
        private static extern bool IsWindow(IntPtr hWnd);

        // получаем текущую позицию курсора мыши
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        // структура для координат окна
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            // левая граница окна
            public int Left;

            // верхняя граница окна
            public int Top;

            // правая граница окна
            public int Right;

            // нижняя граница окна
            public int Bottom;
        }

        // структура для координат курсора
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            // координата курсора по x
            public int X;

            // координата курсора по y
            public int Y;
        }

        #endregion

        #region вспомогательные классы

        // класс для хранения информации об окне
        private class WindowInfo
        {
            // дескриптор окна
            public IntPtr Handle { get; set; }

            // заголовок окна
            public string Title { get; set; }

            // имя класса окна
            public string ClassName { get; set; }

            // признак видимости окна
            public bool Visible { get; set; }

            // id процесса окна
            public uint ProcessId { get; set; }
        }

        #endregion

        #region загрузка списка окон

        // обновляем список окон по кнопке
        private void btnRefreshWindows_Click(object sender, EventArgs e)
        {
            // загружаем список окон и пытаемся сохранить выбор
            LoadWindows(_selectedHandle);
        }

        // загружаем все найденные окна в таблицу
        private void LoadWindows(IntPtr handleToSelect = default(IntPtr))
        {
            // очищаем таблицу
            dgvWindows.Rows.Clear();

            // снимаем текущее выделение
            dgvWindows.ClearSelection();

            // сбрасываем выбранный дескриптор
            _selectedHandle = IntPtr.Zero;

            // очищаем данные выбранного окна
            ClearSelectedWindowInfo();

            // отключаем элементы управления
            SetControlsEnabled(false);

            // индекс строки для повторного выделения
            int rowToSelect = -1;

            // перебираем все окна системы
            EnumWindows((hWnd, lParam) =>
            {
                // получаем информацию о текущем окне
                WindowInfo info = GetWindowInfo(hWnd);

                // добавляем строку в таблицу
                int rowIndex = dgvWindows.Rows.Add(
                    FormatHandle(info.Handle),
                    string.IsNullOrWhiteSpace(info.Title) ? "<без заголовка>" : info.Title,
                    string.IsNullOrWhiteSpace(info.ClassName) ? "<нет class name>" : info.ClassName,
                    info.Visible ? "Да" : "Нет",
                    info.ProcessId.ToString()
                );

                // сохраняем объект с данными окна в строке
                dgvWindows.Rows[rowIndex].Tag = info;

                // запоминаем строку, если это ранее выбранное окно
                if (handleToSelect != IntPtr.Zero && info.Handle == handleToSelect)
                {
                    rowToSelect = rowIndex;
                }

                // продолжаем перечисление окон
                return true;
            }, IntPtr.Zero);

            // восстанавливаем выделение строки, если окно найдено снова
            if (rowToSelect >= 0 && rowToSelect < dgvWindows.Rows.Count)
            {
                // выделяем нужную строку
                dgvWindows.Rows[rowToSelect].Selected = true;

                // делаем активной первую ячейку выделенной строки
                dgvWindows.CurrentCell = dgvWindows.Rows[rowToSelect].Cells[0];
            }
        }

        // собираем информацию об одном окне
        private WindowInfo GetWindowInfo(IntPtr hWnd)
        {
            // возвращаем заполненный объект с данными окна
            return new WindowInfo
            {
                Handle = hWnd,
                Title = GetWindowTitle(hWnd),
                ClassName = GetWindowClassName(hWnd),
                Visible = IsWindowVisible(hWnd),
                ProcessId = GetProcessId(hWnd)
            };
        }

        // получаем текст заголовка окна
        private string GetWindowTitle(IntPtr hWnd)
        {
            // определяем длину текста заголовка
            int length = GetWindowTextLength(hWnd);

            // создаем буфер для текста
            StringBuilder sb = new StringBuilder(Math.Max(length + 1, 2));

            // записываем текст заголовка в буфер
            GetWindowText(hWnd, sb, sb.Capacity);

            // возвращаем текст заголовка
            return sb.ToString();
        }

        // получаем имя класса окна
        private string GetWindowClassName(IntPtr hWnd)
        {
            // создаем буфер для имени класса
            StringBuilder sb = new StringBuilder(256);

            // записываем имя класса в буфер
            GetClassName(hWnd, sb, sb.Capacity);

            // возвращаем имя класса
            return sb.ToString();
        }

        // получаем id процесса по окну
        private uint GetProcessId(IntPtr hWnd)
        {
            // вызываем winapi для получения id процесса
            GetWindowThreadProcessId(hWnd, out uint processId);

            // возвращаем id процесса
            return processId;
        }

        // форматируем дескриптор окна в шестнадцатеричный вид
        private string FormatHandle(IntPtr handle)
        {
            // выбираем формат в зависимости от разрядности процесса
            string format = IntPtr.Size == 8 ? "X16" : "X8";

            // возвращаем строку вида 0x...
            return "0x" + handle.ToInt64().ToString(format);
        }

        #endregion

        #region выбор окна

        // обрабатываем изменение выбранной строки в таблице
        private void dgvWindows_SelectionChanged(object sender, EventArgs e)
        {
            // если строка не выбрана, сбрасываем состояние
            if (dgvWindows.SelectedRows.Count == 0)
            {
                // выключаем режим вируса
                StopVirusMode();

                // сбрасываем дескриптор окна
                _selectedHandle = IntPtr.Zero;

                // очищаем информацию справа
                ClearSelectedWindowInfo();

                // отключаем элементы управления
                SetControlsEnabled(false);
                return;
            }

            // получаем первую выбранную строку
            DataGridViewRow row = dgvWindows.SelectedRows[0];

            // достаем объект с данными окна из тега строки
            WindowInfo info = row.Tag as WindowInfo;

            // если объект не найден, сбрасываем состояние
            if (info == null)
            {
                // выключаем режим вируса
                StopVirusMode();

                // сбрасываем дескриптор окна
                _selectedHandle = IntPtr.Zero;

                // очищаем информацию справа
                ClearSelectedWindowInfo();

                // отключаем элементы управления
                SetControlsEnabled(false);
                return;
            }

            // если режим вируса был включен для другого окна, выключаем его
            if (_virusModeEnabled)
            {
                // останавливаем режим вируса
                StopVirusMode();
            }

            // сохраняем дескриптор выбранного окна
            _selectedHandle = info.Handle;

            // выводим дескриптор окна
            lblSelectedHandleValue.Text = FormatHandle(info.Handle);

            // выводим заголовок окна
            lblSelectedTitleValue.Text = string.IsNullOrWhiteSpace(info.Title) ? "<без заголовка>" : info.Title;

            // выводим id процесса
            lblSelectedPidValue.Text = info.ProcessId.ToString();

            // подставляем текущий заголовок в поле переименования
            txtNewTitle.Text = info.Title;

            // получаем размеры окна
            if (GetWindowRect(info.Handle, out RECT rect))
            {
                // вычисляем ширину окна
                int width = rect.Right - rect.Left;

                // вычисляем высоту окна
                int height = rect.Bottom - rect.Top;

                // записываем ширину в поле
                txtWidth.Text = width.ToString();

                // записываем высоту в поле
                txtHeight.Text = height.ToString();
            }
            else
            {
                // очищаем поле ширины
                txtWidth.Text = "";

                // очищаем поле высоты
                txtHeight.Text = "";
            }

            // включаем элементы управления
            SetControlsEnabled(true);
        }

        // очищаем информацию о выбранном окне
        private void ClearSelectedWindowInfo()
        {
            // очищаем поле дескриптора
            lblSelectedHandleValue.Text = "-";

            // очищаем поле заголовка
            lblSelectedTitleValue.Text = "-";

            // очищаем поле pid
            lblSelectedPidValue.Text = "-";

            // очищаем поле нового заголовка
            txtNewTitle.Text = "";

            // очищаем поле ширины
            txtWidth.Text = "";

            // очищаем поле высоты
            txtHeight.Text = "";
        }

        // включаем или выключаем элементы управления
        private void SetControlsEnabled(bool enabled)
        {
            // включаем или выключаем поле нового заголовка
            txtNewTitle.Enabled = enabled;

            // включаем или выключаем кнопку переименования
            btnSetWindowText.Enabled = enabled;

            // включаем или выключаем кнопку свернуть
            btnMinimize.Enabled = enabled;

            // включаем или выключаем кнопку развернуть
            btnMaximize.Enabled = enabled;

            // включаем или выключаем кнопку восстановить
            btnRestore.Enabled = enabled;

            // включаем или выключаем поле ширины
            txtWidth.Enabled = enabled;

            // включаем или выключаем поле высоты
            txtHeight.Enabled = enabled;

            // включаем или выключаем кнопку изменения размера
            btnResizeWindow.Enabled = enabled;

            // включаем или выключаем кнопку влево
            btnMoveLeft.Enabled = enabled;

            // включаем или выключаем кнопку вправо
            btnMoveRight.Enabled = enabled;

            // включаем или выключаем кнопку вверх
            btnMoveUp.Enabled = enabled;

            // включаем или выключаем кнопку вниз
            btnMoveDown.Enabled = enabled;

            // включаем или выключаем кнопку по центру
            btnMoveCenter.Enabled = enabled;

            // включаем кнопку запуска вируса только если режим не активен
            btnStartVirus.Enabled = enabled && !_virusModeEnabled;

            // включаем кнопку остановки вируса только если режим активен
            btnStopVirus.Enabled = enabled && _virusModeEnabled;
        }

        // проверяем, что выбрано корректное окно для управления
        private bool EnsureSelectedWindow()
        {
            // если дескриптор отсутствует или окно уже не существует, показываем сообщение
            if (_selectedHandle == IntPtr.Zero || !IsWindow(_selectedHandle))
            {
                MessageBox.Show(
                    "Сначала выбери корректное окно из списка.",
                    "Нет выбранного окна",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // обновляем список окон
                LoadWindows();
                return false;
            }

            // получаем заголовок выбранного окна
            string title = GetWindowTitle(_selectedHandle);

            // если заголовок пустой, запрещаем управление
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show(
                    "Нельзя управлять системными или скрытыми окнами без заголовка.",
                    "Ограничение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // окно выбрано корректно
            return true;
        }

        #endregion

        #region переименование окна

        // обрабатываем нажатие на кнопку переименования
        private void btnSetWindowText_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // читаем новый заголовок из поля ввода
            string newTitle = txtNewTitle.Text.Trim();

            // если строка пустая, показываем предупреждение
            if (string.IsNullOrEmpty(newTitle))
            {
                MessageBox.Show(
                    "Введите новый заголовок окна.",
                    "Пустой заголовок",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // пытаемся изменить заголовок окна
            bool result = SetWindowText(_selectedHandle, newTitle);

            // если winapi вернул ошибку, показываем сообщение
            if (!result)
            {
                MessageBox.Show(
                    "Не удалось изменить заголовок окна.\nНекоторые окна не позволяют сохранить новый заголовок.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // обновляем список окон и сохраняем выбор
            LoadWindows(_selectedHandle);
        }

        #endregion

        #region состояние окна

        // обрабатываем нажатие на кнопку свернуть
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // сворачиваем выбранное окно
            ShowWindow(_selectedHandle, SW_MINIMIZE);

            // обновляем список окон
            LoadWindows(_selectedHandle);
        }

        // обрабатываем нажатие на кнопку развернуть
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // разворачиваем выбранное окно
            ShowWindow(_selectedHandle, SW_MAXIMIZE);

            // обновляем список окон
            LoadWindows(_selectedHandle);
        }

        // обрабатываем нажатие на кнопку восстановить
        private void btnRestore_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // восстанавливаем окно в обычное состояние
            ShowWindow(_selectedHandle, SW_RESTORE);

            // обновляем список окон
            LoadWindows(_selectedHandle);
        }

        #endregion

        #region изменение размера

        // обрабатываем нажатие на кнопку изменения размера
        private void btnResizeWindow_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // пытаемся считать новую ширину
            if (!int.TryParse(txtWidth.Text.Trim(), out int newWidth) || newWidth <= 0)
            {
                MessageBox.Show(
                    "Width должен быть положительным целым числом.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // пытаемся считать новую высоту
            if (!int.TryParse(txtHeight.Text.Trim(), out int newHeight) || newHeight <= 0)
            {
                MessageBox.Show(
                    "Height должен быть положительным целым числом.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // получаем текущее положение окна
            if (!GetWindowRect(_selectedHandle, out RECT rect))
            {
                MessageBox.Show(
                    "Не удалось получить размеры и положение окна.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // сначала восстанавливаем окно, если оно было свернуто или развернуто
            ShowWindow(_selectedHandle, SW_RESTORE);

            // изменяем размер окна, сохраняя его позицию
            bool result = MoveWindow(
                _selectedHandle,
                rect.Left,
                rect.Top,
                newWidth,
                newHeight,
                true);

            // если изменение размера не удалось, показываем сообщение
            if (!result)
            {
                MessageBox.Show(
                    "Не удалось изменить размер окна.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // обновляем список окон
            LoadWindows(_selectedHandle);
        }

        #endregion

        #region перемещение окна

        // обрабатываем нажатие на кнопку влево
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            // перемещаем окно влево
            MoveSelectedWindow(-MOVE_STEP, 0, false);
        }

        // обрабатываем нажатие на кнопку вправо
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            // перемещаем окно вправо
            MoveSelectedWindow(MOVE_STEP, 0, false);
        }

        // обрабатываем нажатие на кнопку вверх
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            // перемещаем окно вверх
            MoveSelectedWindow(0, -MOVE_STEP, false);
        }

        // обрабатываем нажатие на кнопку вниз
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            // перемещаем окно вниз
            MoveSelectedWindow(0, MOVE_STEP, false);
        }

        // обрабатываем нажатие на кнопку центрирования
        private void btnMoveCenter_Click(object sender, EventArgs e)
        {
            // перемещаем окно в центр экрана
            MoveSelectedWindow(0, 0, true);
        }

        // выполняем перемещение выбранного окна
        private void MoveSelectedWindow(int dx, int dy, bool moveToCenter)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // получаем текущее положение окна
            if (!GetWindowRect(_selectedHandle, out RECT rect))
            {
                MessageBox.Show(
                    "Не удалось получить текущее положение окна.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // вычисляем ширину окна
            int width = rect.Right - rect.Left;

            // вычисляем высоту окна
            int height = rect.Bottom - rect.Top;

            // переменные для новых координат
            int newX;
            int newY;

            // получаем рабочую область экрана для выбранного окна
            var workArea = Screen.FromHandle(_selectedHandle).WorkingArea;

            // если выбрано центрирование, считаем координаты центра
            if (moveToCenter)
            {
                // рассчитываем новую координату x
                newX = workArea.Left + (workArea.Width - width) / 2;

                // рассчитываем новую координату y
                newY = workArea.Top + (workArea.Height - height) / 2;
            }
            else
            {
                // рассчитываем новую координату x со смещением
                newX = rect.Left + dx;

                // рассчитываем новую координату y со смещением
                newY = rect.Top + dy;

                // не даем окну уйти за левую границу
                if (newX < workArea.Left)
                    newX = workArea.Left;

                // не даем окну уйти за верхнюю границу
                if (newY < workArea.Top)
                    newY = workArea.Top;

                // не даем окну уйти за правую границу
                if (newX + width > workArea.Right)
                    newX = workArea.Right - width;

                // не даем окну уйти за нижнюю границу
                if (newY + height > workArea.Bottom)
                    newY = workArea.Bottom - height;
            }

            // сначала восстанавливаем окно
            ShowWindow(_selectedHandle, SW_RESTORE);

            // перемещаем окно в новую точку
            bool result = MoveWindow(
                _selectedHandle,
                newX,
                newY,
                width,
                height,
                true);

            // если перемещение не удалось, показываем сообщение
            if (!result)
            {
                MessageBox.Show(
                    "Не удалось переместить окно.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // обновляем список окон
            LoadWindows(_selectedHandle);
        }

        #endregion

        #region режим вируса

        // обрабатываем нажатие на кнопку включения вируса
        private void btnStartVirus_Click(object sender, EventArgs e)
        {
            // проверяем выбранное окно
            if (!EnsureSelectedWindow())
                return;

            // включаем режим вируса
            _virusModeEnabled = true;

            // запускаем таймер слежения за курсором
            timerVirus.Start();

            // обновляем доступность кнопок
            SetControlsEnabled(true);
        }

        // обрабатываем нажатие на кнопку выключения вируса
        private void btnStopVirus_Click(object sender, EventArgs e)
        {
            // выключаем режим вируса
            StopVirusMode();
        }

        // срабатываем по таймеру для проверки положения курсора
        private void timerVirus_Tick(object sender, EventArgs e)
        {
            // если режим вируса выключен, ничего не делаем
            if (!_virusModeEnabled)
                return;

            // если окно больше не существует, выключаем режим
            if (_selectedHandle == IntPtr.Zero || !IsWindow(_selectedHandle))
            {
                // выключаем режим вируса
                StopVirusMode();
                return;
            }

            // если курсор находится внутри окна, запускаем убегание
            if (IsCursorInsideWindow(_selectedHandle))
            {
                // перемещаем окно в случайную точку экрана
                RunAway();
            }
        }

        // останавливаем режим вируса и таймер
        private void StopVirusMode()
        {
            // сбрасываем флаг режима
            _virusModeEnabled = false;

            // останавливаем таймер
            timerVirus.Stop();

            // обновляем доступность кнопок
            SetControlsEnabled(_selectedHandle != IntPtr.Zero);
        }

        // проверяем, находится ли курсор внутри окна
        private bool IsCursorInsideWindow(IntPtr hWnd)
        {
            // получаем координаты курсора
            if (!GetCursorPos(out POINT cursor))
                return false;

            // получаем границы окна
            if (!GetWindowRect(hWnd, out RECT rect))
                return false;

            // проверяем попадание курсора внутрь прямоугольника окна
            return cursor.X >= rect.Left &&
                   cursor.X <= rect.Right &&
                   cursor.Y >= rect.Top &&
                   cursor.Y <= rect.Bottom;
        }

        // перемещаем окно в случайную точку экрана
        private void RunAway()
        {
            // если окно не выбрано, завершаем метод
            if (_selectedHandle == IntPtr.Zero)
                return;

            // получаем границы выбранного окна
            if (!GetWindowRect(_selectedHandle, out RECT rect))
                return;

            // вычисляем ширину окна
            int width = rect.Right - rect.Left;

            // вычисляем высоту окна
            int height = rect.Bottom - rect.Top;

            // получаем рабочую область экрана
            var workArea = Screen.FromHandle(_selectedHandle).WorkingArea;

            // вычисляем максимальную координату x для перемещения
            int maxX = workArea.Right - width;

            // вычисляем максимальную координату y для перемещения
            int maxY = workArea.Bottom - height;

            // если окно слишком большое, прижимаем границу
            if (maxX < workArea.Left)
                maxX = workArea.Left;

            // если окно слишком большое, прижимаем границу
            if (maxY < workArea.Top)
                maxY = workArea.Top;

            // генерируем случайную координату x
            int newX = _random.Next(workArea.Left, maxX + 1);

            // генерируем случайную координату y
            int newY = _random.Next(workArea.Top, maxY + 1);

            // восстанавливаем окно перед перемещением
            ShowWindow(_selectedHandle, SW_RESTORE);

            // перемещаем окно в случайную точку
            bool result = MoveWindow(_selectedHandle, newX, newY, width, height, true);

            // если перемещение не удалось, выключаем режим и показываем сообщение
            if (!result)
            {
                // выключаем режим вируса
                StopVirusMode();

                MessageBox.Show(
                    "Не удалось переместить окно в режиме вируса.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }

        #endregion
    }
}