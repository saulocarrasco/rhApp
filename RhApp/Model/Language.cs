using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public enum LanguageStatus
    {
        Disabled = 0,
        Enable = 1
    }
    public class Language : IBaseInterface
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe Llenar el campo nombre.")]
        public string Name { get; set; }
        public ObjectStatus Status { get; set; }
        public virtual List<Person> Persons { get; set; }
        //  public LanguageStatus Status { get; set; }
    }
}
