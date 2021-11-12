using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;  
using Microsoft.Extensions.Configuration; 
using FighterSolution.DataAccess;

namespace FighterSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)  
        {  
            Configuration = configuration;  
        }  
  
        public IConfiguration Configuration { get; }  
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();  
  
            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];  
  
            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));  
  
            services.AddScoped<IDataAccessProvider, DataAccessProvider>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>  
            {  
                endpoints.MapControllers();  
            });  
        }
    }
}