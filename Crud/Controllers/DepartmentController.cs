using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly AppDbContext _appdbcontext;
        public DepartmentController(AppDbContext appDbContext)
        {
            _appdbcontext = appDbContext;
        }
        public IActionResult Index()
        {
            var data = _appdbcontext.Departments.ToList();

            return View(data);
        }
        public IActionResult Create()
        {
            
            return View();  
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else {
                _appdbcontext.Departments.Add(department);
                _appdbcontext.SaveChanges();
                TempData["success"] = "Department has been added";
            }
            return Redirect("Index");

            
        }

        public IActionResult Edit(int? id)
        {
            DepartmentModel department = new DepartmentModel();
            if (id != null && id != 0)
            {
                department = _appdbcontext.Departments.Find(id);
            }

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit( int? id ,DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
               
                    _appdbcontext.Departments.Update(department);
                    _appdbcontext.SaveChanges();
                    TempData["success"] = "Department has been updated";
                
              
                
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                bool status = _appdbcontext.Employees.Any(x => x.DepartmentId == id);
                if (status)
                {
                    TempData["warning"] = "Departmernt is taken by another employee,so can not sdelete this";
                }
                else {
                    var deparment = _appdbcontext.Departments.Find(id);
                    if (deparment == null)
                    {
                        return NotFound();
                    }
                    else
                    {


                        _appdbcontext.Departments.Remove(deparment);
                        _appdbcontext.SaveChanges();
                        TempData["success"] = "Department has been deleted";
                    }
                }

            }
            else {

                return BadRequest();
            }
            return RedirectToAction("Index");
        }


    }
}
