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
        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>

        public sdznr_entry()     //Создаём конструктор класса, public - видим всеми.
        {
            _id_sd_znr = 0;        //В этом конструкторе значение _amount равно 0
            _cr_date = DateTime.Now; //Добавляем в конструктор класса значение EntryDate присваеваем значение равное текущему времени DateTime.Now
            _c_date = DateTime.Now; //Сохдаём переменную dt, тк для свойств нельзя использовать out параметр.
        }

        public sdznr_entry(int idsdznr, DateTime date) //Инициализируем класс;
        {
            _id_sd_znr = idsdznr;//Создаём параметр amount
            c_date = date;//Создаём параметр date
        }

        public void InitWithString(string idsdznr, string crate_date, string control_date) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            int.TryParse(idsdznr, out _id_sd_znr); //Метод в этой строке получит данные из amount и с OUT модификатором преобразованные вернёт в их в _amount

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
            get { return _cr_date; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _cr_date = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public DateTime c_date
        {
            get { return _c_date; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _c_date = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public string category { get; set; }
        public string ca_task_id { get; set; }
        public string ca_task_name { get; set; }
        public string ca_task_category { get; set; }
        public string in_group { get; set; }
        public string emploe { get; set; }
        public string n_users { get; set; }
    }
}
