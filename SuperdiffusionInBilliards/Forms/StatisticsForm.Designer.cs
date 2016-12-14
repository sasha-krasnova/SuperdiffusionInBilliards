namespace SuperdiffusionInBilliards
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.meanSqareDispOnTime = new System.Windows.Forms.PictureBox();
            this.calculateAcceleration = new System.Windows.Forms.Button();
            this.calculateCoeffisientOfSuperdif = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.averVelOnTime = new System.Windows.Forms.PictureBox();
            this.fermiAcceleration = new System.Windows.Forms.TextBox();
            this.coefOfSuperdif = new System.Windows.Forms.TextBox();
            this.fermiAccelerationTheory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.coefOfSuperdifTheory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonWriteVelToFile = new System.Windows.Forms.Button();
            this.buttonWriteDispInFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.meanSqareDispOnTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averVelOnTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Зависимость средней скорости частицы от времени";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Зависимость среднеквадратичного отклонения от времени";
            // 
            // meanSqareDispOnTime
            // 
            this.meanSqareDispOnTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.meanSqareDispOnTime.Location = new System.Drawing.Point(16, 274);
            this.meanSqareDispOnTime.Name = "meanSqareDispOnTime";
            this.meanSqareDispOnTime.Size = new System.Drawing.Size(303, 208);
            this.meanSqareDispOnTime.TabIndex = 3;
            this.meanSqareDispOnTime.TabStop = false;
            // 
            // calculateAcceleration
            // 
            this.calculateAcceleration.BackColor = System.Drawing.Color.SpringGreen;
            this.calculateAcceleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateAcceleration.Location = new System.Drawing.Point(463, 29);
            this.calculateAcceleration.Name = "calculateAcceleration";
            this.calculateAcceleration.Size = new System.Drawing.Size(267, 65);
            this.calculateAcceleration.TabIndex = 4;
            this.calculateAcceleration.Text = "Построить график и расчитать ускорение Ферми";
            this.calculateAcceleration.UseVisualStyleBackColor = false;
            this.calculateAcceleration.Click += new System.EventHandler(this.calculateAcceleration_Click);
            // 
            // calculateCoeffisientOfSuperdif
            // 
            this.calculateCoeffisientOfSuperdif.BackColor = System.Drawing.Color.SpringGreen;
            this.calculateCoeffisientOfSuperdif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateCoeffisientOfSuperdif.Location = new System.Drawing.Point(463, 274);
            this.calculateCoeffisientOfSuperdif.Name = "calculateCoeffisientOfSuperdif";
            this.calculateCoeffisientOfSuperdif.Size = new System.Drawing.Size(267, 65);
            this.calculateCoeffisientOfSuperdif.TabIndex = 5;
            this.calculateCoeffisientOfSuperdif.Text = "Построить график и расчитать коэффициент супердиффузии";
            this.calculateCoeffisientOfSuperdif.UseVisualStyleBackColor = false;
            this.calculateCoeffisientOfSuperdif.Click += new System.EventHandler(this.calculateCoeffisientOfSuperdif_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ускорение Ферми =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Коэффициент супердиффузии =";
            // 
            // averVelOnTime
            // 
            this.averVelOnTime.BackColor = System.Drawing.SystemColors.Window;
            this.averVelOnTime.Location = new System.Drawing.Point(12, 29);
            this.averVelOnTime.Name = "averVelOnTime";
            this.averVelOnTime.Size = new System.Drawing.Size(303, 208);
            this.averVelOnTime.TabIndex = 9;
            this.averVelOnTime.TabStop = false;
            // 
            // fermiAcceleration
            // 
            this.fermiAcceleration.Location = new System.Drawing.Point(578, 109);
            this.fermiAcceleration.Name = "fermiAcceleration";
            this.fermiAcceleration.Size = new System.Drawing.Size(151, 20);
            this.fermiAcceleration.TabIndex = 13;
            // 
            // coefOfSuperdif
            // 
            this.coefOfSuperdif.Location = new System.Drawing.Point(579, 355);
            this.coefOfSuperdif.Name = "coefOfSuperdif";
            this.coefOfSuperdif.Size = new System.Drawing.Size(151, 20);
            this.coefOfSuperdif.TabIndex = 14;
            // 
            // fermiAccelerationTheory
            // 
            this.fermiAccelerationTheory.Location = new System.Drawing.Point(579, 135);
            this.fermiAccelerationTheory.Name = "fermiAccelerationTheory";
            this.fermiAccelerationTheory.Size = new System.Drawing.Size(150, 20);
            this.fermiAccelerationTheory.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Теоретическое ускорение Ферми = ";
            // 
            // coefOfSuperdifTheory
            // 
            this.coefOfSuperdifTheory.Location = new System.Drawing.Point(580, 380);
            this.coefOfSuperdifTheory.Name = "coefOfSuperdifTheory";
            this.coefOfSuperdifTheory.Size = new System.Drawing.Size(150, 20);
            this.coefOfSuperdifTheory.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Теоретический коэффициент супердиффузии =";
            // 
            // buttonWriteVelToFile
            // 
            this.buttonWriteVelToFile.Enabled = false;
            this.buttonWriteVelToFile.Location = new System.Drawing.Point(463, 172);
            this.buttonWriteVelToFile.Name = "buttonWriteVelToFile";
            this.buttonWriteVelToFile.Size = new System.Drawing.Size(267, 65);
            this.buttonWriteVelToFile.TabIndex = 19;
            this.buttonWriteVelToFile.Text = "Записать в файл";
            this.buttonWriteVelToFile.UseVisualStyleBackColor = true;
            this.buttonWriteVelToFile.Click += new System.EventHandler(this.buttonWriteVelToFile_Click);
            // 
            // buttonWriteDispInFile
            // 
            this.buttonWriteDispInFile.Enabled = false;
            this.buttonWriteDispInFile.Location = new System.Drawing.Point(463, 417);
            this.buttonWriteDispInFile.Name = "buttonWriteDispInFile";
            this.buttonWriteDispInFile.Size = new System.Drawing.Size(266, 65);
            this.buttonWriteDispInFile.TabIndex = 20;
            this.buttonWriteDispInFile.Text = "Записать в файл";
            this.buttonWriteDispInFile.UseVisualStyleBackColor = true;
            this.buttonWriteDispInFile.Click += new System.EventHandler(this.buttonWriteDispInFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Таблицы | *.csv";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 499);
            this.Controls.Add(this.buttonWriteDispInFile);
            this.Controls.Add(this.buttonWriteVelToFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.coefOfSuperdifTheory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fermiAccelerationTheory);
            this.Controls.Add(this.coefOfSuperdif);
            this.Controls.Add(this.fermiAcceleration);
            this.Controls.Add(this.averVelOnTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calculateCoeffisientOfSuperdif);
            this.Controls.Add(this.calculateAcceleration);
            this.Controls.Add(this.meanSqareDispOnTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StatisticsForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meanSqareDispOnTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averVelOnTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox meanSqareDispOnTime;
        private System.Windows.Forms.Button calculateAcceleration;
        private System.Windows.Forms.Button calculateCoeffisientOfSuperdif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox averVelOnTime;
        private System.Windows.Forms.TextBox fermiAcceleration;
        private System.Windows.Forms.TextBox coefOfSuperdif;
        private System.Windows.Forms.TextBox fermiAccelerationTheory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coefOfSuperdifTheory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonWriteVelToFile;
        private System.Windows.Forms.Button buttonWriteDispInFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}