using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class sdznr_entry
    {
        private int _id_sd_znr; //Добавляем приватное(private) поле(_amount), видимое внутри класса.
        private DateTime _cr_date;
        private DateTime _c_date;
        private DateTime _db_min_date;
        private int _n_users;
        private int _n_users_min;
        private string _employee;
        private string _voidName;

        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>

        public sdznr_entry()     //Создаём конструктор класса, public - видим всеми.
        {
            _voidName = "Empty User String";
            _employee = "";
            _id_sd_znr = 0;        //В этом конструкторе значение _amount равно 0
            _cr_date = DateTime.Now; //Добавляем в конструктор класса значение EntryDate присваеваем значение равное текущему времени DateTime.Now
            _c_date = DateTime.Now; //Сохдаём переменную dt, тк для свойств нельзя использовать out параметр.
            DateTime.TryParse("01.01.1753 12:00:00", out _db_min_date);
            _n_users = 0;
            _n_users_min = 1;
        }

        public sdznr_entry(int idsdznr, DateTime date) //Инициализируем класс;
        {
            _id_sd_znr = idsdznr;//Создаём параметр amount
            c_date = date;//Создаём параметр date
        }

        public void InitWithString(string idsdznr, string crate_date, string control_date, string number_of_users) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            int.TryParse(idsdznr, out _id_sd_znr); //Метод в этой строке получит данные из amount и с OUT модификатором преобразованные вернёт в их в _amount

            if (number_of_users == null)
            {
                _n_users = 1;
            }
            else
            {
                int.TryParse(number_of_users, out _n_users); //Метод в этой строке получит данные из amount и с OUT модификатором преобразованные вернёт в их в _amount
            }

            DateTime.TryParse(crate_date, out _cr_date); //Используем TryParse на date передаём значение в dt
            //cr_date = _cr_date;//Занесём в свойство значение dt

            DateTime.TryParse(control_date, out _c_date); //Используем TryParse на date передаём значение в dt
            //c_date = _c_date;//Занесём в свойство значение dt
        }

        public int Id    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _id_sd_znr; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _id_sd_znr = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public string template { get; set; }
        public DateTime cr_date
        {
            get
            {
                if (_cr_date.Date < _db_min_date)
                {
                    return _db_min_date;
                }
                else
                {
                    return _cr_date;
                }
            }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _cr_date = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public DateTime c_date
        {
            get
            {
                if (_c_date.Date < _db_min_date)
                {
                    return _db_min_date;
                }
                else
                {
                    return _c_date;
                }
            }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _c_date = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public string category { get; set; }
        public string ca_task_id { get; set; }
        public string ca_task_name { get; set; }
        public string ca_task_category { get; set; }
        public string work_group { get; set; }
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
        public int n_users
        {
            get
            {
                if (_n_users < _n_users_min)
                {
                    return _n_users_min;
                }
                else
                {
                    return _n_users;
                }
            }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _n_users = value; } //set - Присваевает значеия, value - хранит значение.
        }
    }
}
