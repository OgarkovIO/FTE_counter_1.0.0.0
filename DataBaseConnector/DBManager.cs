using Loader;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBaseConnector
{
    public class DBManager
    {
        #region fields
        private string _dbpath;

        private string _strSQL;

        private string _failPath;

        private string _connParam;

        private string _columnReader;
        #endregion

        #region Auxiliary methods and class designer
        public DBManager()
        {
            _dbpath = null;
            _strSQL = null;
            _failPath = null;
        }

        public DBManager(string dbPath)
        {
            _dbpath = dbPath;
            _connParam = ConnToString();
            _strSQL = null;
            _failPath = null;
        }
        
        public bool CreateConnection()
        {
            ConnPparam = ConnToString();
            if (!File.Exists(_dbpath))//Если(if) не(!) File(системный класс для работы с файлами) .Exists(метод определяющий существует ли данный файл, входной параметр путь к файлу) source - переменная хранящая путь к файлу...... 
                return false;//.....возвращаем (return) false
            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
            return true;//.....возвращаем (return) true
        }

        public string ConnToString() //Переопределяем Метод ToString!!!! Из базового класса Object (Предустановлен в стандартной форме) что-бы можно было выводить информацию. !!Ключевое слово override разворачивает метод базового класса для модификации!!
        {
            return string.Format("Data Source={0};Max Database Size=3072", _dbpath); //Меняем стандартные значения метода(Возвращают название типа класса CSLesson2.MoneyEntry) - return base.ToString(). На текущие - которые будут выводить при конструкции MoneyEntry.ToString "(Число _amount) от (Даты EntryDate)" (5 от 31 декабря 2014)
        }
        #endregion

        #region Loader methods
        public void SM_INC_LoadDataToDB(string FileINCSMPath)
        {
            sminc_entry sminc = new sminc_entry();
            var parser = new CSV_Parser();
            ConnPparam = ConnToString();
            parser.separator = '\t';
            parser.scipline = 1;

            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
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

                        _strSQL = "INSERT INTO sm_inc(id_sm_inc, work_group, employee) VALUES ('" + sminc.ID_SmINC + "','" + sminc.Work_group + "','" + sminc.Employee + "')";
                        cmd.CommandText = _strSQL;
                        cmd.ExecuteNonQuery();

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

        public void SM_ZNO_LoadDataToDB(string FileZNOSMPath)
        {
            smzno_entry smzno = new smzno_entry();
            var parser = new CSV_Parser();
            ConnPparam = ConnToString();
            parser.separator = '\t';
            parser.scipline = 1;

            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
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

                        _strSQL = "INSERT INTO sm_zno(id_sm_zno, work_group, employee) VALUES ('" + smzno.ID_SmZNO + "','" + smzno.Work_group + "','" + smzno.Employee + "')";
                        cmd.CommandText = _strSQL;
                        cmd.ExecuteNonQuery();

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

        public void SD_ZNO_LoadDataToDB(string FileZNOSDPath)
        {
            sdzno_entry sdzno = new sdzno_entry();
            var parser = new CSV_Parser();
            ConnPparam = ConnToString();
            parser.separator = ',';
            char CharQuote;
            char.TryParse("'", out CharQuote);//Залепа чтобы передать ' кавычку, что за бред!!!!???
            parser.quote = CharQuote;
            parser.scipline = 1;

            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
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

        public void SD_ZNR_LoadDataToDB(string FileZNRSDPath)
        {
            sdznr_entry sdznr = new sdznr_entry();
            var parser = new CSV_Parser();
            ConnPparam = ConnToString();
            parser.separator = ',';
            char CharQuote;
            char.TryParse("'", out CharQuote);
            parser.quote = CharQuote;
            parser.scipline = 1;

            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
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

        /*public void ExQueryFromDB(string load_command)
        {
            ConnPparam = ConnToString();
            SqlCeConnection conn = new SqlCeConnection(ConnPparam);//Объявляем экземпляр класса SqlConnection - conn с заданными для соединения параметрами (@"Data Source=R-1\ZOMBO_SERVER;Initial Catalog=CSLessons;Persist Security Info=True;User ID=SYSDBA;Password=amp1011217"), взятыми из настроек для поделючения сервера в обозревателе серверов.
            SqlCeCommand cmd = conn.CreateCommand();//Объяыляем объект SqlCommand - cmd, которому присваеваем значение равное (=) экземпляу класса conn из которого запустили метод CreateCommand() (посрредством метода CreateCommand() выполнятся команда в нашем соединении)
            
            cmd.CommandText = load_command;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    inc.Id = reader.GetValue(0).ToString();
                    inc.work_group = reader.GetValue(1).ToString();
                    inc.emploer = reader.GetValue(2).ToString();

                    AddEntry(inc);

                }
            }
            conn.Close();//Закрываем соединение применив метод Close() экземпляра conn.
        }*/
        #endregion

        #region Internal database methods
        public void Update_sd_zno_emloyees(string ReadCommand)
        {
            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = ReadCommand;
            conn.Open();//Открываем соединение

            using (SqlCeDataReader reader = cmd.ExecuteReader())//Используя утилиту using подключаем экземпляр класса SqlDataReader - reader (который объявлен тут-же) присваеваем ему значение - объект CMD из которого запущен метод ExecuteReader()
            {
                while (reader.Read())//Выполняем цикл while для построчного перебора всех полей таблицы результата запроса, которую на данный момент уже хранит кземпляр класса SqlDataReader - reader и считывания данных методом Read().
                {
                    string columnReader;
                    columnReader = reader.GetValue(0).ToString();
                    cmd = new SqlCeCommand("UPDATE summary_table_employees SET sm_inc_emloyees = @sm_inc_emloyees", conn);
                    cmd.Parameters.AddWithValue("@sm_inc_emloyees", columnReader);
                    cmd.ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public void AddEntryToDB(string entry)
        {
            SqlCeConnection conn = new SqlCeConnection(ConnPparam);
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE summary_table_employees SET sm_inc_emloyees = '" + entry + "'";
        }
        #endregion

        #region properties of this class
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
        #endregion
    }
}

