using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class sdzno_entry
    {
        private int _id_sd_zno; //Добавляем приватное(private) поле(_amount), видимое внутри класса.
        private DateTime _cr_date;
        private DateTime _c_date;
        private DateTime _db_min_date;
        private string _voidName;
        private string _employee;
        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>

        public sdzno_entry()     //Создаём конструктор класса, public - видим всеми.
        {
            _employee = "";
            _voidName = "Empty User String";
            _id_sd_zno = 0;        //В этом конструкторе значение _amount равно 0
            _cr_date = DateTime.Now; //Добавляем в конструктор класса значение EntryDate присваеваем значение равное текущему времени DateTime.Now
            _c_date = DateTime.Now; //Сохдаём переменную dt, тк для свойств нельзя использовать out параметр.
            DateTime.TryParse("01.01.1753 12:00:00", out _db_min_date);
        }

        public sdzno_entry(int idsdzno, DateTime date) //Инициализируем класс;
        {
            _id_sd_zno = idsdzno;//Создаём параметр amount
            c_date = date;//Создаём параметр date
        }

        public void InitWithString(string idsdzno, string crate_date, string control_date) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            int.TryParse(idsdzno, out _id_sd_zno); //Метод в этой строке получит данные из amount и с OUT модификатором преобразованные вернёт в их в _amount

            DateTime.TryParse(crate_date, out _cr_date); //Используем TryParse на date передаём значение в dt
            //cr_date = _cr_date;//Занесём в свойство значение dt

            DateTime.TryParse(control_date, out _c_date); //Используем TryParse на date передаём значение в dt
            //c_date = _c_date;//Занесём в свойство значение dt
        }

        public int Id    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _id_sd_zno; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _id_sd_zno = value; } //set - Присваевает значеия, value - хранит значение.
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
        public string category { get; set; }
        public string ca_task_id { get; set; }
        public string ca_task_name { get; set; }
        public string ca_task_category { get; set; }
        public string work_group { get; set; }
    }
}
