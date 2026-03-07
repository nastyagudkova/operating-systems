using System;
using System.IO; // io - работа с файлами и папками
using System.Runtime.InteropServices; // runtime.interopservices - импорт winapi функций
using System.Windows.Forms;

namespace OSlab3
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")] // dllimport - импорт функции из dll
        private static extern uint GetLogicalDrives(); // private - доступ только внутри класса, static - принадлежит классу, extern - внешняя функция, uint - беззнаковое целое

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)] // charset - кодировка строк, auto - автоматический выбор кодировки
        private static extern uint GetDriveType(string lpRootPathName); // string - строка

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)] // setlasterror - сохраняет код последней ошибки, true - истина
        private static extern bool GetDiskFreeSpaceEx( // bool - логический тип
            string lpDirectoryName,
            out ulong lpFreeBytesAvailable, // out - передача параметра по ссылке для вывода значения, ulong - беззнаковое длинное целое
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)] // unicode - юникод кодировка
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp); // int - целое число, ref - передача по ссылке

        private const int FO_MOVE = 0x0001; // const - константа, 0x0001 - шестнадцатеричное число, код операции перемещения
        private const int FO_COPY = 0x0002; // код операции копирования
        private const int FO_DELETE = 0x0003; // код операции удаления
        private const int FO_RENAME = 0x0004; // код операции переименования

        private const int FOF_NOCONFIRMATION = 0x0010; // флаг без подтверждения пользователя
        private const int FOF_NOERRORUI = 0x0400; // флаг без стандартного окна ошибки
        private const int FOF_SILENT = 0x0004; // флаг без звуков и лишних уведомлений

        private const uint DRIVE_UNKNOWN = 0; // тип диска неизвестен
        private const uint DRIVE_NO_ROOT_DIR = 1; // нет корневой папки
        private const uint DRIVE_REMOVABLE = 2; // съёмный диск
        private const uint DRIVE_FIXED = 3; // жёсткий диск
        private const uint DRIVE_REMOTE = 4; // сетевой диск
        private const uint DRIVE_CDROM = 5; // cd/dvd
        private const uint DRIVE_RAMDISK = 6; // ram-диск

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)] // structlayout - описание расположения полей структуры, sequential - поля идут по порядку
        private struct SHFILEOPSTRUCT // struct - структура
        {
            public IntPtr hwnd; // intptr - указатель на окно
            public uint wFunc; // код файловой операции
            public string pFrom; // исходный путь
            public string pTo; // путь назначения
            public ushort fFlags; // ushort - беззнаковое короткое целое, флаги операции
            public bool fAnyOperationsAborted; // признак прерванной операции
            public IntPtr hNameMappings; // служебный указатель
            public string lpszProgressTitle; // заголовок окна прогресса
        }

        public Form1()
        {
            InitializeComponent(); // initializecomponent - инициализация элементов формы
        }

        private void Form1_Load(object sender, EventArgs e) // void - метод без возвращаемого значения
        {
            RefreshDrives(); // вызываем обновление списка дисков при запуске формы
            AddLog("Программа запущена"); // добавляем запись в журнал о старте программы
        }

        private void buttonRefreshDisks_Click(object sender, EventArgs e)
        {
            RefreshDrives(); // обновляем список дисков по нажатию кнопки
            AddLog("Список дисков обновлён"); // записываем действие в журнал
        }

        private void buttonBrowseSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) // if - условие, showdialog - показать диалог, == - равно, dialogresult.ok - пользователь подтвердил выбор
            {
                textBoxSourcePath.Text = folderBrowserDialog1.SelectedPath; // textboxsourcepath.text - текст в поле исходной папки, selectedpath - выбранный путь
            }
        }

        private void buttonBrowseDest_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxDestPath.Text = folderBrowserDialog1.SelectedPath; // записываем выбранную папку в поле назначения
            }
        }

        private void buttonCopyFolder_Click(object sender, EventArgs e)
        {
            string source = textBoxSourcePath.Text.Trim(); // = - присваивание, trim - удаляет пробелы в начале и конце строки
            string dest = textBoxDestPath.Text.Trim();

            if (!Directory.Exists(source)) // ! - логическое не, directory.exists - проверка существования папки
            {
                ShowError("Исходная папка не найдена."); // выводим сообщение об ошибке
                return; // return - выход из метода
            }

            if (string.IsNullOrWhiteSpace(dest)) // isnullorwhitespace - строка пуста или состоит из пробелов
            {
                ShowError("Укажите папку назначения.");
                return;
            }

            int result = FileOperation(FO_COPY, source, dest); // вызываем winapi операцию копирования папки

            if (result == 0)
            {
                AddLog("Папка скопирована: " + source + " -> " + dest); // + - конкатенация строк, -> - стрелка в тексте для наглядности
                RefreshDrives(); // обновляем информацию о дисках после копирования
            }
            else // else - иначе
            {
                ShowError("Ошибка копирования. Код: " + result);
            }
        }

        private void buttonMoveFolder_Click(object sender, EventArgs e)
        {
            string source = textBoxSourcePath.Text.Trim();
            string dest = textBoxDestPath.Text.Trim();

            if (!Directory.Exists(source))
            {
                ShowError("Исходная папка не найдена.");
                return;
            }

            if (string.IsNullOrWhiteSpace(dest))
            {
                ShowError("Укажите папку назначения.");
                return;
            }

            int result = FileOperation(FO_MOVE, source, dest); // вызываем winapi операцию перемещения папки

            if (result == 0)
            {
                AddLog("Папка перемещена: " + source + " -> " + dest);
                textBoxSourcePath.Clear(); // clear - очистка текстового поля
                RefreshDrives();
            }
            else
            {
                ShowError("Ошибка перемещения. Код: " + result);
            }
        }

        private void buttonRenameFolder_Click(object sender, EventArgs e)
        {
            string source = textBoxSourcePath.Text.Trim();
            string newName = textBoxNewName.Text.Trim();

            if (!Directory.Exists(source))
            {
                ShowError("Исходная папка не найдена.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                ShowError("Введите новое имя папки.");
                return;
            }

            string parentPath = Path.GetDirectoryName(source); // path.getdirectoryname - получить путь родительской папки

            if (string.IsNullOrWhiteSpace(parentPath))
            {
                ShowError("Не удалось определить родительскую папку.");
                return;
            }

            string newFullPath = Path.Combine(parentPath, newName); // path.combine - объединение частей пути

            int result = FileOperation(FO_RENAME, source, newFullPath); // вызываем winapi операцию переименования

            if (result == 0)
            {
                AddLog("Папка переименована: " + source + " -> " + newFullPath);
                textBoxSourcePath.Text = newFullPath;
                textBoxNewName.Clear();
                RefreshDrives();
            }
            else
            {
                ShowError("Ошибка переименования. Код: " + result);
            }
        }

        private void buttonDeleteFolder_Click(object sender, EventArgs e)
        {
            string source = textBoxSourcePath.Text.Trim();

            if (!Directory.Exists(source))
            {
                ShowError("Папка для удаления не найдена.");
                return;
            }

            DialogResult dr = MessageBox.Show( // messagebox.show - показать окно сообщения
                "Удалить папку?\n" + source, // \n - перевод строки
                "Подтверждение",
                MessageBoxButtons.YesNo, // messageboxbuttons.yesno - кнопки да и нет
                MessageBoxIcon.Question); // messageboxicon.question - значок вопроса

            if (dr != DialogResult.Yes) // != - не равно, dialogresult.yes - пользователь нажал да
                return;

            int result = FileOperation(FO_DELETE, source, null); // null - отсутствие значения, вызываем winapi операцию удаления

            if (result == 0)
            {
                AddLog("Папка удалена: " + source);
                textBoxSourcePath.Clear();
                textBoxDestPath.Clear();
                textBoxNewName.Clear();
                RefreshDrives();
            }
            else
            {
                ShowError("Ошибка удаления. Код: " + result);
            }
        }

        private void timerDiskUpdate_Tick(object sender, EventArgs e)
        {
            RefreshDrives(); // по таймеру заново обновляем список дисков и их свободное место
        }

        private void RefreshDrives()
        {
            dataGridViewDisks.Rows.Clear(); // datagridviewdisks.rows.clear - очищаем все строки таблицы

            uint driveMask = GetLogicalDrives(); // получаем битовую маску всех логических дисков

            for (int i = 0; i < 26; i++) // for - цикл, < - меньше
            {
                if ((driveMask & (1u << i)) != 0) // & - побитовое и, << - сдвиг влево, 1u - беззнаковая единица
                {
                    string driveName = ((char)('A' + i)) + @":\"; // char - символ, @ - дословная строка без экранирования

                    uint driveType = GetDriveType(driveName); // определяем тип текущего диска
                    string driveTypeText = GetDriveTypeText(driveType); // переводим тип диска в текст

                    ulong freeBytesAvailable; // объявляем переменную доступных свободных байт
                    ulong totalBytes; // объявляем переменную общего объёма
                    ulong totalFreeBytes; // объявляем переменную общего свободного места

                    string totalGb = "-"; // по умолчанию ставим прочерк
                    string freeGb = "-";
                    string usedGb = "-";

                    bool success = GetDiskFreeSpaceEx( // вызываем winapi функцию получения информации о размере диска
                        driveName,
                        out freeBytesAvailable,
                        out totalBytes,
                        out totalFreeBytes);

                    if (success)
                    {
                        double total = BytesToGb(totalBytes); // double - вещественное число, переводим общий объём из байт в гигабайты
                        double free = BytesToGb(totalFreeBytes); // переводим свободное место в гигабайты
                        double used = total - free; // - - вычитание, вычисляем занятое место

                        totalGb = total.ToString("F2"); // tostring - преобразование в строку, f2 - 2 знака после запятой
                        freeGb = free.ToString("F2");
                        usedGb = used.ToString("F2");
                    }

                    dataGridViewDisks.Rows.Add(driveName, driveTypeText, totalGb, freeGb, usedGb); // rows.add - добавляем строку в таблицу
                }
            }
        }

        private string GetDriveTypeText(uint driveType)
        {
            switch (driveType) // switch - выбор варианта по значению
            {
                case DRIVE_REMOVABLE: // case - вариант значения
                    return "Съёмный";
                case DRIVE_FIXED:
                    return "Жёсткий";
                case DRIVE_REMOTE:
                    return "Сетевой";
                case DRIVE_CDROM:
                    return "CD/DVD";
                case DRIVE_RAMDISK:
                    return "RAM-диск";
                case DRIVE_NO_ROOT_DIR:
                    return "Нет корня";
                default: // default - вариант по умолчанию
                    return "Неизвестно";
            }
        }

        private double BytesToGb(ulong bytes)
        {
            return bytes / 1024.0 / 1024.0 / 1024.0; // / - деление, переводим байты в гигабайты
        }

        private int FileOperation(int operation, string source, string dest)
        {
            SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT(); // создаём структуру для передачи параметров файловой операции
            fileOp.wFunc = (uint)operation; // (uint) - явное преобразование типа
            fileOp.pFrom = source + '\0' + '\0'; // '\0' - нулевой символ завершения строки для winapi
            fileOp.pTo = dest == null ? null : dest + '\0' + '\0'; // ? : - тернарный оператор, если dest null то null, иначе путь назначения
            fileOp.fFlags = (ushort)(FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_SILENT); // | - побитовое или, (ushort) - приведение к ushort

            return SHFileOperation(ref fileOp); // вызываем winapi файловую операцию и возвращаем код результата
        }

        private void AddLog(string message)
        {
            textBoxLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - " + message + Environment.NewLine); // appendtext - добавить текст, datetime.now - текущее время, environment.newline - перевод строки
        }

        private void ShowError(string message)
        {
            AddLog("Ошибка: " + message); // записываем ошибку в журнал
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // messageboxbuttons.ok - кнопка ок, messageboxicon.error - значок ошибки
        }
    }
}