using Abp.Authorization.Roles;

namespace SKecommerce.Core.Domain.Entity;

public class Role : AbpRole<User>
{
    //Can add application specific role properties here

    public Role()
    {
            
    }

    public Role(int? tenantId, string displayName)
        : base(tenantId, displayName)
    {

    }

    public Role(int? tenantId, string name, string displayName)
        : base(tenantId, name, displayName)
    {

    }
}