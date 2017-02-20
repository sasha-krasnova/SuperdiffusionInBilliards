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
            this.VelOrFALabel = new System.Windows.Forms.Label();
            this.MSDOrSupCoefLabel = new System.Windows.Forms.Label();
            this.MSDOrSupCoefPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.velOrFApictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSDOrSupCoefPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // velOrFApictureBox
            // 
            this.velOrFApictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.velOrFApictureBox.Location = new System.Drawing.Point(12, 38);
            this.velOrFApictureBox.Name = "velOrFApictureBox";
            this.velOrFApictureBox.Size = new System.Drawing.Size(331, 195);
            this.velOrFApictureBox.TabIndex = 0;
            this.velOrFApictureBox.TabStop = false;
            // 
            // VelOrFALabel
            // 
            this.VelOrFALabel.AutoSize = true;
            this.VelOrFALabel.Location = new System.Drawing.Point(12, 22);
            this.VelOrFALabel.Name = "VelOrFALabel";
            this.VelOrFALabel.Size = new System.Drawing.Size(35, 13);
            this.VelOrFALabel.TabIndex = 1;
            this.VelOrFALabel.Text = "label1";
            // 
            // MSDOrSupCoefLabel
            // 
            this.MSDOrSupCoefLabel.AutoSize = true;
            this.MSDOrSupCoefLabel.Location = new System.Drawing.Point(15, 248);
            this.MSDOrSupCoefLabel.Name = "MSDOrSupCoefLabel";
            this.MSDOrSupCoefLabel.Size = new System.Drawing.Size(35, 13);
            this.MSDOrSupCoefLabel.TabIndex = 3;
            this.MSDOrSupCoefLabel.Text = "label1";
            // 
            // MSDOrSupCoefPictureBox
            // 
            this.MSDOrSupCoefPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.MSDOrSupCoefPictureBox.Location = new System.Drawing.Point(15, 264);
            this.MSDOrSupCoefPictureBox.Name = "MSDOrSupCoefPictureBox";
            this.MSDOrSupCoefPictureBox.Size = new System.Drawing.Size(331, 195);
            this.MSDOrSupCoefPictureBox.TabIndex = 2;
            this.MSDOrSupCoefPictureBox.TabStop = false;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 471);
            this.Controls.Add(this.MSDOrSupCoefLabel);
            this.Controls.Add(this.MSDOrSupCoefPictureBox);
            this.Controls.Add(this.VelOrFALabel);
            this.Controls.Add(this.velOrFApictureBox);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            ((System.ComponentModel.ISupportInitialize)(this.velOrFApictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSDOrSupCoefPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox velOrFApictureBox;
        private System.Windows.Forms.Label VelOrFALabel;
        private System.Windows.Forms.Label MSDOrSupCoefLabel;
        private System.Windows.Forms.PictureBox MSDOrSupCoefPictureBox;
    }
}