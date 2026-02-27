namespace OSlab2part2
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnTrash = new System.Windows.Forms.Button();
            this.btnTrashView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnCopyStream = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnResize);
            this.panelTop.Controls.Add(this.btnRename);
            this.panelTop.Controls.Add(this.btnCopyStream);
            this.panelTop.Controls.Add(this.btnRestore);
            this.panelTop.Controls.Add(this.btnTrash);
            this.panelTop.Controls.Add(this.btnTrashView);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnCreate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 134);
            this.panelTop.TabIndex = 0;
            // 
            // btnTrash
            // 
            this.btnTrash.Location = new System.Drawing.Point(30, 40);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(229, 23);
            this.btnTrash.TabIndex = 3;
            this.btnTrash.Text = "Переместить файл в корзину";
            this.btnTrash.UseVisualStyleBackColor = true;
            this.btnTrash.Click += new System.EventHandler(this.btnTrash_Click);
            // 
            // btnTrashView
            // 
            this.btnTrashView.Location = new System.Drawing.Point(265, 40);
            this.btnTrashView.Name = "btnTrashView";
            this.btnTrashView.Size = new System.Drawing.Size(236, 23);
            this.btnTrashView.TabIndex = 2;
            this.btnTrashView.Text = "Корзина";
            this.btnTrashView.UseVisualStyleBackColor = true;
            this.btnTrashView.Click += new System.EventHandler(this.btnTrashView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(458, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить файл навсегда";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(70, 11);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(153, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Создать файл";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 134);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(172, 316);
            this.treeView1.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(172, 134);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(628, 316);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Modified";
            this.columnHeader3.Width = 160;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(523, 40);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(201, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Восстановить из корзины";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCopyStream
            // 
            this.btnCopyStream.Location = new System.Drawing.Point(244, 11);
            this.btnCopyStream.Name = "btnCopyStream";
            this.btnCopyStream.Size = new System.Drawing.Size(188, 23);
            this.btnCopyStream.TabIndex = 5;
            this.btnCopyStream.Text = "Копировать по частям";
            this.btnCopyStream.UseVisualStyleBackColor = true;
            this.btnCopyStream.Click += new System.EventHandler(this.btnCopyStream_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(172, 83);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(131, 23);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "Переименовать";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(364, 82);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(148, 23);
            this.btnResize.TabIndex = 7;
            this.btnResize.Text = "Изменить размер";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panelTop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnTrashView;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnCopyStream;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnResize;
    }
}

