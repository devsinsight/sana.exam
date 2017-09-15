using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using sana.webshop.web.Domain;
using sana.webshop.web.Handler;
using sana.webshop.web.Models;
using sana.webshop.web.Query;
using sana.webshop.web.Repository;
using System;

namespace sana.webshop.web.web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMemoryCache();

            
            services.AddDbContext<EFContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductViewModel, Product>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<IProductHandler, ProductHandler>();
            services.AddSingleton<IProductQuery, ProductQuery>();

            services.AddSingleton<InMemoryProductRepository>();
            services.AddSingleton<DatabaseProductRepository>();



            services.AddSingleton(factory =>
            {
                Func<bool, IProductRepository> accesor = IsInMemory =>
                {
                    if (IsInMemory)

                        return factory.GetService<InMemoryProductRepository>();
                    else
                        return factory.GetService<DatabaseProductRepository>();

                };
                return accesor;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
