using CSMSBE.Api;
using CSMSBE.Api.PermissionAttribute;
using CSMSBE.Infrastructure.Implements;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();

        builder.Services.ConfigureServices(builder.Configuration);


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseCors("csms");

        app.UseHttpsRedirection();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<NotificationHub>("/notificationHub");
        });

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<PermissionMiddleware>();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.MapControllers();

        app.Run();
    }
}