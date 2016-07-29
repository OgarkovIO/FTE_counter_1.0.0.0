using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class sd_employee
    {
        private string _voidName;
        private string _employee;

        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _clearFullName;

        public sd_employee()
        {
            _voidName = "Empty User String";
        }

        public void ClearFullName(string FullName) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            if (FullName == null || FullName == "")
            {
                _firstName = "Empty User String";//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = "Empty User String";//В поле .Category экземпляра me записываем [3] элемент массива
                _middleName = "Empty User String";
                _clearFullName = "Empty User String";
            }
            else
            {
                string[] fields = FullName.Split(' ');//Объявляем string-строковый []- массив fields которому присвоим значение, полученное путём преобразования встроенным методом Split(), с заданным нами значением разделителя - '|', строковой переменной FileLine;
                _firstName = fields[0];//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = fields[1];//В поле .Category экземпляра me записываем [3] элемент массива
                ClearMiddleName(fields[2]);
                _clearFullName = string.Format("{0} {1} {2}", fields[0], fields[1], _middleName);
            }
        }

        private void ClearMiddleName(string InspectionMidleName)
        {
            if (InspectionMidleName.Contains('('))
            {
                string[] fields = InspectionMidleName.Split('(');
                _middleName = fields[0];
            }
            else
            {
                _middleName = InspectionMidleName;
            }
        }

        public string employee
        {
            get
            {
                if (_employee == null || _employee == "")
                {
                    return _voidName;
                }
                else
                {
                    return _employee;
                }
            }
            set
            {
                _employee = value;
            }
        }

        public string ClearedFullName
        {
            get
            {
                if (_clearFullName == null || _clearFullName == "")
                {
                    return _voidName;
                }
                else
                {
                    return _clearFullName;
                }
            }

            set
            {
                _clearFullName = value;
            }
        }

        public string id_employee { get; set; }
    }
}
