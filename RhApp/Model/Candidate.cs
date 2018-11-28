using RhApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Model
{
    public class Candidate : Person, IBaseInterface
    {
        public string AspirePosition { get; set; }
        public string Department { get; set; }
        public virtual List<Competition> Competitions { get; set; }
        public virtual List<Training> Trainings { get; set; }
        public virtual List<WorkExperience> WorkExperiences { get; set; }
        public ObjectStatus Status { get; set; }
        public decimal SalaryLike { get; set; }

        //[NotMapped]
        //public string CompetitionShows
        //{

        //    get
        //    {
        //        var result = "";

        //        if (Competitions.Count > 0)
        //        {
        //            result = string.Join("-", Array.ConvertAll<object, string>(Competitions, Convert.ToString));
        //        }
        //        return "";
        //    }
        //}
    }
}
