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
        #region fields
        private int _count;

        private bool _chekboxsensor;

        private int _min;

        private string _dbpath;

        private int _sm_upload_type;
        #endregion

        #region Auxiliary methods and class designer
        public LoaderForm()
        {
            InitializeComponent();

            ReadConfig();

            _count = 0;

            _min = 0;

            FormChange();
        }

        private void FormChange()
        {
            if (_sm_upload_type == 1)
            {
                checkBoxZnoSM.Text = "Маршрутизация SM:";
                checkBoxIncSM.Text = "Объединённая выгрузка SM:";
                checkBoxZnoSM.Enabled = false;
            }
            if (_sm_upload_type == 0)
            {
                checkBoxZnoSM.Text = "Загрузка ЗНО из SM:";
                checkBoxIncSM.Text = "Выгрузка инцидентов из SM";
                //radioButtonCSV.Checked = true;
            }
        }

        private void ReadConfig()
        {
            Options_save ops = new Options_save();
            ops.ReadConfig();

            _dbpath = ops.DBPath;
            int.TryParse(ops.Sm_upload_type, out _sm_upload_type);
        }
        #endregion

        #region Methods event handlers form and helper methods
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

        private void LoadData_Click(object sender, EventArgs e)
        {
            if (_sm_upload_type == 1)
            {
                DataLoadingFromExcel();
                LoadData.Enabled = false;
            }
            if (_sm_upload_type == 0)
            {
                DataLoading();
                LoadData.Enabled = false;
            }
            /*if (checkBoxIncSM.Checked)
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
            }*/
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
        #endregion

        #region Methods for processing queries to the database and Methods for the second thread
        private void DataLoading()
        {
            
            DBDataLoader dbl = new DBDataLoader(_dbpath);

            BackgroundWorker bw = new BackgroundWorker();

            _count = 0;

            _min = 0;

            dbl.Counter = 0;

            dbl.Сount = 0;

            if (checkBoxIncSM.Checked)
            {
                _count += dbl.CountData(textBoxIncSM.Text);
            }
            if (checkBoxZnoSM.Checked)
            {
                _count += dbl.CountData(textBoxZnoSM.Text);
            }
            if (checkBoxZnoSD.Checked)
            {
                _count += dbl.CountData(textBoxZnoSD.Text);
            }
            if (checkBoxZnrSD.Checked)
            {
                _count += dbl.CountData(textBoxZnrSD.Text);
            }

            progressBarLoad.Maximum = _count;
            progressBarLoad.Value = _min;

            if (checkBoxIncSM.Checked)
            {
                dbl.FileINCSMPath = textBoxIncSM.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SM_INC_LoadDataToDB);
            }
            if (checkBoxZnoSM.Checked)
            {
                dbl.FileZNOSMPath = textBoxZnoSM.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SM_ZNO_LoadDataToDB);
            }
            if (checkBoxZnoSD.Checked)
            {
                dbl.FileZNOSDPath = textBoxZnoSD.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SD_ZNO_LoadDataToDB);
            }
            if (checkBoxZnrSD.Checked)
            {
                dbl.FileZNRSDPath = textBoxZnrSD.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SD_ZNR_LoadDataToDB);
            }

            bw.RunWorkerAsync();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void DataLoadingFromExcel()
        {
            DBDataLoader dbl = new DBDataLoader(_dbpath);

            BackgroundWorker bw = new BackgroundWorker();

            _count = 0;

            _min = 0;

            dbl.Counter = 0;

            dbl.Сount = 0;

            if (checkBoxIncSM.Checked)
            {
                _count += dbl.DB_COUNT_EXCEL_TABLE_ROWS(textBoxIncSM.Text,"Sheet1$","IM");
                _count += dbl.DB_COUNT_EXCEL_TABLE_ROWS(textBoxIncSM.Text,"Sheet1$","ЗНО");
            }
            if (checkBoxZnoSM.Checked)
            {
                //_count += dbl.DB_COUNT_IM_EXCEL_TABLE_ROWS(textBoxZnoSM.Text, "Sheet1$","ЗНО");
            }
            if (checkBoxZnoSD.Checked)
            {
                _count += dbl.CountData(textBoxZnoSD.Text);
            }
            if (checkBoxZnrSD.Checked)
            {
                _count += dbl.CountData(textBoxZnrSD.Text);
            }

            progressBarLoad.Maximum = _count;
            progressBarLoad.Value = _min;

            if (checkBoxIncSM.Checked)
            {
                dbl.FileINCSMPath = textBoxIncSM.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SM_INC_EXCEL_TO_DB);
                bw.DoWork += new DoWorkEventHandler(dbl.SM_ZNO_EXCEL_TO_DB);
            }
            if (checkBoxZnoSM.Checked)
            {
                dbl.FileZNOSMPath = textBoxZnoSM.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SM_ZNO_LoadDataToDB);
            }
            if (checkBoxZnoSD.Checked)
            {
                dbl.FileZNOSDPath = textBoxZnoSD.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SD_ZNO_LoadDataToDB);
            }
            if (checkBoxZnrSD.Checked)
            {
                dbl.FileZNRSDPath = textBoxZnrSD.Text;
                bw.DoWork += new DoWorkEventHandler(dbl.SD_ZNR_LoadDataToDB);
            }

            bw.RunWorkerAsync();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        public void SetProgressValue(int newValue)
        {
            if (newValue < _min || newValue > _count)
                throw new ArgumentException(string.Format(
                    "Передано неверное значение, диапазон допустимых значений от {0} до {1}", _min, _count));

            progressBarLoad.Value = newValue;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgressValue(e.ProgressPercentage);
        }

        //выполнение закончилось
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker aw = new BackgroundWorker();

            aw.DoWork += new DoWorkEventHandler(FindUsersInDB);
            aw.RunWorkerAsync();
            aw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(aw_SQLWorkerCompleted);
        }

        void aw_SQLWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Данные успешно загружены, и проиндексированны");
            LoadData.Enabled = true;
            progressBarLoad.Value = _min;
        }

        private void FindUsersInDB(object sender, EventArgs e)
        {
            DBDataLoader dbl = new DBDataLoader(_dbpath);
            dbl.DB_SM_ENTRY_INSERTER(@"SELECT employee FROM sm_zno WHERE id_employee IS NULL GROUP BY employee UNION SELECT employee FROM sm_inc WHERE id_employee IS NULL GROUP BY employee", @"INSERT INTO sm_employee(employee) VALUES (@entry)");//Вносим не идексированных пользователпей во вспомогательную таблицу пользователей SM.
            dbl.DB_SD_EMLOYEES_INSERTER(@"SELECT employee FROM sd_zno WHERE id_employee IS NULL GROUP BY employee UNION SELECT employee FROM sd_znr WHERE id_employee IS NULL GROUP BY employee", @"INSERT INTO sd_employee(employee, full_name) VALUES (@employee, @full_name)");//Вносим не идексированных пользователпей во вспомогательную таблицу пользователей SD.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");//Сопоставляем пользователей SM с таблицей пользователей, индексируем.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_employee.id AS sd_employee FROM employees, sd_employee WHERE sd_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_employee SET id_employee = @entry0 WHERE Id = @entry1");//Сопоставляем пользователей SD с таблицей пользователей, индексируем.
            dbl.DB_EMLOYEES_INSERTER(@"SELECT full_name FROM sd_employee WHERE id_employee IS NULL GROUP BY full_name", @"INSERT INTO employees(Full_Name, First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@ClearFullName, @First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");//Вносим не идексированных пользователпей в основную таблицу пользователей
            dbl.DB_GETNAME_EMLOYEES_INSERTER(@"SELECT employee FROM sm_employee WHERE id_employee IS NULL", @"INSERT INTO employees(Full_Name, First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@ClearFullName, @First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");//Вычисляем тех из таблицы SM кого нет в основнуй таблице.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%' AND id_employee IS NULL", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");//Индексируем нулевые значения
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_employee.id AS sd_employee FROM employees, sd_employee WHERE sd_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%' AND id_employee IS NULL", @"UPDATE sd_employee SET id_employee = @entry0 WHERE Id = @entry1");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_zno.id AS sd_id FROM employees, sd_zno WHERE sd_zno.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_zno SET id_employee = @entry0 WHERE Id = @entry1");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_znr.id AS sdznr_id FROM employees, sd_znr WHERE sd_znr.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_znr SET id_employee = @entry0 WHERE Id = @entry1");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_zno.id AS smzno_id FROM employees, sm_zno WHERE sm_zno.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_zno SET id_employee = @entry0 WHERE Id = @entry1");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_inc.id AS sminc_id FROM employees, sm_inc WHERE sm_inc.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_inc SET id_employee = @entry0 WHERE Id = @entry1");
        }
        #endregion

        #region properties of this class
        public int Counter { get; set; }
        #endregion
    }
}
