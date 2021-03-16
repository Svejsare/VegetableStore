using LocalDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VegetableWarehouse.Repositories;
using VegetableWarehouse.Repositories.Models;
using VegetableWarehouse.Services;

namespace VegetableWarehouse
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost",
                                            "https://localhost")
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                    });
            });

            services.AddDbContext<DBContext>(opt => opt.UseInMemoryDatabase("VegetableWarehouse"), ServiceLifetime.Singleton);
            services.AddTransient<VegetableInventoryService, VegetableInventoryService>();
            services.AddTransient<VegetableInventoryRepository, VegetableInventoryRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var context = app.ApplicationServices.GetService<DBContext>();
            AddData(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddData(DBContext context)
        {
            var vegetable1 = new Vegetable
            {
                Id = 1,
                Name = "Cucumber",
                Price = 10.99m
            };


            var vegetable2 = new Vegetable
            {
                Id = 2,
                Name = "Tomato",
                Price = 4.79m
            };

            var vegetable3 = new Vegetable
            {
                Id = 3,
                Name = "Lettuce",
                Price = 7.99m
            };

            context.Vegetables.Add(vegetable1);
            context.Vegetables.Add(vegetable2);
            context.Vegetables.Add(vegetable3);

            context.SaveChanges();
        }
    }
}
