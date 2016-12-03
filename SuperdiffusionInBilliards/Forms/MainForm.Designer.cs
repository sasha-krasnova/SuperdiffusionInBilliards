namespace SuperdiffusionInBilliards
{
    partial class MainForm
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
            this.typeOfOscillations = new System.Windows.Forms.GroupBox();
            this.stochasticScatterer = new System.Windows.Forms.RadioButton();
            this.harmonicScatterer = new System.Windows.Forms.RadioButton();
            this.lattice = new System.Windows.Forms.GroupBox();
            this.randomScene = new System.Windows.Forms.RadioButton();
            this.triangularScene = new System.Windows.Forms.RadioButton();
            this.squareScene = new System.Windows.Forms.RadioButton();
            this.initialVelocity = new System.Windows.Forms.TextBox();
            this.amplitudeOfScattererVelocity = new System.Windows.Forms.TextBox();
            this.periodOfScattererOsc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.averageRadius = new System.Windows.Forms.TextBox();
            this.averageRadiusOfCentralSc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.latticeSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fullTime = new System.Windows.Forms.TextBox();
            this.deltaTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numberOfRealisations = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statistics = new System.Windows.Forms.Button();
            this.leastSquares = new System.Windows.Forms.Button();
            this.averagingForm = new System.Windows.Forms.Button();
            this.typeOfOscillations.SuspendLayout();
            this.lattice.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfOscillations
            // 
            this.typeOfOscillations.Controls.Add(this.stochasticScatterer);
            this.typeOfOscillations.Controls.Add(this.harmonicScatterer);
            this.typeOfOscillations.Location = new System.Drawing.Point(12, 12);
            this.typeOfOscillations.Name = "typeOfOscillations";
            this.typeOfOscillations.Size = new System.Drawing.Size(268, 78);
            this.typeOfOscillations.TabIndex = 0;
            this.typeOfOscillations.TabStop = false;
            this.typeOfOscillations.Text = "Тип колебаний скорости стенки рассеивателей";
            // 
            // stochasticScatterer
            // 
            this.stochasticScatterer.AutoSize = true;
            this.stochasticScatterer.Enabled = false;
            this.stochasticScatterer.Location = new System.Drawing.Point(23, 19);
            this.stochasticScatterer.Name = "stochasticScatterer";
            this.stochasticScatterer.Size = new System.Drawing.Size(80, 17);
            this.stochasticScatterer.TabIndex = 1;
            this.stochasticScatterer.Text = "Случайные";
            this.stochasticScatterer.UseVisualStyleBackColor = true;
            // 
            // harmonicScatterer
            // 
            this.harmonicScatterer.AutoSize = true;
            this.harmonicScatterer.Checked = true;
            this.harmonicScatterer.Location = new System.Drawing.Point(23, 42);
            this.harmonicScatterer.Name = "harmonicScatterer";
            this.harmonicScatterer.Size = new System.Drawing.Size(104, 17);
            this.harmonicScatterer.TabIndex = 0;
            this.harmonicScatterer.TabStop = true;
            this.harmonicScatterer.Text = "Гармонические";
            this.harmonicScatterer.UseVisualStyleBackColor = true;
            // 
            // lattice
            // 
            this.lattice.Controls.Add(this.randomScene);
            this.lattice.Controls.Add(this.triangularScene);
            this.lattice.Controls.Add(this.squareScene);
            this.lattice.Location = new System.Drawing.Point(12, 96);
            this.lattice.Name = "lattice";
            this.lattice.Size = new System.Drawing.Size(268, 96);
            this.lattice.TabIndex = 1;
            this.lattice.TabStop = false;
            this.lattice.Text = "Тип решетки";
            // 
            // randomScene
            // 
            this.randomScene.AutoSize = true;
            this.randomScene.Enabled = false;
            this.randomScene.Location = new System.Drawing.Point(23, 19);
            this.randomScene.Name = "randomScene";
            this.randomScene.Size = new System.Drawing.Size(78, 17);
            this.randomScene.TabIndex = 2;
            this.randomScene.Text = "Случайная";
            this.randomScene.UseVisualStyleBackColor = true;
            // 
            // triangularScene
            // 
            this.triangularScene.AutoSize = true;
            this.triangularScene.Enabled = false;
            this.triangularScene.Location = new System.Drawing.Point(23, 65);
            this.triangularScene.Name = "triangularScene";
            this.triangularScene.Size = new System.Drawing.Size(90, 17);
            this.triangularScene.TabIndex = 1;
            this.triangularScene.Text = "Треугольная";
            this.triangularScene.UseVisualStyleBackColor = true;
            this.triangularScene.CheckedChanged += new System.EventHandler(this.triangularScene_CheckedChanged);
            // 
            // squareScene
            // 
            this.squareScene.AutoSize = true;
            this.squareScene.Checked = true;
            this.squareScene.Location = new System.Drawing.Point(23, 42);
            this.squareScene.Name = "squareScene";
            this.squareScene.Size = new System.Drawing.Size(85, 17);
            this.squareScene.TabIndex = 0;
            this.squareScene.TabStop = true;
            this.squareScene.Text = "Квадратная";
            this.squareScene.UseVisualStyleBackColor = true;
            this.squareScene.CheckedChanged += new System.EventHandler(this.squareScene_CheckedChanged);
            // 
            // initialVelocity
            // 
            this.initialVelocity.Location = new System.Drawing.Point(679, 23);
            this.initialVelocity.Name = "initialVelocity";
            this.initialVelocity.Size = new System.Drawing.Size(100, 20);
            this.initialVelocity.TabIndex = 2;
            this.initialVelocity.Text = "10";
            this.initialVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amplitudeOfScattererVelocity
            // 
            this.amplitudeOfScattererVelocity.Location = new System.Drawing.Point(679, 48);
            this.amplitudeOfScattererVelocity.Name = "amplitudeOfScattererVelocity";
            this.amplitudeOfScattererVelocity.Size = new System.Drawing.Size(100, 20);
            this.amplitudeOfScattererVelocity.TabIndex = 3;
            this.amplitudeOfScattererVelocity.Text = "0,2";
            this.amplitudeOfScattererVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // periodOfScattererOsc
            // 
            this.periodOfScattererOsc.Location = new System.Drawing.Point(679, 74);
            this.periodOfScattererOsc.Name = "periodOfScattererOsc";
            this.periodOfScattererOsc.Size = new System.Drawing.Size(100, 20);
            this.periodOfScattererOsc.TabIndex = 4;
            this.periodOfScattererOsc.Text = "20";
            this.periodOfScattererOsc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Начальная скорость частицы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Амплитуда колебаний скорости рассеивателей";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(383, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Период колебаний стенки рассеивателей (для периодических колебаний)";
            // 
            // averageRadius
            // 
            this.averageRadius.Location = new System.Drawing.Point(679, 100);
            this.averageRadius.Name = "averageRadius";
            this.averageRadius.Size = new System.Drawing.Size(100, 20);
            this.averageRadius.TabIndex = 8;
            this.averageRadius.Text = "9";
            this.averageRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // averageRadiusOfCentralSc
            // 
            this.averageRadiusOfCentralSc.Location = new System.Drawing.Point(679, 126);
            this.averageRadiusOfCentralSc.Name = "averageRadiusOfCentralSc";
            this.averageRadiusOfCentralSc.Size = new System.Drawing.Size(100, 20);
            this.averageRadiusOfCentralSc.TabIndex = 9;
            this.averageRadiusOfCentralSc.Text = "3";
            this.averageRadiusOfCentralSc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Средний радиус рассеивателей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Средний радиус центрального рассеивателя (для квадратной решетки)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(418, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(356, 58);
            this.button1.TabIndex = 12;
            this.button1.Text = "Старт с графикой";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // latticeSize
            // 
            this.latticeSize.Location = new System.Drawing.Point(679, 152);
            this.latticeSize.Name = "latticeSize";
            this.latticeSize.Size = new System.Drawing.Size(100, 20);
            this.latticeSize.TabIndex = 13;
            this.latticeSize.Text = "20";
            this.latticeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Размер решетки (для периодической решетки)";
            // 
            // fullTime
            // 
            this.fullTime.Location = new System.Drawing.Point(679, 178);
            this.fullTime.Name = "fullTime";
            this.fullTime.Size = new System.Drawing.Size(100, 20);
            this.fullTime.TabIndex = 15;
            this.fullTime.Text = "100";
            this.fullTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // deltaTime
            // 
            this.deltaTime.Location = new System.Drawing.Point(679, 204);
            this.deltaTime.Name = "deltaTime";
            this.deltaTime.Size = new System.Drawing.Size(100, 20);
            this.deltaTime.TabIndex = 16;
            this.deltaTime.Text = "20";
            this.deltaTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Время эксперимента";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Время между точками на графике";
            // 
            // numberOfRealisations
            // 
            this.numberOfRealisations.Location = new System.Drawing.Point(679, 230);
            this.numberOfRealisations.Name = "numberOfRealisations";
            this.numberOfRealisations.Size = new System.Drawing.Size(100, 20);
            this.numberOfRealisations.TabIndex = 19;
            this.numberOfRealisations.Text = "10";
            this.numberOfRealisations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Количество реализаций";
            // 
            // statistics
            // 
            this.statistics.BackColor = System.Drawing.Color.Red;
            this.statistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statistics.Location = new System.Drawing.Point(17, 300);
            this.statistics.Name = "statistics";
            this.statistics.Size = new System.Drawing.Size(356, 58);
            this.statistics.TabIndex = 21;
            this.statistics.Text = "Расчитать статистику";
            this.statistics.UseVisualStyleBackColor = false;
            this.statistics.Click += new System.EventHandler(this.statistics_Click);
            // 
            // leastSquares
            // 
            this.leastSquares.Location = new System.Drawing.Point(17, 226);
            this.leastSquares.Name = "leastSquares";
            this.leastSquares.Size = new System.Drawing.Size(224, 32);
            this.leastSquares.TabIndex = 22;
            this.leastSquares.Text = "Проверка МНК";
            this.leastSquares.UseVisualStyleBackColor = true;
            this.leastSquares.Click += new System.EventHandler(this.leastSquares_Click);
            // 
            // averagingForm
            // 
            this.averagingForm.Location = new System.Drawing.Point(259, 226);
            this.averagingForm.Name = "averagingForm";
            this.averagingForm.Size = new System.Drawing.Size(224, 32);
            this.averagingForm.TabIndex = 23;
            this.averagingForm.Text = "Проверка усреднения";
            this.averagingForm.UseVisualStyleBackColor = true;
            this.averagingForm.Click += new System.EventHandler(this.averagingForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 370);
            this.Controls.Add(this.averagingForm);
            this.Controls.Add(this.leastSquares);
            this.Controls.Add(this.statistics);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numberOfRealisations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deltaTime);
            this.Controls.Add(this.fullTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.latticeSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.averageRadiusOfCentralSc);
            this.Controls.Add(this.averageRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.periodOfScattererOsc);
            this.Controls.Add(this.amplitudeOfScattererVelocity);
            this.Controls.Add(this.initialVelocity);
            this.Controls.Add(this.lattice);
            this.Controls.Add(this.typeOfOscillations);
            this.Name = "MainForm";
            this.Text = "Супердиффузия в бильярдах";
            this.typeOfOscillations.ResumeLayout(false);
            this.typeOfOscillations.PerformLayout();
            this.lattice.ResumeLayout(false);
            this.lattice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox typeOfOscillations;
        private System.Windows.Forms.RadioButton stochasticScatterer;
        private System.Windows.Forms.RadioButton harmonicScatterer;
        private System.Windows.Forms.GroupBox lattice;
        private System.Windows.Forms.RadioButton triangularScene;
        private System.Windows.Forms.RadioButton squareScene;
        private System.Windows.Forms.RadioButton randomScene;
        private System.Windows.Forms.TextBox initialVelocity;
        private System.Windows.Forms.TextBox amplitudeOfScattererVelocity;
        private System.Windows.Forms.TextBox periodOfScattererOsc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox averageRadius;
        private System.Windows.Forms.TextBox averageRadiusOfCentralSc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox latticeSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fullTime;
        private System.Windows.Forms.TextBox deltaTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numberOfRealisations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button statistics;
        private System.Windows.Forms.Button leastSquares;
        private System.Windows.Forms.Button averagingForm;
    }
}

