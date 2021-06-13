namespace PDI_Tarea2
{
    partial class GCODE
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lower_sens = new System.Windows.Forms.NumericUpDown();
            this.upper_sens = new System.Windows.Forms.NumericUpDown();
            this.thickness = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Sigma = new System.Windows.Forms.TextBox();
            this.MatrixX = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Gsmoth = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.MatrixY = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.min_lenght = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Scale1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Z = new System.Windows.Forms.NumericUpDown();
            this.Y = new System.Windows.Forms.NumericUpDown();
            this.X = new System.Windows.Forms.NumericUpDown();
            this.Deepth = new System.Windows.Forms.NumericUpDown();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.AllWay = new System.Windows.Forms.Label();
            this.MiddleWay = new System.Windows.Forms.Label();
            this.points_num = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lower_sens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_sens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_lenght)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(254, 392);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.5625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.4375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Сформувати контури";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Закрити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Генерація програми";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lower_sens
            // 
            this.lower_sens.Cursor = System.Windows.Forms.Cursors.Default;
            this.lower_sens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.lower_sens.Location = new System.Drawing.Point(209, 87);
            this.lower_sens.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.lower_sens.Name = "lower_sens";
            this.lower_sens.Size = new System.Drawing.Size(47, 20);
            this.lower_sens.TabIndex = 1;
            this.lower_sens.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // upper_sens
            // 
            this.upper_sens.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upper_sens.Location = new System.Drawing.Point(209, 113);
            this.upper_sens.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.upper_sens.Name = "upper_sens";
            this.upper_sens.Size = new System.Drawing.Size(47, 20);
            this.upper_sens.TabIndex = 2;
            this.upper_sens.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // thickness
            // 
            this.thickness.Location = new System.Drawing.Point(208, 139);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(48, 20);
            this.thickness.TabIndex = 3;
            this.thickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Sigma);
            this.groupBox1.Controls.Add(this.MatrixX);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Gsmoth);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.MatrixY);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.min_lenght);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lower_sens);
            this.groupBox1.Controls.Add(this.upper_sens);
            this.groupBox1.Controls.Add(this.thickness);
            this.groupBox1.Location = new System.Drawing.Point(254, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 243);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Налаштування знаходження контурів";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Sigma
            // 
            this.Sigma.Location = new System.Drawing.Point(210, 37);
            this.Sigma.Name = "Sigma";
            this.Sigma.Size = new System.Drawing.Size(47, 20);
            this.Sigma.TabIndex = 17;
            this.Sigma.Text = "1";
            this.Sigma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sigma_KeyPress);
            this.Sigma.Validating += new System.ComponentModel.CancelEventHandler(this.Sigma_Validating);
            // 
            // MatrixX
            // 
            this.MatrixX.Enabled = false;
            this.MatrixX.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MatrixX.Location = new System.Drawing.Point(158, 61);
            this.MatrixX.Name = "MatrixX";
            this.MatrixX.Size = new System.Drawing.Size(46, 20);
            this.MatrixX.TabIndex = 16;
            this.MatrixX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Розмірність ядра";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Відхилення (сігма)";
            // 
            // Gsmoth
            // 
            this.Gsmoth.AutoSize = true;
            this.Gsmoth.Location = new System.Drawing.Point(11, 19);
            this.Gsmoth.Name = "Gsmoth";
            this.Gsmoth.Size = new System.Drawing.Size(130, 17);
            this.Gsmoth.TabIndex = 13;
            this.Gsmoth.Text = "Розмиття за Гаусом";
            this.Gsmoth.UseVisualStyleBackColor = true;
            this.Gsmoth.CheckedChanged += new System.EventHandler(this.Gsmoth_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 211);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(236, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Апроксимація (для заощадження пам\'яті)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // MatrixY
            // 
            this.MatrixY.Enabled = false;
            this.MatrixY.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MatrixY.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MatrixY.Location = new System.Drawing.Point(210, 61);
            this.MatrixY.Name = "MatrixY";
            this.MatrixY.Size = new System.Drawing.Size(46, 20);
            this.MatrixY.TabIndex = 11;
            this.MatrixY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 165);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(175, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Мінімальна довжина контуру ";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // min_lenght
            // 
            this.min_lenght.Enabled = false;
            this.min_lenght.Location = new System.Drawing.Point(208, 165);
            this.min_lenght.Name = "min_lenght";
            this.min_lenght.Size = new System.Drawing.Size(48, 20);
            this.min_lenght.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 188);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Тільки зовнішні контури";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Товщина контуру (пікселів)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Верхня границя чутивості";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Нижня границя чутивості";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Scale1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Z);
            this.groupBox2.Controls.Add(this.Y);
            this.groupBox2.Controls.Add(this.X);
            this.groupBox2.Controls.Add(this.Deepth);
            this.groupBox2.Controls.Add(this.Speed);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(254, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 128);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Налаштування керуючої програми";
            // 
            // Scale1
            // 
            this.Scale1.Location = new System.Drawing.Point(210, 74);
            this.Scale1.Name = "Scale1";
            this.Scale1.Size = new System.Drawing.Size(47, 20);
            this.Scale1.TabIndex = 8;
            this.Scale1.Text = "1";
            this.Scale1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Scale1_KeyPress);
            this.Scale1.Validating += new System.ComponentModel.CancelEventHandler(this.Scale1_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "X";
            // 
            // Z
            // 
            this.Z.Location = new System.Drawing.Point(220, 102);
            this.Z.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(38, 20);
            this.Z.TabIndex = 16;
            // 
            // Y
            // 
            this.Y.Location = new System.Drawing.Point(160, 102);
            this.Y.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(38, 20);
            this.Y.TabIndex = 15;
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(104, 102);
            this.X.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(38, 20);
            this.X.TabIndex = 14;
            // 
            // Deepth
            // 
            this.Deepth.Cursor = System.Windows.Forms.Cursors.Default;
            this.Deepth.Location = new System.Drawing.Point(210, 49);
            this.Deepth.Name = "Deepth";
            this.Deepth.Size = new System.Drawing.Size(48, 20);
            this.Deepth.TabIndex = 12;
            this.Deepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(210, 19);
            this.Speed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(48, 20);
            this.Speed.TabIndex = 11;
            this.Speed.TabStop = false;
            this.Speed.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Зміщення (мм)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Міліметрів на піксель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Глибина робочого інструменту (мкм)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Швидкість подачі (мм/хв)";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 27);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(236, 409);
            this.checkedListBox1.TabIndex = 6;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // AllWay
            // 
            this.AllWay.AutoSize = true;
            this.AllWay.Location = new System.Drawing.Point(251, 330);
            this.AllWay.Name = "AllWay";
            this.AllWay.Size = new System.Drawing.Size(0, 13);
            this.AllWay.TabIndex = 8;
            // 
            // MiddleWay
            // 
            this.MiddleWay.AutoSize = true;
            this.MiddleWay.Location = new System.Drawing.Point(251, 346);
            this.MiddleWay.Name = "MiddleWay";
            this.MiddleWay.Size = new System.Drawing.Size(0, 13);
            this.MiddleWay.TabIndex = 9;
            // 
            // points_num
            // 
            this.points_num.AutoSize = true;
            this.points_num.Location = new System.Drawing.Point(257, 361);
            this.points_num.Name = "points_num";
            this.points_num.Size = new System.Drawing.Size(0, 13);
            this.points_num.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Список контурів:";
            // 
            // GCODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 443);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.points_num);
            this.Controls.Add(this.MiddleWay);
            this.Controls.Add(this.AllWay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GCODE";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Генерація керуючої програми";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lower_sens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upper_sens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thickness)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_lenght)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown lower_sens;
        private System.Windows.Forms.NumericUpDown upper_sens;
        private System.Windows.Forms.NumericUpDown thickness;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown min_lenght;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Deepth;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Z;
        private System.Windows.Forms.NumericUpDown Y;
        private System.Windows.Forms.NumericUpDown X;
        private System.Windows.Forms.TextBox Scale1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label AllWay;
        private System.Windows.Forms.Label MiddleWay;
        private System.Windows.Forms.Label points_num;
        private System.Windows.Forms.NumericUpDown MatrixY;
        private System.Windows.Forms.CheckBox Gsmoth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown MatrixX;
        private System.Windows.Forms.TextBox Sigma;
        private System.Windows.Forms.Label label13;
    }
}