namespace OSlab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewDisks = new System.Windows.Forms.DataGridView();
            this.ColumnDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRefreshDisks = new System.Windows.Forms.Button();
            this.labelDiskInfo = new System.Windows.Forms.Label();
            this.groupBoxFolders = new System.Windows.Forms.GroupBox();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.buttonDeleteFolder = new System.Windows.Forms.Button();
            this.buttonBrowseDest = new System.Windows.Forms.Button();
            this.buttonRenameFolder = new System.Windows.Forms.Button();
            this.textBoxDestPath = new System.Windows.Forms.TextBox();
            this.buttonMoveFolder = new System.Windows.Forms.Button();
            this.buttonBrowseSource = new System.Windows.Forms.Button();
            this.buttonCopyFolder = new System.Windows.Forms.Button();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.timerDiskUpdate = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisks)).BeginInit();
            this.groupBoxFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDisks
            // 
            this.dataGridViewDisks.AllowUserToAddRows = false;
            this.dataGridViewDisks.AllowUserToDeleteRows = false;
            this.dataGridViewDisks.AllowUserToResizeRows = false;
            this.dataGridViewDisks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDisks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDisks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDisks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDrive,
            this.ColumnType,
            this.ColumnTotal,
            this.ColumnFree,
            this.ColumnUsed});
            this.dataGridViewDisks.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewDisks.MultiSelect = false;
            this.dataGridViewDisks.Name = "dataGridViewDisks";
            this.dataGridViewDisks.ReadOnly = true;
            this.dataGridViewDisks.RowHeadersVisible = false;
            this.dataGridViewDisks.RowHeadersWidth = 51;
            this.dataGridViewDisks.RowTemplate.Height = 24;
            this.dataGridViewDisks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDisks.Size = new System.Drawing.Size(760, 220);
            this.dataGridViewDisks.TabIndex = 0;
            // 
            // ColumnDrive
            // 
            this.ColumnDrive.HeaderText = "Диск";
            this.ColumnDrive.MinimumWidth = 6;
            this.ColumnDrive.Name = "ColumnDrive";
            this.ColumnDrive.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Тип";
            this.ColumnType.MinimumWidth = 6;
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.HeaderText = "Общий объём (GB)";
            this.ColumnTotal.MinimumWidth = 6;
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            // 
            // ColumnFree
            // 
            this.ColumnFree.HeaderText = "Свободно (GB)";
            this.ColumnFree.MinimumWidth = 6;
            this.ColumnFree.Name = "ColumnFree";
            this.ColumnFree.ReadOnly = true;
            // 
            // ColumnUsed
            // 
            this.ColumnUsed.HeaderText = "Занято (GB)";
            this.ColumnUsed.MinimumWidth = 6;
            this.ColumnUsed.Name = "ColumnUsed";
            this.ColumnUsed.ReadOnly = true;
            // 
            // buttonRefreshDisks
            // 
            this.buttonRefreshDisks.Location = new System.Drawing.Point(10, 240);
            this.buttonRefreshDisks.Name = "buttonRefreshDisks";
            this.buttonRefreshDisks.Size = new System.Drawing.Size(142, 23);
            this.buttonRefreshDisks.TabIndex = 1;
            this.buttonRefreshDisks.Text = "Обновить диски";
            this.buttonRefreshDisks.UseVisualStyleBackColor = true;
            this.buttonRefreshDisks.Click += new System.EventHandler(this.buttonRefreshDisks_Click);
            // 
            // labelDiskInfo
            // 
            this.labelDiskInfo.AutoSize = true;
            this.labelDiskInfo.Location = new System.Drawing.Point(170, 249);
            this.labelDiskInfo.Name = "labelDiskInfo";
            this.labelDiskInfo.Size = new System.Drawing.Size(341, 16);
            this.labelDiskInfo.TabIndex = 2;
            this.labelDiskInfo.Text = "Информация о дисках обновляется автоматически";
            // 
            // groupBoxFolders
            // 
            this.groupBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFolders.Controls.Add(this.textBoxNewName);
            this.groupBoxFolders.Controls.Add(this.buttonDeleteFolder);
            this.groupBoxFolders.Controls.Add(this.buttonBrowseDest);
            this.groupBoxFolders.Controls.Add(this.buttonRenameFolder);
            this.groupBoxFolders.Controls.Add(this.textBoxDestPath);
            this.groupBoxFolders.Controls.Add(this.buttonMoveFolder);
            this.groupBoxFolders.Controls.Add(this.buttonBrowseSource);
            this.groupBoxFolders.Controls.Add(this.buttonCopyFolder);
            this.groupBoxFolders.Controls.Add(this.textBoxSourcePath);
            this.groupBoxFolders.Location = new System.Drawing.Point(10, 280);
            this.groupBoxFolders.Name = "groupBoxFolders";
            this.groupBoxFolders.Size = new System.Drawing.Size(760, 180);
            this.groupBoxFolders.TabIndex = 3;
            this.groupBoxFolders.TabStop = false;
            this.groupBoxFolders.Text = "Работа с папками";
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(0, 91);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(450, 22);
            this.textBoxNewName.TabIndex = 6;
            this.textBoxNewName.Text = "Новое имя папки";
            // 
            // buttonDeleteFolder
            // 
            this.buttonDeleteFolder.Location = new System.Drawing.Point(439, 132);
            this.buttonDeleteFolder.Name = "buttonDeleteFolder";
            this.buttonDeleteFolder.Size = new System.Drawing.Size(122, 23);
            this.buttonDeleteFolder.TabIndex = 7;
            this.buttonDeleteFolder.Text = "Удалить";
            this.buttonDeleteFolder.UseVisualStyleBackColor = true;
            this.buttonDeleteFolder.Click += new System.EventHandler(this.buttonDeleteFolder_Click);
            // 
            // buttonBrowseDest
            // 
            this.buttonBrowseDest.Location = new System.Drawing.Point(489, 62);
            this.buttonBrowseDest.Name = "buttonBrowseDest";
            this.buttonBrowseDest.Size = new System.Drawing.Size(116, 23);
            this.buttonBrowseDest.TabIndex = 5;
            this.buttonBrowseDest.Text = "Выбрать";
            this.buttonBrowseDest.UseVisualStyleBackColor = true;
            this.buttonBrowseDest.Click += new System.EventHandler(this.buttonBrowseDest_Click);
            // 
            // buttonRenameFolder
            // 
            this.buttonRenameFolder.Location = new System.Drawing.Point(284, 132);
            this.buttonRenameFolder.Name = "buttonRenameFolder";
            this.buttonRenameFolder.Size = new System.Drawing.Size(135, 23);
            this.buttonRenameFolder.TabIndex = 6;
            this.buttonRenameFolder.Text = "Переименовать";
            this.buttonRenameFolder.UseVisualStyleBackColor = true;
            this.buttonRenameFolder.Click += new System.EventHandler(this.buttonRenameFolder_Click);
            // 
            // textBoxDestPath
            // 
            this.textBoxDestPath.Location = new System.Drawing.Point(0, 60);
            this.textBoxDestPath.Name = "textBoxDestPath";
            this.textBoxDestPath.Size = new System.Drawing.Size(450, 22);
            this.textBoxDestPath.TabIndex = 4;
            this.textBoxDestPath.Text = "Папка назначения";
            // 
            // buttonMoveFolder
            // 
            this.buttonMoveFolder.Location = new System.Drawing.Point(144, 132);
            this.buttonMoveFolder.Name = "buttonMoveFolder";
            this.buttonMoveFolder.Size = new System.Drawing.Size(122, 23);
            this.buttonMoveFolder.TabIndex = 5;
            this.buttonMoveFolder.Text = "Переместить";
            this.buttonMoveFolder.UseVisualStyleBackColor = true;
            this.buttonMoveFolder.Click += new System.EventHandler(this.buttonMoveFolder_Click);
            // 
            // buttonBrowseSource
            // 
            this.buttonBrowseSource.Location = new System.Drawing.Point(489, 32);
            this.buttonBrowseSource.Name = "buttonBrowseSource";
            this.buttonBrowseSource.Size = new System.Drawing.Size(116, 23);
            this.buttonBrowseSource.TabIndex = 1;
            this.buttonBrowseSource.Text = "Выбрать";
            this.buttonBrowseSource.UseVisualStyleBackColor = true;
            this.buttonBrowseSource.Click += new System.EventHandler(this.buttonBrowseSource_Click);
            // 
            // buttonCopyFolder
            // 
            this.buttonCopyFolder.Location = new System.Drawing.Point(6, 132);
            this.buttonCopyFolder.Name = "buttonCopyFolder";
            this.buttonCopyFolder.Size = new System.Drawing.Size(122, 23);
            this.buttonCopyFolder.TabIndex = 4;
            this.buttonCopyFolder.Text = "Копировать";
            this.buttonCopyFolder.UseVisualStyleBackColor = true;
            this.buttonCopyFolder.Click += new System.EventHandler(this.buttonCopyFolder_Click);
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Location = new System.Drawing.Point(2, 32);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(450, 22);
            this.textBoxSourcePath.TabIndex = 0;
            this.textBoxSourcePath.Text = "Исходная папка";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(10, 466);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(760, 120);
            this.textBoxLog.TabIndex = 8;
            // 
            // timerDiskUpdate
            // 
            this.timerDiskUpdate.Interval = 1000;
            this.timerDiskUpdate.Tick += new System.EventHandler(this.timerDiskUpdate_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 646);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxFolders);
            this.Controls.Add(this.labelDiskInfo);
            this.Controls.Add(this.buttonRefreshDisks);
            this.Controls.Add(this.dataGridViewDisks);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDisks)).EndInit();
            this.groupBoxFolders.ResumeLayout(false);
            this.groupBoxFolders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDisks;
        private System.Windows.Forms.Button buttonRefreshDisks;
        private System.Windows.Forms.Label labelDiskInfo;
        private System.Windows.Forms.GroupBox groupBoxFolders;
        private System.Windows.Forms.Button buttonBrowseSource;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.Button buttonBrowseDest;
        private System.Windows.Forms.TextBox textBoxDestPath;
        private System.Windows.Forms.Button buttonCopyFolder;
        private System.Windows.Forms.Button buttonMoveFolder;
        private System.Windows.Forms.Button buttonRenameFolder;
        private System.Windows.Forms.Button buttonDeleteFolder;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Timer timerDiskUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUsed;
    }
}

