using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public enum RiskLevel
    {
        High = 1,
        Medium=2,
        Low=3
    }

    public class JobPosition : IBaseInterface
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Debe ingresar el nombre.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe ingresar El nivel de riesgo.")]
        [Range(1, 3, ErrorMessage = "Debe ingresar el nivel de riesgo.")]
        public RiskLevel? RiskLevel { get; set; }
        [Required(ErrorMessage ="Debe ingresar el salario minimo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar el salario minimo.")]
        public decimal MinSalary { get; set; }
        [Required(ErrorMessage ="Debe ingresar el salario maximo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar el salario maximo.")]
        public decimal MaxSalary { get; set; }
        //public JobPositionStatus Status { get; set; }
        public ObjectStatus Status { get; set; }
    }
}
