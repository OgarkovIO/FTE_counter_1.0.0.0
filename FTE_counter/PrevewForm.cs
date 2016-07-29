using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Loader;

namespace FTE_counter
{
    public partial class PreviewForm : Form

    {
        private static string _dbpath;

        public PreviewForm()
        {
            InitializeComponent();
            GetDBPath();
        }

        private void GetDBPath()
        {
            Options_save ops = new Options_save();

            ops.ReadConfig();

            _dbpath = ops.DBPath;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Options dlg = new Options();//Создаём экземпляр нашего класса Otions (той формы которую мы используем для сохранения настроек) который назовём  dlg
            // dlg.PathTextBox.Text = _dbpath;//Записываем посредством свойства text в элемент формы PathTextBox(содержится в нашем созданном экземпляре класса dlg)
            dlg.Show();//Отображаем нашу форму пользователю.

            //Loader.Options_save ops = new Options_save();//Туту-же создаём экземпляр класса который содержит методы сохранения данных в файл.
        }

        private void Start_CenralForm_Click(object sender, EventArgs e)
        {
            ManageForm ctf = new ManageForm();//Создаём экземпляр нашего класса Otions (той формы которую мы используем для сохранения настроек) который назовём  dlg
            ctf.Show();//Отображаем нашу форму пользователю.
        }

        private void Load_Data_Click(object sender, EventArgs e)
        {
            LoaderForm ltf = new LoaderForm();
            ltf.Show();
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            ReportForm rep = new ReportForm();//Создаём экземпляр нашего класса Otions (той формы которую мы используем для сохранения настроек) который назовём  dlg
            rep.Show();//Отображаем нашу форму пользователю.
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static string DBPath    //Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _dbpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _dbpath = value; } //set - Присваевает значеия, value - хранит значение.
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
