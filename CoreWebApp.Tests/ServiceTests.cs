using AutoFixture;
using AutoFixture.Kernel;
using CoreWebApp.Controllers;
using CoreWebApp.Data;
using CoreWebApp.Interfaces;
using CoreWebApp.Models;
using CoreWebApp.Repositories;
using CoreWebApp.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CoreWebApp.Tests
{
    public class ServiceTests
    {
        private readonly IFixture _fixture;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly HomeController _homeController;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ServiceTests()
        {
            _fixture = new Fixture();
            
            _employeeRepository = new MockEmployeeRepository();
            _homeController = new HomeController(_employeeRepository, hostingEnvironment);

        }
        [Fact]
        public void GetAllEmployees()
        {
            //Arrange
            var employees = _fixture.Create<List<Employee>>();
            var newEmp = _fixture.Create<EmployeeCreateViewModel>();
            //Act
            var result = _homeController.Create(newEmp);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
