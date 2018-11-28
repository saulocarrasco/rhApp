using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public enum LevelTraining
    {
        Grade=1, PostGrade=2, Master=3, PHD=4, Technical=5, Management=6
    }
    public class Training: IBaseInterface
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe ingresar la Descripcion.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Debe ingresar El nivel de la Capacitacion.")]
        [Range(1, 6,ErrorMessage ="Debe ingresar el nivel de la Capacitacion.")]
        public LevelTraining? Level { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre la institución donde realizo la capacitación.")]
        public string Institution { get; set; }
        public virtual List<Candidate> Candidates { get; set; }
        public ObjectStatus Status { get; set; }
    }
}
