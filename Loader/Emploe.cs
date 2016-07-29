using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class Emploe
    {
        private double _amount; //Добавляем приватное(private) поле(_amount), видимое внутри класса.

        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>

        public Emploe()     //Создаём конструктор класса, public - видим всеми.
        {
            _amount = 0;        //В этом конструкторе значение _amount равно 0
            EntryDate = DateTime.Now; //Добавляем в конструктор класса значение EntryDate присваеваем значение равное текущему времени DateTime.Now
            ;
        }

        public Emploe(double amount, DateTime date) //Инициализируем класс;
        {
            _amount = amount;//Создаём параметр amount
            EntryDate = date;//Создаём параметр date
        }

        public void InitWithString(string amount, string date) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            double.TryParse(amount, out _amount); //Метод в этой строке получит данные из amount и с OUT модификатором преобразованные вернёт в их в _amount

            DateTime dt;//Сохдаём переменную dt, тк для свойств нельзя использовать out параметр.
            DateTime.TryParse(date, out dt); //Используем TryParse на date передаём значение в dt
            EntryDate = dt;//Занесём в свойство значение dt



        }

        public override string ToString() //Переопределяем Метод ToString!!!! Из базового класса Object (Предустановлен в стандартной форме) что-бы можно было выводить информацию. !!Ключевое слово override разворачивает метод базового класса для модификации!!
        {
            return string.Format("{0} от {1}", _amount, EntryDate.Date); //Меняем стандартные значения метода(Возвращают название типа класса CSLesson2.MoneyEntry) - return base.ToString(). На текущие - которые будут выводить при конструкции MoneyEntry.ToString "(Число _amount) от (Даты EntryDate)" (5 от 31 декабря 2014)
        }

        public bool IsDebit    //Добавляем свойство которое определяет является ли запись доходом или расходом.
        {
            get //Возвращает значение.
            {
                return (_amount >= 0); //Принудительно вернёт true если значение положительно
            }

            set //Присваевает значение.
            {
                if (value && _amount < 0)  //Условие, если value - TRUE а _amount отрицательно то.....
                    _amount = -_amount;//.....То данная функция перобразует _amount в положительное число и сним можно будет провести дальнеёшие операции.
            }

        }
        public double Amount    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _amount; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _amount = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public DateTime EntryDate { get; set; } //Пример АвтоРеализуемого свойства, нет объявления переменной и.т.д , переменная EntryDate тип DateTime.
        public string Description { get; set; }
        public string Category { get; set; }
    }
}

