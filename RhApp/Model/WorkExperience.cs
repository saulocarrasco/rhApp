using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal Salary { get; set; }
        public int? CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
