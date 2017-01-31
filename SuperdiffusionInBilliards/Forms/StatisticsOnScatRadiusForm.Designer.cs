namespace SuperdiffusionInBilliards
{
    partial class StatisticsOnScatRadiusForm
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
            this.buttonFermiAcc = new System.Windows.Forms.Button();
            this.buttonPlotGraphs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxSuperdifCoef = new System.Windows.Forms.PictureBox();
            this.pictureBoxFermiAcc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuperdifCoef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFermiAcc)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFermiAcc
            // 
            this.buttonFermiAcc.Location = new System.Drawing.Point(455, 151);
            this.buttonFermiAcc.Name = "buttonFermiAcc";
            this.buttonFermiAcc.Size = new System.Drawing.Size(184, 51);
            this.buttonFermiAcc.TabIndex = 11;
            this.buttonFermiAcc.Text = "Записать в файл";
            this.buttonFermiAcc.UseVisualStyleBackColor = true;
            // 
            // buttonPlotGraphs
            // 
            this.buttonPlotGraphs.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonPlotGraphs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonPlotGraphs.Location = new System.Drawing.Point(455, 35);
            this.buttonPlotGraphs.Name = "buttonPlotGraphs";
            this.buttonPlotGraphs.Size = new System.Drawing.Size(184, 51);
            this.buttonPlotGraphs.TabIndex = 10;
            this.buttonPlotGraphs.Text = "Построить графики и расчитать теорию";
            this.buttonPlotGraphs.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Коэффициент супердиффузии от радиуса рассеивателей";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ускорение Ферми от радиуса рассеивателей";
            // 
            // pictureBoxSuperdifCoef
            // 
            this.pictureBoxSuperdifCoef.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxSuperdifCoef.Location = new System.Drawing.Point(12, 263);
            this.pictureBoxSuperdifCoef.Name = "pictureBoxSuperdifCoef";
            this.pictureBoxSuperdifCoef.Size = new System.Drawing.Size(381, 178);
            this.pictureBoxSuperdifCoef.TabIndex = 9;
            this.pictureBoxSuperdifCoef.TabStop = false;
            // 
            // pictureBoxFermiAcc
            // 
            this.pictureBoxFermiAcc.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxFermiAcc.Location = new System.Drawing.Point(12, 35);
            this.pictureBoxFermiAcc.Name = "pictureBoxFermiAcc";
            this.pictureBoxFermiAcc.Size = new System.Drawing.Size(381, 178);
            this.pictureBoxFermiAcc.TabIndex = 6;
            this.pictureBoxFermiAcc.TabStop = false;
            // 
            // StatisticsOnScatRadiusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 455);
            this.Controls.Add(this.buttonFermiAcc);
            this.Controls.Add(this.buttonPlotGraphs);
            this.Controls.Add(this.pictureBoxSuperdifCoef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxFermiAcc);
            this.Name = "StatisticsOnScatRadiusForm";
            this.Text = "StatisticsOnScatRadiusForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSuperdifCoef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFermiAcc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFermiAcc;
        private System.Windows.Forms.Button buttonPlotGraphs;
        private System.Windows.Forms.PictureBox pictureBoxSuperdifCoef;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxFermiAcc;
    }
}