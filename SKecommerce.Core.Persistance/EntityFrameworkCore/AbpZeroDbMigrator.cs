using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;

namespace SKecommerce.Core.Persistance.EntityFrameworkCore;

public class AbpZeroDbMigrator : AbpZeroDbMigrator<ApplicationDbContext>
{
    public AbpZeroDbMigrator(
        IUnitOfWorkManager unitOfWorkManager,
        IDbPerTenantConnectionStringResolver connectionStringResolver,
        IDbContextResolver dbContextResolver) :
        base(
            unitOfWorkManager,
            connectionStringResolver,
            dbContextResolver)
    {
        
    }
}