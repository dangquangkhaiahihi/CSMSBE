using CSMS.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CSMSBE.Api
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CsmsDbContext>
    {
        public CsmsDbContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                //.AddJsonFile($"appsettings.{_environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configurations.GetConnectionString("MyWebApiConection");

            var builder = new DbContextOptionsBuilder<CsmsDbContext>()
                .UseNpgsql(connectionString,
                    b => b.MigrationsAssembly(typeof(AssemblyReference).Assembly.FullName));

            return new csms_dbContext(builder.Options, configurations);
        }
    }
}
