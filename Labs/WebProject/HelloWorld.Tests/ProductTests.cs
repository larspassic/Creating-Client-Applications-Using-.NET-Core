using NUnit.Framework;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Microsoft.Extensions.Options;
using System.Linq;

namespace HelloWorld.Tests
{
    public class ProductTests
    {
        [Test] //Doing the test 
        public void TestMethodWithFakeClass()
        {
            // Arrange - set up your test
            //var optionsMyJsonSettings = Options.Create(new MyJsonSettings());
            //var optionsSecondJson = Options.Create(new SecondJson());

            var controller = new HomeController(new FakeProductRepository()/*, optionsMyJsonSettings, optionsSecondJson*/);

            // Act - execute the code that you are testing
            // We want to test how many products we "display"
            var result = controller.Products();

            // Assert - verify the results
            var products = (Product[])((Microsoft.AspNetCore.Mvc.ViewResult)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
        }

        [Test]
        public void TestExercise2()
        {
            //Arrange
            var controller = new HomeController(new FakeProductRepository()/*, optionsMyJsonSettings, optionsSecondJson*/);

            //Act
            var result = controller.Products();

            //Assert
            var products = (Product[])((Microsoft.AspNetCore.Mvc.ViewResult)(result)).Model;

            
            Assert.GreaterOrEqual(products.Where(t => t.Price > 10).Count(), 3);
            Assert.GreaterOrEqual(products.Where(t => t.Price < 10).Count(), 2);
        }
    }
}