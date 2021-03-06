﻿namespace SuperdiffusionInBilliards
{
    partial class StatisticsOnScatVelForm
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
            this.buttonPlotGraphs = new System.Windows.Forms.Button();
            this.buttonFermiAcc = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBoxSuperdifCoef = new System.Windows.Forms.PictureBox();
            this.pictureBoxFermiAcc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuperdifCoef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFermiAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ускорение Ферми от квадрата амплитуды скорости рассеивателя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Коэффициент супердиффузии от квадрата амплитуды скорости рассеивателя";
            // 
            // buttonPlotGraphs
            // 
            this.buttonPlotGraphs.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonPlotGraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonPlotGraphs.Location = new System.Drawing.Point(459, 40);
            this.buttonPlotGraphs.Name = "buttonPlotGraphs";
            this.buttonPlotGraphs.Size = new System.Drawing.Size(184, 51);
            this.buttonPlotGraphs.TabIndex = 4;
            this.buttonPlotGraphs.Text = "Построить графики и расчитать теорию";
            this.buttonPlotGraphs.UseVisualStyleBackColor = false;
            this.buttonPlotGraphs.Click += new System.EventHandler(this.buttonPlotGraphs_Click);
            // 
            // buttonFermiAcc
            // 
            this.buttonFermiAcc.Location = new System.Drawing.Point(459, 156);
            this.buttonFermiAcc.Name = "buttonFermiAcc";
            this.buttonFermiAcc.Size = new System.Drawing.Size(184, 51);
            this.buttonFermiAcc.TabIndex = 5;
            this.buttonFermiAcc.Text = "Записать в файл";
            this.buttonFermiAcc.UseVisualStyleBackColor = true;
            this.buttonFermiAcc.Click += new System.EventHandler(this.buttonFermiAcc_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Таблицы | *.csv";
            // 
            // pictureBoxSuperdifCoef
            // 
            this.pictureBoxSuperdifCoef.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxSuperdifCoef.Location = new System.Drawing.Point(16, 268);
            this.pictureBoxSuperdifCoef.Name = "pictureBoxSuperdifCoef";
            this.pictureBoxSuperdifCoef.Size = new System.Drawing.Size(381, 178);
            this.pictureBoxSuperdifCoef.TabIndex = 3;
            this.pictureBoxSuperdifCoef.TabStop = false;
            // 
            // pictureBoxFermiAcc
            // 
            this.pictureBoxFermiAcc.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxFermiAcc.Location = new System.Drawing.Point(16, 40);
            this.pictureBoxFermiAcc.Name = "pictureBoxFermiAcc";
            this.pictureBoxFermiAcc.Size = new System.Drawing.Size(381, 178);
            this.pictureBoxFermiAcc.TabIndex = 0;
            this.pictureBoxFermiAcc.TabStop = false;
            // 
            // StatisticsOnScatVelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 489);
            this.Controls.Add(this.buttonFermiAcc);
            this.Controls.Add(this.buttonPlotGraphs);
            this.Controls.Add(this.pictureBoxSuperdifCoef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxFermiAcc);
            this.Name = "StatisticsOnScatVelForm";
            this.Text = "DependenceOnAmpOfScVelForm";
            this.Load += new System.EventHandler(this.StatisticsOnScatVelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuperdifCoef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFermiAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFermiAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxSuperdifCoef;
        private System.Windows.Forms.Button buttonPlotGraphs;
        private System.Windows.Forms.Button buttonFermiAcc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}