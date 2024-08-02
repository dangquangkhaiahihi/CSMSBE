using CSMSBE.Infrastructure.Interfaces;
using System.Text;
using CSMSBE.Services.Interfaces;
using CSMSBE.Services.Implements;
using CSMSBE.Infrastructure.Implements;
using CSMS.Data.Interfaces;
using CSMSBE.Services.BaseServices.Interfaces;
using CSMS.Data.Implements;
using CSMSBE.Core.Helper;
using Microsoft.AspNetCore.Identity;
using CSMS.Entity.IdentityAccess;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using CSMS.Data.Repository;
using CSMS.Data.UnitOfWork;
using CSMS.Entity;
using CSMSBE.Core.Settings;
using CSMSBE.Services.Configuration;
using CSMSBE.Services.Configurations;
using Data.Implements;
using Data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using CSMSBE.Infrastructure.Email;

namespace CSMSBE.Api
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<IAspNetRefreshTokensRepository, AspNetRefreshTokensRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // Log history
            services.AddTransient<IWebHelper, WebHelper>();
            services.AddScoped<ILogHistoryRepository, LogHistoryRepository>();
            services.AddScoped<ILogHistoryService, LogHistoryService>();

            // User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<SignInManager<User>>();

            // SecurityMatrix
            services.AddScoped<ISecurityMatrixService, SecurityMatrixService>();
            services.AddScoped<ISecurityMatrixRepository, SecurityMatrixRepository>();
            services.AddScoped<IActionRepository, ActionRepository>();
            services.AddScoped<IScreenRepository, ScreenRepository>();

            // Role
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            // Project
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();

            // TypeProject
            services.AddScoped<ITypeProjectRepository, TypeProjectRepository>();

            // Location
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();

            // SomeTable
            services.AddScoped<ISomeTableRepository, SomeTableRepository>();
            services.AddScoped<ISomeTableService, SomeTableService>();

            // Issue
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IIssueRepository, IssueRepository>();

            // Comment
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            // Model
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();
            
            // PushNotification
            services.AddScoped<IPushNotificationRepository, PushNotificationRepository>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();

            services.AddControllers();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            SpeckleHelper.SetupSpeckleAccount(configuration["SpeckleInfo:ServerUrl"],
                configuration["SpeckleInfo:AuthToken"]);

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("csms",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:5173",
                                "http://127.0.0.1:5173") // Adjust this to your frontend URL
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<CsmsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("MyWebApiConection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.EnableRetryOnFailure(); // Enable retry on failureAddHttpClient
                        npgsqlOptions.CommandTimeout(30); // Set command timeout (in seconds)
                    }));
            services.AddHttpClient();

            var appConfig = configuration
                .GetSection("AppSettings")
                .Get<AppSettings>();
            services.AddSingleton(appConfig);
            services.AddSingleton<JwtSecurityTokenHandler>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddLogging();

            // app settings
            var authenticationSections = configuration.GetSection("JWT");
            services.Configure<AuthenticationSettings>(authenticationSections);
            var authenticationSettings = authenticationSections.Get<AuthenticationSettings>();

            services.AddSingleton(authenticationSettings);

            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                })
                .AddEntityFrameworkStores<CsmsDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(x =>
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
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authenticationSettings.SecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        RequireExpirationTime = false,
                        ClockSkew = TimeSpan.FromMinutes(appConfig.AccessTokenExpireTimeSpan),
                    };
                });
            services.AddAuthorization(options =>
            {
                // Cấu hình các chính sách ủy quyền nếu cần
            });

            services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
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
                        Array.Empty<string>()
                    }
                });
            });

            services.AddSignalR();
            services.AddScoped<IEmailSenderFactory, EmailSenderFactory>()
                .AddScoped<IEmailService, EmailService>()
                .Configure<SmtpConfiguration>(configuration.GetSection("SmtpConfiguration"))
                .Configure<PostmarkConfiguration>(configuration.GetSection("PostmarkConfiguration"));
        }
    }
}