
namespace Catelog.Data.Seed;

public class CatelogDataSeeder(CatelogDbContext context)
        : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if (!await context.Products.AnyAsync())
        {
            await context.Products.AddRangeAsync(InitialData.Products);

            await context.SaveChangesAsync();
        }
    }
}
