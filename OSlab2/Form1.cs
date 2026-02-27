using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OSlab2part2
{
    public partial class Form1 : Form
    {
        //состояние:папка корзины программы
        private string TrashFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "RecycleBinSimple");
        //состояние:сейчас открыт просмотр корзины
        private bool isTrashView = false;

        //WinAPI:константы
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint FILE_SHARE_READ = 0x00000001;
        private const uint OPEN_EXISTING = 3;
        private const uint CREATE_ALWAYS = 2;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_BEGIN = 0;

        //WinAPI:структуры для перечисления файлов
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FILETIME
        {
            public int dwLowDateTime;
            public int dwHighDateTime;
        }

        //WinAPI:перечисление файлов
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr FindFirstFileW(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool FindNextFileW(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

        //WinAPI:создание/открытие файла
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr CreateFileW(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        //WinAPI:операции над файлами
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool DeleteFileW(string lpFileName);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool MoveFileW(string lpExistingFileName, string lpNewFileName);

        //WinAPI:изменение размера файла
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetFilePointerEx(IntPtr hFile, long liDistanceToMove, out long lpNewFilePointer, uint dwMoveMethod);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetEndOfFile(IntPtr hFile);

        public Form1()
        {
            InitializeComponent();
            //загрузка дисков в TreeView
            LoadDrives();
            //события дерева
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
        }

        //UI:загрузить диски
        private void LoadDrives()
        {
            treeView1.Nodes.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                var node = new TreeNode(drive.Name);
                node.Tag = drive.Name;//путь
                node.Nodes.Add("...");//заглушка для раскрытия
                treeView1.Nodes.Add(node);
            }
        }

        //UI:раскрытие папок в TreeView
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //если есть заглушка,подгружаем подпапки
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "...")
            {
                e.Node.Nodes.Clear();
                string path = (string)e.Node.Tag;
                try
                {
                    foreach (string dir in Directory.GetDirectories(path))
                    {
                        var child = new TreeNode(Path.GetFileName(dir));
                        child.Tag = dir;//путь подпапки
                        child.Nodes.Add("...");
                        e.Node.Nodes.Add(child);
                    }
                }
                catch
                {
                    //нет прав доступа
                }
            }
        }

        //UI:выбор папки слева->показать файлы справа
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            isTrashView = false;//вышли из режима корзины
            string folderPath = (string)e.Node.Tag;
            ShowFiles_WinApi(folderPath);//показать файлы
        }

        //WinAPI:показать файлы в ListView
        private void ShowFiles_WinApi(string folderPath)
        {
            listView1.Items.Clear();
            string search = Path.Combine(folderPath, "*");
            WIN32_FIND_DATA data;
            IntPtr hFind = FindFirstFileW(search, out data);
            if (hFind == INVALID_HANDLE_VALUE) return;

            try
            {
                do
                {
                    string name = data.cFileName;
                    if (name == "." || name == "..") continue;
                    bool isDir = (data.dwFileAttributes & FileAttributes.Directory) != 0;
                    if (isDir) continue;//показываем только файлы

                    long size = ((long)data.nFileSizeHigh << 32) + data.nFileSizeLow;
                    long ft = (((long)data.ftLastWriteTime.dwHighDateTime) << 32) | (uint)data.ftLastWriteTime.dwLowDateTime;
                    DateTime modified = DateTime.FromFileTimeUtc(ft).ToLocalTime();

                    var item = new ListViewItem(name);
                    item.SubItems.Add(size.ToString());
                    item.SubItems.Add(modified.ToString());
                    item.Tag = Path.Combine(folderPath, name);//полный путь
                    listView1.Items.Add(item);

                } while (FindNextFileW(hFind, out data));
            }
            finally
            {
                FindClose(hFind);//закрыть поиск
            }
        }

        //создать файл и записать текст
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Выбери папку слева.");
                return;
            }

            string folderPath = (string)treeView1.SelectedNode.Tag;
            string filePath = Path.Combine(folderPath, "test.txt");

            IntPtr hFile = CreateFileW(filePath, GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (hFile == INVALID_HANDLE_VALUE)
            {
                MessageBox.Show("Не удалось создать файл. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            try
            {
                //запись в файл через WinAPI
                byte[] data = System.Text.Encoding.UTF8.GetBytes("Файл создан через WinAPI\r\n");
                if (!WriteFile(hFile, data, (uint)data.Length, out uint written, IntPtr.Zero))
                {
                    MessageBox.Show("Не удалось записать. Ошибка: " + Marshal.GetLastWin32Error());
                    return;
                }
            }
            finally
            {
                CloseHandle(hFile);//закрыть файл
            }

            //обновить список
            ShowFiles_WinApi(folderPath);
        }

        //удалить файл навсегда
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл справа.");
                return;
            }

            string filePath = (string)listView1.SelectedItems[0].Tag;
            var result = MessageBox.Show("Удалить файл?\n" + filePath, "Подтверждение", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            //удаление через WinAPI
            if (!DeleteFileW(filePath))
            {
                MessageBox.Show("Не удалось удалить. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            //обновить список
            if (treeView1.SelectedNode != null) ShowFiles_WinApi((string)treeView1.SelectedNode.Tag);
        }

        //переместить файл в корзину программы
        private void btnTrash_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл справа.");
                return;
            }

            string filePath = (string)listView1.SelectedItems[0].Tag;
            string fileName = Path.GetFileName(filePath);

            //создать папку корзины
            Directory.CreateDirectory(TrashFolder);

            //уникальное имя в корзине
            string newName = DateTime.Now.ToString("yyyyMMdd_HHmmss_") + fileName;
            string destPath = Path.Combine(TrashFolder, newName);

            //перемещение через WinAPI
            if (!MoveFileW(filePath, destPath))
            {
                MessageBox.Show("Не удалось переместить. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            //обновить список
            if (treeView1.SelectedNode != null) ShowFiles_WinApi((string)treeView1.SelectedNode.Tag);
            MessageBox.Show("Файл перемещён в корзину программы.");
        }

        //открыть корзину программы в ListView
        private void btnTrashView_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(TrashFolder);//на всякий случай
            isTrashView = true;//режим корзины
            ShowFiles_WinApi(TrashFolder);//показать содержимое корзины
        }

        //восстановить выбранный файл из корзины в выбранную папку
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!isTrashView)
            {
                MessageBox.Show("Сначала открой корзину кнопкой 'Корзина'.");
                return;
            }

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл в корзине (справа).");
                return;
            }

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Выбери папку слева, куда восстанавливать.");
                return;
            }

            string trashedFilePath = (string)listView1.SelectedItems[0].Tag;
            string restoreFolder = (string)treeView1.SelectedNode.Tag;

            //вытаскиваем исходное имя без префикса даты
            string nameWithPrefix = Path.GetFileName(trashedFilePath);
            string originalName = nameWithPrefix;
            if (originalName.Length > 16 && originalName[8] == '_' && originalName[15] == '_') originalName = originalName.Substring(16);

            string destPath = Path.Combine(restoreFolder, originalName);

            //восстановление через WinAPI
            if (!MoveFileW(trashedFilePath, destPath))
            {
                MessageBox.Show("Не удалось восстановить. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            //обновить корзину справа
            ShowFiles_WinApi(TrashFolder);
            MessageBox.Show("Восстановлено в: " + destPath);
        }

        //копировать по частям (потоками) через ReadFile/WriteFile
        private void btnCopyStream_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл справа.");
                return;
            }

            if (isTrashView)
            {
                MessageBox.Show("Выйди из режима корзины (выбери папку слева), затем копируй файл.");
                return;
            }

            string srcPath = (string)listView1.SelectedItems[0].Tag;
            string folder = Path.GetDirectoryName(srcPath);
            string fileName = Path.GetFileName(srcPath);
            string dstPath = Path.Combine(folder, "copy_" + fileName);

            //открыть исходный файл на чтение
            IntPtr hSrc = CreateFileW(srcPath, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (hSrc == INVALID_HANDLE_VALUE)
            {
                MessageBox.Show("Не удалось открыть исходный файл. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            //создать файл-копию на запись
            IntPtr hDst = CreateFileW(dstPath, GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (hDst == INVALID_HANDLE_VALUE)
            {
                CloseHandle(hSrc);
                MessageBox.Show("Не удалось создать файл-копию. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            try
            {
                //копирование буфером 64КБ
                byte[] buffer = new byte[64 * 1024];
                while (true)
                {
                    //читать кусок
                    if (!ReadFile(hSrc, buffer, (uint)buffer.Length, out uint bytesRead, IntPtr.Zero))
                    {
                        MessageBox.Show("Ошибка чтения. Ошибка: " + Marshal.GetLastWin32Error());
                        return;
                    }
                    if (bytesRead == 0) break;//конец файла

                    //записать кусок
                    byte[] toWrite = buffer;
                    if (bytesRead != buffer.Length)
                    {
                        toWrite = new byte[bytesRead];
                        Array.Copy(buffer, toWrite, bytesRead);
                    }
                    if (!WriteFile(hDst, toWrite, bytesRead, out uint bytesWritten, IntPtr.Zero))
                    {
                        MessageBox.Show("Ошибка записи. Ошибка: " + Marshal.GetLastWin32Error());
                        return;
                    }
                }
            }
            finally
            {
                CloseHandle(hDst);//закрыть файл-копию
                CloseHandle(hSrc);//закрыть исходный файл
            }

            //обновить список
            if (treeView1.SelectedNode != null) ShowFiles_WinApi((string)treeView1.SelectedNode.Tag);
            MessageBox.Show("Готово! Создана копия:\n" + dstPath);
        }

        //переименовать выбранный файл
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл справа.");
                return;
            }

            if (isTrashView)
            {
                MessageBox.Show("Переименование в режиме корзины не делаем. Открой обычную папку.");
                return;
            }

            string oldPath = (string)listView1.SelectedItems[0].Tag;
            string folder = Path.GetDirectoryName(oldPath);
            string oldName = Path.GetFileName(oldPath);

            //ввод нового имени
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Новое имя файла (с расширением):", "Переименовать", oldName);
            if (string.IsNullOrWhiteSpace(newName) || newName == oldName) return;

            string newPath = Path.Combine(folder, newName);

            //переименование через WinAPI (MoveFileW)
            if (!MoveFileW(oldPath, newPath))
            {
                MessageBox.Show("Не удалось переименовать. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            //обновить список
            if (treeView1.SelectedNode != null) ShowFiles_WinApi((string)treeView1.SelectedNode.Tag);
        }

        //изменить размер выбранного файла
        private void btnResize_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выбери файл справа.");
                return;
            }

            if (isTrashView)
            {
                MessageBox.Show("В режиме корзины размер не меняем. Открой обычную папку.");
                return;
            }

            string filePath = (string)listView1.SelectedItems[0].Tag;

            //ввод нового размера
            string input = Microsoft.VisualBasic.Interaction.InputBox("Новый размер файла в байтах:", "Изменить размер", "0");
            if (!long.TryParse(input, out long newSize) || newSize < 0)
            {
                MessageBox.Show("Введите число >= 0.");
                return;
            }

            //открыть файл на запись
            IntPtr hFile = CreateFileW(filePath, GENERIC_WRITE, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
            if (hFile == INVALID_HANDLE_VALUE)
            {
                MessageBox.Show("Не удалось открыть файл. Ошибка: " + Marshal.GetLastWin32Error());
                return;
            }

            try
            {
                //сдвинуть указатель на нужный размер
                long dummy;
                if (!SetFilePointerEx(hFile, newSize, out dummy, FILE_BEGIN))
                {
                    MessageBox.Show("SetFilePointerEx ошибка: " + Marshal.GetLastWin32Error());
                    return;
                }

                //зафиксировать конец файла
                if (!SetEndOfFile(hFile))
                {
                    MessageBox.Show("SetEndOfFile ошибка: " + Marshal.GetLastWin32Error());
                    return;
                }
            }
            finally
            {
                CloseHandle(hFile);//закрыть файл
            }

            //обновить список
            if (treeView1.SelectedNode != null) ShowFiles_WinApi((string)treeView1.SelectedNode.Tag);
            MessageBox.Show("Размер изменён на " + newSize + " байт.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //пустой обработчик загрузки формы
        }
    }
}