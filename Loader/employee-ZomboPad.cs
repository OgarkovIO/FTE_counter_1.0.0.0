using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class Employee
    {
        private string _firstName;
        private string _secondName;
        private string _therdName;

        private string _sd_name;
        private string _sm_name;

        private string _short_name;

        /// <summary>
        /// конструктор класса, public - видим всеми.
        /// </summary>
        public Employee()
        {
           _firstName = null;
           _secondName = null;
           _therdName = null;

           _sd_name = null;
           _sm_name = null;

           _short_name = null;
        }


        public Employee(sminc_entry sminc, smzno_entry smzno, sdzno_entry sdzno, sdznr_entry sdznr)     //Создаём конструктор класса, public - видим всеми.
        {

        }

        public string SD_Name
        {
            get { return _sd_name; }  //get - Возвращает значение _source, return - принудительно завершает выполнение и возвращает значение
            set { _sd_name = value; }
        }

        public string SM_Name
        {
            get { return _sm_name; }  //get - Возвращает значение _source, return - принудительно завершает выполнение и возвращает значение
            set { _sm_name = value; }
        }

    }
}
