using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Candidate : Person
    {
        public string AspirePosition { get; set; }
        public string Department { get; set; }
        public List<Competition> Competitions { get; set; }
        public List<Training> Trainings { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public int EmployeeId { get; set; }
        // Reference
        public Employee Employee { get; set; }
    }
}
