using Microsoft.AspNetCore.Mvc;
using TestProject.Models;


namespace TestProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployee employee, IWebHostEnvironment environment)
        {
            _employee = employee;
            _environment = environment;
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeModel> employees = _employee.GetEmployees();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            EmployeeModel employee = _employee.GetEmployeeById(id);
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
                return View();

            string uploadFileName = string.Empty;
            if (employee.PhotoPath.FileName != null)
            {
                string uploadFileFolder = Path.Combine(_environment.WebRootPath, "images");

                uploadFileName = Path.Combine(uploadFileFolder, Guid.NewGuid().ToString() +
                                               "_" + employee.PhotoPath.FileName);

                employee.PhotoPath.CopyTo(new FileStream(uploadFileName, FileMode.Create));
            }
            EmployeeModel newEmployee = new EmployeeModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                DepartmentName = employee.DepartmentName,
                PhotoPath = employee.PhotoPath.FileName
            };
            int empId = _employee.Create(newEmployee).Id;

            return RedirectToAction("Details", new { id = empId });

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_employee.Delete(id))
                return RedirectToAction("Index");

            return new JsonResult(new { result = "Error" });
        }
    }
}
