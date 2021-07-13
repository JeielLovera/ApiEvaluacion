using System;
using System.Text;
using ApiEvaluacion.BusinessLayer.Mapper;
using ApiEvaluacion.BusinessLayer.Services.Implementation;
using ApiEvaluacion.BusinessLayer.Services.Interfaces;
using ApiEvaluacion.DataLayer.Context;
using ApiEvaluacion.DataLayer.Repositories.Implementation;
using ApiEvaluacion.DataLayer.Repositories.Interfaces;
using ApiEvaluacion.DataLayer.UnitOfWork;
using ApiEvaluacion.DomainLayer.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ApiEvaluacion.ApiLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );               

            // repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobSectorRepository, JobSectorRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();

            // unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobSectorService, JobSectorService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IQuestionnaireService, QuestionnaireService>();

            // mapper
            var mappingConfig = new MapperConfiguration(
                mc => { mc.AddProfile(new MappingProfile()); }
            );
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // data protection
            services.AddSingleton<DataProtectorKeyStrings>();
            services.AddDataProtection();

            // jwt bearer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opts => opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
                    ClockSkew = TimeSpan.Zero
                }
            );

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Evaluación  v1",
                    Description = "Servicios API REST para la aplicación web de evaluación",
                    Contact = new OpenApiContact()
                    {
                        Name = "Jeiel Tarazona Lovera",
                        Email = "jeiel.disas@gmail.com",
                        Url = new Uri("https://github.com/JeielLovera?tab=repositories")
                    }
                });                
            });

            // CORS
            services.AddCors(opts => { opts.AddPolicy("All", builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*")); });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "API Evaluación v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("All"); 

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
