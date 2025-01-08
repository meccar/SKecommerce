using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SKecommerce.Core.Persistance.EntityFrameworkCore;

public static class ApplicationDbContextConfigure
{
    public static void Configure(DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<ApplicationDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}