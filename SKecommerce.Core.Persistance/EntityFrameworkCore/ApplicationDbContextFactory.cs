using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shared;
using Shared.Helpers;
using SKecommerce.Core.Domain.Configuration;

namespace SKecommerce.Core.Persistance.EntityFrameworkCore;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        var configuration = AppConfigurations.Get(
            WebContentDirectoryFinder.CalculateContentRootFolder(),
            addUserSecrets: true
        );
            
        ApplicationDbContextConfigure.Configure(builder, configuration.GetConnectionString(ApplicationConsts.ConnectionStringName));
        
        return new ApplicationDbContext(builder.Options);
    }
}