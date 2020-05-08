using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilituSearchFile
{
    public class AddFunc
    {
        /// <summary>
        /// делим pickpath(несколько путей в одном) на маленькие пути
        /// </summary>
        /// <param name="fullpath">pickpath(несколько путей в одном)</param>
        /// <param name="countFormat">количество выбранных расширений</param>
        /// <returns></returns>
        public int parserPath(string fullpath, int countCheckExpansion, ref List<string> listPathFile)
        {
            string[] arrPath = fullpath.Split(';');
            while (countCheckExpansion > 0)
            {
                for (int i = 0; i < arrPath.Length; i++)
                {
                    listPathFile.Add(arrPath[i]);
                }
                countCheckExpansion--;
            }
            return arrPath.Length;
        }

        /// <summary>
        /// Проверка на выборы в чек боксе(минимум по каждому формату необходимо)
        /// </summary>
        /// <returns></returns>
        public bool checkMask(Panel panel)
        {
            foreach (Control contrl in panel.Controls)
            {
                if ((contrl.GetType()).Equals(typeof(CheckBox)))
                {
                    CheckBox box = (CheckBox)contrl;
                    if (box.Checked == true)
                        return true;
                }
            }
            return false;
        }

    }
}
