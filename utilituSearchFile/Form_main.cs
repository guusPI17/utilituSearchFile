using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace utilituSearchFile
{
    public partial class Form_main : Form
    {
        /// <summary>
        /// хранит информацию об формата поиска файлов
        /// </summary>
        private List<CheckBox> listFormatSearch = new List<CheckBox>();

        /// <summary>
        /// лист чек боксов расширений
        /// </summary>
        private List<CheckBox> expansionFile_Box = new List<CheckBox>();

        /// <summary>
        /// количество завершеных потоков
        /// </summary>
        private static int countRemoveWork = 0;

        /// <summary>
        /// количество найденных файлов
        /// </summary>
        private static int countFoundFile = 0;

        /// <summary>
        /// лист потоков поиска
        /// </summary>
        private List<BackgroundWorker> listBackgroundWorker = new List<BackgroundWorker>();

        /// <summary>
        /// завершающий поток при синхронной операции(сортировка и добавление в файл)
        /// </summary>
        private BackgroundWorker backgroundWorkerEnd = new BackgroundWorker();

        /// <summary>
        /// лист путей для поиска файлов
        /// </summary>
        private List<string> listPathFile = new List<string>();

        /// <summary>
        /// мьютекс для распределения доступа к файлу под запись результатов(когда не требуется сортировка)
        /// </summary>
        private Mutex mutexObj = new Mutex();


        public Form_main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// инициализация потоков для поиска
        /// </summary>
        /// <param name="countWork">количество потоков</param>
        /// <param name="countCheckExpansion">количество выбранных расширений</param>
        private void initilizeListWork(int countWork, int countCheckExpansion)
        {
            while (countCheckExpansion > 0)
            {
                for (int i = 0; i < countWork; i++)
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.WorkerSupportsCancellation = true;
                    worker.DoWork += new DoWorkEventHandler(backgroundWorker_searchFile_DoWork);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_searchFile_RunWorkerCompleted);
                    listBackgroundWorker.Add(worker);
                }
                countCheckExpansion--;
            }
        }

        /// <summary>
        /// функция по получения файлов
        /// </summary>
        /// <param name="path">путь</param>
        /// <param name="searchPattern">расширение для поиска</param>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private IEnumerable<String> GetAllFiles(string path, string searchPattern, BackgroundWorker worker, DoWorkEventArgs e)
        {
            return Directory.EnumerateFiles(path, searchPattern)
                               .Union(Directory.EnumerateDirectories(path)
                               .SelectMany(d =>
                               {
                                   if (worker.CancellationPending)
                                   {
                                       e.Cancel = true;
                                       return null;
                                   }
                                   try
                                   {
                                       return GetAllFiles(d, searchPattern, worker, e);
                                   }
                                   catch (UnauthorizedAccessException)
                                   {
                                       return Enumerable.Empty<String>();
                                   }
                               }));

        }
        /// <summary>
        /// функция проверки файлов на содержимое
        /// </summary>
        /// <param name="file">путья до файла</param>
        /// <param name="searchText">искомый текст</param>
        private void findTextInFile(string file,string searchText)
        {
            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
            Encoding enc = Encoding.GetEncoding(1251);
            string tmp = File.ReadAllText(file, enc);
            if (tmp.IndexOf(searchText, StringComparison.CurrentCulture) != -1)
            {
                Invoke(new Action(() => countFoundFile++)); // подсчет количество файлов
                Invoke(new Action(() => listBox_foundFile.Items.Add(file))); // добавление путей файлов в listBox
                Invoke(new Action(() => label_countFoundFile.Text = Convert.ToString(countFoundFile)));
                if (checkBox_savelog.Checked == true && checkBox_sortFoundFile.Checked == false)  // если сохранить лог, но не сортировать, то сразу сохраняем в файл
                {
                    mutexObj.WaitOne();
                    using (StreamWriter sw = new StreamWriter(textBox_pathFileLog.Text, true, Encoding.Default))
                    {
                        sw.WriteLine(file);
                    }
                    mutexObj.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// функция поиска для потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_searchFile_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                string searchText = string.Empty;
                string dirPath = string.Empty;
                string myFormat = string.Empty;
                object[] args = e.Argument as object[];
                Invoke(new Action(() => searchText = richTextBox_searchText.Text));
                Invoke(new Action(() => dirPath = args[0] as string));
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                
                IEnumerable<String> files = GetAllFiles(dir.FullName, args[1] as string, worker, e);
                foreach (var file in files)
                {
                    if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked==true) != null
                        && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) != null
                        && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) != null)
                    {
                        if ((File.GetAttributes(file).HasFlag(FileAttributes.System)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) != null
                        && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) != null
                        && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) == null)
                    {
                        if (((File.GetAttributes(file).HasFlag(FileAttributes.System)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                           && !(File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) != null
                       && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) == null
                       && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) != null)
                    {
                        if (((File.GetAttributes(file).HasFlag(FileAttributes.System)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                           && !(File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) 
                           && !((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) != null
                      && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) == null
                      && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) == null)
                    {
                        if (((File.GetAttributes(file).HasFlag(FileAttributes.System)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden))) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                            && !(File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                            && !((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                            && !(File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) == null
                       && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) != null
                       && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) != null)
                    {
                        if (((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))) ||
                           (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                            && !(File.GetAttributes(file).HasFlag(FileAttributes.System))
                            && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)))
                             && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) == null
                       && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) != null
                       && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) == null)
                    {
                        if (((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) ||
                           ((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                            && !(File.GetAttributes(file).HasFlag(FileAttributes.System))
                            && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)))
                             && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                              && !(File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }

                    else if (listFormatSearch.Find(item => item.Text == "системный" && item.Checked == true) == null
                      && listFormatSearch.Find(item => item.Text == "скрытый" && item.Checked == true) == null
                      && listFormatSearch.Find(item => item.Text == "обычный" && item.Checked == true) != null)
                    {
                        if ((File.GetAttributes(file).HasFlag(FileAttributes.Archive))
                             && !(File.GetAttributes(file).HasFlag(FileAttributes.System))
                            && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)))
                             && !((File.GetAttributes(file).HasFlag(FileAttributes.System)) && (File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive)))
                         && !(File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                            && !((File.GetAttributes(file).HasFlag(FileAttributes.Hidden)) && (File.GetAttributes(file).HasFlag(FileAttributes.Archive))))
                        {
                            Console.WriteLine("Attributes are : {0} : {1}", file, File.GetAttributes(file).ToString());
                            findTextInFile(file, searchText);
                        }
                    }
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}: {1}", exc.GetType().Name, exc.Message);
            }
        }

        /// <summary>
        /// функция при заверешение потока для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_searchFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            countRemoveWork++;
            if (countRemoveWork == listBackgroundWorker.Count)
            {
                if (checkBox_savelog.Checked == true && checkBox_sortFoundFile.Checked == true) 
                {
                    backgroundWorkerEnd = new BackgroundWorker();
                    backgroundWorkerEnd.WorkerSupportsCancellation = true;
                    backgroundWorkerEnd.DoWork += new DoWorkEventHandler(backgroundWorker_writeInFile_DoWork);
                    backgroundWorkerEnd.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_writeInFile_RunWorkerCompleted);

                    if (backgroundWorkerEnd.IsBusy != true)
                    {
                        button_searchFile.Text = "Запись в файл...";
                        backgroundWorkerEnd.RunWorkerAsync();
                    }
                }
                else
                {
                    label_countFoundFile.Text = Convert.ToString(listBox_foundFile.Items.Count);
                    button_searchFile.Text = "Начать поиск";
                    unBut();
                    button_searchFile.Enabled = true;
                }
            }
        }

        /// <summary>
        /// функция конечного потока(при сохранение в файл и сортировки) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_writeInFile_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            foreach (var file in listBox_foundFile.Items)
            {
                using (StreamWriter sw = new StreamWriter(textBox_pathFileLog.Text, true, Encoding.Default))
                {
                    if (sw != null) // исключть последнию нулевую строку
                        sw.WriteLine(file);
                }
            }
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// функция при заверешение конечного потока(при сохраение в файл и сортировки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_writeInFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label_countFoundFile.Text = Convert.ToString(listBox_foundFile.Items.Count);
            button_searchFile.Text = "Начать поиск";
            button_searchFile.Enabled = true;
            unBut();
        }

        /// <summary>
        /// Обновлнение переменных(summa,countremoveWork,listFoundFile,
        /// expansionFile_chek,listBox_foundFile.Items) до состояние по умолчанию
        /// </summary>
        private void updateZeroVar()
        {
            countFoundFile = 0;
            countRemoveWork = 0;
            listBox_foundFile.Items.Clear();
        }

        /// <summary>
        /// отключение радиокнопок,чекбоксов
        /// </summary>
        private void disBut()
        {
            radioButton_pickFile.Enabled = false;
            radioButton_oneFile.Enabled = false;
            radioButton_allFile.Enabled = false;
            button_searchFile.Enabled = false;
            checkBox_savelog.Enabled = false;
            button_openForm_expansionFile.Enabled = false;
            button_openForm_formatSearch.Enabled = false;
        }

        /// <summary>
        /// включение радиокнопок,чекбоксов
        /// </summary>
        private void  unBut()
        {
            radioButton_pickFile.Enabled = true;
            radioButton_oneFile.Enabled = true;
            radioButton_allFile.Enabled = true;
            button_searchFile.Enabled = true;
            checkBox_savelog.Enabled = true;
            button_openForm_expansionFile.Enabled = true;
            button_openForm_formatSearch.Enabled = true;
        }

        /// <summary>
        /// Кнопка запуска поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_searchFile_Click(object sender, EventArgs e)
        {
            listBackgroundWorker.Clear();
            updateZeroVar();
            if (listFormatSearch.Count == 0)
            {
                MessageBox.Show("Необходимо настроить формат поиска", "Ошибка");
                return;
            }
            AddFunc aF = new AddFunc();
            List<string> expansionFile_check = new List<string>(); /// лист выбраных чеков расширений
            bool tmp = false;
            for (int i = 0; i < expansionFile_Box.Count; i++)
            {
                if (expansionFile_Box[i].Checked == true)
                {
                    tmp = true;
                    expansionFile_check.Add("*" + expansionFile_Box[i].Text);
                }
            }
            if (tmp == false)
            {
                MessageBox.Show("Необходимо настроить расширения файлов для поиска", "Ошибка");
                return;
            }
            List<string> listPathFile_copy = new List<string>();
            if (radioButton_allFile.Checked == true)
            {
                string[] drives = Environment.GetLogicalDrives();
                string path = string.Join(";", drives);
                if (aF.parserPath(path, expansionFile_check.Count, ref listPathFile_copy) == 0)
                    return;
                else
                {
                    listPathFile_copy.Clear();
                    initilizeListWork(aF.parserPath(path, expansionFile_check.Count, ref listPathFile_copy), expansionFile_check.Count);
                }
            }
            else if (radioButton_oneFile.Checked == true)
            {
                if (aF.parserPath(textBox_onePathDirSearch.Text, expansionFile_check.Count, ref listPathFile_copy) == 0)
                    return;
                else
                {
                    listPathFile_copy.Clear();
                    initilizeListWork(aF.parserPath(textBox_onePathDirSearch.Text, expansionFile_check.Count, ref listPathFile_copy), expansionFile_check.Count);
                }
            }
            else if (radioButton_pickFile.Checked == true)
            {
                if (aF.parserPath(textBox_pickPathDirSearch.Text, expansionFile_check.Count, ref listPathFile_copy) == 0)
                    return;
                else
                {
                    listPathFile_copy.Clear();
                    initilizeListWork(aF.parserPath(textBox_pickPathDirSearch.Text, expansionFile_check.Count, ref listPathFile_copy), expansionFile_check.Count);
                }
            }
            listPathFile = new List<string>(listPathFile_copy);
            if (textBox_pathFileLog.Text == string.Empty && checkBox_savelog.Checked == true) 
            {
                MessageBox.Show("Введите путь для сохранения результата", "Ошибка");
                return;
            }
            if (File.Exists(textBox_pathFileLog.Text)) 
             File.Delete(textBox_pathFileLog.Text);
            int nomer = listBackgroundWorker.Count / expansionFile_check.Count; // подсчет через сколько потоков менять расширение
            for (int i = 0, j = 0, t = 0; i < listBackgroundWorker.Count; i++, t++)  // запуск потоков
            {
                if (t == nomer)
                {
                    j++;
                    t = 0;
                }
                if (listBackgroundWorker[i].IsBusy != true)
                {
                    object[] eventArgs = new object[] { listPathFile[i], expansionFile_check[j] };
                    listBackgroundWorker[i].RunWorkerAsync(eventArgs);
                    disBut();
                    button_searchFile.Text = "Идет поиск...";
                }
            }
        }

        /// <summary>
        /// Кнопка отмены поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remSearchFile_Click(object sender, EventArgs e)
        {
            foreach (BackgroundWorker worker in listBackgroundWorker)
            {
                worker.CancelAsync();
            }
        }


        private void button_openDirSearch_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_onePathDirSearch.Text = dialog.SelectedPath;
                }
            }
        }

        private void radioButton_checkFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_pickFile.Checked == true) 
            {
                textBox_pickPathDirSearch.Enabled = true;
                textBox_onePathDirSearch.Enabled = false;
                button_openDirSearch.Enabled = false;
                textBox_onePathDirSearch.Text = string.Empty;
            }
            if (radioButton_oneFile.Checked == true)
            {
                textBox_pickPathDirSearch.Enabled = false;
                textBox_onePathDirSearch.Enabled = true;
                button_openDirSearch.Enabled = true;
                textBox_pickPathDirSearch.Text = string.Empty;
            }
            if (radioButton_allFile.Checked == true)
            {
                textBox_pickPathDirSearch.Enabled = false;
                textBox_onePathDirSearch.Enabled = false;
                button_openDirSearch.Enabled = false;
                textBox_onePathDirSearch.Text = string.Empty;
                textBox_pickPathDirSearch.Text = string.Empty;
            }
        }

        private void checkBox_checkSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_savelog.Checked == true)
            {
                textBox_pathFileLog.Enabled = true;
                button_openFileLog.Enabled = true;
            }
            else
            {
                textBox_pathFileLog.Enabled = false;
                button_openFileLog.Enabled = false;
            }
            if (checkBox_sortFoundFile.Checked == true) 
            {
                listBox_foundFile.Sorted = true;
            }
            else
            {
                listBox_foundFile.Sorted = false;
            }
        }

        private void button_openFileLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.Cancel)
                return;
            textBox_pathFileLog.Text = openFile.FileName;
        }

        /// <summary>
        /// Открытие настройки форматов каталогов для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_openForm_formatSearch_Click(object sender, EventArgs e)
        {
            Form_expansionFile tmp;
            if (expansionFile_Box.Count != 0)
                tmp = new Form_expansionFile(expansionFile_Box);
            else
                tmp = new Form_expansionFile();
            tmp.ShowDialog();
            expansionFile_Box = new List<CheckBox>(tmp.getExpansionFile_Box());
        }

        /// <summary>
        /// Открытие настройки расширений файлов для поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_openForm_expansionFile_Click(object sender, EventArgs e)
        {
            Form_formatSearch tmp;
            if (listFormatSearch.Count == 0) 
                tmp = new Form_formatSearch();
            else
                tmp = new Form_formatSearch(listFormatSearch);
            tmp.ShowDialog();
            listFormatSearch = new List<CheckBox>(tmp.getFormatList());

        }

        private void инструкцияПопутьДляПоискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "\t\t\t<Путь для поиска>\n" +
                "При выборе варианта пути 'искать по выбору', требуется вводить путь в ручную.\n" +
                "При вводе пути в ручную имеется возможность вбить через 'точку с запятой'(;) без пробелов " +
               "другие пути для поиска файлов.\n" + @"Пример: D:\testDir;C:\Windows;C:\SystemFile";
            MessageBox.Show(text, "Помощь");
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "\t\t<Сортировать результирующий файл>\n" +
               "При выборе варианта 'сортировать результирующий файл', после окончания поиска все найденные пути файлов " +
               "будут записаны в заранее выбранный Вами файл в алфавитном порядке.\n" +
               "Данная функция имеет возмоность сортировать панель вывода найденных путей. Для этого требуется активироваь ее в любой момент времени";
            MessageBox.Show(text, "Помощь");
        }
    }
}
