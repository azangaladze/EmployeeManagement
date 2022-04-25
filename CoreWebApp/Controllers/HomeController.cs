using CoreWebApp.Helpers;
using CoreWebApp.Models;
using CoreWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    [Authorize]
    [Route("[Controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                                IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }


        [Route("~/Home")]
        [Route("~/")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? pageNumber)
        {

            int pageSize = 3;
            var model = _employeeRepository.GetAll();
            return View(await PaginatedList<Employee>.CreateAsync((IQueryable<Employee>)model, pageNumber ?? 1, pageSize));
        }

        [Route("{id}")]
        [AllowAnonymous]
        public ViewResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }

            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            _employeeRepository.GetEmployee(1);

            ViewBag.PageTitle = "Employee Details";
            return View(homeDetailsViewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Employee newEmployee = new()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            var employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        var filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                _employeeRepository.Edit(employee);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.Delete(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }

            return RedirectToAction("index");
        }


        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
