namespace FlowerShop.Tests.Mocks
{
    using FlowerShop.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DatabaseMock
    {
        public static FlowerShopDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<FlowerShopDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new FlowerShopDbContext(dbContextOptions);
            }
        }
    }
}
