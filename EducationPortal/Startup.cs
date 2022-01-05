namespace EducationPortal
{
    using EducationPortal.AutoMapper;
    using EducationPortal.Core.Interfaces;
    using EducationPortal.Infrastructure;
    using EducationPortal.Infrastructure.Data;
    using EducationPortal.Infrastructure.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationPortalDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultSqlConnection")));
            services.AddScoped<DbContext, EducationPortalDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ISkillService, SkillService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers();

            services.AddCors(options => {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3000")
                        );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}