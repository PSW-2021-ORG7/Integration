using backend.Repositories.Interfaces;
using Integration_Class_Library.PharmacyEntity.DAL;
using Integration_Class_Library.PharmacyEntity.DAL.Repositories;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Models;
using Integration_Class_Library.TenderingEntity.DAL;
using Integration_Class_Library.TenderingEntity.DAL.Repositories;
using Integration_Class_Library.TenderingEntity.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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

            services.AddMassTransit(x =>
            {
                x.AddConsumer<OfferConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("offer-queue", e =>
                    {
                        e.ConfigureConsumer<OfferConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<PharmacyDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("APIConnection"))
            );

            services.AddDbContext<FeedbackDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("APIConnection"))
            );

            services.AddDbContext<MedicineDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("APIConnection"))
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
