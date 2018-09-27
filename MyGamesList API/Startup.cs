using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using MyGamesListAPI.Repository;
using MyGamesListAPI.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MyGamesList_API
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
            SetupSwagger(services);

            services.AddDbContext<DBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionStr")));
            RegisterServices(services);
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "The My Games List Rest API");
            });

            app.UseMvc();
        }

        private void RegisterServices(IServiceCollection services) {
            services.AddTransient<IGame, GameRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IWishlistItem, WishlistItemRepository>();
            services.AddTransient<IOwnedGame, OwnedGameRepository>();
        }

        private void SetupSwagger(IServiceCollection services) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info {
                    Title = "My Games List API",
                    Version = "v1", 
                    Description = "The My Games List Rest API",
                    Contact = new Contact {
                        Name = "Samuel Alves",
                        Url = "https://www.github.com/SamuelIGT"
                    }
                });

                //string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                //string applicationName = PlatformServices.Default.Application.ApplicationName;

                //string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");

                //c.IncludeXmlComments(xmlDocPath);
            });
        }
    }
}
