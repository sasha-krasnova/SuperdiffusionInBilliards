namespace SuperdiffusionInBilliards
{
    partial class WaitForm
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
            this.percent = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Location = new System.Drawing.Point(68, 42);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(0, 13);
            this.percent.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 58);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(221, 25);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 106);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.percent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Пожалуйста, подождите";
            this.Load += new System.EventHandler(this.WaitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.ProgressBar progressBar;



    }
}