using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Filters;

namespace Loader
{
    class Filters //Создаём набор классов которые будут содержать наши фильтры.
    {
        public class StrictMoneyEntryDescriptionFilter : IFilter<Emploe>//Объявляем публичный(public) класс(class) - StrictMoneyEntryDescriptionFilter, наследник(наследующий свойства и методы) класса - : IFilter, входными объектами (<T>) для которого будут объекты типа - <MoneyEntry>;
        {
            public string SerchPattern { get; set; }//Объявляем публичное свойство(способно хранить значение) - SerchPattern

            public bool Filter(Emploe entry)//Объявляем  публичный(public) метод Filter с входными данными - объект entry типа MoneyEntry
            {
                return entry.Description == SerchPattern;//сравниваем объект entry по полю .Description с текстом нашего поискового запроса - SerchPattern
            }

            public IEnumerable<Emploe> Filter(List<Emploe> entries)//Объявляем  публичный(public) интерфейс класса IEnumerable? c входными данными класса <MoneyEntry>, - Filter( List<MoneyEntry> entries)
            {
                return from Emploe me in entries//Задействуем субъязык Linq, пишем выражение запроса, ключевое слово - return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение. Выражение запроса должно начинаться с предложения from, Предложение from определяет в данном случае источник данных, применительно к которому запрос или вложенный запрос будет выполняться
                       where me.Description == SerchPattern//Букв. where - где me.Description - поле(в экземпляре класса MoneyEntry me ) ==(Сравним) с SerchPattern - поисковый запрос.
                       select me; //В выражении запроса предложение select задает тип значений, получаемых при выполнении запроса, - это будет me - экземпляр класса, объект, описывающий строку в таблице, записанных нами через  форму Form1 значений.
            }
        }

        public class LeftMoneyEntryDescriptionFilter : IFilter<Emploe>//Объявляем публичный(public) класс(class) - LeftMoneyEntryDescriptionFilter, наследник(наследующий свойства и методы) класса - : IFilter, входными объектами (<T>) для которого будут объекты типа - <MoneyEntry>;
        {
            public string SerchPattern { get; set; }//Объявляем публичное свойство(способно хранить значение) - SerchPattern

            public bool Filter(Emploe entry)//Объявляем  публичный(public) метод Filter с входными данными - объект entry типа MoneyEntry
            {
                return entry.Description.StartsWith(SerchPattern);//сравниваем объект entry по полю .Description посредством метода .StartsWith который определяет, совпадает ли начало данного экземпляра строки с указанной строкой со строкой (SerchPattern).
            }

            public IEnumerable<Emploe> Filter(List<Emploe> entries)//Объявляем  публичный(public) интерфейс класса IEnumerable? c входными данными класса <MoneyEntry>, - Filter( List<MoneyEntry> entries)
            {
                return from Emploe me in entries //return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение. Предложение from определяет в данном случае источник данных, применительно к которому запрос или вложенный запрос будет выполняться, это будет экземпляр класса  MoneyEntry - me, в (in) entries - list <money entry> - смотри выше.
                       where me.Description.StartsWith(SerchPattern) //Букв. where - где me.Description - поле(в экземпляре класса MoneyEntry me ) .StartWith(Метод. Букв.перевод начинается с....).(SerchPattern) - наш запрос
                       select me;//Букв. select - выбрать, т.е выберем экземпляр me, который подощёл нам по запросу, и отправим его назад. Смотри выше.
            }
        }

        public class RightMoneyEntryDescriptionFilter : IFilter<Emploe>//Объявляем публичный(public) класс(class) - RightMoneyEntryDescriptionFilter, наследник(наследующий свойства и методы) класса - : IFilter, входными объектами (<T>) для которого будут объекты типа - <MoneyEntry>;
        {
            public string SerchPattern { get; set; }//Объявляем публичное свойство(способно хранить значение) - SerchPattern

            public bool Filter(Emploe entry)//Объявляем  публичный(public) метод Filter с входными данными - объект entry типа MoneyEntry
            {
                return entry.Description.EndsWith(SerchPattern);//EndWish - метод сравнивающий конец строки с концом задаваемой строки - SerchPattern
            }

            public IEnumerable<Emploe> Filter(List<Emploe> entries)//Объявляем  публичный(public) интерфейс класса IEnumerable? c входными данными класса <MoneyEntry>, - Filter( List<MoneyEntry> entries)
            {
                return from Emploe me in entries//return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение. Предложение from определяет в данном случае источник данных, применительно к которому запрос или вложенный запрос будет выполняться, это будет экземпляр класса  MoneyEntry - me, в (in) entries - list <money entry> - смотри выше.
                       where me.Description.EndsWith(SerchPattern)//Букв. where - где me.Description - поле(в экземпляре класса MoneyEntry me ) .EndsWith(Метод. Букв.перевод заканчива с этого....).(SerchPattern) - наш запрос
                       select me;//Букв. select - выбрать, т.е выберем экземпляр me, который подощёл нам по запросу, и отправим его назад. Смотри выше.
            }
        }

        public class FreeMoneyEntryDescriptionFilter : IFilter<Emploe>//Объявляем публичный(public) класс(class) - FreeMoneyEntryDescriptionFilter, наследник(наследующий свойства и методы) класса - : IFilter, входными объектами (<T>) для которого будут объекты типа - <MoneyEntry>;
        {
            public string SerchPattern { get; set; }//Объявляем публичное свойство(способно хранить значение) - SerchPattern

            public bool Filter(Emploe entry)//Объявляем  публичный(public) метод Filter с входными данными - объект entry типа MoneyEntry
            {
                return entry.Description.ToLower().Contains(SerchPattern.ToLower());//сравниваем объект entry по полю .Description посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру.
            }

            public IEnumerable<Emploe> Filter(List<Emploe> entries)//Объявляем  публичный(public) интерфейс класса IEnumerable? c входными данными класса <MoneyEntry>, - Filter( List<MoneyEntry> entries)
            {
                return from Emploe me in entries//return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение. Предложение from определяет в данном случае источник данных, применительно к которому запрос или вложенный запрос будет выполняться, это будет экземпляр класса  MoneyEntry - me, в (in) entries - list <money entry> - смотри выше
                       where me.Description.ToLower().Contains(SerchPattern.ToLower())//Букв. where - где me.Description - поле(в экземпляре класса MoneyEntry me ) .ToLower() переводим значение к нижнему регистру .Contains Возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра этого - (SerchPattern - наш запрос.ToLower() -  преводит значение к нижнему регистру )
                       select me;//Букв. select - выбрать, т.е выберем экземпляр me, который подощёл нам по запросу, и отправим его назад. Смотри выше.
            }
        }

        public class FullMoneyEntryFilter : IFilter<Emploe>//Объявляем публичный(public) класс(class) - FullMoneyEntryDescriptionFilter, наследник(наследующий свойства и методы) класса - : IFilter, входными объектами (<T>) для которого будут объекты типа - <MoneyEntry>
        {
            public string SerchPattern { get; set; }//Объявляем публичное свойство(способно хранить значение) - SerchPattern

            public bool Filter(Emploe entry)//Объявляем  публичный(public) метод Filter с входными данными - объект entry типа MoneyEntry
            {
                return//return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение
                    entry.Description.ToLower().Contains(SerchPattern.ToLower()) ||//сравниваем объект entry по полю .Description посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру.
                    entry.Category.ToLower().Contains(SerchPattern.ToLower()) ||//сравниваем объект entry по полю .Description посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру..
                    entry.Amount.ToString().ToLower().Contains(SerchPattern.ToLower()) ||//сравниваем объект entry по полю .Amount посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру. Методом .ToString(), приводим наши данные к строчным значениям.
                    entry.EntryDate.ToString().ToLower().Contains(SerchPattern.ToLower());//сравниваем объект entry по полю .EntryDate посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру. Методом .ToString(), приводим наши данные к строчным значениям. Здесь были ошибки и они исправленны!!!
            }

            public IEnumerable<Emploe> Filter(List<Emploe> entries)//Объявляем  публичный(public) интерфейс класса IEnumerable? c входными данными класса <MoneyEntry>, - Filter( List<MoneyEntry> entries)
            {
                return from Emploe me in entries//return прерывает выполнение метода, в котором оно присутствует и возвращает управление вызывающему методу, а так-же не обязательное значение. Предложение from определяет в данном случае источник данных, применительно к которому запрос или вложенный запрос будет выполняться, это будет экземпляр класса  MoneyEntry - me, в (in) entries - list <money entry> - смотри выше
                       where me.Description.ToLower().Contains(SerchPattern.ToLower()) ||//Ключевое слово where задаёт алгоритм сравнения, отбора, поиска, сравниваем объект entry по полю .Description посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру.
                             me.Category.ToLower().Contains(SerchPattern.ToLower()) ||//сравниваем объект entry по полю .Description посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру.
                             me.Amount.ToString().ToLower().Contains(SerchPattern.ToLower()) ||//сравниваем объект entry по полю .Amount посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру. Методом .ToString(), приводим наши данные к строчным значениям.
                             me.EntryDate.ToString().ToLower().Contains(SerchPattern.ToLower())//сравниваем объект entry по полю .EntryDate посредством метода .Contains который возвращает значение, указывающее, содержит ли указанная строка значение подстроки переданной в качестве параметра - (SerchPattern.ToLower()), методом ToLower() мы переводим значения обоих строчных параметров к нижнему регистру. Методом .ToString(), приводим наши данные к строчным значениям. Здесь были ошибки и они исправленны!!! Теперь ТОЧНО ВСЁ!!!!!! ААААА!!!!! МУРУ МУР!!!!!!!!!!!!!!!!!!!!!!!! УРААААААА!!! ПОБЕДА!!!!!
                       select me;//Букв. select - выбрать, т.е выберем экземпляр me, который подощёл нам по запросу, и отправим его назад. Смотри выше.
            }
        }
    }
}
