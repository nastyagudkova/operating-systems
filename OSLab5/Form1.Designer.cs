namespace OSLab5
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
            this.btnRefreshWindows = new System.Windows.Forms.Button();
            this.dgvWindows = new System.Windows.Forms.DataGridView();
            this.colHandle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBoxMove = new System.Windows.Forms.GroupBox();
            this.btnMoveCenter = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.btnResizeWindow = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.groupBoxRename = new System.Windows.Forms.GroupBox();
            this.btnSetWindowText = new System.Windows.Forms.Button();
            this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.lblNewTitle = new System.Windows.Forms.Label();
            this.groupBoxSelectedWindow = new System.Windows.Forms.GroupBox();
            this.lblSelectedPidValue = new System.Windows.Forms.Label();
            this.lblSelectedPidTitle = new System.Windows.Forms.Label();
            this.lblSelectedTitleValue = new System.Windows.Forms.Label();
            this.lblSelectedTitleTitle = new System.Windows.Forms.Label();
            this.lblSelectedHandleValue = new System.Windows.Forms.Label();
            this.lblSelectedHandleTitle = new System.Windows.Forms.Label();
            this.btnStartVirus = new System.Windows.Forms.Button();
            this.btnStopVirus = new System.Windows.Forms.Button();
            this.timerVirus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWindows)).BeginInit();
            this.panelRight.SuspendLayout();
            this.groupBoxMove.SuspendLayout();
            this.groupBoxSize.SuspendLayout();
            this.groupBoxState.SuspendLayout();
            this.groupBoxRename.SuspendLayout();
            this.groupBoxSelectedWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefreshWindows
            // 
            this.btnRefreshWindows.AutoSize = true;
            this.btnRefreshWindows.Location = new System.Drawing.Point(20, 20);
            this.btnRefreshWindows.Name = "btnRefreshWindows";
            this.btnRefreshWindows.Size = new System.Drawing.Size(163, 26);
            this.btnRefreshWindows.TabIndex = 0;
            this.btnRefreshWindows.Text = "Обновить список окон";
            this.btnRefreshWindows.UseVisualStyleBackColor = true;
            this.btnRefreshWindows.Click += new System.EventHandler(this.btnRefreshWindows_Click);
            // 
            // dgvWindows
            // 
            this.dgvWindows.AllowUserToAddRows = false;
            this.dgvWindows.AllowUserToDeleteRows = false;
            this.dgvWindows.AllowUserToResizeRows = false;
            this.dgvWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvWindows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWindows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWindows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHandle,
            this.colTitle,
            this.colClassName,
            this.colVisible,
            this.colPid});
            this.dgvWindows.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvWindows.Location = new System.Drawing.Point(20, 70);
            this.dgvWindows.MultiSelect = false;
            this.dgvWindows.Name = "dgvWindows";
            this.dgvWindows.ReadOnly = true;
            this.dgvWindows.RowHeadersVisible = false;
            this.dgvWindows.RowHeadersWidth = 51;
            this.dgvWindows.RowTemplate.Height = 24;
            this.dgvWindows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWindows.Size = new System.Drawing.Size(750, 560);
            this.dgvWindows.TabIndex = 1;
            this.dgvWindows.SelectionChanged += new System.EventHandler(this.dgvWindows_SelectionChanged);
            // 
            // colHandle
            // 
            this.colHandle.FillWeight = 20F;
            this.colHandle.HeaderText = "Handle";
            this.colHandle.MinimumWidth = 6;
            this.colHandle.Name = "colHandle";
            this.colHandle.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.FillWeight = 35F;
            this.colTitle.HeaderText = "Заголовок";
            this.colTitle.MinimumWidth = 6;
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colClassName
            // 
            this.colClassName.FillWeight = 20F;
            this.colClassName.HeaderText = "ClassName";
            this.colClassName.MinimumWidth = 6;
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            // 
            // colVisible
            // 
            this.colVisible.FillWeight = 10F;
            this.colVisible.HeaderText = "Visible";
            this.colVisible.MinimumWidth = 6;
            this.colVisible.Name = "colVisible";
            this.colVisible.ReadOnly = true;
            // 
            // colPid
            // 
            this.colPid.FillWeight = 15F;
            this.colPid.HeaderText = "Process ID";
            this.colPid.MinimumWidth = 6;
            this.colPid.Name = "colPid";
            this.colPid.ReadOnly = true;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.groupBoxMove);
            this.panelRight.Controls.Add(this.groupBoxSize);
            this.panelRight.Controls.Add(this.groupBoxState);
            this.panelRight.Controls.Add(this.groupBoxRename);
            this.panelRight.Controls.Add(this.groupBoxSelectedWindow);
            this.panelRight.Location = new System.Drawing.Point(790, 20);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(380, 610);
            this.panelRight.TabIndex = 2;
            // 
            // groupBoxMove
            // 
            this.groupBoxMove.Controls.Add(this.btnMoveCenter);
            this.groupBoxMove.Controls.Add(this.btnMoveDown);
            this.groupBoxMove.Controls.Add(this.btnMoveUp);
            this.groupBoxMove.Controls.Add(this.btnMoveRight);
            this.groupBoxMove.Controls.Add(this.btnMoveLeft);
            this.groupBoxMove.Location = new System.Drawing.Point(15, 510);
            this.groupBoxMove.Name = "groupBoxMove";
            this.groupBoxMove.Size = new System.Drawing.Size(345, 95);
            this.groupBoxMove.TabIndex = 4;
            this.groupBoxMove.TabStop = false;
            this.groupBoxMove.Text = "Перемещение окна";
            // 
            // btnMoveCenter
            // 
            this.btnMoveCenter.AutoSize = true;
            this.btnMoveCenter.Enabled = false;
            this.btnMoveCenter.Location = new System.Drawing.Point(120, 60);
            this.btnMoveCenter.Name = "btnMoveCenter";
            this.btnMoveCenter.Size = new System.Drawing.Size(85, 26);
            this.btnMoveCenter.TabIndex = 14;
            this.btnMoveCenter.Text = "По центру";
            this.btnMoveCenter.UseVisualStyleBackColor = true;
            this.btnMoveCenter.Click += new System.EventHandler(this.btnMoveCenter_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(250, 25);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 30);
            this.btnMoveDown.TabIndex = 13;
            this.btnMoveDown.Text = "вниз";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(170, 25);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 30);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.Text = "вверх";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Enabled = false;
            this.btnMoveRight.Location = new System.Drawing.Point(85, 25);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(75, 30);
            this.btnMoveRight.TabIndex = 11;
            this.btnMoveRight.Text = "вправо >";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Enabled = false;
            this.btnMoveLeft.Location = new System.Drawing.Point(5, 25);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(75, 30);
            this.btnMoveLeft.TabIndex = 10;
            this.btnMoveLeft.Text = "< влево";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // groupBoxSize
            // 
            this.groupBoxSize.Controls.Add(this.btnResizeWindow);
            this.groupBoxSize.Controls.Add(this.txtHeight);
            this.groupBoxSize.Controls.Add(this.txtWidth);
            this.groupBoxSize.Controls.Add(this.lblHeight);
            this.groupBoxSize.Controls.Add(this.lblWidth);
            this.groupBoxSize.Location = new System.Drawing.Point(15, 385);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Size = new System.Drawing.Size(345, 110);
            this.groupBoxSize.TabIndex = 3;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Изменение размера";
            // 
            // btnResizeWindow
            // 
            this.btnResizeWindow.AutoSize = true;
            this.btnResizeWindow.Enabled = false;
            this.btnResizeWindow.Location = new System.Drawing.Point(15, 70);
            this.btnResizeWindow.Name = "btnResizeWindow";
            this.btnResizeWindow.Size = new System.Drawing.Size(134, 26);
            this.btnResizeWindow.TabIndex = 9;
            this.btnResizeWindow.Text = "Изменить размер";
            this.btnResizeWindow.UseVisualStyleBackColor = true;
            this.btnResizeWindow.Click += new System.EventHandler(this.btnResizeWindow_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(225, 32);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(80, 22);
            this.txtHeight.TabIndex = 8;
            // 
            // txtWidth
            // 
            this.txtWidth.Enabled = false;
            this.txtWidth.Location = new System.Drawing.Point(70, 32);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(80, 22);
            this.txtWidth.TabIndex = 7;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(170, 35);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(49, 16);
            this.lblHeight.TabIndex = 1;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(15, 35);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(44, 16);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width:";
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.btnRestore);
            this.groupBoxState.Controls.Add(this.btnMaximize);
            this.groupBoxState.Controls.Add(this.btnMinimize);
            this.groupBoxState.Location = new System.Drawing.Point(15, 285);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(345, 85);
            this.groupBoxState.TabIndex = 2;
            this.groupBoxState.TabStop = false;
            this.groupBoxState.Text = "Состояние окна";
            // 
            // btnRestore
            // 
            this.btnRestore.AutoSize = true;
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(217, 35);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(109, 26);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Восстановить";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.AutoSize = true;
            this.btnMaximize.Enabled = false;
            this.btnMaximize.Location = new System.Drawing.Point(104, 35);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(96, 26);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.Text = "Развернуть";
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.Enabled = false;
            this.btnMinimize.Location = new System.Drawing.Point(6, 35);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(80, 26);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "Свернуть";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // groupBoxRename
            // 
            this.groupBoxRename.Controls.Add(this.btnSetWindowText);
            this.groupBoxRename.Controls.Add(this.txtNewTitle);
            this.groupBoxRename.Controls.Add(this.lblNewTitle);
            this.groupBoxRename.Location = new System.Drawing.Point(15, 160);
            this.groupBoxRename.Name = "groupBoxRename";
            this.groupBoxRename.Size = new System.Drawing.Size(345, 110);
            this.groupBoxRename.TabIndex = 1;
            this.groupBoxRename.TabStop = false;
            this.groupBoxRename.Text = "Переименование окна";
            // 
            // btnSetWindowText
            // 
            this.btnSetWindowText.AutoSize = true;
            this.btnSetWindowText.Enabled = false;
            this.btnSetWindowText.Location = new System.Drawing.Point(206, 53);
            this.btnSetWindowText.Name = "btnSetWindowText";
            this.btnSetWindowText.Size = new System.Drawing.Size(122, 26);
            this.btnSetWindowText.TabIndex = 3;
            this.btnSetWindowText.Text = "Переименовать";
            this.btnSetWindowText.UseVisualStyleBackColor = true;
            this.btnSetWindowText.Click += new System.EventHandler(this.btnSetWindowText_Click);
            // 
            // txtNewTitle
            // 
            this.txtNewTitle.Enabled = false;
            this.txtNewTitle.Location = new System.Drawing.Point(15, 55);
            this.txtNewTitle.Name = "txtNewTitle";
            this.txtNewTitle.Size = new System.Drawing.Size(185, 22);
            this.txtNewTitle.TabIndex = 2;
            // 
            // lblNewTitle
            // 
            this.lblNewTitle.AutoSize = true;
            this.lblNewTitle.Location = new System.Drawing.Point(15, 30);
            this.lblNewTitle.Name = "lblNewTitle";
            this.lblNewTitle.Size = new System.Drawing.Size(125, 16);
            this.lblNewTitle.TabIndex = 0;
            this.lblNewTitle.Text = "Новый заголовок:";
            // 
            // groupBoxSelectedWindow
            // 
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedPidValue);
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedPidTitle);
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedTitleValue);
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedTitleTitle);
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedHandleValue);
            this.groupBoxSelectedWindow.Controls.Add(this.lblSelectedHandleTitle);
            this.groupBoxSelectedWindow.Location = new System.Drawing.Point(15, 15);
            this.groupBoxSelectedWindow.Name = "groupBoxSelectedWindow";
            this.groupBoxSelectedWindow.Size = new System.Drawing.Size(345, 130);
            this.groupBoxSelectedWindow.TabIndex = 0;
            this.groupBoxSelectedWindow.TabStop = false;
            this.groupBoxSelectedWindow.Text = "Выбранное окно";
            // 
            // lblSelectedPidValue
            // 
            this.lblSelectedPidValue.AutoSize = true;
            this.lblSelectedPidValue.Location = new System.Drawing.Point(100, 95);
            this.lblSelectedPidValue.Name = "lblSelectedPidValue";
            this.lblSelectedPidValue.Size = new System.Drawing.Size(11, 16);
            this.lblSelectedPidValue.TabIndex = 5;
            this.lblSelectedPidValue.Text = "-";
            // 
            // lblSelectedPidTitle
            // 
            this.lblSelectedPidTitle.AutoSize = true;
            this.lblSelectedPidTitle.Location = new System.Drawing.Point(15, 95);
            this.lblSelectedPidTitle.Name = "lblSelectedPidTitle";
            this.lblSelectedPidTitle.Size = new System.Drawing.Size(76, 16);
            this.lblSelectedPidTitle.TabIndex = 4;
            this.lblSelectedPidTitle.Text = "Process ID:";
            // 
            // lblSelectedTitleValue
            // 
            this.lblSelectedTitleValue.AutoSize = true;
            this.lblSelectedTitleValue.Location = new System.Drawing.Point(100, 60);
            this.lblSelectedTitleValue.Name = "lblSelectedTitleValue";
            this.lblSelectedTitleValue.Size = new System.Drawing.Size(11, 16);
            this.lblSelectedTitleValue.TabIndex = 3;
            this.lblSelectedTitleValue.Text = "-";
            // 
            // lblSelectedTitleTitle
            // 
            this.lblSelectedTitleTitle.AutoSize = true;
            this.lblSelectedTitleTitle.Location = new System.Drawing.Point(15, 60);
            this.lblSelectedTitleTitle.Name = "lblSelectedTitleTitle";
            this.lblSelectedTitleTitle.Size = new System.Drawing.Size(80, 16);
            this.lblSelectedTitleTitle.TabIndex = 2;
            this.lblSelectedTitleTitle.Text = "Заголовок:";
            // 
            // lblSelectedHandleValue
            // 
            this.lblSelectedHandleValue.AutoSize = true;
            this.lblSelectedHandleValue.Location = new System.Drawing.Point(100, 30);
            this.lblSelectedHandleValue.Name = "lblSelectedHandleValue";
            this.lblSelectedHandleValue.Size = new System.Drawing.Size(11, 16);
            this.lblSelectedHandleValue.TabIndex = 1;
            this.lblSelectedHandleValue.Text = "-";
            // 
            // lblSelectedHandleTitle
            // 
            this.lblSelectedHandleTitle.AutoSize = true;
            this.lblSelectedHandleTitle.Location = new System.Drawing.Point(15, 30);
            this.lblSelectedHandleTitle.Name = "lblSelectedHandleTitle";
            this.lblSelectedHandleTitle.Size = new System.Drawing.Size(54, 16);
            this.lblSelectedHandleTitle.TabIndex = 0;
            this.lblSelectedHandleTitle.Text = "Handle:";
            // 
            // btnStartVirus
            // 
            this.btnStartVirus.Enabled = false;
            this.btnStartVirus.Location = new System.Drawing.Point(209, 22);
            this.btnStartVirus.Name = "btnStartVirus";
            this.btnStartVirus.Size = new System.Drawing.Size(75, 23);
            this.btnStartVirus.TabIndex = 3;
            this.btnStartVirus.Text = "Вирус";
            this.btnStartVirus.UseVisualStyleBackColor = true;
            this.btnStartVirus.Click += new System.EventHandler(this.btnStartVirus_Click);
            // 
            // btnStopVirus
            // 
            this.btnStopVirus.AutoSize = true;
            this.btnStopVirus.Enabled = false;
            this.btnStopVirus.Location = new System.Drawing.Point(313, 22);
            this.btnStopVirus.Name = "btnStopVirus";
            this.btnStopVirus.Size = new System.Drawing.Size(90, 26);
            this.btnStopVirus.TabIndex = 4;
            this.btnStopVirus.Text = "Выключить";
            this.btnStopVirus.UseVisualStyleBackColor = true;
            this.btnStopVirus.Click += new System.EventHandler(this.btnStopVirus_Click);
            // 
            // timerVirus
            // 
            this.timerVirus.Interval = 120;
            this.timerVirus.Tick += new System.EventHandler(this.timerVirus_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.btnStopVirus);
            this.Controls.Add(this.btnStartVirus);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.dgvWindows);
            this.Controls.Add(this.btnRefreshWindows);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWindows)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.groupBoxMove.ResumeLayout(false);
            this.groupBoxMove.PerformLayout();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.groupBoxRename.ResumeLayout(false);
            this.groupBoxRename.PerformLayout();
            this.groupBoxSelectedWindow.ResumeLayout(false);
            this.groupBoxSelectedWindow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshWindows;
        private System.Windows.Forms.DataGridView dgvWindows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHandle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPid;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxSelectedWindow;
        private System.Windows.Forms.Label lblSelectedPidValue;
        private System.Windows.Forms.Label lblSelectedPidTitle;
        private System.Windows.Forms.Label lblSelectedTitleValue;
        private System.Windows.Forms.Label lblSelectedTitleTitle;
        private System.Windows.Forms.Label lblSelectedHandleValue;
        private System.Windows.Forms.Label lblSelectedHandleTitle;
        private System.Windows.Forms.GroupBox groupBoxRename;
        private System.Windows.Forms.Button btnSetWindowText;
        private System.Windows.Forms.TextBox txtNewTitle;
        private System.Windows.Forms.Label lblNewTitle;
        private System.Windows.Forms.GroupBox groupBoxState;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.GroupBox groupBoxSize;
        private System.Windows.Forms.Button btnResizeWindow;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.GroupBox groupBoxMove;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveCenter;
        private System.Windows.Forms.Button btnStartVirus;
        private System.Windows.Forms.Button btnStopVirus;
        private System.Windows.Forms.Timer timerVirus;
    }
}

