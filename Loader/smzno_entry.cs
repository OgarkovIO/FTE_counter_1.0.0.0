using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class smzno_entry
    {
        private string _smzno_work_group;

        private DateTime _db_min_date;
        private string _voidName;
        private int _Id;
        private string _to_the_target_date;
        private string _smzno_id;
        private string _number_of_object;
        private string _work_group;
        private string _employee;
        private string _description;
        private string _information;
        private string _service;
        private string _ca_task_id;
        private string _category;
        private string _priority;
        private string _status;
        private string _sender;
        private DateTime _cr_date;
        private DateTime _c_date;
        private DateTime _complete_date;
        private DateTime _date_of_start_work;
        private string _decision;
        private string _closing_code;
        private string _deadline_breached;
        private string _department_addressed;
        private string _Internal_division;
        private string _addressed_structure;
        private string _bank_addressed;
        private string _op;
        private string _type_of_services;
        private int _counter_rediscovered;
        private string _evaluation;
        private string _id_service;
        private string _id_CE;
        private string _object;
        private string _cause_of_incident;
        private string _parent_group;
        private string _intdiv_category;
        private string _customer_comment;
        private int _id_employee;

        public smzno_entry()
        {
            DateTime.TryParse("01.01.1753 12:00:00", out _db_min_date);
            _voidName = "Empty User String";
            _employee = "";
            _work_group = "";
            _smzno_id = "";
            _cr_date = _db_min_date; //Добавляем в конструктор класса значение EntryDate присваеваем значение равное текущему времени DateTime.Now
            _c_date = _db_min_date;
            _complete_date = _db_min_date;
            _date_of_start_work = _db_min_date;
            _counter_rediscovered = 0;
        }

        public void InitWithString(string counter_rediscovered, string crate_date, string control_date, string complete_date, string date_of_start_work) //Создаём публичный - public метод InitWithString, не возвращающий значения - void, с двумя параметрами string amount и string date. В метод будут передаваться значения для преобразования в строку.
        {
            int.TryParse(counter_rediscovered, out _counter_rediscovered);

            DateTime.TryParse(crate_date, out _cr_date); //Используем TryParse на date передаём значение в dt
            //cr_date = _cr_date;//Занесём в свойство значение dt
            DateTime.TryParse(control_date, out _c_date); //Используем TryParse на date передаём значение в dt
            //c_date = _c_date;//Занесём в свойство значение dt
            DateTime.TryParse(complete_date, out _complete_date);

            DateTime.TryParse(date_of_start_work, out _date_of_start_work);
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string ID_SmZNO    //Создаём свойство которое даёт возможность считывать и записывать в поле _amount значения.
        {
            get { return _smzno_id; }  //get - Возвращает значение _amount, return - принудительно завершает выполнение и возвращает значение
            set { _smzno_id = value; } //set - Присваевает значеия, value - хранит значение.
        }
        public string Employee
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

        public string To_the_target_date
        {
            get
            {
                return _to_the_target_date;
            }

            set
            {
                _to_the_target_date = value;
            }
        }

        public string Number_of_object
        {
            get
            {
                return _number_of_object;
            }

            set
            {
                _number_of_object = value;
            }
        }

        public string Work_group
        {
            get
            {
                return _work_group;
            }

            set
            {
                _work_group = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Information
        {
            get
            {
                return _information;
            }

            set
            {
                _information = value;
            }
        }

        public string Service
        {
            get
            {
                return _service;
            }

            set
            {
                _service = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
            }
        }

        public string Priority
        {
            get
            {
                return _priority;
            }

            set
            {
                _priority = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public string Sender
        {
            get
            {
                return _sender;
            }

            set
            {
                _sender = value;
            }
        }

        public DateTime Cr_date
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
            }

            set
            {
                _cr_date = value;
            }
        }

        public DateTime C_date
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
            }

            set
            {
                _c_date = value;
            }
        }

        public DateTime Complete_date
        {
            get
            {
                if (_complete_date.Date < _db_min_date)
                {
                    return _db_min_date;
                }
                else
                {
                    return _complete_date;
                }
            }

            set
            {
                _complete_date = value;
            }
        }

        public DateTime Date_of_start_work
        {
            get
            {
                if (_date_of_start_work.Date < _db_min_date)
                {
                    return _db_min_date;
                }
                else
                {
                    return _date_of_start_work;
                }
            }

            set
            {
                _date_of_start_work = value;
            }
        }

        public string Decision
        {
            get
            {
                return _decision;
            }

            set
            {
                _decision = value;
            }
        }

        public string Closing_code
        {
            get
            {
                return _closing_code;
            }

            set
            {
                _closing_code = value;
            }
        }

        public string Deadline_breached
        {
            get
            {
                return _deadline_breached;
            }

            set
            {
                _deadline_breached = value;
            }
        }

        public string Department_addressed
        {
            get
            {
                return _department_addressed;
            }

            set
            {
                _department_addressed = value;
            }
        }

        public string Internal_division
        {
            get
            {
                return _Internal_division;
            }

            set
            {
                _Internal_division = value;
            }
        }

        public string Addressed_structure
        {
            get
            {
                return _addressed_structure;
            }

            set
            {
                _addressed_structure = value;
            }
        }

        public string Bank_addressed
        {
            get
            {
                return _bank_addressed;
            }

            set
            {
                _bank_addressed = value;
            }
        }

        public string Op
        {
            get
            {
                return _op;
            }

            set
            {
                _op = value;
            }
        }

        public string Type_of_services
        {
            get
            {
                return _type_of_services;
            }

            set
            {
                _type_of_services = value;
            }
        }

        public int Counter_rediscovered
        {
            get
            {
                return _counter_rediscovered;
            }

            set
            {
                _counter_rediscovered = value;
            }
        }

        public string Evaluation
        {
            get
            {
                return _evaluation;
            }

            set
            {
                _evaluation = value;
            }
        }

        public string Id_service
        {
            get
            {
                return _id_service;
            }

            set
            {
                _id_service = value;
            }
        }

        public string Id_CE
        {
            get
            {
                return _id_CE;
            }

            set
            {
                _id_CE = value;
            }
        }

        public string Object
        {
            get
            {
                return _object;
            }

            set
            {
                _object = value;
            }
        }

        public string Cause_of_incident
        {
            get
            {
                return _cause_of_incident;
            }

            set
            {
                _cause_of_incident = value;
            }
        }

        public string Parent_group
        {
            get
            {
                return _parent_group;
            }

            set
            {
                _parent_group = value;
            }
        }

        public string Intdiv_category
        {
            get
            {
                return _intdiv_category;
            }

            set
            {
                _intdiv_category = value;
            }
        }

        public string Customer_comment
        {
            get
            {
                return _customer_comment;
            }

            set
            {
                _customer_comment = value;
            }
        }

        public int Id_employee
        {
            get
            {
                return _id_employee;
            }

            set
            {
                _id_employee = value;
            }
        }

        public string Ca_task_id
        {
            get
            {
                return _ca_task_id;
            }

            set
            {
                _ca_task_id = value;
            }
        }
    }
}
