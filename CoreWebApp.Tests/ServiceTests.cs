using CoreWebApp.Interfaces;
using CoreWebApp.Models;
using CoreWebApp.Repositories;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CoreWebApp.Tests
{
    public class ServiceTests
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ServiceTests()
        {
            _employeeRepository = new MockEmployeeRepository();
        }
        [Fact]
        public void GetAllEmployees_ShouldReturn_AllEmployees()
        {
            //Arrange
            //Act
            var result = _employeeRepository.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Employee>>();
            result.Should().HaveCount(3);
        }

        [Fact]
        public void DeleteEmployee_ShouldDeleteEmployeeFromList()
        {
            //Arrange
            var employeeId = 1;

            //Act
            _employeeRepository.Delete(employeeId);

            //Assert
            var result = _employeeRepository.GetAll();
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }


        [Fact]
        public void UpdateEmployee_ShouldReturnUpdatedEmployee() 
        {
            //Arrange
            var employeeToUpdate = new Employee()
            {
                Id = 1,
                Department = Enums.Department.HR,
                Email = "james@test.com",
                Name = "James",
            };


            //Act
            var result = _employeeRepository.Edit(employeeToUpdate);

            //Assert
            result.Name.Should().BeEquivalentTo(employeeToUpdate.Name);
            result.Department.Should().Be(Enums.Department.HR);
            result.Email.Should().BeEquivalentTo(employeeToUpdate.Email);
        }

        [Fact]
        public void GetEmployee_ShouldReturnEmployeeWithPassedId() 
        {
            //Arrange
            var employeeId = 1;
            //Act
            var result = _employeeRepository.GetEmployee(employeeId);
            //Assert

            result.Name.Should().Be("Mary");
            result.Department.Should().Be(Enums.Department.HR);
            result.Email.Should().Be("mary@test.com");

        }

        [Fact]
        public void AddEmployee_ShouldReturnAddedEmployee() 
        {
            //Arrange
            var employeeToAdd = new Employee()
            {
                Name = "George",
                Department = Enums.Department.IT,
                Email = "george@test.com"
            };
            //Act

            var result = _employeeRepository.Add(employeeToAdd);

            //Assert
            var employees = _employeeRepository.GetAll();
            employees.Should().HaveCount(4);
            result.Should().BeEquivalentTo(employeeToAdd);
            result.Should().NotBeNull();
        }
    }
}
