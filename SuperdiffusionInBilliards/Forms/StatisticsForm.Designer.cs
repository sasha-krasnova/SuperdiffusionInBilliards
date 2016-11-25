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
            this.velocityOnTime = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.meanSqareDispOnTime = new System.Windows.Forms.PictureBox();
            this.calculateAcceleration = new System.Windows.Forms.Button();
            this.calculateCoeffisientOfSuperdif = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.velocityOnTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanSqareDispOnTime)).BeginInit();
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
            // velocityOnTime
            // 
            this.velocityOnTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.velocityOnTime.Location = new System.Drawing.Point(12, 29);
            this.velocityOnTime.Name = "velocityOnTime";
            this.velocityOnTime.Size = new System.Drawing.Size(303, 165);
            this.velocityOnTime.TabIndex = 1;
            this.velocityOnTime.TabStop = false;
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
            this.calculateAcceleration.Location = new System.Drawing.Point(347, 29);
            this.calculateAcceleration.Name = "calculateAcceleration";
            this.calculateAcceleration.Size = new System.Drawing.Size(267, 65);
            this.calculateAcceleration.TabIndex = 4;
            this.calculateAcceleration.Text = "Расчитать ускорение Ферми";
            this.calculateAcceleration.UseVisualStyleBackColor = false;
            // 
            // calculateCoeffisientOfSuperdif
            // 
            this.calculateCoeffisientOfSuperdif.BackColor = System.Drawing.Color.SpringGreen;
            this.calculateCoeffisientOfSuperdif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculateCoeffisientOfSuperdif.Location = new System.Drawing.Point(347, 231);
            this.calculateCoeffisientOfSuperdif.Name = "calculateCoeffisientOfSuperdif";
            this.calculateCoeffisientOfSuperdif.Size = new System.Drawing.Size(267, 65);
            this.calculateCoeffisientOfSuperdif.TabIndex = 5;
            this.calculateCoeffisientOfSuperdif.Text = "Расчитать коэффициент супердиффузии";
            this.calculateCoeffisientOfSuperdif.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 136);
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
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 405);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calculateCoeffisientOfSuperdif);
            this.Controls.Add(this.calculateAcceleration);
            this.Controls.Add(this.meanSqareDispOnTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.velocityOnTime);
            this.Controls.Add(this.label1);
            this.Name = "StatisticsForm";
            this.Text = "Статистика движегия частицы";
            ((System.ComponentModel.ISupportInitialize)(this.velocityOnTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanSqareDispOnTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox velocityOnTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox meanSqareDispOnTime;
        private System.Windows.Forms.Button calculateAcceleration;
        private System.Windows.Forms.Button calculateCoeffisientOfSuperdif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}