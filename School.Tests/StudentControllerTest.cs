using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using School.API.Context;
using School.API.Controllers;
using School.API.Helper.Student.Strategy;
using School.API.Helper.Student.Strategy.Strategies;
using School.API.Models;

namespace School.Tests
{
    public class StudentControllerTest
    {
        public StudentControllerTest()
        {

            
        }


        [Fact]
        public async Task StudentController_ValidRequestNameMinLength_ShouldReturnError()
        {
            //Arrange
            var mockContext = new Mock<SchoolContext>();
            var strategies = new List<IValidateStudentStrategy>()
            {
                new MaxNameLengthStrategy(),
                new MinNameLengthStrategy()
            };

            var factoryStrategy = new ValidateStudentFactoryStrategy(strategies);

            var _unterTest = new StudentsController(mockContext.Object, factoryStrategy);
            var response = new StudentAddModel("Bruno", 1);

            //Act
            var result = await _unterTest.PostStudent(response);

            //Assert
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }

        [Fact]
        public async Task StudentController_ValidRequestNameMaxLength_ShouldReturnError()
        {
            //Arrange
            var mockContext = new Mock<SchoolContext>();
            var strategies = new List<IValidateStudentStrategy>()
            {
                new MaxNameLengthStrategy(),
                new MinNameLengthStrategy()
            };

            var factoryStrategy = new ValidateStudentFactoryStrategy(strategies);

            var _unterTest = new StudentsController(mockContext.Object, factoryStrategy);
            var response = new StudentAddModel("Bruno Costa Souza Alves Oliveira", 1);

            //Act
            var result = await _unterTest.PostStudent(response);

            //Assert
            Assert.Equal(400, ((ObjectResult)result.Result).StatusCode);
        }
    }
}