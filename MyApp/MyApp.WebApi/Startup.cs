﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyApp.Infra;
using Microsoft.Extensions.Configuration;

namespace MyApp.WebApi
{
    public class Startup
    {
        public IConfiguration Confiuration;

        public Startup(IConfiguration confiuration)
        {
            Confiuration = confiuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<MyAppContext>(option => option.UseSqlServer(this.Confiuration.GetConnectionString("Cnn")));
            services.AddDbContext<MyAppContext>(option => option.UseInMemoryDatabase("MyInMemoryDB"));

            //services.AddMvc();
            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
