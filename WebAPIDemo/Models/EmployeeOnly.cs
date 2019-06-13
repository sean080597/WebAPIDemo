using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class EmployeeOnly
    {
        public short EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public Nullable<short> EMPLOYEE_DEPARTMENT { get; set; }
        public Nullable<int> EMPLOYEE_SALARY { get; set; }
    }
}