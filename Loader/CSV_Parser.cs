using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Loader
{
    public class CSV_Parser
    {
        private char _separator = ',';
        private char _quote = '"';
        private int _scipline = 0;

        public IEnumerable<string> ReadLines(string fileName, Encoding enc)
        {
            using (StreamReader sr = new StreamReader(fileName, enc))
                while (sr.Peek() >= 0)
                    yield return sr.ReadLine();
        }

        public static char AutoDetectSeparator(string fileName, Encoding enc)
        {
            fileName = fileName.Split(';')[0];
            using (StreamReader sr = new StreamReader(fileName, enc))
                while (sr.Peek() >= 0)
                {
                    var s = sr.ReadLine();
                    //если есть табуляции - скорее всего это и есть разделитель
                    if (s.Contains("\t")) return '\t';
                    //считаем число запятых и точек с запятыми
                    int semicolonCount = 0;
                    int commaCount = 0;
                    foreach (char c in s)
                        if (c == ';') semicolonCount++;
                        else
                            if (c == ',') commaCount++;
                    //точек с запятыми больше чем запятых
                    if (semicolonCount > commaCount) return ';';
                    return ',';
                }

            return ',';
        }

        public IEnumerable<List<string>> Parse(string fileName, Encoding enc)
        {
            foreach (var line in Parse(ReadLines(fileName, enc).Skip(_scipline)))
                yield return line;
        }

        public IEnumerable<List<string>> Parse(IEnumerable<string> lines)
        {
            var e = lines.GetEnumerator();
            while (e.MoveNext())
                yield return ParseLine(e);
        }

        private List<string> ParseLine(IEnumerator<string> e)
        {
            var items = new List<string>();
            foreach (string token in GetToken(e))
                items.Add(token);
            return items;
        }

        private IEnumerable<string> GetToken(IEnumerator<string> e)
        {
            string token = "";
            State state = State.outQuote;

        again:
            foreach (char c in e.Current)
                switch (state)
                {
                    case State.outQuote:
                        if (c == _separator)
                        {
                            yield return token;
                            token = "";
                        }
                        else
                            if (c == _quote)
                            state = State.inQuote;
                        else
                            token += c;
                        break;
                    case State.inQuote:
                        if (c == _quote)
                            state = State.mayBeOutQuote;
                        else
                            token += c;
                        break;
                    case State.mayBeOutQuote:
                        if (c == _quote)
                        {
                            //кавычки внутри кавычек
                            state = State.inQuote;
                            token += c;
                        }
                        else
                        {
                            state = State.outQuote;
                            goto case State.outQuote;
                        }
                        break;
                }

            //разрыв строки внутри кавычек
            if (state == State.inQuote && e.MoveNext())
            {
                token += Environment.NewLine;
                goto again;
            }

            yield return token;
        }

        enum State { outQuote, inQuote, mayBeOutQuote }

        public char separator    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _separator; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _separator = value; } //set - Присваевает значеия, value - хранит значение.
        }

        public char quote    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _quote; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _quote = value; } //set - Присваевает значеия, value - хранит значение.
        }

        public int scipline    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _scipline; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _scipline = value; } //set - Присваевает значеия, value - хранит значение.
        }
    }
}
/*
var parser = new CsvParser();
            parser.separator = '\t';
            foreach (var line in parser.Parse("c:\\1.csv", Encoding.Default))
                 foreach (var item in line)
                    Console.WriteLine(item);
*/
