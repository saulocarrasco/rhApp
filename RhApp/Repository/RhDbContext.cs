using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Data.Repository
{
    public class RhDataBase : DbContext
    {
        public RhDataBase() : base("AzureRhConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RhDataBase>());
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Competition> Competencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobPosition> Jobpositions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
