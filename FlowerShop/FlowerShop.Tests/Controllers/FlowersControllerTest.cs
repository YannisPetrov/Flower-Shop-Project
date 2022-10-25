namespace FlowerShop.Tests.Controllers
{
    using FlowerShop.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    public class FlowersControllerTest
    {
        
        [Fact]
        public void AddShouldReturnView()
        {
            // Arrange

            var flowersController = new FlowersController(null, null);
            // Act

            var result = flowersController.Add();
            // Assert

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
