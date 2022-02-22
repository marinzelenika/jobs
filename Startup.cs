using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using System.Text.Json.Serialization;
using AutoMapper;
using jobs.Helpers;
using WebApi.Services.JobPostService;
using dotnet_5_role_based_authorization_api.Services.JobPostService;
using dotnet_5_role_based_authorization_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            
            //services.AddDatabaseDeveloperPageExceptionFilter();

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IJobPostRepository, JobPostRepository>();
            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobPostService, JobPostService>();
            

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, DataContext context)
        {
            createTestUsers(context);

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }

        private void createTestUsers(DataContext context)
        {
            // add hardcoded test users to db on startup
            var testUsers = new List<User>
            { 
                new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", PasswordHash = BCryptNet.HashPassword("admin"), Role = Role.Admin },
                new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", PasswordHash = BCryptNet.HashPassword("user"), Role = Role.User } 
            };
            context.Users.AddRange(testUsers);
            context.SaveChanges();
        }
    }
}
