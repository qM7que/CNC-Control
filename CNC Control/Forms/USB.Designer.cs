namespace PDI_Tarea2.Forms
{
    partial class USB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USB));
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbbaudrate = new System.Windows.Forms.ComboBox();
            this.cmbdatabits = new System.Windows.Forms.ComboBox();
            this.cmbparity = new System.Windows.Forms.ComboBox();
            this.cmbstopbits = new System.Windows.Forms.ComboBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmbSend = new System.Windows.Forms.Button();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.txtDatatoSend = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.nUDDelay = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btPause = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPort
            // 
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Location = new System.Drawing.Point(12, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 21);
            this.txtPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Порти";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Швидкість пер.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Біт парності";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Бітів даних";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Стопових бітів";
            // 
            // cmbbaudrate
            // 
            this.cmbbaudrate.FormattingEnabled = true;
            this.cmbbaudrate.Items.AddRange(new object[] {
            "9600"});
            this.cmbbaudrate.Location = new System.Drawing.Point(99, 31);
            this.cmbbaudrate.Name = "cmbbaudrate";
            this.cmbbaudrate.Size = new System.Drawing.Size(80, 21);
            this.cmbbaudrate.TabIndex = 8;
            // 
            // cmbdatabits
            // 
            this.cmbdatabits.FormattingEnabled = true;
            this.cmbdatabits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbdatabits.Location = new System.Drawing.Point(271, 31);
            this.cmbdatabits.Name = "cmbdatabits";
            this.cmbdatabits.Size = new System.Drawing.Size(80, 21);
            this.cmbdatabits.TabIndex = 10;
            // 
            // cmbparity
            // 
            this.cmbparity.FormattingEnabled = true;
            this.cmbparity.Items.AddRange(new object[] {
            "Even",
            "Mark",
            "None",
            "Odd",
            "Space"});
            this.cmbparity.Location = new System.Drawing.Point(185, 31);
            this.cmbparity.Name = "cmbparity";
            this.cmbparity.Size = new System.Drawing.Size(80, 21);
            this.cmbparity.TabIndex = 11;
            // 
            // cmbstopbits
            // 
            this.cmbstopbits.FormattingEnabled = true;
            this.cmbstopbits.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two",
            "None"});
            this.cmbstopbits.Location = new System.Drawing.Point(357, 31);
            this.cmbstopbits.Name = "cmbstopbits";
            this.cmbstopbits.Size = new System.Drawing.Size(80, 21);
            this.cmbstopbits.TabIndex = 12;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(12, 75);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(80, 23);
            this.cmdConnect.TabIndex = 13;
            this.cmdConnect.Text = "З\'єднати";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(99, 75);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(80, 23);
            this.cmdClose.TabIndex = 14;
            this.cmdClose.Text = "Відключити";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmbSend
            // 
            this.cmbSend.Location = new System.Drawing.Point(357, 75);
            this.cmbSend.Name = "cmbSend";
            this.cmbSend.Size = new System.Drawing.Size(80, 23);
            this.cmbSend.TabIndex = 15;
            this.cmbSend.Text = "Відправити";
            this.cmbSend.UseVisualStyleBackColor = true;
            this.cmbSend.Click += new System.EventHandler(this.cmbSend_Click);
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(443, 31);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceive.Size = new System.Drawing.Size(248, 173);
            this.txtReceive.TabIndex = 16;
            // 
            // txtDatatoSend
            // 
            this.txtDatatoSend.Location = new System.Drawing.Point(185, 78);
            this.txtDatatoSend.Name = "txtDatatoSend";
            this.txtDatatoSend.Size = new System.Drawing.Size(166, 20);
            this.txtDatatoSend.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Текст відправлення:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Вивід:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 44);
            this.button2.TabIndex = 21;
            this.button2.Text = "Відкрити файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(357, 112);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(80, 44);
            this.btSend.TabIndex = 22;
            this.btSend.Text = "Відправити вміст";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Відкритий файл: ";
            // 
            // txPath
            // 
            this.txPath.Location = new System.Drawing.Point(12, 184);
            this.txPath.Name = "txPath";
            this.txPath.ReadOnly = true;
            this.txPath.Size = new System.Drawing.Size(339, 20);
            this.txPath.TabIndex = 24;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // nUDDelay
            // 
            this.nUDDelay.Location = new System.Drawing.Point(271, 136);
            this.nUDDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nUDDelay.Name = "nUDDelay";
            this.nUDDelay.Size = new System.Drawing.Size(80, 20);
            this.nUDDelay.TabIndex = 25;
            this.nUDDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Затримка передачі (мс.)";
            // 
            // btPause
            // 
            this.btPause.Location = new System.Drawing.Point(99, 112);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(80, 21);
            this.btPause.TabIndex = 27;
            this.btPause.Text = "Пауза";
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(99, 135);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(80, 21);
            this.btStop.TabIndex = 28;
            this.btStop.Text = "Стоп";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(70, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(357, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 23);
            this.button3.TabIndex = 29;
            this.button3.Text = "Закрити";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // USB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(703, 224);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nUDDelay);
            this.Controls.Add(this.txPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDatatoSend);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.cmbSend);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.cmbstopbits);
            this.Controls.Add(this.cmbparity);
            this.Controls.Add(this.cmbdatabits);
            this.Controls.Add(this.cmbbaudrate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Name = "USB";
            this.ShowIcon = false;
            this.Text = "Підключені пристрої";
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox txtPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbbaudrate;
        private System.Windows.Forms.ComboBox cmbdatabits;
        private System.Windows.Forms.ComboBox cmbparity;
        private System.Windows.Forms.ComboBox cmbstopbits;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmbSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.TextBox txtDatatoSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown nUDDelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button button3;
    }
}