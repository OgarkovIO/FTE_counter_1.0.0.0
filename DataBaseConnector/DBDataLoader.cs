using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using Loader;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.OleDb;

namespace DataBaseConnector
{
    public class DBDataLoader
    {
        #region fields
        private string _dbpath;

        private string _smincpath;

        private string _strSQL;

        private int _count;

        private int _counter;

        private int _skipline;

        private string _failPath;

        private string _connParam;
        #endregion

        #region Auxiliary methods and class designer

        public DBDataLoader()
        {
            _dbpath = null;
            _strSQL = null;
            _failPath = null;
            _count = 0;
            _connParam = null;
            _counter = 0;
            _skipline = 1;
        }

        public DBDataLoader(string dbPath)
        {
            _dbpath = dbPath;
            _connParam = ConnToString();
            _strSQL = null;
            _failPath = null;
            _count = 0;
            _counter = 0;
            _skipline = 1;
        }

        public bool CreateConnection()
        {
            _connParam = ConnToString();
            if (!File.Exists(_dbpath))//Если(if) не(!) File(системный класс для работы с файлами) .Exists(метод определяющий существует ли данный файл, входной параметр путь к файлу) source - переменная хранящая путь к файлу...... 
                return false;//.....возвращаем (return) false
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            return true;//.....возвращаем (return) true
        }

        public int CountData(string CSV)
        {
            _count = File.ReadAllLines(CSV).Length - _skipline;
            return
                _count;
        }
        #endregion

        #region Loader methods
        public void SM_INC_EXCEL_TO_DB(object sender, DoWorkEventArgs e)
        {
            sminc_entry sminc = new sminc_entry();

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";

                    string sheet;
                    var cs = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + FileINCSMPath + "'; Extended Properties=Excel 8.0;";
                    var connOleDB = new OleDbConnection(cs);

                    connOleDB.Open();
                    conn.Open();//Открываем соединение

                    var OleDBcmd = connOleDB.CreateCommand();
                    sheet = "Sheet1$";
                    OleDBcmd.CommandText = "select * from  [" + sheet + "] where f2 LIKE '%' + 'IM' + '%'";


                    using (OleDbDataReader reader = OleDBcmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
                    {
                        while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                        {
                            sminc.InitWithString(reader.GetValue(26).ToString(), reader.GetValue(13).ToString(), reader.GetValue(14).ToString(), reader.GetValue(15).ToString(), reader.GetValue(16).ToString());
                            sminc.To_the_target_date = reader.GetValue(0).ToString();
                            sminc.ID_SmINC = reader.GetValue(1).ToString();
                            sminc.Number_of_object = reader.GetValue(2).ToString();
                            sminc.Work_group = reader.GetValue(3).ToString();
                            sminc.Employee = reader.GetValue(4).ToString();
                            sminc.Description = reader.GetValue(5).ToString();
                            sminc.Information = reader.GetValue(6).ToString();
                            sminc.Service = reader.GetValue(7).ToString();
                            sminc.Ca_task_id = reader.GetValue(8).ToString();
                            sminc.Category = reader.GetValue(9).ToString();
                            sminc.Priority = reader.GetValue(10).ToString();
                            sminc.Status = reader.GetValue(11).ToString();
                            sminc.Sender = reader.GetValue(12).ToString();
                            sminc.Decision = reader.GetValue(17).ToString();
                            sminc.Closing_code = reader.GetValue(18).ToString();
                            sminc.Deadline_breached = reader.GetValue(19).ToString();
                            sminc.Department_addressed = reader.GetValue(20).ToString();
                            sminc.Internal_division = reader.GetValue(21).ToString();
                            sminc.Addressed_structure = reader.GetValue(22).ToString();
                            sminc.Bank_addressed = reader.GetValue(23).ToString();
                            sminc.Op = reader.GetValue(24).ToString();
                            sminc.Type_of_services = reader.GetValue(25).ToString();
                            sminc.Evaluation = reader.GetValue(27).ToString();
                            sminc.Id_service = reader.GetValue(28).ToString();
                            sminc.Id_CE = reader.GetValue(29).ToString();
                            sminc.Object = reader.GetValue(30).ToString();
                            sminc.Cause_of_incident = reader.GetValue(30).ToString();
                            sminc.Parent_group = reader.GetValue(31).ToString();
                            sminc.Intdiv_category = reader.GetValue(32).ToString();
                            sminc.Customer_comment = reader.GetValue(33).ToString();

                            cmd = new SqlCeCommand("INSERT INTO sm_inc(to_the_target_date, id_sm_inc, number_of_object, work_group, employee, description, information, service, ca_task_id, category, priority, status, sender, cr_date, c_date, complete_date, date_of_start_work, decision, closing_code, deadline_breached, department_addressed, internal_division, addressed_structure, bank_addressed, OP, type_of_services, counter_rediscovered, evaluation, id_service, id_CE, object, cause_of_incident, parent_group, IntDiv_category, customer_comment) VALUES (@to_the_target_date, @id_sm_inc, @number_of_object, @work_group, @employee, @description, @information, @service, @ca_task_id, @category, @priority, @status, @sender, @cr_date, @c_date, @complete_date, @date_of_start_work, @decision, @closing_code, @deadline_breached, @department_addressed, @internal_division, @addressed_structure, @bank_addressed, @OP, @type_of_services, @counter_rediscovered, @evaluation, @id_service, @id_CE, @object, @cause_of_incident, @parent_group, @IntDiv_category, @customer_comment)", conn);
                            //cmd.CommandText = _strSQL;
                            cmd.Parameters.AddWithValue("@to_the_target_date", sminc.To_the_target_date);
                            cmd.Parameters.AddWithValue("@id_sm_inc", sminc.ID_SmINC);
                            cmd.Parameters.AddWithValue("@number_of_object", sminc.Number_of_object);
                            cmd.Parameters.AddWithValue("@work_group", sminc.Work_group);
                            cmd.Parameters.AddWithValue("@employee", sminc.Employee);
                            cmd.Parameters.AddWithValue("@description", sminc.Description);
                            cmd.Parameters.AddWithValue("@information", sminc.Information);
                            cmd.Parameters.AddWithValue("@service", sminc.Service);
                            cmd.Parameters.AddWithValue("@ca_task_id", sminc.Ca_task_id);
                            cmd.Parameters.AddWithValue("@category", sminc.Category);
                            cmd.Parameters.AddWithValue("@priority", sminc.Priority);
                            cmd.Parameters.AddWithValue("@status", sminc.Status);
                            cmd.Parameters.AddWithValue("@sender", sminc.Sender);
                            cmd.Parameters.AddWithValue("@cr_date", sminc.Cr_date);
                            cmd.Parameters.AddWithValue("@c_date", sminc.C_date);
                            cmd.Parameters.AddWithValue("@complete_date", sminc.Complete_date);
                            cmd.Parameters.AddWithValue("@date_of_start_work", sminc.Date_of_start_work);
                            cmd.Parameters.AddWithValue("@decision", sminc.Decision);
                            cmd.Parameters.AddWithValue("@closing_code", sminc.Closing_code);
                            cmd.Parameters.AddWithValue("@deadline_breached", sminc.Deadline_breached);
                            cmd.Parameters.AddWithValue("@department_addressed", sminc.Department_addressed);
                            cmd.Parameters.AddWithValue("@internal_division", sminc.Internal_division);
                            cmd.Parameters.AddWithValue("@addressed_structure", sminc.Addressed_structure);
                            cmd.Parameters.AddWithValue("@bank_addressed", sminc.Bank_addressed);
                            cmd.Parameters.AddWithValue("@OP", sminc.Op);
                            cmd.Parameters.AddWithValue("@type_of_services", sminc.Type_of_services);
                            cmd.Parameters.AddWithValue("@counter_rediscovered", sminc.Counter_rediscovered);
                            cmd.Parameters.AddWithValue("@evaluation", sminc.Evaluation);
                            cmd.Parameters.AddWithValue("@id_service", sminc.Id_service);
                            cmd.Parameters.AddWithValue("@id_CE", sminc.Id_CE);
                            cmd.Parameters.AddWithValue("@object", sminc.Object);
                            cmd.Parameters.AddWithValue("@cause_of_incident", sminc.Cause_of_incident);
                            cmd.Parameters.AddWithValue("@parent_group", sminc.Parent_group);
                            cmd.Parameters.AddWithValue("@IntDiv_category", sminc.Intdiv_category);
                            cmd.Parameters.AddWithValue("@customer_comment", sminc.Customer_comment);
                            //cmd.CommandText = _strSQL;
                            //cmd.ExecuteReader();
                            cmd.ExecuteNonQuery();

                            _counter++;

                            ((BackgroundWorker)sender).ReportProgress(_counter);
                        }
                    }
                    conn.Close();
                    connOleDB.Close();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SM_ZNO_EXCEL_TO_DB(object sender, DoWorkEventArgs e)
        {
            smzno_entry smzno = new smzno_entry();

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";

                    string sheet;
                    var cs = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + FileINCSMPath + "'; Extended Properties=Excel 8.0;";
                    var connOleDB = new OleDbConnection(cs);

                    connOleDB.Open();
                    conn.Open();//Открываем соединение

                    var OleDBcmd = connOleDB.CreateCommand();
                    sheet = "Sheet1$";
                    OleDBcmd.CommandText = "select * from  [" + sheet + "] where f2 LIKE '%' + 'ЗНО' + '%'";


                    using (OleDbDataReader reader = OleDBcmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
                    {
                        while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                        {
                            smzno.InitWithString(reader.GetValue(26).ToString(), reader.GetValue(13).ToString(), reader.GetValue(14).ToString(), reader.GetValue(15).ToString(), reader.GetValue(16).ToString());
                            smzno.To_the_target_date = reader.GetValue(0).ToString();
                            smzno.ID_SmZNO = reader.GetValue(1).ToString();
                            smzno.Number_of_object = reader.GetValue(2).ToString();
                            smzno.Work_group = reader.GetValue(3).ToString();
                            smzno.Employee = reader.GetValue(4).ToString();
                            smzno.Description = reader.GetValue(5).ToString();
                            smzno.Information = reader.GetValue(6).ToString();
                            smzno.Service = reader.GetValue(7).ToString();
                            smzno.Ca_task_id = reader.GetValue(8).ToString();
                            smzno.Category = reader.GetValue(9).ToString();
                            smzno.Priority = reader.GetValue(10).ToString();
                            smzno.Status = reader.GetValue(11).ToString();
                            smzno.Sender = reader.GetValue(12).ToString();
                            smzno.Decision = reader.GetValue(17).ToString();
                            smzno.Closing_code = reader.GetValue(18).ToString();
                            smzno.Deadline_breached = reader.GetValue(19).ToString();
                            smzno.Department_addressed = reader.GetValue(20).ToString();
                            smzno.Internal_division = reader.GetValue(21).ToString();
                            smzno.Addressed_structure = reader.GetValue(22).ToString();
                            smzno.Bank_addressed = reader.GetValue(23).ToString();
                            smzno.Op = reader.GetValue(24).ToString();
                            smzno.Type_of_services = reader.GetValue(25).ToString();
                            smzno.Evaluation = reader.GetValue(27).ToString();
                            smzno.Id_service = reader.GetValue(28).ToString();
                            smzno.Id_CE = reader.GetValue(29).ToString();
                            smzno.Object = reader.GetValue(30).ToString();
                            smzno.Cause_of_incident = reader.GetValue(30).ToString();
                            smzno.Parent_group = reader.GetValue(31).ToString();
                            smzno.Intdiv_category = reader.GetValue(32).ToString();
                            smzno.Customer_comment = reader.GetValue(33).ToString();

                            cmd = new SqlCeCommand("INSERT INTO sm_zno(to_the_target_date, id_sm_zno, number_of_object, work_group, employee, description, information, service, ca_task_id, category, priority, status, sender, cr_date, c_date, complete_date, date_of_start_work, decision, closing_code, deadline_breached, department_addressed, internal_division, addressed_structure, bank_addressed, OP, type_of_services, counter_rediscovered, evaluation, id_service, id_CE, object, cause_of_incident, parent_group, IntDiv_category, customer_comment) VALUES (@to_the_target_date, @id_sm_zno, @number_of_object, @work_group, @employee, @description, @information, @service, @ca_task_id, @category, @priority, @status, @sender, @cr_date, @c_date, @complete_date, @date_of_start_work, @decision, @closing_code, @deadline_breached, @department_addressed, @internal_division, @addressed_structure, @bank_addressed, @OP, @type_of_services, @counter_rediscovered, @evaluation, @id_service, @id_CE, @object, @cause_of_incident, @parent_group, @IntDiv_category, @customer_comment)", conn);
                            //cmd.CommandText = _strSQL;
                            cmd.Parameters.AddWithValue("@to_the_target_date", smzno.To_the_target_date);
                            cmd.Parameters.AddWithValue("@id_sm_zno", smzno.ID_SmZNO);
                            cmd.Parameters.AddWithValue("@number_of_object", smzno.Number_of_object);
                            cmd.Parameters.AddWithValue("@work_group", smzno.Work_group);
                            cmd.Parameters.AddWithValue("@employee", smzno.Employee);
                            cmd.Parameters.AddWithValue("@description", smzno.Description);
                            cmd.Parameters.AddWithValue("@information", smzno.Information);
                            cmd.Parameters.AddWithValue("@service", smzno.Service);
                            cmd.Parameters.AddWithValue("@ca_task_id", smzno.Ca_task_id);
                            cmd.Parameters.AddWithValue("@category", smzno.Category);
                            cmd.Parameters.AddWithValue("@priority", smzno.Priority);
                            cmd.Parameters.AddWithValue("@status", smzno.Status);
                            cmd.Parameters.AddWithValue("@sender", smzno.Sender);
                            cmd.Parameters.AddWithValue("@cr_date", smzno.Cr_date);
                            cmd.Parameters.AddWithValue("@c_date", smzno.C_date);
                            cmd.Parameters.AddWithValue("@complete_date", smzno.Complete_date);
                            cmd.Parameters.AddWithValue("@date_of_start_work", smzno.Date_of_start_work);
                            cmd.Parameters.AddWithValue("@decision", smzno.Decision);
                            cmd.Parameters.AddWithValue("@closing_code", smzno.Closing_code);
                            cmd.Parameters.AddWithValue("@deadline_breached", smzno.Deadline_breached);
                            cmd.Parameters.AddWithValue("@department_addressed", smzno.Department_addressed);
                            cmd.Parameters.AddWithValue("@internal_division", smzno.Internal_division);
                            cmd.Parameters.AddWithValue("@addressed_structure", smzno.Addressed_structure);
                            cmd.Parameters.AddWithValue("@bank_addressed", smzno.Bank_addressed);
                            cmd.Parameters.AddWithValue("@OP", smzno.Op);
                            cmd.Parameters.AddWithValue("@type_of_services", smzno.Type_of_services);
                            cmd.Parameters.AddWithValue("@counter_rediscovered", smzno.Counter_rediscovered);
                            cmd.Parameters.AddWithValue("@evaluation", smzno.Evaluation);
                            cmd.Parameters.AddWithValue("@id_service", smzno.Id_service);
                            cmd.Parameters.AddWithValue("@id_CE", smzno.Id_CE);
                            cmd.Parameters.AddWithValue("@object", smzno.Object);
                            cmd.Parameters.AddWithValue("@cause_of_incident", smzno.Cause_of_incident);
                            cmd.Parameters.AddWithValue("@parent_group", smzno.Parent_group);
                            cmd.Parameters.AddWithValue("@IntDiv_category", smzno.Intdiv_category);
                            cmd.Parameters.AddWithValue("@customer_comment", smzno.Customer_comment);
                            //cmd.CommandText = _strSQL;
                            //cmd.ExecuteReader();
                            cmd.ExecuteNonQuery();

                            _counter++;

                            ((BackgroundWorker)sender).ReportProgress(_counter);
                        }
                    }
                    conn.Close();
                    connOleDB.Close();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SM_INC_LoadDataToDB(object sender, DoWorkEventArgs e)
        {
            sminc_entry sminc = new sminc_entry();
            var parser = new CSV_Parser();
            parser.separator = '\t';
            parser.scipline = _skipline;

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";

                    conn.Open();//Открываем соединение

                    foreach (var line in parser.Parse(FileINCSMPath, Encoding.Default))
                    {
                        sminc.ID_SmINC = line[0];
                        sminc.Work_group = line[1];
                        sminc.Employee = line[2];

                        _strSQL = "INSERT INTO sm_inc(id_sm_inc, work_group, employee, cr_date, c_date, complete_date, date_of_start_work) VALUES ('" + sminc.ID_SmINC + "','" + sminc.Work_group + "','" + sminc.Employee + "','" + sminc.Cr_date + "','" + sminc.C_date + "','" + sminc.Complete_date + "','" + sminc.Date_of_start_work + "')";
                        cmd.CommandText = _strSQL;
                        cmd.ExecuteNonQuery();

                        _counter++;

                        ((BackgroundWorker)sender).ReportProgress(_counter);

                        //AddEntry(inc); Из тестового варианта.
                    };

                    conn.Close();//Закрываем соединение применив метод Close() экземпляра conn.
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SM_ZNO_LoadDataToDB(object sender, DoWorkEventArgs e)
        {
            smzno_entry smzno = new smzno_entry();
            var parser = new CSV_Parser();
            parser.separator = '\t';
            parser.scipline = _skipline;

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";

                    conn.Open();//Открываем соединение

                    foreach (var line in parser.Parse(FileZNOSMPath, Encoding.Default))
                    {
                        smzno.ID_SmZNO = line[0];
                        smzno.Work_group = line[1];
                        smzno.Employee = line[2];

                        _strSQL = "INSERT INTO sm_zno(id_sm_zno, work_group, employee, cr_date, c_date, complete_date, date_of_start_work) VALUES ('" + smzno.ID_SmZNO + "','" + smzno.Work_group + "','" + smzno.Employee + "','" + smzno.Cr_date + "','" + smzno.C_date + "','" + smzno.Complete_date + "','" + smzno.Date_of_start_work + "')";
                        cmd.CommandText = _strSQL;
                        cmd.ExecuteNonQuery();

                        _counter++;

                        ((BackgroundWorker)sender).ReportProgress(_counter);
                        //AddEntry(inc); Из тестового варианта.
                    };

                    conn.Close();//Закрываем соединение применив метод Close() экземпляра conn.
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SD_ZNO_LoadDataToDB(object sender, DoWorkEventArgs e)
        {
            sdzno_entry sdzno = new sdzno_entry();
            var parser = new CSV_Parser();
            parser.separator = ',';
            char CharQuote;
            char.TryParse("'", out CharQuote);//Залепа чтобы передать ' кавычку, что за бред!!!!???
            parser.quote = CharQuote;
            parser.scipline = _skipline;

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";
                    conn.Open();//Открываем соединение

                    foreach (var line in parser.Parse(FileZNOSDPath, Encoding.Default))
                    {
                        sdzno.InitWithString(line[0], line[2], line[3]);
                        sdzno.template = line[1];
                        sdzno.category = line[4];
                        sdzno.ca_task_id = line[5];
                        sdzno.ca_task_name = line[6];
                        sdzno.ca_task_category = line[7];
                        sdzno.employee = line[8];
                        sdzno.work_group = line[9];

                        cmd = new SqlCeCommand("INSERT INTO sd_zno(id_sd_zno, template, cr_date, c_date, category, ca_task_id, ca_task_name, ca_task_category, employee, work_group) VALUES (@sdznoId, @sdznotemplate ,@sdznocr_date, @sdznoc_date, @sdznocategory, @sdznoca_task_id, @sdznoca_task_name, @sdznoca_task_category, @sdznoemployee, @sdznowork_group)", conn);
                        //cmd.CommandText = _strSQL;
                        cmd.Parameters.AddWithValue("@sdznoId", sdzno.Id);
                        cmd.Parameters.AddWithValue("@sdznotemplate", sdzno.template);
                        cmd.Parameters.AddWithValue("@sdznocr_date", sdzno.cr_date);
                        cmd.Parameters.AddWithValue("@sdznoc_date", sdzno.c_date);
                        cmd.Parameters.AddWithValue("@sdznocategory", sdzno.category);
                        cmd.Parameters.AddWithValue("@sdznoca_task_id", sdzno.ca_task_id);
                        cmd.Parameters.AddWithValue("@sdznoca_task_name", sdzno.ca_task_name);
                        cmd.Parameters.AddWithValue("@sdznoca_task_category", sdzno.ca_task_category);
                        cmd.Parameters.AddWithValue("@sdznoemployee", sdzno.employee);
                        cmd.Parameters.AddWithValue("@sdznowork_group", sdzno.work_group);
                        //cmd.CommandText = _strSQL;
                        //cmd.ExecuteReader();
                        cmd.ExecuteNonQuery();

                        _counter++;

                        ((BackgroundWorker)sender).ReportProgress(_counter);

                        //AddEntry(inc); Из тестового варианта.
                    };

                    conn.Close();//Закрываем соединение применив метод Close() экземпляра conn.
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void SD_ZNR_LoadDataToDB(object sender, DoWorkEventArgs e)
        {
            sdznr_entry sdznr = new sdznr_entry();
            var parser = new CSV_Parser();
            parser.separator = ',';
            char CharQuote;
            char.TryParse("'", out CharQuote);//Залепа чтобы передать ' кавычку, что за бред!!!!???
            parser.quote = CharQuote;
            parser.scipline = _skipline;

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";
                    conn.Open();//Открываем соединение

                    foreach (var line in parser.Parse(FileZNRSDPath, Encoding.Default))
                    {
                        sdznr.InitWithString(line[0], line[2], line[3], line[10]);
                        sdznr.template = line[1];
                        sdznr.category = line[4];
                        sdznr.ca_task_id = line[5];
                        sdznr.ca_task_name = line[6];
                        sdznr.ca_task_category = line[7];
                        sdznr.work_group = line[8];
                        sdznr.employee = line[9];

                        cmd = new SqlCeCommand("INSERT INTO sd_znr(id_sd_znr, template, cr_date, c_date, category, ca_task_id, ca_task_name, ca_task_category, work_group, employee, n_users) VALUES (@sdznrId, @sdznrtemplate ,@sdznrcr_date, @sdznrc_date, @sdznrcategory, @sdznrca_task_id, @sdznrca_task_name, @sdznrca_task_category, @sdznrwork_group, @sdznremployee, @sdznrn_users)", conn);
                        //cmd.CommandText = _strSQL;
                        cmd.Parameters.AddWithValue("@sdznrId", sdznr.Id);
                        cmd.Parameters.AddWithValue("@sdznrtemplate", sdznr.template);
                        cmd.Parameters.AddWithValue("@sdznrcr_date", sdznr.cr_date);
                        cmd.Parameters.AddWithValue("@sdznrc_date", sdznr.c_date);
                        cmd.Parameters.AddWithValue("@sdznrcategory", sdznr.category);
                        cmd.Parameters.AddWithValue("@sdznrca_task_id", sdznr.ca_task_id);
                        cmd.Parameters.AddWithValue("@sdznrca_task_name", sdznr.ca_task_name);
                        cmd.Parameters.AddWithValue("@sdznrca_task_category", sdznr.ca_task_category);
                        cmd.Parameters.AddWithValue("@sdznrwork_group", sdznr.work_group);
                        cmd.Parameters.AddWithValue("@sdznremployee", sdznr.employee);
                        cmd.Parameters.AddWithValue("@sdznrn_users", sdznr.n_users);
                        //cmd.CommandText = _strSQL;
                        //cmd.ExecuteReader();
                        cmd.ExecuteNonQuery();

                        _counter++;

                        ((BackgroundWorker)sender).ReportProgress(_counter);

                        //AddEntry(inc); Из тестового варианта.
                    };

                    conn.Close();//Закрываем соединение применив метод Close() экземпляра conn.
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region Internal database methods
        public void DB_ENTRY_INSERTER(string GetCommand, string LoadCommand)
        {
            //AllUsers au = new AllUsers();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
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

        public void DB_COLUMN_INSERTER(string GetCommand/*, string LoadCommand*/)
        {
            //AllUsers au = new AllUsers();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    string UNI = Transliteration.Front(reader.GetValue(0).ToString());
                    cmd = new SqlCeCommand("ALTER TABLE[UNI_FTE] ADD "+ UNI + " int NULL", conn);
                    //cmd.Parameters.AddWithValue("@entry", Transliteration.Front(reader.GetValue(0).ToString()));
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_SM_ENTRY_INSERTER(string GetCommand, string LoadCommand)
        {
            sm_employee sm = new sm_employee();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    sm.Employee = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    cmd.Parameters.AddWithValue("@entry", sm.Employee);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_TWO_INT_ENTRY_INSERTER(string GetCommand, string LoadCommand)
        {
            //AllUsers au = new AllUsers();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    int entry0;//Проверить не верный код, слишком много преобразований
                    int entry1;//Проверить не верный код, слишком много преобразований
                    int.TryParse(reader.GetValue(0).ToString(), out entry0);//Проверить не верный код, слишком много преобразований
                    int.TryParse(reader.GetValue(1).ToString(), out entry1);//Возможног есть резон заложить всё в класс.
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    cmd.Parameters.AddWithValue("@entry0", entry0);
                    cmd.Parameters.AddWithValue("@entry1", entry1);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_STRING_INT_ENTRY_INSERTER(string GetCommand, string LoadCommand)
        {
            //AllUsers au = new AllUsers();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            //SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    string entry0;//Проверить не верный код, слишком много преобразований
                    int entry1;//Проверить не верный код, слишком много преобразований
                    entry0 = reader.GetValue(0).ToString();//Проверить не верный код, слишком много преобразований
                    int.TryParse(reader.GetValue(1).ToString(), out entry1);//Возможног есть резон заложить всё в класс.
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    cmd.Parameters.AddWithValue("@entry0", entry0);
                    cmd.Parameters.AddWithValue("@entry1", entry1);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void EXCEL_DB_STRING_INT_ENTRY_INSERTER(string ExcelFilePath, string LoadCommand)
        {

            SqlCeConnection conn = new SqlCeConnection(_connParam);
            {
                try
                {
                    SqlCeCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "";

                    string sheet;
                    var cs = "provider=Microsoft.ACE.OLEDB.12.0; Data Source='" + ExcelFilePath + "'; Extended Properties=Excel 8.0;";
                    var connOleDB = new OleDbConnection(cs);

                    connOleDB.Open();
                    conn.Open();//Открываем соединение

                    var OleDBcmd = connOleDB.CreateCommand();
                    sheet = "Лист1$";//Только трэш только реальный ХАРДКОД Иеееееее!!!!
                    OleDBcmd.CommandText = "select * from  [" + sheet + "]'%'";


                    using (OleDbDataReader reader = OleDBcmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
                    {
                        while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                        {
                            string entry0;//Проверить не верный код, слишком много преобразований
                            int entry1;//Проверить не верный код, слишком много преобразований
                            entry0 = reader.GetValue(0).ToString();//Проверить не верный код, слишком много преобразований
                            int.TryParse(reader.GetValue(1).ToString(), out entry1);//Возможног есть резон заложить всё в класс.
                            cmd = new SqlCeCommand(LoadCommand, conn);
                            cmd.Parameters.AddWithValue("@entry0", entry0);
                            cmd.Parameters.AddWithValue("@entry1", entry1);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                    connOleDB.Close();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void DB_SD_EMLOYEES_INSERTER(string GetCommand, string LoadCommand)
        {
            sd_employee sd = new sd_employee();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            //SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    sd.ClearFullName(reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@employee", reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@full_name", sd.ClearedFullName);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_EMLOYEES_INSERTER(string GetCommand, string LoadCommand)
        {
            employee em = new employee();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            //SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    em.GetClearedFullName(reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@ClearFullName", reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@First_Name", em.FirstName);
                    cmd.Parameters.AddWithValue("@Last_Name", em.LastName);
                    cmd.Parameters.AddWithValue("@Middle_Name", em.MiddleName);
                    cmd.Parameters.AddWithValue("@Serch_pattern", em.Serch_pattern);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_GETNAME_EMLOYEES_INSERTER(string GetCommand, string LoadCommand)
        {
            employee em = new employee();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            //SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = GetCommand;
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    //au.SM_INC = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand(LoadCommand, conn);
                    em.GetName(reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@ClearFullName", reader.GetValue(0).ToString());
                    cmd.Parameters.AddWithValue("@First_Name", em.FirstName);
                    cmd.Parameters.AddWithValue("@Last_Name", em.LastName);
                    cmd.Parameters.AddWithValue("@Middle_Name", em.MiddleName);
                    cmd.Parameters.AddWithValue("@Serch_pattern", em.Serch_pattern);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void DB_SINGLE_COMMAND(string Command)
        {
            SqlCeConnection cn = new SqlCeConnection(_connParam);
            {
                try
                {
                    cn.Open();
                    SqlCeCommand cmd = new SqlCeCommand(Command, cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch (SqlCeException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region database count mathods
        public int DB_COUNT_TABLE_ROWS(string table)
        {
            int TableRowsCount = 0;
            employee em = new employee();
            SqlCeConnection conn = new SqlCeConnection(_connParam);
            SqlCeCommand cmd = conn.CreateCommand();
            //SqlCeCommand cmdL = conn.CreateCommand();
            cmd.CommandText = @"SELECT COUNT(*) FROM '" + table + "'";
            conn.Open();//Открываем соединение


            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    int.TryParse(reader.GetValue(0).ToString(), out TableRowsCount);
                }
            }
            conn.Close();
            return TableRowsCount;
        }

        public int DB_COUNT_EXCEL_TABLE_ROWS(string path, string sheet, string type)
        {
            int TableRowsCount = 0;
            //employee em = new employee();
            OleDbConnection conn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + path + "'; Extended Properties=Excel 8.0;");
            OleDbCommand cmd = conn.CreateCommand();
            //OleDbCommand cmdL = conn.CreateCommand();
            cmd.CommandText = @"SELECT COUNT(*) FROM [" + sheet + "] where f2 LIKE '%' + '[" + type + "]' + '%'";
            conn.Open();//Открываем соединение

            using (OleDbDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    int.TryParse(reader.GetValue(0).ToString(), out TableRowsCount);
                }
            }
            conn.Close();
            return TableRowsCount;
        }
        #endregion

        #region properties of this class
        public int SkipLine
        {
            get { return _skipline; }
            set { _skipline = value; }
        }

        public int Сount
        {
            get { return _count; }
            set { _count = value; }
        }

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public string ConnToString() //Переопределяем Метод ToString!!!! Из базового класса Object (Предустановлен в стандартной форме) что-бы можно было выводить информацию. !!Ключевое слово override разворачивает метод базового класса для модификации!!
        {
            return string.Format("Data Source={0};Max Database Size=3072", _dbpath); //Меняем стандартные значения метода(Возвращают название типа класса CSLesson2.MoneyEntry) - return base.ToString(). На текущие - которые будут выводить при конструкции MoneyEntry.ToString "(Число _amount) от (Даты EntryDate)" (5 от 31 декабря 2014)
        }

        public string ConnPparam
        {
            get { return _connParam; }
            set { _connParam = value; }
        }

        public string FilePath
        {
            get { return _failPath; }
            set { _failPath = value; }
        }

        public string DBPath//Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _dbpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _dbpath = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public string SmIncPath//Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _smincpath; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _smincpath = value; } //set - Присваевает значеия, value - хранит значение.
        }

        public string FileINCSMPath { get; set; }

        public string FileZNOSMPath { get; set; }

        public string FileZNOSDPath { get; set; }

        public string FileZNRSDPath { get; set; }
        #endregion
    }
}
