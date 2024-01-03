using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Arfware.ArfBlocks.Core.Extentions;
using Arfware.ArfBlocks.Core;
using Microsoft.Extensions.Configuration;
using TaskManager.Infrastructure.Services;
using TaskManager.Application.Configurations;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// For Dotnet-Ef Commands
var configurations = builder.Configuration.GetSection("ProjectConfigurations").Get<ProjectConfigurations>();
//builder.Services.AddSingleton(new AssignmentDbContext(configurations.RelationalDbConfiguration.ConnectionString));

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

//builder.Services.AddDbContext<AssignmentDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//    b => b.MigrationsAssembly("TaskManager.API")));

// ArfBlocks Dependencies
builder.Services.AddArfBlocks(options =>
{
    options.ApplicationProjectNamespace = "Taskmanager.Application";
    options.ConfigurationSection = builder.Configuration.GetSection("ProjectConfigurations");
    options.LogLevel = LogLevels.Warning;
});

string DefaultCorsPolicy = "DefaultCorsPolicy";
builder.Services.AddCors(options =>
{
    // Development Cors Policy
    options.AddPolicy(name: DefaultCorsPolicy,
        builder =>
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

//app.UseArfBlocksRequestHandlers((Action<UseRequestHandlersOptions>)(options =>
//{
//    options.AuthorizationType = UseRequestHandlersOptions.AuthorizationTypes.Jwt;
//    options.AuthorizationPolicy = UseRequestHandlersOptions.AuthorizationPolicies.AssumeAllAuthorized;
//    options.JwtAuthorizationOptions = new UseRequestHandlersOptions.JwtAuthorizationOptionsModel()
//    {
//        Audience = "taskManager",
//        Secret = configuration.GetSection("JwtSettings")["Key"],
//    };
//}));

// 	// Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Audience = JwtService.Audience;
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtService.Secret)),
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
        };

        var handler = new JwtSecurityTokenHandler();
        handler.InboundClaimTypeMap.Clear();
    });


// 	services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    //c.AddServer(new OpenApiServer() { Url = environmentService.ApiUrl, Description = environmentService.EnvironmentName });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager.Api", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    // For avoid Scheme Collision for the same name classes
    c.CustomSchemaIds(x => x.FullName);

    // Define Security Scheme
    c.AddSecurityDefinition("Bearer", // Name #1
        new OpenApiSecurityScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer"
        });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", // Name #1
								Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(DefaultCorsPolicy);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
             .RequireAuthorization();  // Automatically add [Authorize] to all Controllers
});

app.Run();