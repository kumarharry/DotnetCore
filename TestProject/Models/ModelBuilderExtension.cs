using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public static class ModelBuilderExtension
    {
        public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasData(
           new EmployeeModel
           {
               Id = 1,
               Name = "Harinder Kumar",
               Email = "harry@gmail.com",
               DepartmentName = DepartmentEnum.IT
           },
           new EmployeeModel
           {
               Id = 2,
               Name = "Mukesh Kumar",
               Email = "mk@gmail.com",
               DepartmentName = DepartmentEnum.HR
           }
           );
        }
    }
}
