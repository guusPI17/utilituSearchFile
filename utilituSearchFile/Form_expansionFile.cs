using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace utilituSearchFile
{
    public partial class Form_expansionFile : Form
    {
        /// <summary>
        /// Объект для работы с доп.функциями
        /// </summary>
        private AddFunc aF = new AddFunc();

        /// <summary>
        /// количество доступных расширений файлов в программе
        /// </summary>
        private const int expansionCount = 6;

        /// <summary>
        /// название всех расширение
        /// </summary>
        private string[] expansionFile_string = new string[expansionCount] { ".txt", ".bat", ".html", ".xml", ".js", ".php" };

        /// <summary>
        /// лист чек боксов расширений
        /// </summary>
        private List<CheckBox> expansionFile_Box = new List<CheckBox>();

        /// <summary>
        /// копия лист чек бокса с расширением(в случае если данные не придется сохранять для отправки)
        /// </summary>
        private List<CheckBox> expansionFile_Box_copy = new List<CheckBox>();

        /// <summary>
        /// bool для отслеживания кнопки включения/отключения чеков у всех box
        /// </summary>
        private bool checkAllExp = true;

        /// <summary>
        /// для опредения сохранять данные по нажатия на крестик или нет
        /// </summary>
        private bool checkButtonNoSave = true;

        public Form_expansionFile(List<CheckBox> checkBoxes)
        {
            InitializeComponent();
            initializeCheckBox(checkBoxes);
            copyCheckBox(expansionFile_Box_copy, checkBoxes);
        }

        public Form_expansionFile()
        {
            InitializeComponent();
            // первичная инициалация листа чек боксов чеками=false
            for (int i = 0; i < expansionCount; i++)
            {
                CheckBox box = new CheckBox();
                box.Text = expansionFile_string[i];
                box.Checked = false;
                expansionFile_Box_copy.Add(box);
            }
            initializeCheckBox(expansionFile_Box_copy);
        }

        public List<CheckBox> getExpansionFile_Box()
        {
            return expansionFile_Box;
        }

        /// <summary>
        /// инициализация чек боксов с доступными расширениями файлов для поиска
        /// </summary>
        /// <param name="checkBoxes">лист чеков для инициализации</param>
        private void initializeCheckBox(List<CheckBox> checkBoxes)
        {
            int x = -42;
            int y = 10;
            int _x = x;
            int _y = y;
            for (int i = 0, j = 0; i < expansionCount; i++, j++)
            {
                CheckBox tmp = new CheckBox();
                tmp.Font = new Font("Microsoft Sans Serif",10);
                tmp.Text = expansionFile_string[i];
                tmp.Size = new Size(60, 21);
                if (j == 4)
                {
                    _x = x;
                    tmp.Location = new Point(_x += 57, y += 25);
                    j = 0;
                }
                else
                {
                    tmp.Location = new Point(_x += 57, y);
                }
                tmp.Checked = checkBoxes[i].Checked;
                expansionFile_Box.Add(tmp);
                this.Controls.Add(tmp);
                tmp.Parent = this.panel_arrExpansionFile;
                tmp.BringToFront();
            }
        }

        /// <summary>
        /// Кнопка "выбрать/убрать все" чеки на чекбоксах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_allClickExpanxion_Click(object sender, EventArgs e)
        {
            if (checkAllExp == true)
            {
                foreach (CheckBox box in expansionFile_Box)
                    box.Checked = true;
                checkAllExp = false;
                button_allClickExpanxion.Text = "Убрать все";
            }
            else
            {
                foreach (CheckBox box in expansionFile_Box)
                    box.Checked = false;
                checkAllExp = true;
                button_allClickExpanxion.Text = "Выбрать все"; 
            }
        }

        private void button_notSave_Click(object sender, EventArgs e)
        {
            if (aF.checkMask(panel_arrExpansionFile) == false)
            {
                MessageBox.Show("Выберите расширение файлов для поиска", "Ошибка");
                return;
            }
            expansionFile_Box = new List<CheckBox>(expansionFile_Box_copy);
            checkButtonNoSave = true;
            this.Close();
        }

        private void button_saveForm_Click(object sender, EventArgs e)
        {
            if (aF.checkMask(panel_arrExpansionFile) == false)
            {
                MessageBox.Show("Выберите расширение файлов для поиска", "Ошибка");
                return;
            }
            checkButtonNoSave = false;
            this.Close();
        }

        /// <summary>
        /// копирование из одного листа чекбоксов информацию о чеках и тексте в другой лист бокс
        /// </summary>
        /// <param name="boxesCopy">лист для копии</param>
        /// <param name="boxesOrig">лист для оригинала</param>
        private void copyCheckBox(List<CheckBox> boxesCopy, List<CheckBox> boxesOrig)
        {
            for (int i = 0; i < boxesOrig.Count; i++)
            {
                CheckBox tmp = new CheckBox();
                tmp.Text = boxesOrig[i].Text;
                tmp.Checked = boxesOrig[i].Checked;
                boxesCopy.Add(tmp);
            }
        }

        private void Form_expansionFile_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(e.CloseReason == CloseReason.UserClosing)
            {
                if (checkButtonNoSave == true) 
                    expansionFile_Box = new List<CheckBox>(expansionFile_Box_copy);
            }
        }

        /// <summary>
        /// Выход по esc
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys dataKey)
        {
            if (dataKey == Keys.Escape)
            {
                this.Close();
                if (checkButtonNoSave == true)
                    expansionFile_Box = new List<CheckBox>(expansionFile_Box_copy);
            }
            return base.ProcessCmdKey(ref msg, dataKey);
        }
    }
}
