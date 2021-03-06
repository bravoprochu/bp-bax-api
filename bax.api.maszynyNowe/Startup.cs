﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using bax.api.Services;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace bax.api.maszynyNowe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string corsPolicyName = "allowAll";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy(corsPolicyName, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                });
            });
            services.AddMvc()
             .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<GalleryService>();
            services.AddSingleton<MaszynyNoweService>();
            services.AddSingleton<NewsService>();
            services.AddSingleton<SiteMapService>();
            services.AddSingleton<DataFactoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(corsPolicyName);
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
