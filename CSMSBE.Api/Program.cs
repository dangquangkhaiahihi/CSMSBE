using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CSMSBE.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using CSMSBE.Core.Settings;
using CSMS.Data.Interfaces;
using CSMS.Entity;
using CSMS.Entity.IdentityAccess;
using CSMSBE.Infrastructure.Interfaces;
using CSMSBE.Services.Configuration;
using CSMSBE.Services.Configurations;
using CSMSBE.Services.Interfaces;
using CSMSBE.Services.Implements;

using CSMSBE.Core.Helper;
using CSMS.Data.Implements;
using CSMSBE.Services.BaseServices.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Data.Implements;
using Data.Interfaces;
using CSMS.Data.Repository;
using CSMSBE.Api.PermissionAttribute;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @builder.Configuration["FirebasePrivateKeyPath"]);

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();

        builder.Services.AddControllers();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        var configuration = builder.Configuration;
        SpeckleHelper.SetupSpeckleAccount(configuration["SpeckleInfo:ServerUrl"], configuration["SpeckleInfo:AuthToken"]);
        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("csms",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173") // Adjust this to your frontend URL
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddDbContext<CsmsDbContext>(options =>
       options.UseNpgsql(configuration.GetConnectionString("MyWebApiConection"),
           npgsqlOptions => {
               npgsqlOptions.EnableRetryOnFailure(); // Enable retry on failureAddHttpClient
               npgsqlOptions.CommandTimeout(30); // Set command timeout (in seconds)
           }));
        builder.Services.AddHttpClient();
        //Start Add Scoped
        builder.Services.AddScoped<IWorkerService, WorkerService>();
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddTransient<IAspNetRefreshTokensRepository, AspNetRefreshTokensRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
        builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        //log history
        builder.Services.AddTransient<IWebHelper, WebHelper>();
        builder.Services.AddScoped<ILogHistoryRepository, LogHistoryRepository>();
        builder.Services.AddScoped<ILogHistoryService, LogHistoryService>();
        // User
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserManager<User>>();
        builder.Services.AddScoped<SignInManager<User>>();
        //SecurityMatrix
        builder.Services.AddScoped<ISecurityMatrixService, SecurityMatrixService>();
        builder.Services.AddScoped<ISecurityMatrixRepository, SecurityMatrixRepository>();
        builder.Services.AddScoped<IActionRepository, ActionRepository>();
        builder.Services.AddScoped<IScreenRepository, ScreenRepository>();

        //SecurityMatrix
        builder.Services.AddScoped<ISecurityMatrixService, SecurityMatrixService>();
        builder.Services.AddScoped<ISecurityMatrixRepository, SecurityMatrixRepository>();
        builder.Services.AddScoped<IActionRepository, ActionRepository>();
        builder.Services.AddScoped<IScreenRepository, ScreenRepository>();
        //Role
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        //Issue
        builder.Services.AddScoped<IIssueService, IssueService>();
        builder.Services.AddScoped<IIssueRepository, IssueRepository>();
        //Comment
        builder.Services.AddScoped<ICommentService, CommentService>();
        builder.Services.AddScoped<ICommentRepository, CommentRepository>();
        //Model
        builder.Services.AddScoped<IModelService, ModelService>();
        builder.Services.AddScoped<IModelRepository, ModelRepository>();
        //End Add Scoped
        builder.Services.Configuration();
        builder.Services.AddSingleton<JwtSecurityTokenHandler>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddLogging();

        // app settings
        var appConfig = configuration
            .GetSection("AppSettings")
            .Get<AppSettings>();
        builder.Services.AddSingleton(appConfig);
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var authenticationSections = configuration.GetSection("JWT");
        builder.Services.Configure<AuthenticationSettings>(authenticationSections);
        var authenticationSettings = authenticationSections.Get<AuthenticationSettings>();

        builder.Services.AddSingleton(authenticationSettings);

        builder.Services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        })
            .AddEntityFrameworkStores<CsmsDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationSettings.SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.FromMinutes(appConfig.AccessTokenExpireTimeSpan),
                };
            });
        builder.Services.AddAuthorization(options =>
        {
            // Cấu hình các chính sách ủy quyền nếu cần
        });

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authoriztion header using the Bearer scheme"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[0]
                    }
                });
        });



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

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<PermissionMiddleware>();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.MapControllers();

        app.Run();
    }
}
