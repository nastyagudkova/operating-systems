namespace OSlab4
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
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.txtCommonCounter = new System.Windows.Forms.TextBox();
            this.txtParentValue = new System.Windows.Forms.TextBox();
            this.labelCommonCounter = new System.Windows.Forms.Label();
            this.labelParentValue = new System.Windows.Forms.Label();
            this.groupBoxThread1 = new System.Windows.Forms.GroupBox();
            this.txtReturned1 = new System.Windows.Forms.TextBox();
            this.labelReturned1 = new System.Windows.Forms.Label();
            this.txtReceived1 = new System.Windows.Forms.TextBox();
            this.labelReceived1 = new System.Windows.Forms.Label();
            this.labelStateValue1 = new System.Windows.Forms.Label();
            this.labelState1 = new System.Windows.Forms.Label();
            this.groupBoxThread2 = new System.Windows.Forms.GroupBox();
            this.groupBoxThread3 = new System.Windows.Forms.GroupBox();
            this.groupBoxThread4 = new System.Windows.Forms.GroupBox();
            this.labelPriority1 = new System.Windows.Forms.Label();
            this.cmbPriority1 = new System.Windows.Forms.ComboBox();
            this.btnStart1 = new System.Windows.Forms.Button();
            this.btnPause1 = new System.Windows.Forms.Button();
            this.btnStop1 = new System.Windows.Forms.Button();
            this.labelState2 = new System.Windows.Forms.Label();
            this.labelReceived2 = new System.Windows.Forms.Label();
            this.labelReturned2 = new System.Windows.Forms.Label();
            this.labelPriority2 = new System.Windows.Forms.Label();
            this.labelState3 = new System.Windows.Forms.Label();
            this.labelReceived3 = new System.Windows.Forms.Label();
            this.labelReturned3 = new System.Windows.Forms.Label();
            this.labelPriority3 = new System.Windows.Forms.Label();
            this.labelState4 = new System.Windows.Forms.Label();
            this.labelReceived4 = new System.Windows.Forms.Label();
            this.labelReturned4 = new System.Windows.Forms.Label();
            this.labelPriority4 = new System.Windows.Forms.Label();
            this.labelStateValue2 = new System.Windows.Forms.Label();
            this.labelStateValue3 = new System.Windows.Forms.Label();
            this.labelStateValue4 = new System.Windows.Forms.Label();
            this.txtReceived2 = new System.Windows.Forms.TextBox();
            this.txtReceived3 = new System.Windows.Forms.TextBox();
            this.txtReceived4 = new System.Windows.Forms.TextBox();
            this.txtReturned2 = new System.Windows.Forms.TextBox();
            this.txtReturned3 = new System.Windows.Forms.TextBox();
            this.txtReturned4 = new System.Windows.Forms.TextBox();
            this.cmbPriority2 = new System.Windows.Forms.ComboBox();
            this.cmbPriority3 = new System.Windows.Forms.ComboBox();
            this.cmbPriority4 = new System.Windows.Forms.ComboBox();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.btnPause2 = new System.Windows.Forms.Button();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.btnStart3 = new System.Windows.Forms.Button();
            this.btnPause3 = new System.Windows.Forms.Button();
            this.btnStop3 = new System.Windows.Forms.Button();
            this.btnStart4 = new System.Windows.Forms.Button();
            this.btnPause4 = new System.Windows.Forms.Button();
            this.btnStop4 = new System.Windows.Forms.Button();
            this.groupBoxMain.SuspendLayout();
            this.groupBoxThread1.SuspendLayout();
            this.groupBoxThread2.SuspendLayout();
            this.groupBoxThread3.SuspendLayout();
            this.groupBoxThread4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.txtCommonCounter);
            this.groupBoxMain.Controls.Add(this.txtParentValue);
            this.groupBoxMain.Controls.Add(this.labelCommonCounter);
            this.groupBoxMain.Controls.Add(this.labelParentValue);
            this.groupBoxMain.Location = new System.Drawing.Point(335, 28);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(368, 124);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Главный поток";
            // 
            // txtCommonCounter
            // 
            this.txtCommonCounter.Location = new System.Drawing.Point(125, 62);
            this.txtCommonCounter.Name = "txtCommonCounter";
            this.txtCommonCounter.ReadOnly = true;
            this.txtCommonCounter.Size = new System.Drawing.Size(100, 22);
            this.txtCommonCounter.TabIndex = 3;
            this.txtCommonCounter.TabStop = false;
            this.txtCommonCounter.Text = "0";
            this.txtCommonCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtParentValue
            // 
            this.txtParentValue.Location = new System.Drawing.Point(181, 34);
            this.txtParentValue.MaxLength = 1000;
            this.txtParentValue.Name = "txtParentValue";
            this.txtParentValue.Size = new System.Drawing.Size(100, 22);
            this.txtParentValue.TabIndex = 2;
            this.txtParentValue.Text = "0";
            this.txtParentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtParentValue.TextChanged += new System.EventHandler(this.txtParentValue_TextChanged);
            // 
            // labelCommonCounter
            // 
            this.labelCommonCounter.AutoSize = true;
            this.labelCommonCounter.Location = new System.Drawing.Point(10, 63);
            this.labelCommonCounter.Name = "labelCommonCounter";
            this.labelCommonCounter.Size = new System.Drawing.Size(109, 16);
            this.labelCommonCounter.TabIndex = 1;
            this.labelCommonCounter.Text = "Общий счетчик:";
            // 
            // labelParentValue
            // 
            this.labelParentValue.AutoSize = true;
            this.labelParentValue.Location = new System.Drawing.Point(7, 34);
            this.labelParentValue.Name = "labelParentValue";
            this.labelParentValue.Size = new System.Drawing.Size(168, 16);
            this.labelParentValue.TabIndex = 0;
            this.labelParentValue.Text = "Значение для передачи:";
            // 
            // groupBoxThread1
            // 
            this.groupBoxThread1.Controls.Add(this.btnStop1);
            this.groupBoxThread1.Controls.Add(this.btnPause1);
            this.groupBoxThread1.Controls.Add(this.btnStart1);
            this.groupBoxThread1.Controls.Add(this.cmbPriority1);
            this.groupBoxThread1.Controls.Add(this.labelPriority1);
            this.groupBoxThread1.Controls.Add(this.txtReturned1);
            this.groupBoxThread1.Controls.Add(this.labelReturned1);
            this.groupBoxThread1.Controls.Add(this.txtReceived1);
            this.groupBoxThread1.Controls.Add(this.labelReceived1);
            this.groupBoxThread1.Controls.Add(this.labelStateValue1);
            this.groupBoxThread1.Controls.Add(this.labelState1);
            this.groupBoxThread1.Location = new System.Drawing.Point(24, 168);
            this.groupBoxThread1.Name = "groupBoxThread1";
            this.groupBoxThread1.Size = new System.Drawing.Size(354, 222);
            this.groupBoxThread1.TabIndex = 1;
            this.groupBoxThread1.TabStop = false;
            this.groupBoxThread1.Text = "Дочерний поток 1";
            // 
            // txtReturned1
            // 
            this.txtReturned1.Location = new System.Drawing.Point(122, 99);
            this.txtReturned1.Name = "txtReturned1";
            this.txtReturned1.ReadOnly = true;
            this.txtReturned1.Size = new System.Drawing.Size(100, 22);
            this.txtReturned1.TabIndex = 5;
            this.txtReturned1.TabStop = false;
            this.txtReturned1.Text = "0";
            this.txtReturned1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReturned1
            // 
            this.labelReturned1.AutoSize = true;
            this.labelReturned1.Location = new System.Drawing.Point(24, 102);
            this.labelReturned1.Name = "labelReturned1";
            this.labelReturned1.Size = new System.Drawing.Size(92, 16);
            this.labelReturned1.TabIndex = 4;
            this.labelReturned1.Text = "Возвращено:";
            // 
            // txtReceived1
            // 
            this.txtReceived1.Location = new System.Drawing.Point(121, 65);
            this.txtReceived1.Name = "txtReceived1";
            this.txtReceived1.Size = new System.Drawing.Size(100, 22);
            this.txtReceived1.TabIndex = 3;
            this.txtReceived1.TabStop = false;
            this.txtReceived1.Text = "0";
            this.txtReceived1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelReceived1
            // 
            this.labelReceived1.AutoSize = true;
            this.labelReceived1.Location = new System.Drawing.Point(36, 65);
            this.labelReceived1.Name = "labelReceived1";
            this.labelReceived1.Size = new System.Drawing.Size(76, 16);
            this.labelReceived1.TabIndex = 2;
            this.labelReceived1.Text = "Получено:";
            // 
            // labelStateValue1
            // 
            this.labelStateValue1.AutoSize = true;
            this.labelStateValue1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateValue1.Location = new System.Drawing.Point(132, 31);
            this.labelStateValue1.Name = "labelStateValue1";
            this.labelStateValue1.Size = new System.Drawing.Size(89, 18);
            this.labelStateValue1.TabIndex = 1;
            this.labelStateValue1.Text = "Остановлен";
            this.labelStateValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelState1
            // 
            this.labelState1.AutoSize = true;
            this.labelState1.Location = new System.Drawing.Point(36, 33);
            this.labelState1.Name = "labelState1";
            this.labelState1.Size = new System.Drawing.Size(80, 16);
            this.labelState1.TabIndex = 0;
            this.labelState1.Text = "Состояние:";
            // 
            // groupBoxThread2
            // 
            this.groupBoxThread2.Controls.Add(this.btnStop2);
            this.groupBoxThread2.Controls.Add(this.btnPause2);
            this.groupBoxThread2.Controls.Add(this.btnStart2);
            this.groupBoxThread2.Controls.Add(this.cmbPriority2);
            this.groupBoxThread2.Controls.Add(this.txtReturned2);
            this.groupBoxThread2.Controls.Add(this.txtReceived2);
            this.groupBoxThread2.Controls.Add(this.labelStateValue2);
            this.groupBoxThread2.Controls.Add(this.labelPriority2);
            this.groupBoxThread2.Controls.Add(this.labelReturned2);
            this.groupBoxThread2.Controls.Add(this.labelReceived2);
            this.groupBoxThread2.Controls.Add(this.labelState2);
            this.groupBoxThread2.Location = new System.Drawing.Point(472, 168);
            this.groupBoxThread2.Name = "groupBoxThread2";
            this.groupBoxThread2.Size = new System.Drawing.Size(403, 231);
            this.groupBoxThread2.TabIndex = 2;
            this.groupBoxThread2.TabStop = false;
            this.groupBoxThread2.Text = "Дочерний поток 2";
            // 
            // groupBoxThread3
            // 
            this.groupBoxThread3.Controls.Add(this.btnStop3);
            this.groupBoxThread3.Controls.Add(this.btnPause3);
            this.groupBoxThread3.Controls.Add(this.btnStart3);
            this.groupBoxThread3.Controls.Add(this.cmbPriority3);
            this.groupBoxThread3.Controls.Add(this.txtReturned3);
            this.groupBoxThread3.Controls.Add(this.txtReceived3);
            this.groupBoxThread3.Controls.Add(this.labelStateValue3);
            this.groupBoxThread3.Controls.Add(this.labelPriority3);
            this.groupBoxThread3.Controls.Add(this.labelReturned3);
            this.groupBoxThread3.Controls.Add(this.labelReceived3);
            this.groupBoxThread3.Controls.Add(this.labelState3);
            this.groupBoxThread3.Location = new System.Drawing.Point(24, 414);
            this.groupBoxThread3.Name = "groupBoxThread3";
            this.groupBoxThread3.Size = new System.Drawing.Size(390, 220);
            this.groupBoxThread3.TabIndex = 3;
            this.groupBoxThread3.TabStop = false;
            this.groupBoxThread3.Text = "Дочерний поток 3";
            // 
            // groupBoxThread4
            // 
            this.groupBoxThread4.Controls.Add(this.btnStop4);
            this.groupBoxThread4.Controls.Add(this.btnPause4);
            this.groupBoxThread4.Controls.Add(this.btnStart4);
            this.groupBoxThread4.Controls.Add(this.cmbPriority4);
            this.groupBoxThread4.Controls.Add(this.txtReturned4);
            this.groupBoxThread4.Controls.Add(this.txtReceived4);
            this.groupBoxThread4.Controls.Add(this.labelStateValue4);
            this.groupBoxThread4.Controls.Add(this.labelPriority4);
            this.groupBoxThread4.Controls.Add(this.labelReturned4);
            this.groupBoxThread4.Controls.Add(this.labelReceived4);
            this.groupBoxThread4.Controls.Add(this.labelState4);
            this.groupBoxThread4.Location = new System.Drawing.Point(472, 423);
            this.groupBoxThread4.Name = "groupBoxThread4";
            this.groupBoxThread4.Size = new System.Drawing.Size(424, 211);
            this.groupBoxThread4.TabIndex = 4;
            this.groupBoxThread4.TabStop = false;
            this.groupBoxThread4.Text = "Дочерний поток 4";
            // 
            // labelPriority1
            // 
            this.labelPriority1.AutoSize = true;
            this.labelPriority1.Location = new System.Drawing.Point(16, 130);
            this.labelPriority1.Name = "labelPriority1";
            this.labelPriority1.Size = new System.Drawing.Size(82, 16);
            this.labelPriority1.TabIndex = 6;
            this.labelPriority1.Text = "Приоритет:";
            // 
            // cmbPriority1
            // 
            this.cmbPriority1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority1.FormattingEnabled = true;
            this.cmbPriority1.Items.AddRange(new object[] {
            "Низкий",
            "Ниже обычного",
            "Обычный",
            "Выше обычного",
            "Высокий"});
            this.cmbPriority1.Location = new System.Drawing.Point(121, 127);
            this.cmbPriority1.Name = "cmbPriority1";
            this.cmbPriority1.Size = new System.Drawing.Size(121, 24);
            this.cmbPriority1.TabIndex = 7;
            this.cmbPriority1.Tag = "1";
            this.cmbPriority1.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // btnStart1
            // 
            this.btnStart1.Location = new System.Drawing.Point(16, 169);
            this.btnStart1.Name = "btnStart1";
            this.btnStart1.Size = new System.Drawing.Size(75, 23);
            this.btnStart1.TabIndex = 8;
            this.btnStart1.Tag = "1";
            this.btnStart1.Text = "Пуск";
            this.btnStart1.UseVisualStyleBackColor = true;
            this.btnStart1.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause1
            // 
            this.btnPause1.Enabled = false;
            this.btnPause1.Location = new System.Drawing.Point(111, 169);
            this.btnPause1.Name = "btnPause1";
            this.btnPause1.Size = new System.Drawing.Size(75, 23);
            this.btnPause1.TabIndex = 9;
            this.btnPause1.Tag = "1";
            this.btnPause1.Text = "Пауза";
            this.btnPause1.UseVisualStyleBackColor = true;
            this.btnPause1.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop1
            // 
            this.btnStop1.Enabled = false;
            this.btnStop1.Location = new System.Drawing.Point(208, 169);
            this.btnStop1.Name = "btnStop1";
            this.btnStop1.Size = new System.Drawing.Size(75, 23);
            this.btnStop1.TabIndex = 10;
            this.btnStop1.Tag = "1";
            this.btnStop1.Text = "Стоп";
            this.btnStop1.UseVisualStyleBackColor = true;
            this.btnStop1.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labelState2
            // 
            this.labelState2.AutoSize = true;
            this.labelState2.Location = new System.Drawing.Point(41, 33);
            this.labelState2.Name = "labelState2";
            this.labelState2.Size = new System.Drawing.Size(80, 16);
            this.labelState2.TabIndex = 0;
            this.labelState2.Text = "Состояние:";
            // 
            // labelReceived2
            // 
            this.labelReceived2.AutoSize = true;
            this.labelReceived2.Location = new System.Drawing.Point(44, 65);
            this.labelReceived2.Name = "labelReceived2";
            this.labelReceived2.Size = new System.Drawing.Size(76, 16);
            this.labelReceived2.TabIndex = 1;
            this.labelReceived2.Text = "Получено:";
            // 
            // labelReturned2
            // 
            this.labelReturned2.AutoSize = true;
            this.labelReturned2.Location = new System.Drawing.Point(44, 101);
            this.labelReturned2.Name = "labelReturned2";
            this.labelReturned2.Size = new System.Drawing.Size(92, 16);
            this.labelReturned2.TabIndex = 2;
            this.labelReturned2.Text = "Возвращено:";
            // 
            // labelPriority2
            // 
            this.labelPriority2.AutoSize = true;
            this.labelPriority2.Location = new System.Drawing.Point(47, 130);
            this.labelPriority2.Name = "labelPriority2";
            this.labelPriority2.Size = new System.Drawing.Size(82, 16);
            this.labelPriority2.TabIndex = 3;
            this.labelPriority2.Text = "Приоритет:";
            // 
            // labelState3
            // 
            this.labelState3.AutoSize = true;
            this.labelState3.Location = new System.Drawing.Point(16, 41);
            this.labelState3.Name = "labelState3";
            this.labelState3.Size = new System.Drawing.Size(80, 16);
            this.labelState3.TabIndex = 0;
            this.labelState3.Text = "Состояние:";
            // 
            // labelReceived3
            // 
            this.labelReceived3.AutoSize = true;
            this.labelReceived3.Location = new System.Drawing.Point(19, 73);
            this.labelReceived3.Name = "labelReceived3";
            this.labelReceived3.Size = new System.Drawing.Size(76, 16);
            this.labelReceived3.TabIndex = 1;
            this.labelReceived3.Text = "Получено:";
            // 
            // labelReturned3
            // 
            this.labelReturned3.AutoSize = true;
            this.labelReturned3.Location = new System.Drawing.Point(19, 102);
            this.labelReturned3.Name = "labelReturned3";
            this.labelReturned3.Size = new System.Drawing.Size(92, 16);
            this.labelReturned3.TabIndex = 2;
            this.labelReturned3.Text = "Возвращено:";
            // 
            // labelPriority3
            // 
            this.labelPriority3.AutoSize = true;
            this.labelPriority3.Location = new System.Drawing.Point(19, 133);
            this.labelPriority3.Name = "labelPriority3";
            this.labelPriority3.Size = new System.Drawing.Size(82, 16);
            this.labelPriority3.TabIndex = 3;
            this.labelPriority3.Text = "Приоритет:";
            // 
            // labelState4
            // 
            this.labelState4.AutoSize = true;
            this.labelState4.Location = new System.Drawing.Point(44, 32);
            this.labelState4.Name = "labelState4";
            this.labelState4.Size = new System.Drawing.Size(80, 16);
            this.labelState4.TabIndex = 0;
            this.labelState4.Text = "Состояние:";
            // 
            // labelReceived4
            // 
            this.labelReceived4.AutoSize = true;
            this.labelReceived4.Location = new System.Drawing.Point(44, 63);
            this.labelReceived4.Name = "labelReceived4";
            this.labelReceived4.Size = new System.Drawing.Size(76, 16);
            this.labelReceived4.TabIndex = 1;
            this.labelReceived4.Text = "Получено:";
            // 
            // labelReturned4
            // 
            this.labelReturned4.AutoSize = true;
            this.labelReturned4.Location = new System.Drawing.Point(44, 93);
            this.labelReturned4.Name = "labelReturned4";
            this.labelReturned4.Size = new System.Drawing.Size(92, 16);
            this.labelReturned4.TabIndex = 2;
            this.labelReturned4.Text = "Возвращено:";
            // 
            // labelPriority4
            // 
            this.labelPriority4.AutoSize = true;
            this.labelPriority4.Location = new System.Drawing.Point(44, 123);
            this.labelPriority4.Name = "labelPriority4";
            this.labelPriority4.Size = new System.Drawing.Size(82, 16);
            this.labelPriority4.TabIndex = 3;
            this.labelPriority4.Text = "Приоритет:";
            // 
            // labelStateValue2
            // 
            this.labelStateValue2.AutoSize = true;
            this.labelStateValue2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateValue2.Location = new System.Drawing.Point(132, 31);
            this.labelStateValue2.Name = "labelStateValue2";
            this.labelStateValue2.Size = new System.Drawing.Size(89, 18);
            this.labelStateValue2.TabIndex = 4;
            this.labelStateValue2.Text = "Остановлен";
            this.labelStateValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStateValue3
            // 
            this.labelStateValue3.AutoSize = true;
            this.labelStateValue3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateValue3.Location = new System.Drawing.Point(102, 41);
            this.labelStateValue3.Name = "labelStateValue3";
            this.labelStateValue3.Size = new System.Drawing.Size(89, 18);
            this.labelStateValue3.TabIndex = 4;
            this.labelStateValue3.Text = "Остановлен";
            this.labelStateValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStateValue4
            // 
            this.labelStateValue4.AutoSize = true;
            this.labelStateValue4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateValue4.Location = new System.Drawing.Point(132, 32);
            this.labelStateValue4.Name = "labelStateValue4";
            this.labelStateValue4.Size = new System.Drawing.Size(89, 18);
            this.labelStateValue4.TabIndex = 4;
            this.labelStateValue4.Text = "Остановлен";
            this.labelStateValue4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReceived2
            // 
            this.txtReceived2.Location = new System.Drawing.Point(147, 62);
            this.txtReceived2.Name = "txtReceived2";
            this.txtReceived2.ReadOnly = true;
            this.txtReceived2.Size = new System.Drawing.Size(100, 22);
            this.txtReceived2.TabIndex = 5;
            this.txtReceived2.TabStop = false;
            this.txtReceived2.Text = "0";
            this.txtReceived2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReceived3
            // 
            this.txtReceived3.Location = new System.Drawing.Point(107, 70);
            this.txtReceived3.Name = "txtReceived3";
            this.txtReceived3.ReadOnly = true;
            this.txtReceived3.Size = new System.Drawing.Size(100, 22);
            this.txtReceived3.TabIndex = 5;
            this.txtReceived3.TabStop = false;
            this.txtReceived3.Text = "0";
            this.txtReceived3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReceived4
            // 
            this.txtReceived4.Location = new System.Drawing.Point(135, 64);
            this.txtReceived4.Name = "txtReceived4";
            this.txtReceived4.ReadOnly = true;
            this.txtReceived4.Size = new System.Drawing.Size(100, 22);
            this.txtReceived4.TabIndex = 5;
            this.txtReceived4.TabStop = false;
            this.txtReceived4.Text = "0";
            this.txtReceived4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReturned2
            // 
            this.txtReturned2.Location = new System.Drawing.Point(168, 101);
            this.txtReturned2.Name = "txtReturned2";
            this.txtReturned2.ReadOnly = true;
            this.txtReturned2.Size = new System.Drawing.Size(100, 22);
            this.txtReturned2.TabIndex = 6;
            this.txtReturned2.TabStop = false;
            this.txtReturned2.Text = "0";
            this.txtReturned2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReturned3
            // 
            this.txtReturned3.Location = new System.Drawing.Point(121, 98);
            this.txtReturned3.Name = "txtReturned3";
            this.txtReturned3.ReadOnly = true;
            this.txtReturned3.Size = new System.Drawing.Size(100, 22);
            this.txtReturned3.TabIndex = 6;
            this.txtReturned3.TabStop = false;
            this.txtReturned3.Text = "0";
            this.txtReturned3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReturned4
            // 
            this.txtReturned4.Location = new System.Drawing.Point(168, 90);
            this.txtReturned4.Name = "txtReturned4";
            this.txtReturned4.ReadOnly = true;
            this.txtReturned4.Size = new System.Drawing.Size(100, 22);
            this.txtReturned4.TabIndex = 6;
            this.txtReturned4.TabStop = false;
            this.txtReturned4.Text = "0";
            this.txtReturned4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbPriority2
            // 
            this.cmbPriority2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority2.FormattingEnabled = true;
            this.cmbPriority2.Items.AddRange(new object[] {
            "Низкий",
            "Ниже обычного",
            "Обычный",
            "Выше обычного",
            "Высокий"});
            this.cmbPriority2.Location = new System.Drawing.Point(147, 130);
            this.cmbPriority2.Name = "cmbPriority2";
            this.cmbPriority2.Size = new System.Drawing.Size(121, 24);
            this.cmbPriority2.TabIndex = 7;
            this.cmbPriority2.Tag = "2";
            this.cmbPriority2.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // cmbPriority3
            // 
            this.cmbPriority3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority3.FormattingEnabled = true;
            this.cmbPriority3.Items.AddRange(new object[] {
            "Низкий",
            "Ниже обычного",
            "Обычный",
            "Выше обычного",
            "Высокий"});
            this.cmbPriority3.Location = new System.Drawing.Point(111, 129);
            this.cmbPriority3.Name = "cmbPriority3";
            this.cmbPriority3.Size = new System.Drawing.Size(121, 24);
            this.cmbPriority3.TabIndex = 7;
            this.cmbPriority3.Tag = "3";
            this.cmbPriority3.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // cmbPriority4
            // 
            this.cmbPriority4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority4.FormattingEnabled = true;
            this.cmbPriority4.Items.AddRange(new object[] {
            "Низкий",
            "Ниже обычного",
            "Обычный",
            "Выше обычного",
            "Высокий"});
            this.cmbPriority4.Location = new System.Drawing.Point(147, 124);
            this.cmbPriority4.Name = "cmbPriority4";
            this.cmbPriority4.Size = new System.Drawing.Size(121, 24);
            this.cmbPriority4.TabIndex = 7;
            this.cmbPriority4.Tag = "4";
            this.cmbPriority4.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(20, 190);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(75, 23);
            this.btnStart2.TabIndex = 8;
            this.btnStart2.Tag = "2";
            this.btnStart2.Text = "Пуск";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause2
            // 
            this.btnPause2.Enabled = false;
            this.btnPause2.Location = new System.Drawing.Point(135, 190);
            this.btnPause2.Name = "btnPause2";
            this.btnPause2.Size = new System.Drawing.Size(75, 23);
            this.btnPause2.TabIndex = 9;
            this.btnPause2.Tag = "2";
            this.btnPause2.Text = "Пауза";
            this.btnPause2.UseVisualStyleBackColor = true;
            this.btnPause2.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop2
            // 
            this.btnStop2.Enabled = false;
            this.btnStop2.Location = new System.Drawing.Point(266, 190);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(75, 23);
            this.btnStop2.TabIndex = 10;
            this.btnStop2.Tag = "2";
            this.btnStop2.Text = "Стоп";
            this.btnStop2.UseVisualStyleBackColor = true;
            this.btnStop2.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart3
            // 
            this.btnStart3.Location = new System.Drawing.Point(39, 178);
            this.btnStart3.Name = "btnStart3";
            this.btnStart3.Size = new System.Drawing.Size(75, 23);
            this.btnStart3.TabIndex = 8;
            this.btnStart3.Tag = "3";
            this.btnStart3.Text = "Пуск";
            this.btnStart3.UseVisualStyleBackColor = true;
            this.btnStart3.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause3
            // 
            this.btnPause3.Enabled = false;
            this.btnPause3.Location = new System.Drawing.Point(132, 178);
            this.btnPause3.Name = "btnPause3";
            this.btnPause3.Size = new System.Drawing.Size(75, 23);
            this.btnPause3.TabIndex = 9;
            this.btnPause3.Tag = "3";
            this.btnPause3.Text = "Пауза";
            this.btnPause3.UseVisualStyleBackColor = true;
            this.btnPause3.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop3
            // 
            this.btnStop3.Enabled = false;
            this.btnStop3.Location = new System.Drawing.Point(246, 177);
            this.btnStop3.Name = "btnStop3";
            this.btnStop3.Size = new System.Drawing.Size(75, 23);
            this.btnStop3.TabIndex = 10;
            this.btnStop3.Tag = "3";
            this.btnStop3.Text = "Стоп";
            this.btnStop3.UseVisualStyleBackColor = true;
            this.btnStop3.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart4
            // 
            this.btnStart4.Location = new System.Drawing.Point(50, 168);
            this.btnStart4.Name = "btnStart4";
            this.btnStart4.Size = new System.Drawing.Size(75, 23);
            this.btnStart4.TabIndex = 8;
            this.btnStart4.Tag = "4";
            this.btnStart4.Text = "Пуск";
            this.btnStart4.UseVisualStyleBackColor = true;
            this.btnStart4.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause4
            // 
            this.btnPause4.Enabled = false;
            this.btnPause4.Location = new System.Drawing.Point(179, 168);
            this.btnPause4.Name = "btnPause4";
            this.btnPause4.Size = new System.Drawing.Size(75, 23);
            this.btnPause4.TabIndex = 9;
            this.btnPause4.Tag = "4";
            this.btnPause4.Text = "Пауза";
            this.btnPause4.UseVisualStyleBackColor = true;
            this.btnPause4.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop4
            // 
            this.btnStop4.Enabled = false;
            this.btnStop4.Location = new System.Drawing.Point(290, 168);
            this.btnStop4.Name = "btnStop4";
            this.btnStop4.Size = new System.Drawing.Size(75, 23);
            this.btnStop4.TabIndex = 10;
            this.btnStop4.Tag = "4";
            this.btnStop4.Text = "Стоп";
            this.btnStop4.UseVisualStyleBackColor = true;
            this.btnStop4.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 661);
            this.Controls.Add(this.groupBoxThread4);
            this.Controls.Add(this.groupBoxThread3);
            this.Controls.Add(this.groupBoxThread2);
            this.Controls.Add(this.groupBoxThread1);
            this.Controls.Add(this.groupBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление потоками";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBoxThread1.ResumeLayout(false);
            this.groupBoxThread1.PerformLayout();
            this.groupBoxThread2.ResumeLayout(false);
            this.groupBoxThread2.PerformLayout();
            this.groupBoxThread3.ResumeLayout(false);
            this.groupBoxThread3.PerformLayout();
            this.groupBoxThread4.ResumeLayout(false);
            this.groupBoxThread4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.TextBox txtCommonCounter;
        private System.Windows.Forms.TextBox txtParentValue;
        private System.Windows.Forms.Label labelCommonCounter;
        private System.Windows.Forms.Label labelParentValue;
        private System.Windows.Forms.GroupBox groupBoxThread1;
        private System.Windows.Forms.GroupBox groupBoxThread2;
        private System.Windows.Forms.GroupBox groupBoxThread3;
        private System.Windows.Forms.GroupBox groupBoxThread4;
        private System.Windows.Forms.TextBox txtReceived1;
        private System.Windows.Forms.Label labelReceived1;
        private System.Windows.Forms.Label labelStateValue1;
        private System.Windows.Forms.Label labelState1;
        private System.Windows.Forms.TextBox txtReturned1;
        private System.Windows.Forms.Label labelReturned1;
        private System.Windows.Forms.Label labelPriority1;
        private System.Windows.Forms.ComboBox cmbPriority1;
        private System.Windows.Forms.Button btnStart1;
        private System.Windows.Forms.Button btnStop1;
        private System.Windows.Forms.Button btnPause1;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.Button btnPause2;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.ComboBox cmbPriority2;
        private System.Windows.Forms.TextBox txtReturned2;
        private System.Windows.Forms.TextBox txtReceived2;
        private System.Windows.Forms.Label labelStateValue2;
        private System.Windows.Forms.Label labelPriority2;
        private System.Windows.Forms.Label labelReturned2;
        private System.Windows.Forms.Label labelReceived2;
        private System.Windows.Forms.Label labelState2;
        private System.Windows.Forms.Button btnStop3;
        private System.Windows.Forms.Button btnPause3;
        private System.Windows.Forms.Button btnStart3;
        private System.Windows.Forms.ComboBox cmbPriority3;
        private System.Windows.Forms.TextBox txtReturned3;
        private System.Windows.Forms.TextBox txtReceived3;
        private System.Windows.Forms.Label labelStateValue3;
        private System.Windows.Forms.Label labelPriority3;
        private System.Windows.Forms.Label labelReturned3;
        private System.Windows.Forms.Label labelReceived3;
        private System.Windows.Forms.Label labelState3;
        private System.Windows.Forms.Button btnStop4;
        private System.Windows.Forms.Button btnPause4;
        private System.Windows.Forms.Button btnStart4;
        private System.Windows.Forms.ComboBox cmbPriority4;
        private System.Windows.Forms.TextBox txtReturned4;
        private System.Windows.Forms.TextBox txtReceived4;
        private System.Windows.Forms.Label labelStateValue4;
        private System.Windows.Forms.Label labelPriority4;
        private System.Windows.Forms.Label labelReturned4;
        private System.Windows.Forms.Label labelReceived4;
        private System.Windows.Forms.Label labelState4;
    }
}

