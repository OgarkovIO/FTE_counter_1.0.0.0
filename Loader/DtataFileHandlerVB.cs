using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;

namespace Loader
{
    public class DataFileHandlerVB//Данный класс не используется в программе взят только для примера, можно удалять.
    {
        private string _pathIncFile;

        public DataFileHandlerVB()//Создаём публичный конструктор класса
        {
            _pathIncFile = "";//Содержащий команду на присвоение переменной  _filePath пустоно значения при инициализации экземпляра класса.
        }
        /// <summary>
        /// Чтение CSV-файла и сохранение записей в таблицу БД
        /// </summary>
        /// <returns>
        /// 0 - всё прошло без ошибок
        /// 1 - не удалось сохранить записи в БД
        /// 2 - ещё что-то не удалось
        /// </returns>
        int readCSVandSave2DB() // в параметры можно вынести размер буфера и путь до файла
        {
            // задаём размер буфера, пусть будет 9000 (строк CSV-файла)
            int csvBufferSize = 1000;
            // указываем путь до CSV-файла
            string path2file = _pathIncFile;
            // сюда он будет читаться
            DataTable csvData = new DataTable();
            try // пробуем читать
            {
                // для TextFieldParser надо подключить библиотеку Microsoft.VisualBasic
                // но он вовсе не обязателен, CSV в DataTable можете разбирать как хотите
                using (TextFieldParser csvReader = new TextFieldParser(path2file))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    //foreach (string column in colFields) // автобиндинг
                    //{
                    // названия колонок в таблице
                    DataColumn datecolumnID = new DataColumn("id_sm_inc");
                    datecolumnID.AllowDBNull = false;
                    csvData.Columns.Add(datecolumnID);
                    DataColumn datecolumnWorkGr = new DataColumn("work_group");
                    datecolumnWorkGr.AllowDBNull = true;
                    csvData.Columns.Add(datecolumnWorkGr);
                    DataColumn datecolumnEmpl = new DataColumn("emploer");
                    datecolumnEmpl.AllowDBNull = true;
                    csvData.Columns.Add(datecolumnEmpl);
                    //}
                    int buffer_wannabe = 0;
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        csvData.Rows.Add(fieldData);

                        buffer_wannabe++;
                        // начитали 9000 строк, заносим их в базу и сбрасываем буфер на 0
                        if (buffer_wannabe == csvBufferSize)
                        {
                            buffer_wannabe = 0;

                            // функция вставки записей описана ниже
                            if (!insertCurrentBunchOfRecs(csvData)) return 1;

                            csvData.Rows.Clear();
                        }
                    }
                    // в последнем чтении в буфере меньше 9000 записей, их тоже надо занести
                    if (buffer_wannabe != 0)
                    {
                        if (!insertCurrentBunchOfRecs(csvData)) return 1;
                        csvData.Rows.Clear();
                    }
                }
            }
            catch { return 2; }

            // всё огонь
            return 0;
        }

        /// <summary>
        /// Сохранение новых записей во временную таблицу в БД
        /// </summary>
        /// <param name="csvData">строки из CSV</param>
        /// <returns></returns>
        static private bool insertCurrentBunchOfRecs(DataTable csvData)
        {
            Options_save ops = new Options_save();
            try
            {
                using (SqlConnection dbConnection = new SqlConnection(ops.DBPath))
                {
                    dbConnection.Open();
                    // вся соль вот в этом классе - SqlBulkCopy - он делает всю магию
                    using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                    {
                        // если таблица в какой-то схеме, то указать это
                        s.DestinationTableName = "Statistic.sm_inc";
                        foreach (var column in csvData.Columns)
                        {
                            s.ColumnMappings.Add(column.ToString(), column.ToString());
                        }
                        s.WriteToServer(csvData);
                    }
                }
            }
            catch { return false; }

            return true;
        }

        public string pathIncFile//Создаём свойство которое даёт возможность считывать и записывать в поле _FilePath значения.
        {
            get { return _pathIncFile; }  //get - Возвращает значение _FilePath, return - принудительно завершает выполнение и возвращает значение
            set { _pathIncFile = value; } //set - Присваевает значеия, value - хранит значение.
        }
    }
}