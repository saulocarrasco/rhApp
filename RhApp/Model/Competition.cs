using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public enum CompetitionStatus
    {
        Disabled = 0,
        Enable = 1
    }

    public class Competition
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El valor nombre no puede estar vacio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El valor descripcion no puede estar vacio.")]
        public string Description { get; set; }
        public CompetitionStatus Status { get; set; }
        public List<Candidate> Candidates { get; set; } 
    }
}
