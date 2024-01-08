using CRUD.DTOs;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public DepartmentController(ApplicationDbContext _db)
        {
            db = _db;
        }


        [HttpGet("{id:int}")]
        public IActionResult GetDepartment(int id)
        {
            Department deptModel = db.Departments.Include(x=>x.Employees).FirstOrDefault(x => x.Id == id);
            DepartmentWithEmployeesDTO deptDTO = new DepartmentWithEmployeesDTO();
            deptDTO.Id = deptModel.Id;
            deptDTO.DepName = deptModel.Name;
            foreach (var item in deptModel.Employees)
            {
                deptDTO.EmpsName.Add(new EmployeeDTO { Id = item.Id, Name = item.Name });
            }
            return Ok(deptDTO);
        }
    }
}
