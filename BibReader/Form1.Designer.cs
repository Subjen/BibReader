﻿namespace BibReader
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.tbSourсe = new System.Windows.Forms.TextBox();
            this.tbKeywords = new System.Windows.Forms.TextBox();
            this.tbAffiliation = new System.Windows.Forms.TextBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tbDoi = new System.Windows.Forms.TextBox();
            this.tbPages = new System.Windows.Forms.TextBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbPublisher = new System.Windows.Forms.TextBox();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbJournalName = new System.Windows.Forms.TextBox();
            this.tbAbstract = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbAuthors = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbSourse = new System.Windows.Forms.Label();
            this.lbPublisher = new System.Windows.Forms.Label();
            this.lbKeywords = new System.Windows.Forms.Label();
            this.lbAbstract = new System.Windows.Forms.Label();
            this.lbAffiliation = new System.Windows.Forms.Label();
            this.lbUrl = new System.Windows.Forms.Label();
            this.lbDoi = new System.Windows.Forms.Label();
            this.lbPage = new System.Windows.Forms.Label();
            this.lbVolume = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.lbJournalName = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbAuthors = new System.Windows.Forms.Label();
            this.tpBib = new System.Windows.Forms.TabPage();
            this.rtbBib = new System.Windows.Forms.RichTextBox();
            this.tpYearStatistic = new System.Windows.Forms.TabPage();
            this.lvYearStatistic = new System.Windows.Forms.ListView();
            this.tpSourceStatistic = new System.Windows.Forms.TabPage();
            this.lvSourceStatistic = new System.Windows.Forms.ListView();
            this.lvItems = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCurrSelectedItem = new System.Windows.Forms.Label();
            this.btFirst = new System.Windows.Forms.Button();
            this.btUnique = new System.Windows.Forms.Button();
            this.btRelevance = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpData.SuspendLayout();
            this.tpBib.SuspendLayout();
            this.tpYearStatistic.SuspendLayout();
            this.tpSourceStatistic.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Location = new System.Drawing.Point(848, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 723);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tpData);
            this.tabControl.Controls.Add(this.tpBib);
            this.tabControl.Controls.Add(this.tpYearStatistic);
            this.tabControl.Controls.Add(this.tpSourceStatistic);
            this.tabControl.Location = new System.Drawing.Point(6, 21);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(664, 696);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.tbSourсe);
            this.tpData.Controls.Add(this.tbKeywords);
            this.tpData.Controls.Add(this.tbAffiliation);
            this.tpData.Controls.Add(this.tbUrl);
            this.tpData.Controls.Add(this.tbDoi);
            this.tpData.Controls.Add(this.tbPages);
            this.tpData.Controls.Add(this.tbNumber);
            this.tpData.Controls.Add(this.tbPublisher);
            this.tpData.Controls.Add(this.tbVolume);
            this.tpData.Controls.Add(this.tbYear);
            this.tpData.Controls.Add(this.tbJournalName);
            this.tpData.Controls.Add(this.tbAbstract);
            this.tpData.Controls.Add(this.tbTitle);
            this.tpData.Controls.Add(this.tbAuthors);
            this.tpData.Controls.Add(this.lbNumber);
            this.tpData.Controls.Add(this.lbSourse);
            this.tpData.Controls.Add(this.lbPublisher);
            this.tpData.Controls.Add(this.lbKeywords);
            this.tpData.Controls.Add(this.lbAbstract);
            this.tpData.Controls.Add(this.lbAffiliation);
            this.tpData.Controls.Add(this.lbUrl);
            this.tpData.Controls.Add(this.lbDoi);
            this.tpData.Controls.Add(this.lbPage);
            this.tpData.Controls.Add(this.lbVolume);
            this.tpData.Controls.Add(this.lbYear);
            this.tpData.Controls.Add(this.lbJournalName);
            this.tpData.Controls.Add(this.lbTitle);
            this.tpData.Controls.Add(this.lbAuthors);
            this.tpData.Location = new System.Drawing.Point(4, 25);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(656, 667);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Данные";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // tbSourсe
            // 
            this.tbSourсe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourсe.Location = new System.Drawing.Point(179, 639);
            this.tbSourсe.Name = "tbSourсe";
            this.tbSourсe.Size = new System.Drawing.Size(471, 22);
            this.tbSourсe.TabIndex = 27;
            this.tbSourсe.TextChanged += new System.EventHandler(this.tbSourсe_TextChanged);
            // 
            // tbKeywords
            // 
            this.tbKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbKeywords.Location = new System.Drawing.Point(179, 578);
            this.tbKeywords.Multiline = true;
            this.tbKeywords.Name = "tbKeywords";
            this.tbKeywords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbKeywords.Size = new System.Drawing.Size(471, 55);
            this.tbKeywords.TabIndex = 26;
            this.tbKeywords.TextChanged += new System.EventHandler(this.tbKeywords_TextChanged);
            // 
            // tbAffiliation
            // 
            this.tbAffiliation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAffiliation.Location = new System.Drawing.Point(179, 512);
            this.tbAffiliation.Multiline = true;
            this.tbAffiliation.Name = "tbAffiliation";
            this.tbAffiliation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAffiliation.Size = new System.Drawing.Size(471, 60);
            this.tbAffiliation.TabIndex = 25;
            this.tbAffiliation.TextChanged += new System.EventHandler(this.tbAffiliation_TextChanged);
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Location = new System.Drawing.Point(179, 447);
            this.tbUrl.Multiline = true;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbUrl.Size = new System.Drawing.Size(471, 59);
            this.tbUrl.TabIndex = 24;
            this.tbUrl.TextChanged += new System.EventHandler(this.tbUrl_TextChanged);
            // 
            // tbDoi
            // 
            this.tbDoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDoi.Location = new System.Drawing.Point(179, 419);
            this.tbDoi.Name = "tbDoi";
            this.tbDoi.Size = new System.Drawing.Size(471, 22);
            this.tbDoi.TabIndex = 23;
            this.tbDoi.TextChanged += new System.EventHandler(this.tbDoi_TextChanged);
            // 
            // tbPages
            // 
            this.tbPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPages.Location = new System.Drawing.Point(179, 391);
            this.tbPages.Name = "tbPages";
            this.tbPages.Size = new System.Drawing.Size(471, 22);
            this.tbPages.TabIndex = 22;
            this.tbPages.TextChanged += new System.EventHandler(this.tbPages_TextChanged);
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNumber.Location = new System.Drawing.Point(179, 363);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(471, 22);
            this.tbNumber.TabIndex = 21;
            this.tbNumber.TextChanged += new System.EventHandler(this.tbNumber_TextChanged);
            // 
            // tbPublisher
            // 
            this.tbPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPublisher.Location = new System.Drawing.Point(179, 335);
            this.tbPublisher.Name = "tbPublisher";
            this.tbPublisher.Size = new System.Drawing.Size(471, 22);
            this.tbPublisher.TabIndex = 20;
            this.tbPublisher.TextChanged += new System.EventHandler(this.tbPublisher_TextChanged);
            // 
            // tbVolume
            // 
            this.tbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVolume.Location = new System.Drawing.Point(179, 305);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(471, 22);
            this.tbVolume.TabIndex = 19;
            this.tbVolume.TextChanged += new System.EventHandler(this.tbVolume_TextChanged);
            // 
            // tbYear
            // 
            this.tbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbYear.Location = new System.Drawing.Point(179, 271);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(471, 22);
            this.tbYear.TabIndex = 18;
            this.tbYear.TextChanged += new System.EventHandler(this.tbYear_TextChanged);
            // 
            // tbJournalName
            // 
            this.tbJournalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJournalName.Location = new System.Drawing.Point(179, 243);
            this.tbJournalName.Name = "tbJournalName";
            this.tbJournalName.Size = new System.Drawing.Size(471, 22);
            this.tbJournalName.TabIndex = 17;
            this.tbJournalName.TextChanged += new System.EventHandler(this.tbJournalName_TextChanged);
            // 
            // tbAbstract
            // 
            this.tbAbstract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAbstract.Location = new System.Drawing.Point(179, 141);
            this.tbAbstract.Multiline = true;
            this.tbAbstract.Name = "tbAbstract";
            this.tbAbstract.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAbstract.Size = new System.Drawing.Size(471, 96);
            this.tbAbstract.TabIndex = 16;
            this.tbAbstract.TextChanged += new System.EventHandler(this.tbAbstract_TextChanged);
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(179, 110);
            this.tbTitle.Multiline = true;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(471, 22);
            this.tbTitle.TabIndex = 15;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // tbAuthors
            // 
            this.tbAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAuthors.Location = new System.Drawing.Point(179, 20);
            this.tbAuthors.Multiline = true;
            this.tbAuthors.Name = "tbAuthors";
            this.tbAuthors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAuthors.Size = new System.Drawing.Size(471, 84);
            this.tbAuthors.TabIndex = 14;
            this.tbAuthors.TextChanged += new System.EventHandler(this.tbAuthors_TextChanged);
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(3, 363);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(51, 17);
            this.lbNumber.TabIndex = 13;
            this.lbNumber.Text = "Номер";
            // 
            // lbSourse
            // 
            this.lbSourse.AutoSize = true;
            this.lbSourse.Location = new System.Drawing.Point(6, 639);
            this.lbSourse.Name = "lbSourse";
            this.lbSourse.Size = new System.Drawing.Size(71, 17);
            this.lbSourse.TabIndex = 12;
            this.lbSourse.Text = "Источник";
            // 
            // lbPublisher
            // 
            this.lbPublisher.AutoSize = true;
            this.lbPublisher.Location = new System.Drawing.Point(6, 335);
            this.lbPublisher.Name = "lbPublisher";
            this.lbPublisher.Size = new System.Drawing.Size(71, 17);
            this.lbPublisher.TabIndex = 11;
            this.lbPublisher.Text = "Издатель";
            // 
            // lbKeywords
            // 
            this.lbKeywords.AutoSize = true;
            this.lbKeywords.Location = new System.Drawing.Point(7, 578);
            this.lbKeywords.Name = "lbKeywords";
            this.lbKeywords.Size = new System.Drawing.Size(118, 17);
            this.lbKeywords.TabIndex = 10;
            this.lbKeywords.Text = "Ключевые слова";
            // 
            // lbAbstract
            // 
            this.lbAbstract.AutoSize = true;
            this.lbAbstract.Location = new System.Drawing.Point(6, 140);
            this.lbAbstract.Name = "lbAbstract";
            this.lbAbstract.Size = new System.Drawing.Size(80, 17);
            this.lbAbstract.TabIndex = 9;
            this.lbAbstract.Text = "Аннотация";
            // 
            // lbAffiliation
            // 
            this.lbAffiliation.AutoSize = true;
            this.lbAffiliation.Location = new System.Drawing.Point(7, 515);
            this.lbAffiliation.Name = "lbAffiliation";
            this.lbAffiliation.Size = new System.Drawing.Size(65, 17);
            this.lbAffiliation.TabIndex = 8;
            this.lbAffiliation.Text = "Affiliation";
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(7, 447);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(26, 17);
            this.lbUrl.TabIndex = 7;
            this.lbUrl.Text = "Url";
            // 
            // lbDoi
            // 
            this.lbDoi.AutoSize = true;
            this.lbDoi.Location = new System.Drawing.Point(6, 419);
            this.lbDoi.Name = "lbDoi";
            this.lbDoi.Size = new System.Drawing.Size(29, 17);
            this.lbDoi.TabIndex = 6;
            this.lbDoi.Text = "Doi";
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(6, 391);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(74, 17);
            this.lbPage.TabIndex = 5;
            this.lbPage.Text = "Страницы";
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(6, 305);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(34, 17);
            this.lbVolume.TabIndex = 4;
            this.lbVolume.Text = "Том";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Location = new System.Drawing.Point(6, 271);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(32, 17);
            this.lbYear.TabIndex = 3;
            this.lbYear.Text = "Год";
            // 
            // lbJournalName
            // 
            this.lbJournalName.AutoSize = true;
            this.lbJournalName.Location = new System.Drawing.Point(3, 243);
            this.lbJournalName.Name = "lbJournalName";
            this.lbJournalName.Size = new System.Drawing.Size(60, 17);
            this.lbJournalName.TabIndex = 2;
            this.lbJournalName.Text = "Журнал";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(6, 110);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(72, 17);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Название";
            // 
            // lbAuthors
            // 
            this.lbAuthors.AutoSize = true;
            this.lbAuthors.Location = new System.Drawing.Point(6, 20);
            this.lbAuthors.Name = "lbAuthors";
            this.lbAuthors.Size = new System.Drawing.Size(57, 17);
            this.lbAuthors.TabIndex = 0;
            this.lbAuthors.Text = "Авторы";
            // 
            // tpBib
            // 
            this.tpBib.Controls.Add(this.rtbBib);
            this.tpBib.Location = new System.Drawing.Point(4, 25);
            this.tpBib.Name = "tpBib";
            this.tpBib.Padding = new System.Windows.Forms.Padding(3);
            this.tpBib.Size = new System.Drawing.Size(656, 667);
            this.tpBib.TabIndex = 1;
            this.tpBib.Text = "Библ. описания";
            this.tpBib.UseVisualStyleBackColor = true;
            // 
            // rtbBib
            // 
            this.rtbBib.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBib.Location = new System.Drawing.Point(7, 7);
            this.rtbBib.Name = "rtbBib";
            this.rtbBib.Size = new System.Drawing.Size(643, 654);
            this.rtbBib.TabIndex = 0;
            this.rtbBib.Text = "";
            // 
            // tpYearStatistic
            // 
            this.tpYearStatistic.Controls.Add(this.lvYearStatistic);
            this.tpYearStatistic.Location = new System.Drawing.Point(4, 25);
            this.tpYearStatistic.Name = "tpYearStatistic";
            this.tpYearStatistic.Padding = new System.Windows.Forms.Padding(3);
            this.tpYearStatistic.Size = new System.Drawing.Size(656, 667);
            this.tpYearStatistic.TabIndex = 2;
            this.tpYearStatistic.Text = "Statistic";
            this.tpYearStatistic.UseVisualStyleBackColor = true;
            // 
            // lvYearStatistic
            // 
            this.lvYearStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvYearStatistic.Location = new System.Drawing.Point(3, 6);
            this.lvYearStatistic.Name = "lvYearStatistic";
            this.lvYearStatistic.Size = new System.Drawing.Size(647, 655);
            this.lvYearStatistic.TabIndex = 0;
            this.lvYearStatistic.UseCompatibleStateImageBehavior = false;
            this.lvYearStatistic.View = System.Windows.Forms.View.Details;
            // 
            // tpSourceStatistic
            // 
            this.tpSourceStatistic.Controls.Add(this.lvSourceStatistic);
            this.tpSourceStatistic.Location = new System.Drawing.Point(4, 25);
            this.tpSourceStatistic.Name = "tpSourceStatistic";
            this.tpSourceStatistic.Padding = new System.Windows.Forms.Padding(3);
            this.tpSourceStatistic.Size = new System.Drawing.Size(656, 667);
            this.tpSourceStatistic.TabIndex = 3;
            this.tpSourceStatistic.Text = "Source statistic";
            this.tpSourceStatistic.UseVisualStyleBackColor = true;
            // 
            // lvSourceStatistic
            // 
            this.lvSourceStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSourceStatistic.Location = new System.Drawing.Point(6, 6);
            this.lvSourceStatistic.Name = "lvSourceStatistic";
            this.lvSourceStatistic.Size = new System.Drawing.Size(644, 655);
            this.lvSourceStatistic.TabIndex = 0;
            this.lvSourceStatistic.UseCompatibleStateImageBehavior = false;
            this.lvSourceStatistic.View = System.Windows.Forms.View.Details;
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvItems.FullRowSelect = true;
            this.lvItems.Location = new System.Drawing.Point(12, 189);
            this.lvItems.MultiSelect = false;
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(776, 557);
            this.lvItems.TabIndex = 2;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvItems_ItemSelectionChanged);
            this.lvItems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvItems_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1536, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.добавитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // lbCurrSelectedItem
            // 
            this.lbCurrSelectedItem.AutoSize = true;
            this.lbCurrSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrSelectedItem.Location = new System.Drawing.Point(343, 154);
            this.lbCurrSelectedItem.Name = "lbCurrSelectedItem";
            this.lbCurrSelectedItem.Size = new System.Drawing.Size(0, 29);
            this.lbCurrSelectedItem.TabIndex = 4;
            // 
            // btFirst
            // 
            this.btFirst.Location = new System.Drawing.Point(12, 65);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(126, 64);
            this.btFirst.TabIndex = 5;
            this.btFirst.Text = "Корпус первичных документов";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // btUnique
            // 
            this.btUnique.Location = new System.Drawing.Point(168, 65);
            this.btUnique.Name = "btUnique";
            this.btUnique.Size = new System.Drawing.Size(126, 64);
            this.btUnique.TabIndex = 6;
            this.btUnique.Text = "Корпус уникальных документов";
            this.btUnique.UseVisualStyleBackColor = true;
            this.btUnique.Click += new System.EventHandler(this.btUnique_Click);
            // 
            // btRelevance
            // 
            this.btRelevance.Location = new System.Drawing.Point(323, 65);
            this.btRelevance.Name = "btRelevance";
            this.btRelevance.Size = new System.Drawing.Size(126, 64);
            this.btRelevance.TabIndex = 7;
            this.btRelevance.Text = "Корпус релевантных документов";
            this.btRelevance.UseVisualStyleBackColor = true;
            this.btRelevance.Click += new System.EventHandler(this.btRelevance_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 28);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(132, 24);
            this.toolStripMenuItem1.Text = "удалить";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 765);
            this.Controls.Add(this.btRelevance);
            this.Controls.Add(this.btUnique);
            this.Controls.Add(this.btFirst);
            this.Controls.Add(this.lbCurrSelectedItem);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1550, 800);
            this.Name = "MainForm";
            this.Text = "BibReader";
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpData.PerformLayout();
            this.tpBib.ResumeLayout(false);
            this.tpYearStatistic.ResumeLayout(false);
            this.tpSourceStatistic.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.TabPage tpBib;
        private System.Windows.Forms.RichTextBox rtbBib;
        private System.Windows.Forms.Label lbDoi;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.Label lbJournalName;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbAuthors;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbSourse;
        private System.Windows.Forms.Label lbPublisher;
        private System.Windows.Forms.Label lbKeywords;
        private System.Windows.Forms.Label lbAbstract;
        private System.Windows.Forms.Label lbAffiliation;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbJournalName;
        private System.Windows.Forms.TextBox tbAbstract;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbAuthors;
        private System.Windows.Forms.TextBox tbSourсe;
        private System.Windows.Forms.TextBox tbKeywords;
        private System.Windows.Forms.TextBox tbAffiliation;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.TextBox tbDoi;
        private System.Windows.Forms.TextBox tbPages;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbPublisher;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.TabPage tpYearStatistic;
        private System.Windows.Forms.TabPage tpSourceStatistic;
        private System.Windows.Forms.ListView lvYearStatistic;
        private System.Windows.Forms.Label lbCurrSelectedItem;
        private System.Windows.Forms.ListView lvSourceStatistic;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.Button btUnique;
        private System.Windows.Forms.Button btRelevance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

