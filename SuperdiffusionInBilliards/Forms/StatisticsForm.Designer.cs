﻿namespace SuperdiffusionInBilliards
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
            this.koefficientOfSuperdif = new System.Windows.Forms.TextBox();
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
            this.label2.Location = new System.Drawing.Point(9, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Зависимость среднеквадратичного отклонения от времени";
            // 
            // meanSqareDispOnTime
            // 
            this.meanSqareDispOnTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.meanSqareDispOnTime.Location = new System.Drawing.Point(12, 231);
            this.meanSqareDispOnTime.Name = "meanSqareDispOnTime";
            this.meanSqareDispOnTime.Size = new System.Drawing.Size(303, 159);
            this.meanSqareDispOnTime.TabIndex = 3;
            this.meanSqareDispOnTime.TabStop = false;
            // 
            // calculateAcceleration
            // 
            this.calculateAcceleration.BackColor = System.Drawing.Color.SpringGreen;
            this.calculateAcceleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateAcceleration.Location = new System.Drawing.Point(403, 29);
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
            this.calculateCoeffisientOfSuperdif.Location = new System.Drawing.Point(403, 231);
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
            this.label3.Location = new System.Drawing.Point(401, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ускорение Ферми =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 332);
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
            this.averVelOnTime.Size = new System.Drawing.Size(303, 162);
            this.averVelOnTime.TabIndex = 9;
            this.averVelOnTime.TabStop = false;
            // 
            // fermiAcceleration
            // 
            this.fermiAcceleration.Location = new System.Drawing.Point(519, 136);
            this.fermiAcceleration.Name = "fermiAcceleration";
            this.fermiAcceleration.Size = new System.Drawing.Size(151, 20);
            this.fermiAcceleration.TabIndex = 13;
            // 
            // koefficientOfSuperdif
            // 
            this.koefficientOfSuperdif.Location = new System.Drawing.Point(519, 329);
            this.koefficientOfSuperdif.Name = "koefficientOfSuperdif";
            this.koefficientOfSuperdif.Size = new System.Drawing.Size(151, 20);
            this.koefficientOfSuperdif.TabIndex = 14;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 405);
            this.Controls.Add(this.koefficientOfSuperdif);
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
            this.Text = "Статистика движегия частицы";
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
        private System.Windows.Forms.TextBox koefficientOfSuperdif;
    }
}