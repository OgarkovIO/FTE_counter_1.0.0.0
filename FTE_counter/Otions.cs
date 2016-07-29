using System;
using System.Windows.Forms;
using Loader;

namespace FTE_counter
{
    public partial class Options : Form
    {
        private int _sm_upload_type;
        private int _fields_upload_type;

        public Options()//Форма сохранения настроек.
        {
            InitializeComponent();//...Метод InitializeComponent() - стандартные самсоздающеиеся строки, которые инициализируют компоненты формы, прописывает свойства, поля форм, обработчики событий и.т.д...
            ReadConfig();
        }

        public void Income_Fields_Upload_Type(string Fields_upload_type)
        {
            int IncomData;
            int.TryParse(Fields_upload_type, out IncomData);
            _fields_upload_type = IncomData;
        }

        private void FileView_Click(object sender, EventArgs e)//Событие нажатия кнопки "Обзор" формы настроек, для выбора пути к файлу.
        {
            //string listAddres = "";//Пустая, незадействованная сейчас переменная, на случай, если хранить настройки буду не в самой форме.
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                PathTextBox.Text = fdl.FileName; //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }

        }

        private void SaveConfig_Click(object sender, EventArgs e)//Событие нажатия кнопки Сохранить формы "Options".
        {
            Options_save ops = new Options_save();
            ops.saveConfig(PathTextBox.Text, _sm_upload_type);//Применяем метод saveConfig() класса Options_save через экземпляр даннрого класса ops на текстовое поле(свойство .Text) нашего элемента PathTextBox.
            //ops.Fields_upload_type = _fields_upload_type.ToString();
            Close();//Закрываем нашу форму, посредством метода Close();

            MessageBox.Show("Для вступления в силу настроек перезапустите программу!");//Выводим сообщение для пользователя посредством системного класса MessageBox и его метода Show().
        }


        private void ReadConfig()
        {
            Options_save ops = new Options_save();//Объявляем(посредством ключегого слова new) экземпляр созданного нами класса Options_save, ops.
            ops.ReadConfig();//Выполняем Метод класса Options_save - ReadConfig() из его экземпляра ops
            PathTextBox.Text = ops.DBPath;
            int.TryParse(ops.Sm_upload_type, out _sm_upload_type);
            if (_sm_upload_type == 1)
            {
                radioButtonSAP.Checked = true;
            }
            if (_sm_upload_type == 0)
            {
                radioButtonCSV.Checked = true;
            }
        }

        private void DiscardConfig_Click(object sender, EventArgs e)//Событие нажатя кнопки Отмена формы "Options".
        {
            Close();//Закрываем нашу форму, посредством метода Close();
        }

        private void radioButtonCSV_CheckedChanged(object sender, EventArgs e)
        {
            _sm_upload_type = 0;
            buttonExcelSM.Enabled = false;
        }

        private void radioButtonSAP_CheckedChanged(object sender, EventArgs e)
        {
            _sm_upload_type = 1;
            buttonExcelSM.Enabled = true;
        }

        public int Sm_upload_type
        {
            get
            {
                return _sm_upload_type;
            }

            set
            {
                _sm_upload_type = value;
            }
        }

        public int Fields_upload_type
        {
            get
            {
                return _fields_upload_type;
            }

            set
            {
                _fields_upload_type = value;
            }
        }

        private void buttonExcelSM_Click(object sender, EventArgs e)
        {
            Options_EXCEL dlg = new Options_EXCEL();
            dlg.Show();
        }
    }
}
