namespace Plugin3D.UI
{
    partial class SprocketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SprocketForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.NumberOfTeethTextBox7 = new System.Windows.Forms.TextBox();
            this.ExeavationDepthTextBox6 = new System.Windows.Forms.TextBox();
            this.CylinderThicknessTextBox5 = new System.Windows.Forms.TextBox();
            this.CircleThicknessTextBox4 = new System.Windows.Forms.TextBox();
            this.HoleRadiusTextBox3 = new System.Windows.Forms.TextBox();
            this.CylinderRadiusTextBox2 = new System.Windows.Forms.TextBox();
            this.CircleRadiusTextBox1 = new System.Windows.Forms.TextBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 8);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.NumberOfTeethTextBox7);
            this.splitContainer1.Panel1.Controls.Add(this.ExeavationDepthTextBox6);
            this.splitContainer1.Panel1.Controls.Add(this.CylinderThicknessTextBox5);
            this.splitContainer1.Panel1.Controls.Add(this.CircleThicknessTextBox4);
            this.splitContainer1.Panel1.Controls.Add(this.HoleRadiusTextBox3);
            this.splitContainer1.Panel1.Controls.Add(this.CylinderRadiusTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.CircleRadiusTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.BuildButton);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(997, 366);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 2;
            // 
            // NumberOfTeethTextBox7
            // 
            this.NumberOfTeethTextBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberOfTeethTextBox7.Location = new System.Drawing.Point(235, 165);
            this.NumberOfTeethTextBox7.Name = "NumberOfTeethTextBox7";
            this.NumberOfTeethTextBox7.Size = new System.Drawing.Size(84, 20);
            this.NumberOfTeethTextBox7.TabIndex = 6;
            this.NumberOfTeethTextBox7.Text = "18";
            this.NumberOfTeethTextBox7.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // ExeavationDepthTextBox6
            // 
            this.ExeavationDepthTextBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExeavationDepthTextBox6.Location = new System.Drawing.Point(235, 139);
            this.ExeavationDepthTextBox6.Name = "ExeavationDepthTextBox6";
            this.ExeavationDepthTextBox6.Size = new System.Drawing.Size(84, 20);
            this.ExeavationDepthTextBox6.TabIndex = 5;
            this.ExeavationDepthTextBox6.Text = "9";
            this.ExeavationDepthTextBox6.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // CylinderThicknessTextBox5
            // 
            this.CylinderThicknessTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CylinderThicknessTextBox5.Location = new System.Drawing.Point(235, 113);
            this.CylinderThicknessTextBox5.Name = "CylinderThicknessTextBox5";
            this.CylinderThicknessTextBox5.Size = new System.Drawing.Size(84, 20);
            this.CylinderThicknessTextBox5.TabIndex = 4;
            this.CylinderThicknessTextBox5.Text = "20";
            this.CylinderThicknessTextBox5.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // CircleThicknessTextBox4
            // 
            this.CircleThicknessTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CircleThicknessTextBox4.Location = new System.Drawing.Point(235, 87);
            this.CircleThicknessTextBox4.Name = "CircleThicknessTextBox4";
            this.CircleThicknessTextBox4.Size = new System.Drawing.Size(84, 20);
            this.CircleThicknessTextBox4.TabIndex = 3;
            this.CircleThicknessTextBox4.Text = "12";
            this.CircleThicknessTextBox4.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // HoleRadiusTextBox3
            // 
            this.HoleRadiusTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HoleRadiusTextBox3.Location = new System.Drawing.Point(234, 61);
            this.HoleRadiusTextBox3.Name = "HoleRadiusTextBox3";
            this.HoleRadiusTextBox3.Size = new System.Drawing.Size(84, 20);
            this.HoleRadiusTextBox3.TabIndex = 2;
            this.HoleRadiusTextBox3.Text = "42";
            this.HoleRadiusTextBox3.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // CylinderRadiusTextBox2
            // 
            this.CylinderRadiusTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CylinderRadiusTextBox2.Location = new System.Drawing.Point(235, 35);
            this.CylinderRadiusTextBox2.Name = "CylinderRadiusTextBox2";
            this.CylinderRadiusTextBox2.Size = new System.Drawing.Size(84, 20);
            this.CylinderRadiusTextBox2.TabIndex = 1;
            this.CylinderRadiusTextBox2.Text = "85";
            this.CylinderRadiusTextBox2.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // CircleRadiusTextBox1
            // 
            this.CircleRadiusTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CircleRadiusTextBox1.Location = new System.Drawing.Point(235, 9);
            this.CircleRadiusTextBox1.Name = "CircleRadiusTextBox1";
            this.CircleRadiusTextBox1.Size = new System.Drawing.Size(84, 20);
            this.CircleRadiusTextBox1.TabIndex = 0;
            this.CircleRadiusTextBox1.Text = "180";
            this.CircleRadiusTextBox1.TextChanged += new System.EventHandler(this.TextBoxChanged);
            // 
            // BuildButton
            // 
            this.BuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildButton.Location = new System.Drawing.Point(235, 212);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(83, 20);
            this.BuildButton.TabIndex = 7;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Количество зубьев(n)";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Глубина шпоночной выемки (Н)";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Толщина цилиндра (Sц)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Толщина внешней части звездочки (S)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Радиус отверстия (r)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Радиус цилиндра (Rц)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Радиус внешней окружности (Rокр)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 333);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SprocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 375);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "SprocketForm";
            this.Text = "Плагин для КОМПАС-3D";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox NumberOfTeethTextBox7;
        private System.Windows.Forms.TextBox ExeavationDepthTextBox6;
        private System.Windows.Forms.TextBox CylinderThicknessTextBox5;
        private System.Windows.Forms.TextBox CircleThicknessTextBox4;
        private System.Windows.Forms.TextBox HoleRadiusTextBox3;
        private System.Windows.Forms.TextBox CylinderRadiusTextBox2;
        private System.Windows.Forms.TextBox CircleRadiusTextBox1;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

