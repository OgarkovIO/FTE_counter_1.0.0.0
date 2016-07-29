using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Loader;
using DataBaseConnector;
using System.Data.SqlServerCe;

namespace FTE_counter
{
    public partial class ManageForm : Form
    {
        #region fields
        private string _dbpath;//Создаём приватную переменную для хранения данных о месте размещения файла.

        private string _connparam;
        #endregion

        #region Auxiliary methods and class designer
        public ManageForm()
        {
            InitializeComponent();
            ReadConfig();
            //Reload();
            MakeDGV();
        }
        /*
        private void Reload()
        {
            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(MakeDGV);
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler();
        }*/

        private void Options_Click(object sender, EventArgs e)
        {
            Options dlg = new Options();//Создаём экземпляр нашего класса Otions (той формы которую мы используем для сохранения настроек) который назовём  dlg
            //dlg.PathTextBox.Text = _dbpath;//Записываем посредством свойства text в элемент формы PathTextBox(содержится в нашем созданном экземпляре класса dlg)
            dlg.Show();//Отображаем нашу форму пользователю.

           // Options_save ops = new Options_save();//Туту-же создаём экземпляр класса который содержит методы сохранения данных в файл.
            //ops.ReadConfig();//Выполняем Метод класса Options_save - ReadConfig() из его экземпляра ops
            //dlg.PathTextBox.Text = ops.DBPath;
        }

        private void ReadConfig()
        {
            Options_save ops = new Options_save();
            ops.ReadConfig();
            _dbpath = ops.DBPath;
        }
        #endregion

        #region Methods event handlers form
        private void FindAllUsers_Click(object sender, EventArgs e)
        {
            MakeDGV();
            //DBDataLoader dbl = new DBDataLoader(ops.DBPath);
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_GETNAME_EMLOYEES_INSERTER(@"SELECT employee FROM sm_employee WHERE id_employee IS NULL", @"INSERT INTO employees(Full_Name, First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@ClearFullName, @First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_zno.id AS sd_id FROM employees, sd_zno WHERE sd_zno.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_zno SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_znr.id AS sdznr_id FROM employees, sd_znr WHERE sd_znr.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_znr SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_zno.id AS smzno_id FROM employees, sm_zno WHERE sm_zno.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_zno SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_inc.id AS sminc_id FROM employees, sm_inc WHERE sm_inc.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_inc SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");
            //dbl.DB_EMLOYEES_INSERTER(@"SELECT sd_employee.employee FROM sd_employee", @"INSERT INTO employees(First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");
            //dbl.DB_ENTRY_INSERTER(@"SELECT employee FROM sm_zno GROUP BY employee UNION SELECT employee FROM sm_inc GROUP BY employee", @"INSERT INTO sm_employee(employee) VALUES (@entry)");
            //dbl.DB_ENTRY_INSERTER(@"SELECT employee FROM sd_zno GROUP BY employee UNION SELECT employee FROM sd_znr GROUP BY employee", @"INSERT INTO sd_employee(employee) VALUES (@entry)");
            //dbl.DB_EMLOYEES_INSERTER(@"SELECT sd_employee.employee FROM sd_employee", @"INSERT INTO employees(First_Name, Last_Name, Middle_Name) VALUES (@First_Name, @Last_Name, @Middle_Name)");
            //BackgroundWorker bw = new BackgroundWorker();

            //bw.DoWork += new DoWorkEventHandler(FindUsersInDB);
            //bw.RunWorkerAsync();
            //FindUsersOfDBToDGV(@"SELECT [sm_inc_employees] ,[sm_zno_employees] ,[sd_zno_employees] ,[sd_znr_employees] FROM [summary_table_employees];");
            //FindUsersOfDBToDGV(@"SELECT [sm_inc_employee].[sm_inc_employee] ,[sm_zno_employee].[sm_zno_employee] ,[sd_zno_employee].[sd_zno_employee] ,[sd_znr_employee].[sd_znr_employee] FROM [sm_inc_employee] ,[sm_zno_employee] ,[sd_zno_employee] ,[sd_znr_employee];");
        }

        private void ViewCangetTabels_Click(object sender, EventArgs e)
        {
            switch (comboBoxTables.SelectedIndex)
            {
                case 0:
                    CountOfDBToDGV(@"SELECT employee, COUNT(*) FROM sm_inc GROUP BY employee");
                    break;
                case 1:
                    CountOfDBToDGV(@"SELECT employee, COUNT(*) FROM sm_zno GROUP BY employee");
                    break;
                case 2:
                    CountOfDBToDGV(@"SELECT employee, COUNT(*) FROM sd_zno GROUP BY employee");
                    break;
                case 3:
                    CountOfDBToDGV(@"SELECT employee, SUM(n_users) FROM sd_znr GROUP BY employee");
                    break;
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ViewCangetTabels.Enabled = true;
            if (comboBoxTables.SelectedText != null)
            {
                ViewCangetTabels.Enabled = true;
            }
        }

        private void FindUsersInDB(object sender, EventArgs e)
        {
            Update_sm_inc_emloyees(@"SELECT employee FROM sm_inc GROUP BY employee", @"INSERT INTO sm_inc_employee(employee)  VALUES (@entry)");
            Update_sm_inc_emloyees(@"SELECT employee FROM sm_zno GROUP BY employee", @"INSERT INTO sm_zno_employee(employee)  VALUES (@entry)");
            Update_sm_inc_emloyees(@"SELECT employee FROM sd_zno GROUP BY employee", @"INSERT INTO sd_zno_employee(employee)  VALUES (@entry)");
            Update_sm_inc_emloyees(@"SELECT employee FROM sd_znr GROUP BY employee", @"INSERT INTO sd_znr_employee(employee)  VALUES (@entry)");
        }

        private void Save_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog();//Обявляем новый (new) экземпляр системного класса OpenFileDialog - fdl
            if (fdl.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Если (if) метод (.ShowDialog()) экземпляра (fdl) ==(оператор сравнени на равенство) System.Windows.Forms.DialogResult.OK - возвращаемое значение диалогового окна - ок .....
            {
                DBDataLoader dbl = new DBDataLoader(_dbpath);
                dbl.EXCEL_DB_STRING_INT_ENTRY_INSERTER(fdl.FileName, @"UPDATE employees SET Hours_Worked = @entry1 WHERE @entry0 LIKE '%' + SERCH_PATTERN + '%'");
                //.....то, в PathTextBox(объект).Text(свойство получает или задаёт текущий текст в данном элементе) = (записываем) fdl(объект).FileName(свойство возвращает или задаёт имя файла выбранное в диалоговом окне)
            }
        }
        #endregion

        #region  Methods for processing queries to the database and methods DataGridView loaders

        private void MakeDGV()
        {
            DBManager dbm = new DBManager(_dbpath);
            //var path = @"C:\Users\Игорь\OneDrive\Develop\FTE\DATA\Отчет март\Отчет по выполненным запросам из SM.XLS";
            var dt = new DataTable();
            dt.Load(LoadDataINDGV(dbm.ConnPparam, "employees"));

            //new DataGrid { Parent = this, Dock = DockStyle.Fill, DataSource = dt };
            //dataGridViewEmployees.Parent = this;
            //dataGridViewEmployees.Dock = DockStyle.Fill;
            dataGridViewEmployees.DataSource = dt;
        }

        SqlCeDataReader LoadDataINDGV(string path, string sheet)
        {
            var cs = path;
            var c = new SqlCeConnection(cs);
            c.Open();
            var cmd = c.CreateCommand();
            cmd.CommandText = "select * from  [" + sheet + "]";
            //cmd.CommandText = "select * from  [" + sheet + "] where f2 LIKE '%' + 'IM' + '%'";
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        private void SaveDGV()
        {
            //DBManager dbm = new DBManager(_dbpath);
            //var path = @"C:\Users\Игорь\OneDrive\Develop\FTE\DATA\Отчет март\Отчет по выполненным запросам из SM.XLS";
            //var dt = new DataTable();
            //dt.Load(LoadDataINDGV(dbm.ConnPparam, "employees"));

            //new DataGrid { Parent = this, Dock = DockStyle.Fill, DataSource = dt };
            //dataGridViewEmployees.Parent = this;
            //dataGridViewEmployees.Dock = DockStyle.Fill;
        }

        private void CountOfDBToDGV(string command)
        {
            DGVCount_DB.Rows.Clear();
            DBManager dbm = new DBManager(_dbpath);
            UserCount uc = new UserCount();
            SqlCeConnection conn = new SqlCeConnection(dbm.ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    uc.FullNameOfemployee = reader.GetValue(0).ToString();
                    uc.index = reader.GetValue(1).ToString();

                    AddEntryToDGVCount(uc);
                }
            }

            conn.Close();
        }

        private void FindUsersOfDBToDGV(string command)
        {
            DGVCount_DB.Rows.Clear();
            DBManager dbm = new DBManager(_dbpath);
            AllUsers au = new AllUsers();
            SqlCeConnection conn = new SqlCeConnection(dbm.ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    au.SM_INC = reader.GetValue(0).ToString();
                    au.SM_ZNO = reader.GetValue(1).ToString();
                    au.SD_ZNO = reader.GetValue(2).ToString();
                    au.SD_ZNR = reader.GetValue(3).ToString();

                    AddAllEntryToDGVEmployees(au);
                }
            }

            conn.Close();
        }

        private void ReadAndLoadToDB(string sm_inc_readCommand)
        {
            DBManager dbm = new DBManager(_dbpath);
            //Update_sm_inc_emloyees(sm_inc_readCommand);
        }

        private void AddAllEntryToDGVEmployees(AllUsers au)//Not Not used, replaced by a more effective
        {
            dataGridViewEmployees.Rows.Add(au.SM_INC, au.SM_ZNO, au.SD_ZNO, au.SD_ZNR);
        }

        public void Update_sm_inc_emloyees(string GetCommand, string LoadCommand)
        {
            AllUsers au = new AllUsers();
            DBManager dbm = new DBManager(_dbpath);
            SqlCeConnection conn = new SqlCeConnection(dbm.ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение
            

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    cmd.Parameters.AddWithValue("@entry", reader.GetValue(0).ToString());
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        private void AddEntryToDGVCount(UserCount uc)//Объявляем приватный(private), не возвращающий значений(void) метод AddEntry, вхлдными параметрами которого будут - (MoneyEntry me) переменная me подключенного через .dll класса MoneyEntry
        {
            DGVCount_DB.Rows.Add(uc.FullNameOfemployee, uc.index);
        }
        #endregion

        #region properties of this class
        public string DBPath    //Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _dbpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _dbpath = value; } //set - Присваевает значеия, value - хранит значение.
        }
        #endregion
    }
}
