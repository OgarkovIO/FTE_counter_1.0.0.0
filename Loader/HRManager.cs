using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Filters;
using System.Windows.Forms;

namespace Loader
{
    public class HRManager
    {
        private string _source;//Объявляем приватное( private) строковое(string) поле (_source), для храниния данных о месте расположения файла.
        private List<Emploe> _entries;//Объявляем приватную(private) список(List) который будет содержать элементы класса <MoneyEntry> наз. _entries;
        private IFilter<Emploe> _filter;

        public HRManager()//Создаём публичный конструктор класса, для работы с ним во внешней среде.
        {
            _entries = new List<Emploe>();//Объявляем что _entries является новым(new) листом (List) элементов типа <MoneyEntry>().
            _source = "";//полю _source присваевается пустое значение.             
        }

        /*public Manager(string source)//!!ВАЖНО!!Публичный конструктор класса со входными параметраме - строка (string) source сделано для возможности запуска метода ReadData() не из формы.
            :this()//Пока не работает, не ясно зачем
        {//Это всё можно превратить в комментарии, оно не нуэно на самом деле, смотри конструктор класса FORM1 с пояснениями.
            _entries = new List<MoneyEntry>();//Объявляем что _entries является новым(new) листом (List) элементов типа <MoneyEntry>().

            ReadData(source);//не читает при инициализации не разбирался почему..... Если везеде убрать комментарии то всё равно будет работать.
        }*/

        public bool ReadData(string source)//Создаём метод чтения из файла, входные параметры строковая (string) переменная source
        {
            _source = source;//Передаём этой переменной путь к файлу который хранится в _source

            if (!File.Exists(source))//Если(if) не(!) File(системный класс для работы с файлами) .Exists(метод определяющий существует ли данный файл, входной параметр путь к файлу) source - переменная хранящая путь к файлу...... 
                return false;//.....возвращаем (return) false

            StreamReader sr = new StreamReader(source, Encoding.UTF8);//Создаём новый экземпляр - sr системного класса StreamReader(считывает данные из потока), и тут-же объявляем его = new StreamReader(source, Encoding.UTF8) - где входными параметрами будет переменная хранящая путь к файлу - source, и класс Encoding, с помощью которого мы обозначим кодировку - .UTF8
            string FileLine;//Создадим новую строковую - string переменную FileLine

            while ((FileLine = sr.ReadLine()) != null)//Запускаем цикл  while который будет выполнятся пока равенство (FileLine = sr.ReadLine()) не равно (!=) null(нолю), а метод sr.ReadLine() будет производить чтение строк каждую итерацию и записывать и перезаписывать их значения в переменную FileLine
            {
                string[] fields = FileLine.Split('|');//Объявляем string-строковый []- массив fields которому присвоим значение, полученное путём преобразования встроенным методом Split(), с заданным нами значением разделителя - '|', строковой переменной FileLine;
                Emploe me = new Emploe();//Объявляем и инициализируем новый (new) экземпляр класса MoneyEntry me
                me.InitWithString(fields[0], fields[1]);//Используя метод InitWithString экземпляра me класса MoneyEntry преобразуем и записываем [0] и [1] элемент массива в наш класс, где храним.
                me.Description = fields[2];//В поле .Description экземпляра me записываем [2] элемент массива
                me.Category = fields[3];//В поле .Category экземпляра me записываем [3] элемент массива

                AddEntry(me);//Применяем метод AddEntry() входными значениями для которого будет экземпляр me
            }
            sr.Close();//Закрываем, поток на чтение методом .Close()

            return true;//.....возвращаем (return) true
        }

        public void AddEntry(Emploe me)//Создаём публичны метод для записи, наших данных в виртуальный список _entries
        {
            _entries.Add(me);//из списка запускаем, команду создания строки .Add, в скобках указываем вносимые данные, которые являются экземпляром класса MoneyEntry - me
        }

        public void SaveOne(Emploe me)//Создаём так-же метод для сохранения лишь одной строки в файл, потребуется при работе с базами, я думаю.
        {
            StreamWriter sw = new StreamWriter(_source, true, Encoding.UTF8);//Объявляем новый экземпляр класса StreamWriter - sw, посредством клюяегово слова new и повторногу указания класса StreamWriter, в скобках задаём параметры - 1. место хранения(хранится в переменной _source), 2. true для добавления данных в файл, если false то файл перезапишется. 3.Уазываем в какой кодировки писать в файл.
            sw.WriteLine(//Вызываем из экземпляра sw метод .WriteLine, во в ходных данных указывакм
                    string.Format("{0}|{1}|{2}|{3}",//Во входных данных указывакм посредством расширителя строки(string) - метода (.Format), разделяем строку на 4 части символом (|), обозначаем эти части {0}|{1}|{2}... и т.д.
                    me.Amount,//Через запятую перечисляем поля по порядку, т.е, это {0}....
                    me.EntryDate.ToShortDateString(),//Это {1}, методом ToShortDateString(), мы приводим запись вида "11 марта 2015 года" к виду "11.03.2015".
                    me.Description,//{2}
                    me.Category));//{3}
            sw.Close();//Обязательно закрываем поток, иначе, ничего не сохранится, и файл зависнет. Ты забыл об этом прошлый раз!!!
        }

        public void SaveAll()//Объявляем метод для сохранения всех данных формы в файл.
        {
            try//Добавляем обработчик исключений в нутрь которого ложим запускаемый код.
            {
                StreamWriter sw = new StreamWriter(_source, false, Encoding.UTF8);//Объявляем новый экземпляр класса StreamWriter - sw, посредством клюяегово слова new и повторногу указания класса StreamWriter, в скобках задаём параметры - 1. место хранения(хранится в переменной _source). 2. Значение false для перезаписи файла. 3.Уазываем в какой кодировки писать в файл.

                foreach (Emploe me in _entries)//Объявляем цикл foreach, с условием() - Если в(in) коллекции(_entries) есть экземпляр класса MoneyEntry, условно me, то выполнится действие ниже, и цикл перейдёт к следующему элементу.
                {
                    sw.WriteLine(//Вызываем из экземпляра sw метод .WriteLine, во в ходных данных указывакм....
                        string.Format("{0}|{1}|{2}|{3}",//....Во входных данных указываем посредством расширителя строки(string) - метода (.Format), разделяем строку на 4 части символом (|), обозначаем эти части {0}|{1}|{2}... и т.д.
                        me.Amount,//Через запятую перечисляем поля по порядку, т.е, это {0}....
                        me.EntryDate.ToShortDateString(),//Это {1}, методом ToShortDateString(), мы приводим запись вида "11 марта 2015 года" к виду "11.03.2015".
                        me.Description,//{2}
                        me.Category));//{3}
                }
                sw.Close();//Повторим!!!!! Обязательно закрываем поток, иначе, ничего не сохранится, и файл зависнет. Ты забыл об этом прошлый раз!!!
            }
            catch//Перехватываем исключение и ......
            {
                MessageBox.Show("Недоступен файл для записи");//В случе ошибки будет показанно это сообщение.
            }
        }

        public double balance//Здесь объявлен метод для расчёта баланса вне формы
        {
            get//get - Возвращает значение
            {
                double balance = 0;//Обявляем переменнуютипа double, с названием balance, присваеваем ей значение - 0 (= 0)
                foreach (Emploe me in _entries)//Объявляем цикл foreach, с условием() - Если в(in) коллекции(_entries) есть экземпляр класса MoneyEntry, условно me, то выполнится действие ниже, и цикл перейдёт к следующему элементу.
                    balance += me.Amount;//...переменной balance прибавляется (+=) значение поля me.Amount экземпляра me класса MoneyEntry...... Затем мы переходим к следующему значению. 
                return balance;//return - принудительно завершает выполнение и возвращает значение
            }
        }

        public double FiltredBalace
        {
            get//get - Возвращает значение
            {
                double balance = 0;//Обявляем переменнуютипа double, с названием balance, присваеваем ей значение - 0 (= 0)
                foreach (Emploe me in Entries)//Объявляем цикл foreach, с условием() - Если в(in) коллекции(_entries) есть экземпляр класса MoneyEntry, условно me, то выполнится действие ниже, и цикл перейдёт к следующему элементу.
                    balance += me.Amount;//...переменной balance прибавляется (+=) значение поля me.Amount экземпляра me класса MoneyEntry...... Затем мы переходим к следующему значению. 
                return balance;//return - принудительно завершает выполнение и возвращает значение
            }
        }

        public string source    //Создаём свойство которое даёт возможность считывать и записывать в поле _source значения.
        {
            get { return _source; }  //get - Возвращает значение _source, return - принудительно завершает выполнение и возвращает значение
            set { _source = value; } //set - Присваевает значеия, value - хранит значение.
        }

        public IEnumerable<Emploe> Entries// Объявляем публичный метод перечеслитель(класс IEnumerable) в<скобках> указанно что будем перебирать - <MoneyEntry>, называем его Entries
        {
            get//Задаём возращение значений словом get
            {
                if (_filter == null)
                {
                    foreach (Emploe me in _entries)
                        yield return me;
                }

                //return _entries;//версия 2 - Возвращаем (return) _entries, коллекцию.
                else
                {
                    //List<MoneyEntry> FilteredEntries = new List<MoneyEntry>();//версия 2 - Плохой способ фильтрации т.к держит список в памяти, занимает место.
                    foreach (Emploe me in _entries)
                        if (_filter.Filter(me))
                            yield return me;
                    // FilteredEntries.Add(me);//версия 2 - к списку.
                    //return FilteredEntries;//версия 2 - Нужен для списка.
                }
            }
        }

        public IEnumerable<Emploe> LinqEntries// Объявляем публичный метод перечеслитель(класс IEnumerable) в<скобках> указанно что будем перебирать - <MoneyEntry>, называем его Entries
        {
            get//Задаём возращение значений словом get
            {
                if (_filter == null)
                {
                    return _entries;
                }

                //return _entries;//версия 2 - Возвращаем (return) _entries, коллекцию.
                else
                {
                    //List<MoneyEntry> FilteredEntries = new List<MoneyEntry>();//версия 2 - Плохой способ фильтрации т.к держит список в памяти, занимает место.
                    return Filter.Filter(_entries);
                    // FilteredEntries.Add(me);//версия 2 - к списку.
                    //return FilteredEntries;//версия 2 - Нужен для списка.
                }
            }
        }

        public IFilter<Emploe> Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

    }

}
