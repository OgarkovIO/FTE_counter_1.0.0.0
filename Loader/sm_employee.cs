using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class sm_employee
    {
        private string _employee;
        private int _id_emploee;
        private string _voidName;

        public sm_employee()
        {
            _voidName = "Empty User String";
            _id_emploee = 0;
            _employee = "Empty User String";
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

        public int Id_emploee
        {
            get
            {
                return _id_emploee;
            }

            set
            {
                _id_emploee = value;
            }
        }
    }
}
