using Data.Model;
using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public class Competition : IBaseInterface
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El valor nombre no puede estar vacio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El valor descripcion no puede estar vacio.")]
        public string Description { get; set; }
        public List<Candidate> Candidates { get; set; }
        public ObjectStatus Status { get; set; }
    }
}
