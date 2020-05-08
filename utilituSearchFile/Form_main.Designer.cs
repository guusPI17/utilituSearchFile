namespace utilituSearchFile
{
    partial class Form_main
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
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_searchText = new System.Windows.Forms.RichTextBox();
            this.panel_initial = new System.Windows.Forms.Panel();
            this.panel_setting = new System.Windows.Forms.Panel();
            this.checkBox_sortFoundFile = new System.Windows.Forms.CheckBox();
            this.button_openFileLog = new System.Windows.Forms.Button();
            this.textBox_pathFileLog = new System.Windows.Forms.TextBox();
            this.panel_formatFile = new System.Windows.Forms.Panel();
            this.button_openForm_formatSearch = new System.Windows.Forms.Button();
            this.button_openForm_expansionFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_savelog = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_fountFile = new System.Windows.Forms.Panel();
            this.label_countFoundFile = new System.Windows.Forms.Label();
            this.button_remSearchFile = new System.Windows.Forms.Button();
            this.button_searchFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_foundFile = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_searchFile = new System.Windows.Forms.Panel();
            this.panel_settingPathSerach = new System.Windows.Forms.Panel();
            this.button_openDirSearch = new System.Windows.Forms.Button();
            this.textBox_pickPathDirSearch = new System.Windows.Forms.TextBox();
            this.textBox_onePathDirSearch = new System.Windows.Forms.TextBox();
            this.radioButton_allFile = new System.Windows.Forms.RadioButton();
            this.radioButton_oneFile = new System.Windows.Forms.RadioButton();
            this.radioButton_pickFile = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструкцияПопутьДляПоискаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_initial.SuspendLayout();
            this.panel_setting.SuspendLayout();
            this.panel_formatFile.SuspendLayout();
            this.panel_fountFile.SuspendLayout();
            this.panel_searchFile.SuspendLayout();
            this.panel_settingPathSerach.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Искомный текст:";
            // 
            // richTextBox_searchText
            // 
            this.richTextBox_searchText.Location = new System.Drawing.Point(31, 45);
            this.richTextBox_searchText.Name = "richTextBox_searchText";
            this.richTextBox_searchText.Size = new System.Drawing.Size(161, 108);
            this.richTextBox_searchText.TabIndex = 2;
            this.richTextBox_searchText.Text = "";
            // 
            // panel_initial
            // 
            this.panel_initial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_initial.Controls.Add(this.richTextBox_searchText);
            this.panel_initial.Controls.Add(this.label1);
            this.panel_initial.Location = new System.Drawing.Point(22, 42);
            this.panel_initial.Name = "panel_initial";
            this.panel_initial.Size = new System.Drawing.Size(229, 173);
            this.panel_initial.TabIndex = 3;
            // 
            // panel_setting
            // 
            this.panel_setting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_setting.Controls.Add(this.checkBox_sortFoundFile);
            this.panel_setting.Controls.Add(this.button_openFileLog);
            this.panel_setting.Controls.Add(this.textBox_pathFileLog);
            this.panel_setting.Controls.Add(this.panel_formatFile);
            this.panel_setting.Controls.Add(this.checkBox_savelog);
            this.panel_setting.Controls.Add(this.label2);
            this.panel_setting.Location = new System.Drawing.Point(22, 226);
            this.panel_setting.Name = "panel_setting";
            this.panel_setting.Size = new System.Drawing.Size(229, 312);
            this.panel_setting.TabIndex = 4;
            // 
            // checkBox_sortFoundFile
            // 
            this.checkBox_sortFoundFile.AutoSize = true;
            this.checkBox_sortFoundFile.Location = new System.Drawing.Point(22, 65);
            this.checkBox_sortFoundFile.Name = "checkBox_sortFoundFile";
            this.checkBox_sortFoundFile.Size = new System.Drawing.Size(199, 21);
            this.checkBox_sortFoundFile.TabIndex = 11;
            this.checkBox_sortFoundFile.Text = "отсортировать результат";
            this.checkBox_sortFoundFile.UseVisualStyleBackColor = true;
            this.checkBox_sortFoundFile.CheckedChanged += new System.EventHandler(this.checkBox_checkSetting_CheckedChanged);
            // 
            // button_openFileLog
            // 
            this.button_openFileLog.Enabled = false;
            this.button_openFileLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_openFileLog.Location = new System.Drawing.Point(161, 86);
            this.button_openFileLog.Name = "button_openFileLog";
            this.button_openFileLog.Size = new System.Drawing.Size(37, 32);
            this.button_openFileLog.TabIndex = 5;
            this.button_openFileLog.Text = "...";
            this.button_openFileLog.UseVisualStyleBackColor = true;
            this.button_openFileLog.Click += new System.EventHandler(this.button_openFileLog_Click);
            // 
            // textBox_pathFileLog
            // 
            this.textBox_pathFileLog.Enabled = false;
            this.textBox_pathFileLog.Location = new System.Drawing.Point(14, 92);
            this.textBox_pathFileLog.Name = "textBox_pathFileLog";
            this.textBox_pathFileLog.Size = new System.Drawing.Size(141, 22);
            this.textBox_pathFileLog.TabIndex = 6;
            // 
            // panel_formatFile
            // 
            this.panel_formatFile.Controls.Add(this.button_openForm_formatSearch);
            this.panel_formatFile.Controls.Add(this.button_openForm_expansionFile);
            this.panel_formatFile.Controls.Add(this.label3);
            this.panel_formatFile.Controls.Add(this.label6);
            this.panel_formatFile.Location = new System.Drawing.Point(3, 120);
            this.panel_formatFile.Name = "panel_formatFile";
            this.panel_formatFile.Size = new System.Drawing.Size(218, 111);
            this.panel_formatFile.TabIndex = 5;
            // 
            // button_openForm_formatSearch
            // 
            this.button_openForm_formatSearch.Location = new System.Drawing.Point(137, 65);
            this.button_openForm_formatSearch.Name = "button_openForm_formatSearch";
            this.button_openForm_formatSearch.Size = new System.Drawing.Size(78, 31);
            this.button_openForm_formatSearch.TabIndex = 5;
            this.button_openForm_formatSearch.Text = "перейти";
            this.button_openForm_formatSearch.UseVisualStyleBackColor = true;
            this.button_openForm_formatSearch.Click += new System.EventHandler(this.button_openForm_formatSearch_Click);
            // 
            // button_openForm_expansionFile
            // 
            this.button_openForm_expansionFile.Location = new System.Drawing.Point(137, 18);
            this.button_openForm_expansionFile.Name = "button_openForm_expansionFile";
            this.button_openForm_expansionFile.Size = new System.Drawing.Size(78, 31);
            this.button_openForm_expansionFile.TabIndex = 4;
            this.button_openForm_expansionFile.Text = "перейти";
            this.button_openForm_expansionFile.UseVisualStyleBackColor = true;
            this.button_openForm_expansionFile.Click += new System.EventHandler(this.button_openForm_expansionFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Форматы:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(15, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Расширения:";
            // 
            // checkBox_savelog
            // 
            this.checkBox_savelog.AutoSize = true;
            this.checkBox_savelog.Location = new System.Drawing.Point(22, 43);
            this.checkBox_savelog.Name = "checkBox_savelog";
            this.checkBox_savelog.Size = new System.Drawing.Size(184, 21);
            this.checkBox_savelog.TabIndex = 3;
            this.checkBox_savelog.Text = "сохр. результат в файл";
            this.checkBox_savelog.UseVisualStyleBackColor = true;
            this.checkBox_savelog.CheckedChanged += new System.EventHandler(this.checkBox_checkSetting_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(52, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Настройки";
            // 
            // panel_fountFile
            // 
            this.panel_fountFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_fountFile.Controls.Add(this.label_countFoundFile);
            this.panel_fountFile.Controls.Add(this.button_remSearchFile);
            this.panel_fountFile.Controls.Add(this.button_searchFile);
            this.panel_fountFile.Controls.Add(this.label5);
            this.panel_fountFile.Controls.Add(this.listBox_foundFile);
            this.panel_fountFile.Location = new System.Drawing.Point(257, 226);
            this.panel_fountFile.Name = "panel_fountFile";
            this.panel_fountFile.Size = new System.Drawing.Size(413, 312);
            this.panel_fountFile.TabIndex = 5;
            // 
            // label_countFoundFile
            // 
            this.label_countFoundFile.AutoSize = true;
            this.label_countFoundFile.Location = new System.Drawing.Point(302, 14);
            this.label_countFoundFile.Name = "label_countFoundFile";
            this.label_countFoundFile.Size = new System.Drawing.Size(0, 17);
            this.label_countFoundFile.TabIndex = 11;
            // 
            // button_remSearchFile
            // 
            this.button_remSearchFile.Location = new System.Drawing.Point(218, 250);
            this.button_remSearchFile.Name = "button_remSearchFile";
            this.button_remSearchFile.Size = new System.Drawing.Size(113, 49);
            this.button_remSearchFile.TabIndex = 10;
            this.button_remSearchFile.Text = "Отмена";
            this.button_remSearchFile.UseVisualStyleBackColor = true;
            this.button_remSearchFile.Click += new System.EventHandler(this.button_remSearchFile_Click);
            // 
            // button_searchFile
            // 
            this.button_searchFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_searchFile.Location = new System.Drawing.Point(82, 250);
            this.button_searchFile.Name = "button_searchFile";
            this.button_searchFile.Size = new System.Drawing.Size(113, 49);
            this.button_searchFile.TabIndex = 7;
            this.button_searchFile.Text = "Начать поиск";
            this.button_searchFile.UseVisualStyleBackColor = true;
            this.button_searchFile.Click += new System.EventHandler(this.button_searchFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(121, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Найденные файлы:";
            // 
            // listBox_foundFile
            // 
            this.listBox_foundFile.FormattingEnabled = true;
            this.listBox_foundFile.HorizontalScrollbar = true;
            this.listBox_foundFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox_foundFile.ItemHeight = 16;
            this.listBox_foundFile.Location = new System.Drawing.Point(39, 50);
            this.listBox_foundFile.Name = "listBox_foundFile";
            this.listBox_foundFile.Size = new System.Drawing.Size(337, 180);
            this.listBox_foundFile.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(141, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Путь для поиска:";
            // 
            // panel_searchFile
            // 
            this.panel_searchFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_searchFile.Controls.Add(this.panel_settingPathSerach);
            this.panel_searchFile.Controls.Add(this.label4);
            this.panel_searchFile.Location = new System.Drawing.Point(257, 42);
            this.panel_searchFile.Name = "panel_searchFile";
            this.panel_searchFile.Size = new System.Drawing.Size(413, 173);
            this.panel_searchFile.TabIndex = 6;
            // 
            // panel_settingPathSerach
            // 
            this.panel_settingPathSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_settingPathSerach.Controls.Add(this.button_openDirSearch);
            this.panel_settingPathSerach.Controls.Add(this.textBox_pickPathDirSearch);
            this.panel_settingPathSerach.Controls.Add(this.textBox_onePathDirSearch);
            this.panel_settingPathSerach.Controls.Add(this.radioButton_allFile);
            this.panel_settingPathSerach.Controls.Add(this.radioButton_oneFile);
            this.panel_settingPathSerach.Controls.Add(this.radioButton_pickFile);
            this.panel_settingPathSerach.Location = new System.Drawing.Point(17, 34);
            this.panel_settingPathSerach.Name = "panel_settingPathSerach";
            this.panel_settingPathSerach.Size = new System.Drawing.Size(373, 119);
            this.panel_settingPathSerach.TabIndex = 12;
            // 
            // button_openDirSearch
            // 
            this.button_openDirSearch.Enabled = false;
            this.button_openDirSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_openDirSearch.Location = new System.Drawing.Point(321, 73);
            this.button_openDirSearch.Name = "button_openDirSearch";
            this.button_openDirSearch.Size = new System.Drawing.Size(37, 32);
            this.button_openDirSearch.TabIndex = 7;
            this.button_openDirSearch.Text = "...";
            this.button_openDirSearch.UseVisualStyleBackColor = true;
            this.button_openDirSearch.Click += new System.EventHandler(this.button_openDirSearch_Click);
            // 
            // textBox_pickPathDirSearch
            // 
            this.textBox_pickPathDirSearch.Enabled = false;
            this.textBox_pickPathDirSearch.Location = new System.Drawing.Point(3, 79);
            this.textBox_pickPathDirSearch.Name = "textBox_pickPathDirSearch";
            this.textBox_pickPathDirSearch.Size = new System.Drawing.Size(145, 22);
            this.textBox_pickPathDirSearch.TabIndex = 7;
            // 
            // textBox_onePathDirSearch
            // 
            this.textBox_onePathDirSearch.Enabled = false;
            this.textBox_onePathDirSearch.Location = new System.Drawing.Point(162, 79);
            this.textBox_onePathDirSearch.Name = "textBox_onePathDirSearch";
            this.textBox_onePathDirSearch.ReadOnly = true;
            this.textBox_onePathDirSearch.Size = new System.Drawing.Size(145, 22);
            this.textBox_onePathDirSearch.TabIndex = 10;
            // 
            // radioButton_allFile
            // 
            this.radioButton_allFile.AutoSize = true;
            this.radioButton_allFile.Checked = true;
            this.radioButton_allFile.Location = new System.Drawing.Point(3, 11);
            this.radioButton_allFile.Name = "radioButton_allFile";
            this.radioButton_allFile.Size = new System.Drawing.Size(151, 21);
            this.radioButton_allFile.TabIndex = 8;
            this.radioButton_allFile.TabStop = true;
            this.radioButton_allFile.Text = "искать на всем ПК";
            this.radioButton_allFile.UseVisualStyleBackColor = true;
            this.radioButton_allFile.CheckedChanged += new System.EventHandler(this.radioButton_checkFile_CheckedChanged);
            // 
            // radioButton_oneFile
            // 
            this.radioButton_oneFile.AutoSize = true;
            this.radioButton_oneFile.Location = new System.Drawing.Point(162, 52);
            this.radioButton_oneFile.Name = "radioButton_oneFile";
            this.radioButton_oneFile.Size = new System.Drawing.Size(168, 21);
            this.radioButton_oneFile.TabIndex = 11;
            this.radioButton_oneFile.Text = "Искать в директории";
            this.radioButton_oneFile.UseVisualStyleBackColor = true;
            this.radioButton_oneFile.CheckedChanged += new System.EventHandler(this.radioButton_checkFile_CheckedChanged);
            // 
            // radioButton_pickFile
            // 
            this.radioButton_pickFile.AutoSize = true;
            this.radioButton_pickFile.Location = new System.Drawing.Point(3, 52);
            this.radioButton_pickFile.Name = "radioButton_pickFile";
            this.radioButton_pickFile.Size = new System.Drawing.Size(145, 21);
            this.radioButton_pickFile.TabIndex = 9;
            this.radioButton_pickFile.Text = "искать по выбору";
            this.radioButton_pickFile.UseVisualStyleBackColor = true;
            this.radioButton_pickFile.CheckedChanged += new System.EventHandler(this.radioButton_checkFile_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инструкцияПопутьДляПоискаToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // инструкцияПопутьДляПоискаToolStripMenuItem
            // 
            this.инструкцияПопутьДляПоискаToolStripMenuItem.Name = "инструкцияПопутьДляПоискаToolStripMenuItem";
            this.инструкцияПопутьДляПоискаToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.инструкцияПопутьДляПоискаToolStripMenuItem.Text = "Выбор пути файлов";
            this.инструкцияПопутьДляПоискаToolStripMenuItem.Click += new System.EventHandler(this.инструкцияПопутьДляПоискаToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сортировкаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 538);
            this.Controls.Add(this.panel_searchFile);
            this.Controls.Add(this.panel_fountFile);
            this.Controls.Add(this.panel_setting);
            this.Controls.Add(this.panel_initial);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(721, 585);
            this.MinimumSize = new System.Drawing.Size(721, 585);
            this.Name = "Form_main";
            this.Text = "Поиск по содержимому";
            this.panel_initial.ResumeLayout(false);
            this.panel_initial.PerformLayout();
            this.panel_setting.ResumeLayout(false);
            this.panel_setting.PerformLayout();
            this.panel_formatFile.ResumeLayout(false);
            this.panel_formatFile.PerformLayout();
            this.panel_fountFile.ResumeLayout(false);
            this.panel_fountFile.PerformLayout();
            this.panel_searchFile.ResumeLayout(false);
            this.panel_searchFile.PerformLayout();
            this.panel_settingPathSerach.ResumeLayout(false);
            this.panel_settingPathSerach.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_searchText;
        private System.Windows.Forms.Panel panel_initial;
        private System.Windows.Forms.Panel panel_setting;
        private System.Windows.Forms.Button button_openFileLog;
        private System.Windows.Forms.TextBox textBox_pathFileLog;
        private System.Windows.Forms.Panel panel_formatFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_savelog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_fountFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_foundFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_searchFile;
        private System.Windows.Forms.Button button_openDirSearch;
        private System.Windows.Forms.TextBox textBox_pickPathDirSearch;
        private System.Windows.Forms.Button button_searchFile;
        private System.Windows.Forms.RadioButton radioButton_pickFile;
        private System.Windows.Forms.RadioButton radioButton_allFile;
        private System.Windows.Forms.Button button_remSearchFile;
        private System.Windows.Forms.TextBox textBox_onePathDirSearch;
        private System.Windows.Forms.Panel panel_settingPathSerach;
        private System.Windows.Forms.RadioButton radioButton_oneFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_sortFoundFile;
        private System.Windows.Forms.Label label_countFoundFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.Button button_openForm_formatSearch;
        private System.Windows.Forms.Button button_openForm_expansionFile;
        private System.Windows.Forms.ToolStripMenuItem инструкцияПопутьДляПоискаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
    }
}

