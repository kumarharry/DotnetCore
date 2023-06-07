namespace TestProject.Models
{
    public interface IEmployee
    {
        public IEnumerable<EmployeeModel> GetEmployees();
        public EmployeeModel GetEmployeeById(int Id);
        public EmployeeModel Add(EmployeeModel employee);
        public bool Delete(int id);
    }
}
