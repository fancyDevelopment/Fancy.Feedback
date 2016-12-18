using Fancy.Feedback.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Fancy.Feedback.Core
{

    public class DesignTimeDbContextFactory : IDbContextFactory<DomainDbContext>
    {
        public DomainDbContext Create(DbContextFactoryOptions options)
        {
           var optionsBuilder = new DbContextOptionsBuilder<DomainDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Fancy.Feedback.Store_Design;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            return new DomainDbContext(optionsBuilder.Options);
        }
    }

}