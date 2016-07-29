using DataBaseConnector;
using Loader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTE_counter
{
    public partial class ReportForm : Form
    {
        private string _dbpath;
        private string _uni_element;

        public ReportForm()
        {
            InitializeComponent();
            ReadConfig();
            LoadOfDBToDGVConRep(@"SELECT Id, sm_inc_1line, sm_inc_dost, sm_inc_disp, sm_zno_1line, sm_zno_dost, sm_zno_disp, sd_zno_1line, sd_zno_dost, sd_zno_disp, sd_znr_1line, sd_znr_dost, sd_znr_disp, employee_short_name FROM FTE");
        }

        private void ReadConfig()
        {
            Options_save ops = new Options_save();
            ops.ReadConfig();
            _dbpath = ops.DBPath;
        }

        private void AddEntry(UserCount nj)
        {
            dataGridViewConRep.Rows.Add(nj.FullNameOfemployee, nj.index);
        }

        private void CountOfDBToDGV(string command)
        {
            dataGridViewConRep.Rows.Clear();
            DBManager dbm = new DBManager(_dbpath);
            UserCount nj = new UserCount();
            SqlCeConnection conn = new SqlCeConnection(dbm.ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    nj.FullNameOfemployee = reader.GetValue(0).ToString();
                    nj.index = reader.GetValue(1).ToString();

                    AddEntry(nj);
                }
            }

            conn.Close();
        }

        private void dataGridViewConRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CountByUser_Click(object sender, EventArgs e)
        {
            BackgroundWorker aw = new BackgroundWorker();

            aw.DoWork += new DoWorkEventHandler(CountWoksInDB);
            aw.RunWorkerAsync();
            aw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(aw_SQLWorkerCompleted);
        }

        void aw_SQLWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CountByUser.Enabled = true;
            LoadOfDBToDGVConRep(@"SELECT Id, sm_inc_1line, sm_inc_dost, sm_inc_disp, sm_zno_1line, sm_zno_dost, sm_zno_disp, sd_zno_1line, sd_zno_dost, sd_zno_disp, sd_znr_1line, sd_znr_dost, sd_znr_disp, employee_short_name FROM FTE");
        }

        private void CountWoksInDB(object sender, EventArgs e)
        {
            DBDataLoader dbl = new DBDataLoader(_dbpath);
            /*dbl.DB_SM_ENTRY_INSERTER(@"SELECT employee FROM sm_zno GROUP BY employee UNION SELECT employee FROM sm_inc GROUP BY employee", @"INSERT INTO sm_employee(employee) VALUES (@entry)");
            dbl.DB_SD_EMLOYEES_INSERTER(@"SELECT employee FROM sd_zno GROUP BY employee UNION SELECT employee FROM sd_znr GROUP BY employee", @"INSERT INTO sd_employee(employee, full_name) VALUES (@employee, @full_name)");
            dbl.DB_EMLOYEES_INSERTER(@"SELECT full_name FROM sd_employee GROUP BY full_name", @"INSERT INTO employees(Full_Name, First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@ClearFullName, @First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");//Сопоставляем пользователей с таблицей СМ, индексируем.
            dbl.DB_GETNAME_EMLOYEES_INSERTER(@"SELECT employee FROM sm_employee WHERE id_employee IS NULL", @"INSERT INTO employees(Full_Name, First_Name, Last_Name, Middle_Name, SERCH_PATTERN) VALUES (@ClearFullName, @First_Name, @Last_Name, @Middle_Name, @Serch_pattern)");//Вычисляем тех кого нет в базе.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sm_employee.id AS sm_employee FROM employees, sm_employee WHERE sm_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sm_employee SET id_employee = @entry0 WHERE Id = @entry1");//Вносим в базу отсекаем нулевые значения заглушкой.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_employee.id AS sd_employee FROM employees, sd_employee WHERE sd_employee.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_employee SET id_employee = @entry0 WHERE Id = @entry1");
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT employees.Id AS employees_ID, sd_zno.id AS sd_id FROM employees, sd_zno WHERE sd_zno.employee LIKE '%' + employees.SERCH_PATTERN + '%'", @"UPDATE sd_zno SET id_employee = @entry0 WHERE Id = @entry1");*/
            //Уничтожаем временную таблицу
            dbl.DB_SINGLE_COMMAND(@"DROP TABLE [FTE]");
            //Создаём временную таблицу
            dbl.DB_SINGLE_COMMAND(@"CREATE TABLE [FTE] ([Id] int IDENTITY (1,1) NOT NULL
                                    , [employee_id] int NOT NULL
                                    , [Hours_Worked] int NULL
                                    , [sm_inc_1line] int NULL
                                    , [sm_inc_dost] int NULL
                                    , [sm_inc_disp] int NULL
                                    , [sm_zno_1line] int NULL
                                    , [sm_zno_dost] int NULL
                                    , [sm_zno_disp] int NULL
                                    , [sd_zno_1line] int NULL
                                    , [sd_zno_dost] int NULL
                                    , [sd_zno_disp] int NULL
                                    , [sd_znr_1line] int NULL
                                    , [sd_znr_dost] int NULL
                                    , [sd_znr_disp] int NULL
                                    , [sm_inc_fte] int NULL
                                    , [sm_zno_fte] int NULL
                                    , [sd_zno_fte] int NULL
                                    , [sd_znr_fte] int NULL
                                    , [employee_short_name] nvarchar(250) NULL);");
            //Задаём первичный ключ
            dbl.DB_SINGLE_COMMAND(@"ALTER TABLE [FTE] ADD CONSTRAINT [PK_FTE] PRIMARY KEY ([Id])");

            //Находим всех сотрудников первой линии в базе по индексу сотрудника.

            dbl.DB_ENTRY_INSERTER(@"SELECT id_employee FROM sd_znr WHERE work_group LIKE '%' + 'СЗБ 1' + '%' OR work_group LIKE '%' + 'СЗБ дисп' OR work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee
                                    UNION
                                    SELECT id_employee FROM sm_zno WHERE work_group LIKE '%' + 'СЗБ 1' + '%' OR work_group LIKE '%' + 'СЗБ дисп' OR work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee
                                    UNION
                                    SELECT id_employee FROM sd_zno WHERE work_group LIKE '%' + 'СЗБ 1' + '%' OR work_group LIKE '%' + 'СЗБ дисп' OR work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee
                                    UNION
                                    SELECT id_employee FROM sm_inc WHERE work_group LIKE '%' + 'СЗБ 1' + '%' OR work_group LIKE '%' + 'СЗБ дисп' OR work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee", 
                                    @"INSERT INTO FTE(employee_id) VALUES (@entry)");

            //Сопоставляем сотрудников в базе согласно индексу.

            dbl.DB_STRING_INT_ENTRY_INSERTER(@"SELECT employees.SERCH_PATTERN, FTE.employee_id FROM employees, FTE WHERE FTE.employee_id = employees.id", @"UPDATE FTE SET employee_short_name = @entry0 WHERE employee_id = @entry1");

            //Вычисляем инциденты, пишем их в базу, выводим в DataGrid

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_inc WHERE work_group LIKE '%' + 'СЗБ 1' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_inc_1line = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_inc WHERE work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_inc_dost = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_inc WHERE work_group LIKE '%' + 'СЗБ Дисп' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_inc_disp = @entry1 WHERE employee_id = @entry0");

            //Вычисляем ЗНО из SM, так-же пишем в базу, затем всё собираем и выводим.

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_zno WHERE work_group LIKE '%' + 'СЗБ 1' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_zno_1line = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_zno WHERE work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_zno_dost = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sm_zno WHERE work_group LIKE '%' + 'СЗБ Дисп' + '%' GROUP BY id_employee", @"UPDATE FTE SET sm_zno_disp = @entry1 WHERE employee_id = @entry0");

            //Вычисляем ЗНР из SD, так-же пишем в базу, затем всё собираем и выводим.

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sd_znr WHERE work_group LIKE '%' + 'СЗБ 1' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_znr_1line = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sd_znr WHERE work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_znr_dost = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, SUM(n_users) FROM sd_znr WHERE work_group LIKE '%' + 'СЗБ Дисп' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_znr_disp = @entry1 WHERE employee_id = @entry0");

            //Вычисляем ЗНО из SD, так-же пишем в базу, затем всё собираем и выводим.

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sd_zno WHERE work_group LIKE '%' + 'СЗБ 1' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_zno_1line = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sd_zno WHERE work_group LIKE '%' + 'СЗБ дост' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_zno_dost = @entry1 WHERE employee_id = @entry0");

            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, COUNT(*) FROM sd_zno WHERE work_group LIKE '%' + 'СЗБ Дисп' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_zno_disp = @entry1 WHERE employee_id = @entry0");

            //LoadOfDBToDGVConRep(@"SELECT Id, sm_inc_1line, sm_inc_dost, sm_inc_disp, sm_zno_1line, sm_zno_dost, sm_zno_disp, sd_zno_1line, sd_zno_dost, sd_zno_disp, sd_znr_1line, sd_znr_dost, sd_znr_disp, employee_short_name FROM FTE");

            //Вычисляем ПШЕ.
            dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT Id, Hours_Worked FROM employees", @"UPDATE FTE SET Hours_Worked = @entry1 WHERE employee_id = @entry0");
            //dbl.DB_TWO_INT_ENTRY_INSERTER(@"SELECT id_employee, SUM(n_users) FROM sd_znr WHERE work_group LIKE '%' + 'СЗБ Дисп' + '%' GROUP BY id_employee", @"UPDATE FTE SET sd_znr_disp = @entry1 WHERE employee_id = @entry0");

        }

        private void LoadDataToDGV(object sender, EventArgs e)
        {
            LoadOfDBToDGVConRep(@"SELECT Id, sm_inc_1line, sm_inc_dost, sm_inc_disp, sm_zno_1line, sm_zno_dost, sm_zno_disp, sd_zno_1line, sd_zno_dost, sd_zno_disp, sd_znr_1line, sd_znr_dost, sd_znr_disp, employee_short_name FROM FTE");
        }

        private void AddEntryToDGVConRep(FTEEntry fte)//Объявляем приватный(private), не возвращающий значений(void) метод AddEntry, вхлдными параметрами которого будут - (MoneyEntry me) переменная me подключенного через .dll класса MoneyEntry
        {
            dataGridViewConRep.Rows.Add(fte.Id, "", fte.Employee_short_name, "", "", "", "", fte.Sm_inc_1line, fte.Sm_inc_dost, fte.Sm_inc_disp, "", fte.Sm_zno_1line, fte.Sm_zno_dost, fte.Sm_zno_disp, "", fte.Sd_znr_1line, fte.Sd_znr_dost, fte.Sd_znr_disp, "", fte.Sd_zno_1line, fte.Sd_zno_dost, fte.Sd_zno_disp, "", "", "");
        }

        private void LoadOfDBToDGVConRep(string command)
        {
            dataGridViewConRep.Rows.Clear();
            DBManager dbm = new DBManager(_dbpath);
            FTEEntry fte = new FTEEntry();
            SqlCeConnection conn = new SqlCeConnection(dbm.ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    fte.Id = reader.GetValue(0).ToString();
                    fte.Sm_inc_1line = reader.GetValue(1).ToString();
                    fte.Sm_inc_dost = reader.GetValue(2).ToString();
                    fte.Sm_inc_disp = reader.GetValue(3).ToString();
                    fte.Sm_zno_1line = reader.GetValue(4).ToString();
                    fte.Sm_zno_dost = reader.GetValue(5).ToString();
                    fte.Sm_zno_disp = reader.GetValue(6).ToString();
                    fte.Sd_zno_1line = reader.GetValue(7).ToString();
                    fte.Sd_zno_dost = reader.GetValue(8).ToString();
                    fte.Sd_zno_disp = reader.GetValue(9).ToString();
                    fte.Sd_znr_1line = reader.GetValue(10).ToString();
                    fte.Sd_znr_dost = reader.GetValue(11).ToString();
                    fte.Sd_znr_disp = reader.GetValue(12).ToString();
                    fte.Employee_short_name = reader.GetValue(13).ToString();

                    AddEntryToDGVConRep(fte);
                }
            }

            conn.Close();
        }

        //Метод загрузчик в EXCEL
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding Default = Encoding.Default;
            byte[] output = Default.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void LoadToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridViewConRep, sfd.FileName); // Here dataGridview1 is your grid view name
            }
            //LoadOfDBToDGVConRep(@"SELECT Id, sm_inc_1line, sm_inc_dost, sm_inc_disp, sm_zno_1line, sm_zno_dost, sm_zno_disp, sd_zno_1line, sd_zno_dost, sd_zno_disp, sd_znr_1line, sd_znr_dost, sd_znr_disp, employee_short_name FROM FTE");
        }

        private void UniCountAndView_Click(object sender, EventArgs e)
        {
            DBDataLoader dbl = new DBDataLoader(_dbpath);
            
            BackgroundWorker aw = new BackgroundWorker();

            aw.DoWork += new DoWorkEventHandler(UNICountWoksInDB);
            aw.RunWorkerAsync();
            aw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MakeDGV);
            //dbl.DB_COLUMN_INSERTER(@"SELECT sm_inc.work_group FROM sm_inc GROUP BY sm_inc.work_group UNION SELECT sm_zno.work_group FROM sm_zno GROUP BY sm_zno.work_group"/*, @"ALTER TABLE [UNI_FTE] ADD @entry int NULL"*/);
            //MakeDGV();
        }

        private void UNICountWoksInDB(object sender, EventArgs e)
        {
            DBDataLoader dbl = new DBDataLoader(_dbpath);
            //Уничтожаем временную таблицу
            dbl.DB_SINGLE_COMMAND(@"DROP TABLE [UNI_FTE]");
            //Создаём временную таблицу
            dbl.DB_SINGLE_COMMAND(@"CREATE TABLE [UNI_FTE] ([employee_id] int IDENTITY (1,1) NOT NULL
                                    , [Hours_Worked] int NULL
                                    , [employee_short_name] nvarchar(250) NULL);");
            //Задаём первичный ключ
            dbl.DB_SINGLE_COMMAND(@"ALTER TABLE [UNI_FTE] ADD CONSTRAINT [PK_UNI_FTE] PRIMARY KEY ([employee_id])");

            dbl.DB_COLUMN_INSERTER(@"SELECT sm_inc.work_group FROM sm_inc GROUP BY sm_inc.work_group UNION SELECT sm_zno.work_group FROM sm_zno GROUP BY sm_zno.work_group"/*, @"ALTER TABLE [UNI_FTE] ADD @entry int NULL"*/);

            //Находим всех сотрудников первой линии в базе по индексу сотрудника.
        }

        private void MakeDGV(object sender, EventArgs e)
        {
            DBManager dbm = new DBManager(_dbpath);
            //var path = @"C:\Users\Игорь\OneDrive\Develop\FTE\DATA\Отчет март\Отчет по выполненным запросам из SM.XLS";
            var dt = new DataTable();
            dt.Load(LoadDataINDGV(dbm.ConnPparam, "UNI_FTE"));

            //new DataGrid { Parent = this, Dock = DockStyle.Fill, DataSource = dt };
            //dataGridViewEmployees.Parent = this;
            //dataGridViewEmployees.Dock = DockStyle.Fill;
            UNIdataGrid.DataSource = dt;
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
    }
}
