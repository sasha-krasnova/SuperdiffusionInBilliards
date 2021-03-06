﻿namespace SuperdiffusionInBilliards
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
            this.randomScatterer = new System.Windows.Forms.RadioButton();
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
            this.startWithGraphics = new System.Windows.Forms.Button();
            this.latticeSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fullTime = new System.Windows.Forms.TextBox();
            this.deltaTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numberOfRealisations = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statisticsOnPeriod = new System.Windows.Forms.RadioButton();
            this.statisticsOnScatRadius = new System.Windows.Forms.RadioButton();
            this.statisticsOnScatVel = new System.Windows.Forms.RadioButton();
            this.staticticsStandart = new System.Windows.Forms.RadioButton();
            this.textBoxInitAmp = new System.Windows.Forms.TextBox();
            this.textBoxStepAmp = new System.Windows.Forms.TextBox();
            this.textBoxNumPointsAmp = new System.Windows.Forms.TextBox();
            this.textBoxInitRadius = new System.Windows.Forms.TextBox();
            this.textBoxStepRadius = new System.Windows.Forms.TextBox();
            this.textBoxNumPointsRadius = new System.Windows.Forms.TextBox();
            this.textBoxInitPeriod = new System.Windows.Forms.TextBox();
            this.textBoxStepPeriod = new System.Windows.Forms.TextBox();
            this.textBoxNumPointsPeriod = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.scattererConcentrationTextBox = new System.Windows.Forms.TextBox();
            this.GetStatisticsButton = new System.Windows.Forms.Button();
            this.typeOfOscillations.SuspendLayout();
            this.lattice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeOfOscillations
            // 
            this.typeOfOscillations.Controls.Add(this.randomScatterer);
            this.typeOfOscillations.Controls.Add(this.harmonicScatterer);
            this.typeOfOscillations.Location = new System.Drawing.Point(12, 12);
            this.typeOfOscillations.Name = "typeOfOscillations";
            this.typeOfOscillations.Size = new System.Drawing.Size(268, 78);
            this.typeOfOscillations.TabIndex = 0;
            this.typeOfOscillations.TabStop = false;
            this.typeOfOscillations.Text = "Тип колебаний скорости стенки рассеивателей";
            // 
            // randomScatterer
            // 
            this.randomScatterer.AutoSize = true;
            this.randomScatterer.Location = new System.Drawing.Point(23, 42);
            this.randomScatterer.Name = "randomScatterer";
            this.randomScatterer.Size = new System.Drawing.Size(80, 17);
            this.randomScatterer.TabIndex = 1;
            this.randomScatterer.Text = "Случайные";
            this.randomScatterer.UseVisualStyleBackColor = true;
            // 
            // harmonicScatterer
            // 
            this.harmonicScatterer.AutoSize = true;
            this.harmonicScatterer.Checked = true;
            this.harmonicScatterer.Location = new System.Drawing.Point(23, 19);
            this.harmonicScatterer.Name = "harmonicScatterer";
            this.harmonicScatterer.Size = new System.Drawing.Size(104, 17);
            this.harmonicScatterer.TabIndex = 0;
            this.harmonicScatterer.TabStop = true;
            this.harmonicScatterer.Text = "Гармонические";
            this.harmonicScatterer.UseVisualStyleBackColor = true;
            this.harmonicScatterer.CheckedChanged += new System.EventHandler(this.harmonicScatterer_CheckedChanged);
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
            this.randomScene.Location = new System.Drawing.Point(23, 19);
            this.randomScene.Name = "randomScene";
            this.randomScene.Size = new System.Drawing.Size(78, 17);
            this.randomScene.TabIndex = 2;
            this.randomScene.Text = "Случайная";
            this.randomScene.UseVisualStyleBackColor = true;
            this.randomScene.CheckedChanged += new System.EventHandler(this.randomScene_CheckedChanged);
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
            this.averageRadius.Text = "9,2";
            this.averageRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // averageRadiusOfCentralSc
            // 
            this.averageRadiusOfCentralSc.Location = new System.Drawing.Point(679, 126);
            this.averageRadiusOfCentralSc.Name = "averageRadiusOfCentralSc";
            this.averageRadiusOfCentralSc.Size = new System.Drawing.Size(100, 20);
            this.averageRadiusOfCentralSc.TabIndex = 9;
            this.averageRadiusOfCentralSc.Text = "1";
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
            // startWithGraphics
            // 
            this.startWithGraphics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.startWithGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.startWithGraphics.Location = new System.Drawing.Point(833, 295);
            this.startWithGraphics.Name = "startWithGraphics";
            this.startWithGraphics.Size = new System.Drawing.Size(356, 58);
            this.startWithGraphics.TabIndex = 12;
            this.startWithGraphics.Text = "Старт с графикой";
            this.startWithGraphics.UseVisualStyleBackColor = false;
            this.startWithGraphics.Click += new System.EventHandler(this.startWithGraphics_Click_1);
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
            this.fullTime.Text = "5000";
            this.fullTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // deltaTime
            // 
            this.deltaTime.Location = new System.Drawing.Point(679, 204);
            this.deltaTime.Name = "deltaTime";
            this.deltaTime.Size = new System.Drawing.Size(100, 20);
            this.deltaTime.TabIndex = 16;
            this.deltaTime.Text = "500";
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
            this.numberOfRealisations.Text = "50";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statisticsOnPeriod);
            this.groupBox1.Controls.Add(this.statisticsOnScatRadius);
            this.groupBox1.Controls.Add(this.statisticsOnScatVel);
            this.groupBox1.Controls.Add(this.staticticsStandart);
            this.groupBox1.Location = new System.Drawing.Point(12, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 137);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип статистики";
            // 
            // statisticsOnPeriod
            // 
            this.statisticsOnPeriod.AutoSize = true;
            this.statisticsOnPeriod.Location = new System.Drawing.Point(23, 91);
            this.statisticsOnPeriod.Name = "statisticsOnPeriod";
            this.statisticsOnPeriod.Size = new System.Drawing.Size(209, 17);
            this.statisticsOnPeriod.TabIndex = 3;
            this.statisticsOnPeriod.Text = "Зависимость от периода колебаний";
            this.statisticsOnPeriod.UseVisualStyleBackColor = true;
            this.statisticsOnPeriod.CheckedChanged += new System.EventHandler(this.statisticsOnPeriod_CheckedChanged);
            // 
            // statisticsOnScatRadius
            // 
            this.statisticsOnScatRadius.AutoSize = true;
            this.statisticsOnScatRadius.Location = new System.Drawing.Point(23, 67);
            this.statisticsOnScatRadius.Name = "statisticsOnScatRadius";
            this.statisticsOnScatRadius.Size = new System.Drawing.Size(231, 17);
            this.statisticsOnScatRadius.TabIndex = 2;
            this.statisticsOnScatRadius.Text = "Зависимость от радиуса рассеивателей";
            this.statisticsOnScatRadius.UseVisualStyleBackColor = true;
            this.statisticsOnScatRadius.CheckedChanged += new System.EventHandler(this.statisticsOnScatRadius_CheckedChanged);
            // 
            // statisticsOnScatVel
            // 
            this.statisticsOnScatVel.AutoSize = true;
            this.statisticsOnScatVel.Location = new System.Drawing.Point(23, 43);
            this.statisticsOnScatVel.Name = "statisticsOnScatVel";
            this.statisticsOnScatVel.Size = new System.Drawing.Size(231, 17);
            this.statisticsOnScatVel.TabIndex = 1;
            this.statisticsOnScatVel.TabStop = true;
            this.statisticsOnScatVel.Text = "Зависимость от скорости рассеивателя";
            this.statisticsOnScatVel.UseVisualStyleBackColor = true;
            this.statisticsOnScatVel.CheckedChanged += new System.EventHandler(this.statisticsOnScatVel_CheckedChanged);
            // 
            // staticticsStandart
            // 
            this.staticticsStandart.AutoSize = true;
            this.staticticsStandart.Checked = true;
            this.staticticsStandart.Location = new System.Drawing.Point(23, 19);
            this.staticticsStandart.Name = "staticticsStandart";
            this.staticticsStandart.Size = new System.Drawing.Size(90, 17);
            this.staticticsStandart.TabIndex = 0;
            this.staticticsStandart.TabStop = true;
            this.staticticsStandart.Text = "Стандартная";
            this.staticticsStandart.UseVisualStyleBackColor = true;
            this.staticticsStandart.CheckedChanged += new System.EventHandler(this.staticticsStandart_CheckedChanged);
            // 
            // textBoxInitAmp
            // 
            this.textBoxInitAmp.Enabled = false;
            this.textBoxInitAmp.Location = new System.Drawing.Point(1126, 24);
            this.textBoxInitAmp.Name = "textBoxInitAmp";
            this.textBoxInitAmp.Size = new System.Drawing.Size(100, 20);
            this.textBoxInitAmp.TabIndex = 25;
            this.textBoxInitAmp.Text = "0,01";
            this.textBoxInitAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxStepAmp
            // 
            this.textBoxStepAmp.Enabled = false;
            this.textBoxStepAmp.Location = new System.Drawing.Point(1127, 50);
            this.textBoxStepAmp.Name = "textBoxStepAmp";
            this.textBoxStepAmp.Size = new System.Drawing.Size(100, 20);
            this.textBoxStepAmp.TabIndex = 26;
            this.textBoxStepAmp.Text = "0,02";
            this.textBoxStepAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxNumPointsAmp
            // 
            this.textBoxNumPointsAmp.Enabled = false;
            this.textBoxNumPointsAmp.Location = new System.Drawing.Point(1127, 76);
            this.textBoxNumPointsAmp.Name = "textBoxNumPointsAmp";
            this.textBoxNumPointsAmp.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumPointsAmp.TabIndex = 27;
            this.textBoxNumPointsAmp.Text = "12";
            this.textBoxNumPointsAmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxInitRadius
            // 
            this.textBoxInitRadius.Enabled = false;
            this.textBoxInitRadius.Location = new System.Drawing.Point(1127, 112);
            this.textBoxInitRadius.Name = "textBoxInitRadius";
            this.textBoxInitRadius.Size = new System.Drawing.Size(100, 20);
            this.textBoxInitRadius.TabIndex = 28;
            this.textBoxInitRadius.Text = "6";
            this.textBoxInitRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxStepRadius
            // 
            this.textBoxStepRadius.Enabled = false;
            this.textBoxStepRadius.Location = new System.Drawing.Point(1128, 138);
            this.textBoxStepRadius.Name = "textBoxStepRadius";
            this.textBoxStepRadius.Size = new System.Drawing.Size(100, 20);
            this.textBoxStepRadius.TabIndex = 29;
            this.textBoxStepRadius.Text = "0,5";
            this.textBoxStepRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxNumPointsRadius
            // 
            this.textBoxNumPointsRadius.Enabled = false;
            this.textBoxNumPointsRadius.Location = new System.Drawing.Point(1128, 164);
            this.textBoxNumPointsRadius.Name = "textBoxNumPointsRadius";
            this.textBoxNumPointsRadius.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumPointsRadius.TabIndex = 30;
            this.textBoxNumPointsRadius.Text = "7";
            this.textBoxNumPointsRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxInitPeriod
            // 
            this.textBoxInitPeriod.Enabled = false;
            this.textBoxInitPeriod.Location = new System.Drawing.Point(1128, 204);
            this.textBoxInitPeriod.Name = "textBoxInitPeriod";
            this.textBoxInitPeriod.Size = new System.Drawing.Size(100, 20);
            this.textBoxInitPeriod.TabIndex = 31;
            this.textBoxInitPeriod.Text = "10";
            this.textBoxInitPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxStepPeriod
            // 
            this.textBoxStepPeriod.Enabled = false;
            this.textBoxStepPeriod.Location = new System.Drawing.Point(1127, 230);
            this.textBoxStepPeriod.Name = "textBoxStepPeriod";
            this.textBoxStepPeriod.Size = new System.Drawing.Size(100, 20);
            this.textBoxStepPeriod.TabIndex = 32;
            this.textBoxStepPeriod.Text = "2";
            this.textBoxStepPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxNumPointsPeriod
            // 
            this.textBoxNumPointsPeriod.Enabled = false;
            this.textBoxNumPointsPeriod.Location = new System.Drawing.Point(1127, 256);
            this.textBoxNumPointsPeriod.Name = "textBoxNumPointsPeriod";
            this.textBoxNumPointsPeriod.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumPointsPeriod.TabIndex = 33;
            this.textBoxNumPointsPeriod.Text = "6";
            this.textBoxNumPointsPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(820, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(300, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Начальная амплитуда колебаний скорости рассеивателя";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(972, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Шаг по амплитуде скорости";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1024, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Количество точек";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(901, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Начальный средний радиус рассеивателя";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(984, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Шаг по среднему радиусу";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1025, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Количество точек";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(887, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(234, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Начальный период колебаний рассеивателя";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(979, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Шаг по периоду колебаний";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1024, 259);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 42;
            this.label18.Text = "Количество точек";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(510, 259);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(159, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Концентрация рассеивателей";
            // 
            // scattererConcentrationTextBox
            // 
            this.scattererConcentrationTextBox.Enabled = false;
            this.scattererConcentrationTextBox.Location = new System.Drawing.Point(679, 256);
            this.scattererConcentrationTextBox.Name = "scattererConcentrationTextBox";
            this.scattererConcentrationTextBox.Size = new System.Drawing.Size(100, 20);
            this.scattererConcentrationTextBox.TabIndex = 45;
            this.scattererConcentrationTextBox.Text = "0,001";
            this.scattererConcentrationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GetStatisticsButton
            // 
            this.GetStatisticsButton.BackColor = System.Drawing.Color.Red;
            this.GetStatisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GetStatisticsButton.Location = new System.Drawing.Point(377, 295);
            this.GetStatisticsButton.Name = "GetStatisticsButton";
            this.GetStatisticsButton.Size = new System.Drawing.Size(356, 58);
            this.GetStatisticsButton.TabIndex = 46;
            this.GetStatisticsButton.Text = "Рассчитать статистику";
            this.GetStatisticsButton.UseVisualStyleBackColor = false;
            this.GetStatisticsButton.Click += new System.EventHandler(this.GetStatisticsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 372);
            this.Controls.Add(this.GetStatisticsButton);
            this.Controls.Add(this.scattererConcentrationTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxNumPointsPeriod);
            this.Controls.Add(this.textBoxStepPeriod);
            this.Controls.Add(this.textBoxInitPeriod);
            this.Controls.Add(this.textBoxNumPointsRadius);
            this.Controls.Add(this.textBoxStepRadius);
            this.Controls.Add(this.textBoxInitRadius);
            this.Controls.Add(this.textBoxNumPointsAmp);
            this.Controls.Add(this.textBoxStepAmp);
            this.Controls.Add(this.textBoxInitAmp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numberOfRealisations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deltaTime);
            this.Controls.Add(this.fullTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.latticeSize);
            this.Controls.Add(this.startWithGraphics);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox typeOfOscillations;
        private System.Windows.Forms.RadioButton randomScatterer;
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
        private System.Windows.Forms.Button startWithGraphics;
        private System.Windows.Forms.TextBox latticeSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fullTime;
        private System.Windows.Forms.TextBox deltaTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numberOfRealisations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton statisticsOnScatRadius;
        private System.Windows.Forms.RadioButton statisticsOnScatVel;
        private System.Windows.Forms.RadioButton staticticsStandart;
        private System.Windows.Forms.RadioButton statisticsOnPeriod;
        private System.Windows.Forms.TextBox textBoxInitAmp;
        private System.Windows.Forms.TextBox textBoxStepAmp;
        private System.Windows.Forms.TextBox textBoxNumPointsAmp;
        private System.Windows.Forms.TextBox textBoxInitRadius;
        private System.Windows.Forms.TextBox textBoxStepRadius;
        private System.Windows.Forms.TextBox textBoxNumPointsRadius;
        private System.Windows.Forms.TextBox textBoxInitPeriod;
        private System.Windows.Forms.TextBox textBoxStepPeriod;
        private System.Windows.Forms.TextBox textBoxNumPointsPeriod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox scattererConcentrationTextBox;
        private System.Windows.Forms.Button GetStatisticsButton;
    }
}

