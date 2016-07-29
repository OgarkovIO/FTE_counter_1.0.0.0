using Loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTE_counter
{
    public partial class Options_EXCEL : Form
    {
        private int _fields_upload_type;

        public Options_EXCEL()
        {
            InitializeComponent();
            ReadConfig();
            _fields_upload_type = 0;
            /*
            Options_save ops = new Options_save();
            ops.Fields_upload_type += new Options_save.OtionsEvent(Income_Fields_Upload_Type);
            */
        }
        /*
        public void Income_Fields_Upload_Type(string Fields_upload_type)
        {
            Fields_upload_type = _fields_upload_type.ToString();
        }
        */
        private void Discard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReadConfig()
        {
            Options_save ops = new Options_save();//Объявляем(посредством ключегого слова new) экземпляр созданного нами класса Options_save, ops.
            ops.ReadConfig();//Выполняем Метод класса Options_save - ReadConfig() из его экземпляра ops
            int.TryParse(ops.Fields_upload_type, out _fields_upload_type);
            if (_fields_upload_type == 0)
            {
                comboBoxEXCELParam.SelectedItem = "Только необходимые данные";
            }
            if (_fields_upload_type == 1)
            {
                comboBoxEXCELParam.SelectedItem = "Полная загрузка";
            }
        }


        private void Applay_Click(object sender, EventArgs e)
        {
            switch (comboBoxEXCELParam.SelectedIndex)
            {
                case 0:
                _fields_upload_type = 0;
                break;
                case 1:
                _fields_upload_type = 1;
                break;
            }
            //Income_Fields_Upload_Type(_fields_upload_type.ToString());
            Close();
        }

    }
}
