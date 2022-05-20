using CoreWebApp.Controllers;
using CoreWebApp.Interfaces;
using CoreWebApp.Models;
using CoreWebApp.Repositories;
using CoreWebApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoreWebApp.Tests
{
    public class ControllerTests
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IEmployeeRepository _employeeRepository;

        public ControllerTests()
        {
            _employeeRepository = new MockEmployeeRepository();
        }
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfEmployees()
        {

            // Arrange
            
            var controller = new HomeController(_employeeRepository, hostingEnvironment);

            // Act
            var result = controller.Index(1,"");
            
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Employee>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void CreatePost_ReturnsARedirectAndAddsEmployee_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            var emp = new Employee();
            mockRepo.Setup(repo => repo.Add(emp))
                .Returns(emp);
            var controller = new HomeController(mockRepo.Object, hostingEnvironment);
            var empModel = new EmployeeCreateViewModel()
            {
                Name= "Jane",
                Department= Enums.Department.IT,
                Email = "jane@test.com"
            };

            // Act
            var result = controller.Create(empModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("details", redirectToActionResult.ActionName);
            
        }

        [Fact]
        public void DeleteEmployee_RedirectsToIndex() 
        {
            //Arrange
            var employeeId = 1;
            var controller = new HomeController(_employeeRepository, hostingEnvironment);
            //Act
            var result = controller.Delete(employeeId);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("index", redirectToActionResult.ActionName);
        }


        [Fact]
        public void EmployeeDetails_ReturnsAViewResult()
        {
            //Arrange
            var employeeId = 1;
            var controller = new HomeController(_employeeRepository, hostingEnvironment);
            //Act
            var result = controller.Details(employeeId);
            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
