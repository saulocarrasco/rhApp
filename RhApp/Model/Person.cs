using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo cédula no puede estar vacio.")]
        public string IdentificationNumber { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vacio.")]
        public string Name { get; set; }
        public virtual List<Language> Languages { get; set; }
    }
}
