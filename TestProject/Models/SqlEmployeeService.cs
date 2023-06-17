namespace TestProject.Models
{
    public class SqlEmployeeService : IEmployee
    {
        private readonly AppDbContext _context;

        public SqlEmployeeService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public EmployeeModel Create(EmployeeModel employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool Delete(int id)
        {
            EmployeeModel employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public EmployeeModel GetEmployeeById(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            return _context.Employees;
        }

        public EmployeeModel Update(EmployeeModel employeeModel)
        {
            var updatedEmployee = _context.Employees.Attach(employeeModel);
            updatedEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employeeModel;
        }
    }
}
