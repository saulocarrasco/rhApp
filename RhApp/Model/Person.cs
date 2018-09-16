using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public Language Languages { get; set; }
    }
}
