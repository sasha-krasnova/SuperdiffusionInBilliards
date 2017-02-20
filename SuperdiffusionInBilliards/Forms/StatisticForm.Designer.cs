namespace SuperdiffusionInBilliards
{
    partial class StatisticForm
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
            this.velOrFApictureBox = new System.Windows.Forms.PictureBox();
            this.velOrFALabel = new System.Windows.Forms.Label();
            this.msdOrSupCoefLabel = new System.Windows.Forms.Label();
            this.msdOrSupCoefPictureBox = new System.Windows.Forms.PictureBox();
            this.plotVelOrFAButton = new System.Windows.Forms.Button();
            this.plotMSDOrSupCoefButton = new System.Windows.Forms.Button();
            this.faTextBox = new System.Windows.Forms.TextBox();
            this.faTheorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.msdTheorTextBox = new System.Windows.Forms.TextBox();
            this.msdTextBox = new System.Windows.Forms.TextBox();
            this.writeInFileVelButton = new System.Windows.Forms.Button();
            this.writeInFileMSDButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.velOrFApictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msdOrSupCoefPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // velOrFApictureBox
            // 
            this.velOrFApictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.velOrFApictureBox.Location = new System.Drawing.Point(12, 38);
            this.velOrFApictureBox.Name = "velOrFApictureBox";
            this.velOrFApictureBox.Size = new System.Drawing.Size(461, 195);
            this.velOrFApictureBox.TabIndex = 0;
            this.velOrFApictureBox.TabStop = false;
            // 
            // velOrFALabel
            // 
            this.velOrFALabel.AutoSize = true;
            this.velOrFALabel.Location = new System.Drawing.Point(15, 22);
            this.velOrFALabel.Name = "velOrFALabel";
            this.velOrFALabel.Size = new System.Drawing.Size(231, 13);
            this.velOrFALabel.TabIndex = 1;
            this.velOrFALabel.Text = "Зависимость скорости частицы от времени";
            // 
            // msdOrSupCoefLabel
            // 
            this.msdOrSupCoefLabel.AutoSize = true;
            this.msdOrSupCoefLabel.Location = new System.Drawing.Point(15, 248);
            this.msdOrSupCoefLabel.Name = "msdOrSupCoefLabel";
            this.msdOrSupCoefLabel.Size = new System.Drawing.Size(312, 13);
            this.msdOrSupCoefLabel.TabIndex = 3;
            this.msdOrSupCoefLabel.Text = "Зависимость среднеквадратичного отклонения от времени";
            // 
            // msdOrSupCoefPictureBox
            // 
            this.msdOrSupCoefPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.msdOrSupCoefPictureBox.Location = new System.Drawing.Point(15, 264);
            this.msdOrSupCoefPictureBox.Name = "msdOrSupCoefPictureBox";
            this.msdOrSupCoefPictureBox.Size = new System.Drawing.Size(458, 195);
            this.msdOrSupCoefPictureBox.TabIndex = 2;
            this.msdOrSupCoefPictureBox.TabStop = false;
            // 
            // plotVelOrFAButton
            // 
            this.plotVelOrFAButton.BackColor = System.Drawing.Color.SpringGreen;
            this.plotVelOrFAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.plotVelOrFAButton.Location = new System.Drawing.Point(559, 38);
            this.plotVelOrFAButton.Name = "plotVelOrFAButton";
            this.plotVelOrFAButton.Size = new System.Drawing.Size(291, 58);
            this.plotVelOrFAButton.TabIndex = 4;
            this.plotVelOrFAButton.Text = "Построить график и рассчитать ускорение Ферми";
            this.plotVelOrFAButton.UseVisualStyleBackColor = false;
            this.plotVelOrFAButton.Click += new System.EventHandler(this.plotVelOrFAButton_Click);
            // 
            // plotMSDOrSupCoefButton
            // 
            this.plotMSDOrSupCoefButton.BackColor = System.Drawing.Color.SpringGreen;
            this.plotMSDOrSupCoefButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.plotMSDOrSupCoefButton.Location = new System.Drawing.Point(559, 264);
            this.plotMSDOrSupCoefButton.Name = "plotMSDOrSupCoefButton";
            this.plotMSDOrSupCoefButton.Size = new System.Drawing.Size(291, 58);
            this.plotMSDOrSupCoefButton.TabIndex = 5;
            this.plotMSDOrSupCoefButton.Text = "Построить график и рассчитать коэффициент супердиффузии";
            this.plotMSDOrSupCoefButton.UseVisualStyleBackColor = false;
            // 
            // faTextBox
            // 
            this.faTextBox.Location = new System.Drawing.Point(720, 114);
            this.faTextBox.Name = "faTextBox";
            this.faTextBox.Size = new System.Drawing.Size(130, 20);
            this.faTextBox.TabIndex = 6;
            // 
            // faTheorTextBox
            // 
            this.faTheorTextBox.Location = new System.Drawing.Point(720, 147);
            this.faTheorTextBox.Name = "faTheorTextBox";
            this.faTheorTextBox.Size = new System.Drawing.Size(130, 20);
            this.faTheorTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ускорение Ферми (эксп.) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ускорение Ферми (теор.) = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Коэффициент супердиффузии (эксп.) = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Коэффициент супердиффузии (эксп.) = ";
            // 
            // msdTheorTextBox
            // 
            this.msdTheorTextBox.Location = new System.Drawing.Point(720, 383);
            this.msdTheorTextBox.Name = "msdTheorTextBox";
            this.msdTheorTextBox.Size = new System.Drawing.Size(129, 20);
            this.msdTheorTextBox.TabIndex = 11;
            // 
            // msdTextBox
            // 
            this.msdTextBox.Location = new System.Drawing.Point(720, 350);
            this.msdTextBox.Name = "msdTextBox";
            this.msdTextBox.Size = new System.Drawing.Size(129, 20);
            this.msdTextBox.TabIndex = 10;
            // 
            // writeInFileVelButton
            // 
            this.writeInFileVelButton.Location = new System.Drawing.Point(676, 201);
            this.writeInFileVelButton.Name = "writeInFileVelButton";
            this.writeInFileVelButton.Size = new System.Drawing.Size(174, 32);
            this.writeInFileVelButton.TabIndex = 14;
            this.writeInFileVelButton.Text = "Записать в файл";
            this.writeInFileVelButton.UseVisualStyleBackColor = true;
            // 
            // writeInFileMSDButton
            // 
            this.writeInFileMSDButton.Location = new System.Drawing.Point(675, 427);
            this.writeInFileMSDButton.Name = "writeInFileMSDButton";
            this.writeInFileMSDButton.Size = new System.Drawing.Size(174, 32);
            this.writeInFileMSDButton.TabIndex = 15;
            this.writeInFileMSDButton.Text = "button4";
            this.writeInFileMSDButton.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Таблицы | *.csv";
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 478);
            this.Controls.Add(this.writeInFileMSDButton);
            this.Controls.Add(this.writeInFileVelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msdTheorTextBox);
            this.Controls.Add(this.msdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faTheorTextBox);
            this.Controls.Add(this.faTextBox);
            this.Controls.Add(this.plotMSDOrSupCoefButton);
            this.Controls.Add(this.plotVelOrFAButton);
            this.Controls.Add(this.msdOrSupCoefLabel);
            this.Controls.Add(this.msdOrSupCoefPictureBox);
            this.Controls.Add(this.velOrFALabel);
            this.Controls.Add(this.velOrFApictureBox);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)(this.velOrFApictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msdOrSupCoefPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox velOrFApictureBox;
        private System.Windows.Forms.Label velOrFALabel;
        private System.Windows.Forms.Label msdOrSupCoefLabel;
        private System.Windows.Forms.PictureBox msdOrSupCoefPictureBox;
        private System.Windows.Forms.Button plotVelOrFAButton;
        private System.Windows.Forms.Button plotMSDOrSupCoefButton;
        private System.Windows.Forms.TextBox faTextBox;
        private System.Windows.Forms.TextBox faTheorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox msdTheorTextBox;
        private System.Windows.Forms.TextBox msdTextBox;
        private System.Windows.Forms.Button writeInFileVelButton;
        private System.Windows.Forms.Button writeInFileMSDButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}