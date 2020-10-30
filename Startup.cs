﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookUp.Models;

namespace ParksLookUp
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddDbContext<ParksLookUpContext>(opt =>
    opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

      //   services.AddSwaggerGen();



    }


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
      //   app.UseSwagger();
      //   app.UseSwaggerUI(c =>
      //   {
      //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      //   });

      app.UseMvc();
    }
  }
}
