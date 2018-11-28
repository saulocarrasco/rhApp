using Data.Model;
using RhApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace Data.Repository
{
    public class RhDataBase : DbContext
    {
        public RhDataBase() : base("name=AzureRhConnection")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<RhDataBase>());
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Competition> Competencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobPosition> Jobpositions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

    }
}
