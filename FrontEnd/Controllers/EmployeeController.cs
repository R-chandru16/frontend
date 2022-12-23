using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        // GET: EmployeeController
        public ActionResult Index()
        {
            string token = TempData.Peek("Token").ToString();
            ICollection<Employee> emp = _employeeService.GetAll(token);

            return View(emp);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if(_employeeService.Add(emp,TempData.Peek("Token").ToString()) !=null)
                {
                    ViewBag.Message = "Success";
                    return View(); ;
                }
               
            }
            catch
            {
                return View();
                
            }
            ViewBag.Message = "Failure";
            return View();
        }

    
       
    }
}
