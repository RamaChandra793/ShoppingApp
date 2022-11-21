using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ShoppingApi
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

            //EntityFramework Context DB 
            services.AddDbContext<ShoppingDal.ShoppingDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: "server=DESKTOP-90ADLL6\\SQLEXPRESS;database=Shopping;TrustServerCertificate=true;integrated security=sspi");
            });
            services.AddScoped<ShoppingDal.ProductDataAccess>();
            services.AddScoped<ShoppingDal.CategoryDataAccess>();
            services.AddScoped<ShoppingDal.CustomerDataAccess>();
            services.AddScoped<ShoppingDal.OrderDataAccess>();
            services.AddScoped<ShoppingDal.OrderDetailDataAccess>();
            services.AddScoped<ShoppingDal.SellerDataAccess>();
            //services.AddScoped<ProjectsDataAccess.ProjectsDAL>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingApi v1"));
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
