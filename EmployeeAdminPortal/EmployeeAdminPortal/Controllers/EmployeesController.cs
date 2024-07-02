using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxx/api/nameofcontroller(employees)
    [Route("api/[controller]")]//route attribute
    [ApiController] //atrribute
    public class EmployeesController : ControllerBase //inherting from controller base class
    {
        private readonly ApplicationDbContext dbContext;

        // using applicationDbContext from program.cs by creating constructor injection
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        //endPoints
        [HttpGet]//Read
        public IActionResult GetAllEmployees()//defining name of the action method
        {
            //var allEmployees = ;

            return Ok(dbContext.Employees.ToList());
        }


        [HttpGet]//Read by id
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) 
        {
          var employee =  dbContext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();  
            }
            return Ok(employee);
        }


        [HttpPost]//Create
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee == null)
            {
                return BadRequest(404);
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
               return NotFound();
            }

            dbContext.Employees.Remove(employee);

            dbContext.SaveChanges();

            return Ok();
        }
    }
}
