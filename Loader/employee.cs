using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class employee
    {
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _clearFullName;
        private string _voidName;

        private string _sd_alias;
        private string _sd_alias0;
        private string _sd_alias1;
        private string _sm_alias;
        private string _sm_alias0;
        private string _sm_alias1;
        private string _serch_pattern;

        private string _short_name;

        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>
        public employee()
        {
           _firstName = null;
           _lastName = null;
           _middleName = null;
           _voidName = "Empty User String";

           _sd_alias = null;
           _sm_alias = null;

           _short_name = null;
        }

        public employee(sd_employee sd_emp, sm_employee sm_emp)     //Создаём конструктор класса, public - видим всеми.
        {

        }

        public void GetClearedFullName(string FullClearedName)
        {
            if (FullClearedName == null || FullClearedName == "")
            {
                _firstName = "Empty User String";//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = "Empty User String";//В поле .Category экземпляра me записываем [3] элемент массива
                _middleName = "Empty User String";
                _serch_pattern = "Empty User String";
                //_clearFullName = "EmptyUserString";
            }
            else
            {
                string[] fields = FullClearedName.Split(' ');//Объявляем string-строковый []- массив fields которому присвоим значение, полученное путём преобразования встроенным методом Split(), с заданным нами значением разделителя - '|', строковой переменной FileLine;
                _firstName = fields[0];//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = fields[1];//В поле .Category экземпляра me записываем [3] элемент массива
                _middleName = fields[2];
                _serch_pattern = string.Format("{0} {1}", fields[0], fields[1].First());
                //_clearFullName = string.Format("{0} {1} {2}", fields[0], fields[1], fields[2]);
            }
        }

        public void GetName(string FullName) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            if (FullName == null || FullName == "")
            {
                _firstName = "Empty User String";//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = "Empty User String";//В поле .Category экземпляра me записываем [3] элемент массива
                _middleName = "Empty User String";
                _serch_pattern = "Empty User String";
                _clearFullName = "Empty User String";
            }
            else
            {
                string[] fields = FullName.Split(' ');//Объявляем string-строковый []- массив fields которому присвоим значение, полученное путём преобразования встроенным методом Split(), с заданным нами значением разделителя - '|', строковой переменной FileLine;
                _firstName = fields[0];//В поле .Description экземпляра me записываем [2] элемент массива
                _lastName = fields[1];//В поле .Category экземпляра me записываем [3] элемент массива
                ClearMiddleName(fields[2]);
                _serch_pattern = string.Format("{0} {1}", fields[0], fields[1].First());
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

        public string LastName
        {
            get
            {
                if (_lastName == null || _lastName == "")
                {
                    return _voidName;
                }
                else
                {
                    return _lastName;
                }
            }

            set
            {
                _lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                if (_lastName == null || _lastName == "")
                {
                    return _voidName;
                }
                else
                {
                    return _firstName;
                }
            }

            set
            {
                _firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                if (_lastName == null || _lastName == "")
                {
                    return _voidName;
                }
                else
                {
                    return _middleName;
                }
            }

            set
            {
                _middleName = value;
            }
        }

        public string Serch_pattern
        {
            get
            {
                if (_serch_pattern == null || _serch_pattern == "")
                {
                    return _voidName;
                }
                else
                {
                    return _serch_pattern;
                }
            }

            set
            {
                _serch_pattern = value;
            }
        }

        public string Sm_alias0
        {
            get
            {
                return _sm_alias0;
            }

            set
            {
                _sm_alias0 = value;
            }
        }

        public string Sm_alias
        {
            get
            {
                return _sm_alias;
            }

            set
            {
                _sm_alias = value;
            }
        }

        public string Sd_alias
        {
            get
            {
                return _sd_alias;
            }

            set
            {
                _sd_alias = value;
            }
        }

        public string ClearFullName
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

        public string Sm_alias1
        {
            get
            {
                return _sm_alias1;
            }

            set
            {
                _sm_alias1 = value;
            }
        }

        public string Sd_alias0
        {
            get
            {
                return _sd_alias0;
            }

            set
            {
                _sd_alias0 = value;
            }
        }

        public string Sd_alias1
        {
            get
            {
                return _sd_alias1;
            }

            set
            {
                _sd_alias1 = value;
            }
        }
    }
}
