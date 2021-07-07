using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMClient
{
     public class Startup
     {

          readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

          //manually
          
          //manually

          // This method gets called by the runtime. Use this method to add services to the container.
          // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
          public void ConfigureServices(IServiceCollection services)
          {
               services.AddCors(options =>
               {
                    options.AddPolicy(name: MyAllowSpecificOrigins,builder =>{builder.WithOrigins("https://api.darksky.net", "https://localhost:44302/api/cities");});
               });

               services.AddControllersWithViews();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               else
               {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
               }

               app.UseHttpsRedirection();
               app.UseStaticFiles();
               app.UseRouting();
               app.UseAuthorization();

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
               });
          }
     }
}
