namespace FlowerShop.Tests.Services
{
    using FlowerShop.Services.Flowers;
    using FlowerShop.Tests.Mocks;
    using FlowerShop.Data.Models;

    public class FlowerServiceTest
    {
        private const int TestFlowerId = 111;

        [Fact]
        public void DeleteShouldReturnTrueWhenDeleted()
        {
            // Arrange
            var flowerService = GetFlowerService();

            // Act
            var result = flowerService.Delete(TestFlowerId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteShouldReturnFalseWhenNotDeleted()
        {
            // Arrange
            var flowerService = GetFlowerService();

            // Act
            var result = flowerService.Delete(1);

            // Assert
            Assert.False(result);
        }

        private IFlowerService GetFlowerService()
        {
            var data = DatabaseMock.Instance;

            data.Flowers.Add(new Flower
            {
                Id = TestFlowerId,
                FlowerName = "A very nice Flower",
                FlowerPrice = 12,
                ImageURL = "https://i.pinimg.com/236x/bf/ec/23/bfec23f65a6bf2ee13015eabb1534fa2.jpg",
                Info = "This is a very very nice blue flower, excelent for a gift or decoration!"
            });

            data.SaveChanges();

            return new FlowerService(data);
        }
    }
}
