using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
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
        public IActionResult Create(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
                return View();

            EmployeeModel model = _employee.Add(employee);
            return RedirectToAction("Details", new { id = model.Id });

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
