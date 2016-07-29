using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseConnector;
using Loader;
using System.Threading;

namespace FTE_counter
{
    public partial class LoaderForm : Form
    {
        public LoaderForm()
        {
            InitializeComponent();
            ops.ReadConfig();
        }

        Options_save ops = new Options_save();

        private bool _chekboxsensor;

        private void buttonZnoSD_Click(object sender, EventArgs e)//Событие нажатия кнопки "Обзор" формы настроек, для выбора пути к файлу.
        {
            //string listAddres = "";//Пустая, незадействованная сейчас переменная, на случай, если хранить настройки буду не в самой форме.
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                textBoxZnoSD.Text = fdl.FileName; //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }
        }

        private void buttonZnrSD_Click(object sender, EventArgs e)//Событие нажатия кнопки "Обзор" формы настроек, для выбора пути к файлу.
        {
            //string listAddres = "";//Пустая, незадействованная сейчас переменная, на случай, если хранить настройки буду не в самой форме.
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                textBoxZnrSD.Text = fdl.FileName; //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }
        }

        private void buttonZnoSM_Click(object sender, EventArgs e)//Событие нажатия кнопки "Обзор" формы настроек, для выбора пути к файлу.
        {
            //string listAddres = "";//Пустая, незадействованная сейчас переменная, на случай, если хранить настройки буду не в самой форме.
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                textBoxZnoSM.Text = fdl.FileName; //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }
        }

        private void buttonIncSM_Click(object sender, EventArgs e)//Событие нажатия кнопки "Обзор" формы настроек, для выбора пути к файлу.
        {
            //string listAddres = "";//Пустая, незадействованная сейчас переменная, на случай, если хранить настройки буду не в самой форме.
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                textBoxIncSM.Text = fdl.FileName; //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }
        }

        private void checkBoxZnoSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZnoSD.Checked == true)
            {
                textBoxZnoSD.Enabled = true;
                buttonZnoSD.Enabled = true;
            }
            else
            {
                textBoxZnoSD.Enabled = false;
                buttonZnoSD.Enabled = false;
            }
            CheckBoxSensor();
        }

        private void checkBoxZnrSD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZnrSD.Checked == true)
            {
                textBoxZnrSD.Enabled = true;
                buttonZnrSD.Enabled = true;
            }
            else
            {
                textBoxZnrSD.Enabled = false;
                buttonZnrSD.Enabled = false;
            }
            CheckBoxSensor();
        }

        private void checkBoxZnoSM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZnoSM.Checked == true)
            {
                textBoxZnoSM.Enabled = true;
                buttonZnoSM.Enabled = true;
            }
            else
            {
                textBoxZnoSM.Enabled = false;
                buttonZnoSM.Enabled = false;
            }
            CheckBoxSensor();
        }

        private void checkBoxIncSM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIncSM.Checked == true)
            {
                textBoxIncSM.Enabled = true;
                buttonIncSM.Enabled = true;
            }
            else
            {
                textBoxIncSM.Enabled = false;
                buttonIncSM.Enabled = false;
            }
            CheckBoxSensor();
        }
        private void CheckBoxSensor()
        {
            if (checkBoxZnoSD.Checked == true || checkBoxZnrSD.Checked == true || checkBoxZnoSM.Checked == true || checkBoxIncSM.Checked == true)
            {
                _chekboxsensor = true;
                LoadData.Enabled = true;
            }
            else
            {
                _chekboxsensor = false;
                LoadData.Enabled = false;
            }
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            DataLoading();
            DBManager dbc = new DBManager();
            dbc.DBPath = ops.DBPath;
            if (checkBoxIncSM.Checked)
            {
                dbc.SM_INC_LoadDataToDB(textBoxIncSM.Text);
            }
            if (checkBoxZnoSM.Checked)
            {
                dbc.SM_ZNO_LoadDataToDB(textBoxZnoSM.Text);
            }
            if (checkBoxZnoSD.Checked)
            {
                dbc.SD_ZNO_LoadDataToDB(textBoxZnoSD.Text);
            }
            if (checkBoxZnrSD.Checked)
            {
                dbc.SD_ZNR_LoadDataToDB(textBoxZnrSD.Text);
            }
        }

        private void DataLoading()
        {
            DBManager dbc = new DBManager();

            int Count = 10000;

            int[] Mas_1 = new int[Count];
            int[] Mas_2 = new int[Count];

            for (int i = 0; i < Count; ++i)
            {
                
            }

            progressBarLoad.Maximum = Count;
            progressBarLoad.Value = 0;

            Thread t = new Thread(new ThreadStart(delegate {
                for (int i = 0; i < Count; ++i)
                {
                    this.Invoke(new ThreadStart(delegate
                    {
                        progressBarLoad.Value++;
                        if (i < Count)
                        {
                            progressBarLoad.Enabled = true;
                            LoadData.Enabled = false;
                        }
                        else
                        {
                            progressBarLoad.Enabled = false;
                            LoadData.Enabled = true;
                        }
                    }));
                }
            }));
            t.Start();
        }
    }
}
