using Microsoft.EntityFrameworkCore;
using StudentManagement.Core;
using StudentManagement.Infrastructure;
using StudentManagement.Infrastructure.DBModels;
using Serilog;
using StudentManagement.Infrastructure.Repository;
using StudentManagement;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentManagement.Hubs;
using Microsoft.AspNet.SignalR.Messaging;

var policyName = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR()
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    }); ;


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: policyName,
//                      builder =>
//                      builder
//                      .WithOrigins("http://localhost:4200", "http://localhost:4300", "http://192.168.37.17", "http://192.168.37.17:1002", "http://192.168.37.17:2002")
//                      .AllowAnyOrigin()
//                      .AllowAnyMethod()
//                      //.WithMethods("GET", "POST", "PUT", "DELETE")
//                      .AllowAnyHeader()
//                      .AllowCredentials()
//                      .SetIsOriginAllowed((hosts) => true));
//});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = null;
    opts.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddDbContext<StudentSystemContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementDB"))
);

ConfigurationHelper.Initialize(builder.Configuration);
builder.Services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddTestUsers(ConfigurationHelper.TestUsers().ToList())
                .AddInMemoryApiScopes(ConfigurationHelper.ApiScopes)
                .AddInMemoryClients(ConfigurationHelper.Clients);

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7007";
    //options.Authority = "http://192.168.37.17:2002/StudentSystemZipAPI";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
    options.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStandardRepository, StandardRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IAPIVersionRepository, APIVersionRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Student System API", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            //ClientCredentials = new OpenApiOAuthFlow
            Password = new OpenApiOAuthFlow
            {
                //AuthorizationUrl = new Uri("https://localhost:7007/connect/authorize"),
                TokenUrl = new Uri("https://localhost:7007/connect/token"),
                //TokenUrl = new Uri("http://192.168.37.17:2002/StudentSystemZipAPI/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    {builder.Configuration["IdentityAuth:Scope"], "Student System"}
                }
            }
        }
    });
    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("../swagger/v1/swagger.json", "Student System API V1");
        options.OAuthClientId(builder.Configuration["IdentityAuth:ClientId"]);
        options.OAuthClientSecret(builder.Configuration["IdentityAuth:ClientSecrets"]);
        options.OAuthAppName("Student System API - Swagger");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseCors(policyName);
app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

//app.MapHub<NotifyHub>("notify");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<NotifyHub>("/notify");
});
app.MapControllers();

app.Run();
