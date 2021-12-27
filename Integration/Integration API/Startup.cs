using backend.Repositories.Interfaces;
using Integration_Class_Library.PharmacyEntity.DAL;
using Integration_Class_Library.PharmacyEntity.DAL.Repositories;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.TenderingEntity.DAL;
using Integration_Class_Library.TenderingEntity.DAL.Repositories;
using Integration_Class_Library.TenderingEntity.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Integration_API
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

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IConfiguration>(Configuration);

            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_I");
            if (connectionString == null) connectionString = Configuration.GetConnectionString("APIConnection");
            
            services.AddDbContext<IntegrationDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddDbContext<MedicineDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IMedicineInventoryRepository, MedicineInventoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IMedicineCombinationRepository, MedicineCombinationRepository>();

            

            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
