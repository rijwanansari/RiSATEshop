using Microsoft.EntityFrameworkCore;

namespace RiSAT.Eshop.Persistence
{
    public class RiSATeshopDbContextFactory : DesignTimeDbContextFactoryBase<RiSATeshopDbContext>
    {
        protected override RiSATeshopDbContext CreateNewInstance(DbContextOptions<RiSATeshopDbContext> options)
        {
            return new RiSATeshopDbContext(options);
        }
    }
}
