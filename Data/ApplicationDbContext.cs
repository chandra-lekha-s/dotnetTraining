using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<WorkingHour> WorkingHour { get; set; }
        public DbSet<PaymentRule> PaymentRule { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>().HasData(
                new Designation { Id=1,Name="Intern"},
                new Designation { Id=2,Name="Software Engineer"},
                new Designation { Id=3,Name="Senior Software Engineer"}
                );
            modelBuilder.Entity<PaymentRule>().HasData(
                new PaymentRule { Id=1,RuleName="Cash"},
                new PaymentRule { Id=2,RuleName="Card"},
                new PaymentRule { Id=3,RuleName="UPI"}
                );
            modelBuilder.Entity<WorkingHour>().HasData(
                new WorkingHour { Id=1, CompanyMonthlyWorkingHour=12,EmployeeMonthlyWorkingHour=8},
                new WorkingHour { Id=2, CompanyMonthlyWorkingHour=12,EmployeeMonthlyWorkingHour=7},
                new WorkingHour { Id=3, CompanyMonthlyWorkingHour=12,EmployeeMonthlyWorkingHour=6}
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id=1,Name="smith",DesignationId=1,PaymentRuleId=1,WorkingHourId=1},
                new Employee { Id=2,Name="Nobitha",DesignationId=2,PaymentRuleId=2,WorkingHourId=2},
                new Employee { Id=3,Name="Doremon",DesignationId=3,PaymentRuleId=3,WorkingHourId=3}
                );
        }
    }
}
