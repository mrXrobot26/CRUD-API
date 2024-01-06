using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public EmployeeController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = db.Employees.ToList();
            return Ok(employees);

        }
        [HttpGet("{id}")]
        public IActionResult EmployeeDetail(int id)
        {
            var FoundedEmp = db.Employees.FirstOrDefault(x => x.Id == id);
            if (FoundedEmp!=null)
            {
                return Ok(FoundedEmp);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployees([FromRoute]int id , Employee emp)
        {
            var FoundedEmp = db.Employees.FirstOrDefault(x => x.Id == id);
            if (FoundedEmp==null)
            {
                return NotFound();
            }

            FoundedEmp.Name = emp.Name;
            FoundedEmp.Salary = emp.Salary;
            FoundedEmp.Age = emp.Age;

            db.SaveChanges();

            return Ok(FoundedEmp);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody]Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var FoundedEmp = db.Employees.FirstOrDefault(x => x.Id == id);
            if (FoundedEmp == null)
            {
                return NotFound();
            }
            db.Employees.Remove(FoundedEmp);
            db.SaveChanges();
            return Ok($"{FoundedEmp.Name} deleted sucesfuly");

        }



    }
}
