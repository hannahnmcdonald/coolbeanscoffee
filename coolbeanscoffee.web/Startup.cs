using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using coolbeanscoffee.data;
using coolbeanscoffee.web;
using Newtonsoft.Json;
using Npgsql;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using coolbeanscoffee.services.Product;
using coolbeanscoffee.services.Customer;
using coolbeanscoffee.services.Inventory;
using coolbeanscoffee.services.Order;
// using coolbeanscoffee.services.customer;

namespace coolbeanscoffee.web
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
            services.AddCors();
            
            services.AddControllers().AddNewtonsoftJson(opts => {
                opts.SerializerSettings.ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });

            services.AddDbContext<CoolBeansDbContext>(opts =>
            {
                opts.EnableDetailedErrors();
                opts.UseNpgsql(Configuration.GetConnectionString("coolbeanscoffee.dev"));
            });

            // services.AddTransient<IProductService, ProductService>();
            // services.AddTransient<ICustomerService, CustomerService>();
            // services.AddTransient<IInventoryService, InventoryService>();
            // services.AddTransient<IOrderService, OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            
            app.UseCors(
                builder => builder
                    .WithOrigins(
                        "http://localhost:8080", 
                        "http://localhost:8081", 
                        "http://localhost:8082")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}