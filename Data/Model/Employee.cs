using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public enum EmployeeStatus
    {
        Disabled = 0,
        Enable = 1
    }
    public class Employee : Person
    {
        public DateTime DateJoin { get; set; }
        public string Department { get; set; }
        public string JobPosition { get; set; }
        public decimal Salary { get; set; }
        public EmployeeStatus Status {get;set;}
    }
}
