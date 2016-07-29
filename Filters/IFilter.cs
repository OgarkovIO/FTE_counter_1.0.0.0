using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters//Создаём новый класс для фильтрации значений из нашей таблицы.
{
    public interface IFilter<T>//Создаём интерфейс IFilter с входным элементом <T>
    {
        bool Filter(T entry);//Задаём метод Filter(тип выходных данных - bool) с входным элементом(T - Объект, проверяемый на соответствие критериям, заданным в методе, который представлен его делегатом.) - тип entry. 1.Нужно для загрузки в память одного элемента.

        IEnumerable<T> Filter(List<T> entries);//Объявляем IEnumerable интерфейс перечислитель элементов <T> - Filter входными данными которого будет строго типизированный список элементов <T> - List с именем entries.  
    }
}
