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
    public partial class CnetralForm : Form
    {
        private string _dbpath;//Создаём приватную переменную для хранения данных о месте размещения файла.

        public CnetralForm()
        {
            InitializeComponent();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            Options dlg = new Options();//Создаём экземпляр нашего класса Otions (той формы которую мы используем для сохранения настроек) который назовём  dlg
            dlg.PathTextBox.Text = _dbpath;//Записываем посредством свойства text в элемент формы PathTextBox(содержится в нашем созданном экземпляре класса dlg)
            dlg.Show();//Отображаем нашу форму пользователю.

            Options_save ops = new Options_save();//Туту-же создаём экземпляр класса который содержит методы сохранения данных в файл.
            ops.ReadConfig();//Выполняем Метод класса Options_save - ReadConfig() из его экземпляра ops
            dlg.PathTextBox.Text = ops.DBPath;
        }
        public string DBPath    //Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _dbpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _dbpath = value; } //set - Присваевает значеия, value - хранит значение.
        }

    }
}
