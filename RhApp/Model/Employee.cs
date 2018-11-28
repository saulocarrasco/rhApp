using RhApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Employee : Person, IBaseInterface
    {
        public DateTime DateJoin { get; set; }
        public string Department { get; set; }
        public string JobPosition { get; set; }
        public decimal Salary { get; set; }
        public ObjectStatus Status { get; set; }
    }
}
