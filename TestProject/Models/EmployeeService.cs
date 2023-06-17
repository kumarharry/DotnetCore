using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestProject.Models
{
    public class EmployeeService : IEmployee
    {
        List<EmployeeModel> _employees;
        public EmployeeService()
        {
            _employees = new List<EmployeeModel>() {
            new EmployeeModel() {Id =1 , Name= "Harinder Kumar", Email="h@gmail.com", DepartmentName=DepartmentEnum.IT},
            new EmployeeModel() {Id =2 , Name= "Anju Kumari", Email="a@gmail.com", DepartmentName= DepartmentEnum.PayRoll}
            };
        }
        public EmployeeModel GetEmployeeById(int Id)
        {
            return _employees.First(x => x.Id == Id);
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return _employees;
        }

        public EmployeeModel Create(EmployeeModel employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public bool Delete(int id)
        {
            bool result = false;
            EmployeeModel emp = _employees.FirstOrDefault(x => x.Id == id) ?? new EmployeeModel();

            if (emp != null)
            {
                _employees.Remove(emp);
                result = true;
            }
            return result;
        }

        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            EmployeeModel employee = _employees.FirstOrDefault(x=>x.Id == employeeModel.Id) ?? new EmployeeModel();
            if (employee != null)
            {
                employee.Id = employeeModel.Id;
                employee.Name = employeeModel.Name;
                employee.DepartmentName= employeeModel.DepartmentName;
                employee.Email = employeeModel.Email;
            }
            return employee;
        }
    }
}
