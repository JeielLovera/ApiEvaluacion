using ApiEvaluacion.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.DataLayer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobSector> JobSectors { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
