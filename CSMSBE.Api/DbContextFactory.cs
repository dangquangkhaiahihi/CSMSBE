﻿using CSMS.Entity;
using Lucene.Net.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Directory = System.IO.Directory;

namespace CSMSBE.Api
{
    public class DbContextFactory : IDesignTimeDbContextFactory<CsmsDbContext>
    {
        private readonly string? _environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        public CsmsDbContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{_environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configurations.GetConnectionString("MyWebApiConection");

            var builder = new DbContextOptionsBuilder<CsmsDbContext>()
                .UseNpgsql(connectionString,
                    b => b.MigrationsAssembly(typeof(AssemblyReference).Assembly.FullName));

            return new CsmsDbContext(builder.Options);
        }
    }
}