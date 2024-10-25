using Microsoft.AspNetCore.Mvc;
using Crud.Data;
using Crud.Models;

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Collections.Generic;
namespace Crud.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private static string EveryFirstCharacter(string input)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(input))
            {

                var data = input.Split(' ');
                //for (int i = 0; i < data.Length; i++)
                //{

                //    sb.Append(data[i].First().ToString().ToUpper() + data[i].Substring(1) + " ");

                //}
                foreach (var d in data)
                {

                    sb.Append(d.First().ToString().ToUpper() + d.Substring(1) + " ");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        public IActionResult Index()
        {
            //    //merge model method --jb merge model method ka use krte hai to ienumrable ka use view page me nhi krte hai//
            //    ViewModel emp = new ViewModel();
            //emp.employees = _appDbContext.Employees.ToList();
            //emp.departments = _appDbContext.Departments.ToList();
            //    //emp.employees = empdata;
            //    //emp.departments = depdata;
            //return View(emp);

            //using join  linq  model  isme view model ka use nhi krenge//
            var data = (from e in _appDbContext.Employees
                        join d in _appDbContext.Departments
                       on e.DepartmentId equals d.DeparmentId
                        select new EmployeeDeparmentviewmodel
                        {
                            EmployeeId = e.EmployeeId,
                            FirstName = EveryFirstCharacter(e.FirstName),
                            LastName = EveryFirstCharacter(e.LastName),
                            Gender = EveryFirstCharacter(e.Gender),
                            DepartmentCode = d.DepartmentCode.ToUpper(),
                            DepartmentName = EveryFirstCharacter(d.DepartmentName),
                        }).ToList();


            return View(data);

            // use raw query isme ienumrable ka use nhi krenge isme view model ka use krenge//
            //var empdata = _appDbContext.Employees.FromSqlRaw("Select*from Employees").ToList();
            //var depdata = _appDbContext.Departments.FromSqlRaw("Select*from Departments").ToList();

            //ViewModel emp = new ViewModel();
            //emp.employees = empdata;
            //emp.departments = depdata;
            //return View(emp
            //
            //using raw query with join isme ienumrable ka use krenge ismr view model ka use nhi krenge//

            //var data = _appDbContext.EmployeeDeparmentviewmodels.FromSqlRaw("select e.EmployeeId,e.FirstName,e.LastName,e.Gender,d.DepartmentCode,d.DepartmentName from Employees e \r\njoin Departments d on e.DepartmentId=d.DeparmentId");
            //return View(data);

            // using procedure//

            //ViewModel emp = new ViewModel();
            //var empdata = _appDbContext.Employees.FromSqlRaw("exec getemployee").ToList();
            //var depdata = _appDbContext.Departments.FromSqlRaw("exec Getdepartments").ToList();
            //emp.employees = empdata;
            //emp.departments = depdata;

            //return View(emp);

            //using procedure with join//

            //var data = _appDbContext.EmployeeDeparmentviewmodels.FromSqlRaw("exec GetEmployeeDeparmentList").ToList();

            //return View(data);   


        }

        public IActionResult Create()
        {
            ViewBag.y = _appDbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDeparmentviewmodel emp)
        {
            ViewBag.y = _appDbContext.Departments.ToList();
            ModelState.Remove("DepartmentName");
            ModelState.Remove("DepartmentCode");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "please enter valid data!");
                return View(emp);
            }
            else {
                var data = new EmployeeModel()
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Gender = emp.Gender,
                    DepartmentId = emp.DeparmentId,

                };
                _appDbContext.Employees.Add(data);
                _appDbContext.SaveChanges();
                TempData["success"] = "Record has been successful inserted";

            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.y = _appDbContext.Departments.ToList();
            EmployeeDeparmentviewmodel employeedetails = new EmployeeDeparmentviewmodel();

            if (id == 0)
            {
                return BadRequest();
            }
            else
            {


                employeedetails = (from e in _appDbContext.Employees.Where(e => e.EmployeeId == id)
                                   join d in _appDbContext.Departments
                                  on e.DepartmentId equals d.DeparmentId
                                   select new EmployeeDeparmentviewmodel
                                   {
                                       EmployeeId = e.EmployeeId,
                                       FirstName = EveryFirstCharacter(e.FirstName),
                                       LastName = EveryFirstCharacter(e.LastName),
                                       Gender = EveryFirstCharacter(e.Gender),
                                       DeparmentId = e.DepartmentId,

                                       DepartmentCode = d.DepartmentCode.ToUpper(),
                                       DepartmentName = EveryFirstCharacter(d.DepartmentName),
                                   }).First();

                if (employeedetails == null)
                {

                    return NotFound();

                }

            }
            return View(employeedetails);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeDeparmentviewmodel emp)
        {
            ViewBag.y = _appDbContext.Departments.ToList();
            ModelState.Remove("DepartmentName");
            ModelState.Remove("DepartmentCode");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "please enter valid data!");
                return View(emp);
            }
            else
            {
                var data = new EmployeeModel()
                {
                    EmployeeId=emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Gender = emp.Gender,
                    DepartmentId = emp.DeparmentId,

                };
                _appDbContext.Employees.Update(data);
                _appDbContext.SaveChanges();
                TempData["success"] = "Record has been successful Updated";

            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            EmployeeDeparmentviewmodel employeedetails = new EmployeeDeparmentviewmodel();

            if (id == 0)
            {
                return BadRequest();
            }
            else {


                 employeedetails = (from e in _appDbContext.Employees.Where(e=> e.EmployeeId==id)
                            join d in _appDbContext.Departments
                           on e.DepartmentId equals d.DeparmentId
                            select new EmployeeDeparmentviewmodel
                            {
                                EmployeeId = e.EmployeeId,
                                FirstName = EveryFirstCharacter(e.FirstName),
                                LastName = EveryFirstCharacter(e.LastName),
                                Gender = EveryFirstCharacter(e.Gender),
                               DeparmentId=e.DepartmentId,

                                DepartmentCode = d.DepartmentCode.ToUpper(),
                                DepartmentName = EveryFirstCharacter(d.DepartmentName),
                            }).First();

                if (employeedetails == null)
                {

                    return NotFound();

                }

            }
            return View(employeedetails);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {

                return NotFound();
            }
            else {
                var data = _appDbContext.Employees.Find(id);
                if (data == null)
                {
                    return NotFound();

                }
                else
                {
                    _appDbContext.Remove(data);
                    _appDbContext.SaveChanges();
                    TempData["success"] = "Record has been delete";
                }

                return RedirectToAction("Index");

            }
        }

    }
}
  