using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace utilituSearchFile
{
    public partial class Form_formatSearch : Form
    {
        /// <summary>
        /// Объект для работы с доп.функциями
        /// </summary>
        private AddFunc aF = new AddFunc();

        /// <summary>
        /// количество форматов(для каталога и файла по отдельности)
        /// </summary>
        private const int formatCount = 3;

        /// <summary>
        /// хранит все чекбоксы для отправки
        /// </summary>
        private List<CheckBox> listFormatSearch = new List<CheckBox>();
        private List<CheckBox> listFormatSearch_copy = new List<CheckBox>();

        /// <summary>
        /// bool для отслеживания кнопки включения/отключения чеков у всех box
        /// </summary>
        private bool checkAllExp = true;

        /// <summary>
        /// для опредения сохранять данные по нажатия на крестик или нет
        /// </summary>
        private bool checkButtonNoSave = true;

        public Form_formatSearch(List<CheckBox> boxes)
        {
            InitializeComponent();
            foreach(CheckBox box in boxes)
            {
                listFormatSearch.Add(box);
                listFormatSearch_copy.Add(box);
            }
            initializeCheckBox(listFormatSearch);

        }

        /// <summary>
        /// инициализация чек боксов с доступными типами файлов для поиска
        /// </summary>
        /// <param name="checkBoxes">лист чеков для инициализации</param>
        private void initializeCheckBox(List<CheckBox> checkBoxe)
        {
            foreach (Control contrl in panel_arrFormatSearch.Controls)
            {
                if ((contrl.GetType()).Equals(typeof(CheckBox)))
                {
                    CheckBox box = (CheckBox)contrl;
                    for (int i = 0; i < checkBoxe.Count; i++)
                    {
                        if (box.Text == checkBoxe[i].Text)
                            box.Checked = checkBoxe[i].Checked;
                    }
                }
            }
        }

        public Form_formatSearch()
        {
            InitializeComponent();
        }

        public List<CheckBox> getFormatList()
        {
            return listFormatSearch;
        }

        /// <summary>
        /// выбрать все/убрать все чеки с чек боксов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_allClickExpanxion_Click(object sender, EventArgs e)
        {
            if (checkAllExp == true)
            {
                foreach(Control contrl in panel_arrFormatSearch.Controls)
                {
                    if((contrl.GetType()).Equals(typeof(CheckBox)))
                    {
                        CheckBox box = (CheckBox)contrl;
                        box.Checked = true;
                    }
                }
                checkAllExp = false;
                button_allClickExpanxion.Text = "Убрать все";
            }
            else
            {
                foreach (Control contrl in panel_arrFormatSearch.Controls)
                {
                    if ((contrl.GetType()).Equals(typeof(CheckBox)))
                    {
                        CheckBox box = (CheckBox)contrl;
                        box.Checked = false;
                    }
                }
                checkAllExp = true;
                button_allClickExpanxion.Text = "Выбрать все";
            }
        }

        private void button_notSave_Click(object sender, EventArgs e)
        {
            if (aF.checkMask(panel_arrFormatSearch) == false)
            {
                MessageBox.Show("Выберите формат файлов для поиска", "Ошибка");
                return;
            }
            else
            {
                checkButtonNoSave = true;
                listFormatSearch = new List<CheckBox>(listFormatSearch_copy);
                this.Close();
            }
        }

        private void button_saveForm_Click(object sender, EventArgs e)
        {
            if (aF.checkMask(panel_arrFormatSearch) == false)
            {
                MessageBox.Show("Выберите формат каталогов и файлов для поиска", "Ошибка");
                return;
            }
            listFormatSearch.Clear();
            foreach (Control contrl in panel_arrFormatSearch.Controls)
            {
                if ((contrl.GetType()).Equals(typeof(CheckBox)))
                {
                    CheckBox box = (CheckBox)contrl;
                    CheckBox tmp = new CheckBox();
                    tmp.Text = box.Text;
                    tmp.Checked = box.Checked;
                    listFormatSearch.Add(tmp);
                }
            }
            checkButtonNoSave = false;
            this.Close();
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
            }
            return base.ProcessCmdKey(ref msg, dataKey);
        }

        private void Form_formatSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (checkButtonNoSave == true)
                    listFormatSearch = new List<CheckBox>(listFormatSearch_copy);
            }
        }
    }
}
