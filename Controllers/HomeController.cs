using Employees_CRUD.Data;
using Employees_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Diagnostics;

namespace Employees_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeContext context;

        public HomeController(EmployeeContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result=context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            //var result = context.Employees.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Emloyee model)
        {
            //var result = context.Employees.ToList();
            if (ModelState.IsValid)
            {
                var emp = new Emloyee() { 
                    Name = model.Name,
                    ManagerId = model.ManagerId,
                    IsActive = model.IsActive,
                    StartingDate = model.StartingDate
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
                //return View();
            }
            else
            {
                TempData["error"] = "empty field";
            return View(model);

            }
        }

        public IActionResult DeleteEmployee(int Id)
        {
            var emp=context.Employees.SingleOrDefault(x => x.Id == Id);
            if (emp != null) { 
                context.Employees.Remove(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditEmployee(int Id)
        {
            var emp=context.Employees.SingleOrDefault(x=>x.Id==Id);
          if (emp != null)
            {
                var result = new Emloyee()
                {
                    Name = emp.Name,
                    ManagerId = emp.ManagerId,
                    IsActive = emp.IsActive,
                    StartingDate = emp.StartingDate
                };
                return View(result);
            }
                return View();
        }
        [HttpPost]
        public IActionResult EditEmployee(Emloyee model)
        {
            var emp = new Emloyee() {
            Id = model.Id,
            Name = model.Name,
            ManagerId = model.ManagerId,
            IsActive = model.IsActive,
            StartingDate = model.StartingDate
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
