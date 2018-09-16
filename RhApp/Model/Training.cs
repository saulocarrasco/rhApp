using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public enum LevelTraining
    {
        Grade=1, PostGrade, Master, PHD, Technical, Management
    }
    public class Training
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public LevelTraining Level { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Institution { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
