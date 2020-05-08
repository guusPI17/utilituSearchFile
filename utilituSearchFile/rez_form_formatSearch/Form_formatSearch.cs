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
        /// количество форматов(для каталога и файла по отдельности)
        /// </summary>
        const int formatCount = 3;

        List<List<CheckBox>> formatSearch_Box = new List<List<CheckBox>>();
        List<List<CheckBox>> formatSearch_Box_copy = new List<List<CheckBox>>();

        /// <summary>
        /// формат для файлов
        /// </summary>
        FileAttributes? maskFile = null;

        /// <summary>
        /// формат для каталогов
        /// </summary>
        FileAttributes? maskDir = null;

        /// <summary>
        /// формат для файлов(без ?) // Enum.tryParse не позволяет использовать <type>?
        /// </summary>
        FileAttributes maskFile__;

        /// <summary>
        /// формат для каталогов(без ?)  // Enum.tryParse не позволяет использовать <type>?
        /// </summary>
        FileAttributes maskDir__;

        List<List<bool>> listCheck = new List<List<bool>>();

        /// <summary>
        /// Структура "слово-перевед"
        /// </summary>
        struct FormatSearch
        {
            public string nameRu;
            public string nameEu;
        }

        /// <summary>
        /// список структур, содержащий названия всех форматов
        /// </summary>
        List<FormatSearch> formatSearch_struct = new List<FormatSearch>();

        /// <summary>
        /// русский вариант форматов
        /// </summary>
        string[] formatSearch_strRu = new string[formatCount] { "Скрытые", "Системные", "Обычные"};

        /// <summary>
        /// английский вариант форматов
        /// </summary>
        string[] formatSearch_strEu = new string[formatCount] { "Hidden", "System", "Archive" };

        /// <summary>
        /// bool для отслеживания кнопки включения/отключения чеков у всех box
        /// </summary>
        bool checkAllExp = true;

        /// <summary>
        /// для опредения сохранять данные по нажатия на крестик или нет
        /// </summary>
        bool checkButtonNoSave = true;

        /// <summary>
        /// парсинг на слова FileAttributes
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        private string[] parsingFileAttributes(FileAttributes? mask)
        {
            string text = mask.ToString();
            text = text.Replace(" ", string.Empty);
            string[] arrText = text.Split(',');
            return arrText;
        }

        /// <summary>
        /// перевод из английского в русский
        /// </summary>
        /// <param name="text_eu"></param>
        /// <returns></returns>
        private string convertRu_Eu(string text_eu)
        {
            foreach (FormatSearch fs in formatSearch_struct)
            {
                if (text_eu == fs.nameEu)
                    return fs.nameRu;
            }
            return string.Empty;
        }

        /// <summary>
        /// перевод из русского в английский
        /// </summary>
        /// <param name="text_ru"></param>
        /// <returns></returns>
        private string convertEu_Ru(string text_ru)
        {
            foreach (FormatSearch fs in formatSearch_struct)
            {
                if (text_ru == fs.nameRu)
                    return fs.nameEu;
            }
            return string.Empty;
        }

        /// <summary>
        /// копирование из одного листа чекбоксов информацию о чеках и тексте в другой лист бокс
        /// </summary>
        /// <param name="boxesCopy">лист для копии</param>
        /// <param name="boxesOrig">лист для оригинала</param>
        private void copyCheckBox(List<List<CheckBox>> boxesCopy, List<List<CheckBox>> boxesOrig)
        {
            for (int i = 0; i < boxesOrig.Count; i++)
            {
                boxesCopy.Add(new List<CheckBox>());
                for (int j = 0; j < boxesOrig[i].Count; j++)
                {
                    CheckBox tmp = new CheckBox();
                    tmp.Text = boxesOrig[i][j].Text;
                    tmp.Checked = boxesOrig[i][j].Checked;
                    boxesCopy[i].Add(tmp);
                }
            }
        }

        /// <summary>
        /// инициализация чекбоксов(генерация на панелях)
        /// </summary>
        /// <param name="listCheck"></param>
        private void initializeCheckBox()
        {
            for (int i = 0; i < 2; i++)
            {
                formatSearch_Box.Add(new List<CheckBox>());
                int x = 15;
                int y = 10;
                for (int j = 0; j < formatCount; j++)
                {
                    CheckBox tmp = new CheckBox();
                    tmp.Font = new Font("Microsoft Sans Serif", 9);
                    tmp.Text = formatSearch_struct[j].nameRu;
                    tmp.Size = new Size(100, 25);
                    tmp.Location = new Point(x, y += 30);
                    tmp.Checked = false;
                    formatSearch_Box[i].Add(tmp);
                    this.Controls.Add(tmp);
                    if (i == 0)
                    {
                        foreach(Control c in panel_arrFormatSearch.Controls)
                        {
                            if (c.Name == "panel_formatDir")
                                tmp.Parent = c;
                        }
                    }
                    if (i == 1)
                    {
                        foreach (Control c in panel_arrFormatSearch.Controls)
                        {
                            if (c.Name == "panel_formatFile")
                                tmp.Parent = c;
                        }
                    }
                    tmp.BringToFront();
                }
            }
        }

        /// <summary>
        /// конвентирование из FileAttributes в checkbox.checked
        /// </summary>
        private void convertFAtt_bool()
        {
            string[] arrTextFile = parsingFileAttributes(maskFile);
            string[] arrTextDir = parsingFileAttributes(maskDir);


            for (int i = 0; i < formatSearch_Box.Count; i++)
            {
                int t = 0;
                for (int j = 0; j < formatSearch_Box[i].Count(); j++)
                {
                    if (i == 0 && t < arrTextDir.Length)
                        if (convertRu_Eu(arrTextDir[t]) == formatSearch_Box[i][j].Text)
                        {
                            formatSearch_Box[i][j].Checked = true;
                            t++;
                        }
                    if (i == 1 && t < arrTextFile.Length)
                        if (convertRu_Eu(arrTextFile[t]) == formatSearch_Box[i][j].Text)
                        {
                            formatSearch_Box[i][j].Checked = true;
                            t++;
                        } 
                }
            }
        }

        /// <summary>
        /// конвентирование из checkbox.checked в FileAttributes
        /// </summary>
        private void convert_ckbox_FAtt(List<List<CheckBox>> boxes)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                string text = string.Empty;
                for (int j = 0; j < boxes[i].Count; j++)
                {
                    if (boxes[i][j].Checked == true)
                    {
                        text += convertEu_Ru(boxes[i][j].Text) + ",";
                    }
                }
                text = text.Remove(text.Length - 1);
                if (i == 0)
                    Enum.TryParse(text, out maskDir__);
                if (i == 1)
                    Enum.TryParse(text, out maskFile__);
            }
        }

        public Form_formatSearch(FileAttributes? formatFile,FileAttributes? formatDir)
        {
            InitializeComponent();
            for (int i = 0; i < formatCount; i++)
            {
                FormatSearch fs_struct = new FormatSearch();
                fs_struct.nameRu = formatSearch_strRu[i];
                fs_struct.nameEu = formatSearch_strEu[i];
                formatSearch_struct.Add(fs_struct);
            }
            maskFile = formatFile;
            maskDir = formatDir;
            initializeCheckBox();
            convertFAtt_bool();
            copyCheckBox(formatSearch_Box_copy, formatSearch_Box);
        }

        public Form_formatSearch()
        {
            InitializeComponent();
            // заполнение стрктуры
            for (int i = 0; i < formatCount; i++)
            {
                FormatSearch fs_struct = new FormatSearch();
                fs_struct.nameRu = formatSearch_strRu[i];
                fs_struct.nameEu = formatSearch_strEu[i];
                formatSearch_struct.Add(fs_struct);
            }
            // заполнение листа с чеками(false)
            for (int i = 0; i < 2; i++)
            {
                listCheck.Add(new List<bool>());
                for (int j = 0; j < formatCount; j++)
                {
                    listCheck[i].Add(false);
                }
            }
            initializeCheckBox();
        }

        public FileAttributes[] getFormatList()
        {
            FileAttributes[] arrAtr = new FileAttributes[2] { maskDir__, maskFile__};
            return arrAtr;
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
                foreach(List<CheckBox> list_box in formatSearch_Box)
                    foreach (CheckBox box in list_box)
                        box.Checked = true;
                checkAllExp = false;
                button_allClickExpanxion.Text = "Убрать все";
            }
            else
            {
                foreach (List<CheckBox> list_box in formatSearch_Box)
                    foreach (CheckBox box in list_box)
                        box.Checked = false;
                checkAllExp = true;
                button_allClickExpanxion.Text = "Выбрать все";
            }
        }

        /// <summary>
        /// Проверка на выборы в чек боксе(минимум по каждому формату необходимо)
        /// </summary>
        /// <returns></returns>
        private bool checkMask()
        {
            bool answer_file = false;
            bool answer_dir = false;
            for (int i = 0; i < formatSearch_Box.Count; i++)
            {
                for (int j = 0; j < formatSearch_Box[i].Count; j++)
                {
                    if (i == 0 && formatSearch_Box[i][j].Checked == true)
                    {
                        answer_dir = true;
                    }
                    else if (i == 1 && formatSearch_Box[i][j].Checked == true)
                    {
                        answer_file = true;
                    }
                }
            }
           if (answer_file == false || answer_dir == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_notSave_Click(object sender, EventArgs e)
        {
            if (checkMask() == false)
            {
                MessageBox.Show("Выберите формат каталогов и файлов для поиска", "Ошибка");
                return;
            }
            else
            {
                checkButtonNoSave = true;
                convert_ckbox_FAtt(formatSearch_Box_copy);
                this.Close();
            }
        }

        private void button_saveForm_Click(object sender, EventArgs e)
        {
            if (checkMask() == false)
            {
                MessageBox.Show("Выберите формат каталогов и файлов для поиска", "Ошибка");
                return;
            }
            checkButtonNoSave = false;
            convert_ckbox_FAtt(formatSearch_Box);
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
                    convert_ckbox_FAtt(formatSearch_Box_copy);
            }
        }
    }
}
