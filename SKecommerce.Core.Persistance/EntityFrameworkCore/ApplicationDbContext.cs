using Abp.OpenIddict.Applications;
using Abp.OpenIddict.Authorizations;
using Abp.OpenIddict.EntityFrameworkCore;
using Abp.OpenIddict.Scopes;
using Abp.OpenIddict.Tokens;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SKecommerce.Core.Domain.Entity;

namespace SKecommerce.Core.Persistance.EntityFrameworkCore;

public class ApplicationDbContext : AbpZeroDbContext<Tenant, Role, User, ApplicationDbContext>, IOpenIddictDbContext
{
    public DbSet<OpenIddictApplication> Applications { get; }
    public DbSet<OpenIddictAuthorization> Authorizations { get; }
    public DbSet<OpenIddictScope> Scopes { get; }
    public DbSet<OpenIddictToken> Tokens { get; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Tenant>(b =>
        {
            b.HasIndex(x => new { x.SubscriptionEndDateUtc });
            b.HasIndex(x => new { x.CreationTime });
        });
        
        builder.ConfigureOpenIddict();
    }
}