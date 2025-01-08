using Abp.Dependency;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace SKecommerce.Core.Persistance.EntityFrameworkCore;

// [DependsOn(
//     typeof(AbpZeroCoreEntityFrameworkCoreModule),
//     typeof(ApplicationCoreModule),
//     typeof(AbpZeroCoreOpenIddictEntityFrameworkCoreModule)
// )]
public class ApplicationEntityFrameworkCoreModule : AbpModule
{
        /* Used it tests to skip DbContext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<ApplicationDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    ApplicationDbContextConfigure.Configure(options.DbContextOptions,
                        options.ExistingConnection);
                }
                else
                {
                    ApplicationDbContextConfigure.Configure(options.DbContextOptions,
                        options.ConnectionString);
                }
            });
        }

        // Set this setting to true for enabling entity history.
        Configuration.EntityHistory.IsEnabled = false;

        // Uncomment below line to write change logs for the entities below:
        // Configuration.EntityHistory.Selectors.Add("CloudEntities", EntityHistoryHelper.TrackedTypes);
        // Configuration.CustomConfigProviders.Add(new EntityHistoryConfigProvider(Configuration));
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(ApplicationEntityFrameworkCoreModule).GetAssembly());
    }

    // public override void PostInitialize()
    // {
    //     var configurationAccessor = IocManager.Resolve<IAppConfigurationAccessor>();
    //
    //     using (var scope = IocManager.CreateScope())
    //     {
    //         if (!SkipDbSeed && scope.Resolve<DatabaseCheckHelper>()
    //                 .Exist(configurationAccessor.Configuration["ConnectionStrings:Default"]))
    //         {
    //             SeedHelper.SeedHostDb(IocManager);
    //         }
    //     }
    // }
}