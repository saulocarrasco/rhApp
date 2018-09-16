using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public enum RiskLevel
    {
        High = 1,
        Medium,
        Low
    }
    public enum JobPositionStatus
    {
        Disabled = 0,
        Enable = 1
    }

    public class JobPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public JobPositionStatus Status { get; set; }
    }
}
