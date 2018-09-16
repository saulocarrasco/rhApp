using Data.Model;
using System;
using System.Collections.Generic;
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
        public string Description { get; set; }
        public CompetitionStatus Status { get; set; }
        public List<Candidate> Candidates { get; set; } 
    }
}
