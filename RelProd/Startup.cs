﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RelProd.Models;
using Microsoft.AspNetCore.Session;
using RelProd.Services;


namespace RelProd
{
	public class Startup
	{
		public Startup(IConfiguration configuration  , IHostingEnvironment env)
		{
			Configuration = configuration;

			string sAppPath = env.ContentRootPath; //pasta base da aplicação
			string swwwRootPath = env.WebRootPath; //wwwroot folder pasta 
		
		}


		

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

		    services.AddDbContext<RelProdContext>(options =>
		            options.UseMySql(Configuration.GetConnectionString("RelProdContext"), builder => builder.MigrationsAssembly("RelProd")));

			services.AddMemoryCache();
			services.AddSession();
			services.AddScoped<UsuarioServices>();
			services.AddScoped<BuscaService>();
			services.AddScoped<ExportService>();
			services.AddScoped<ChamadoService>();
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
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();
			app.UseSession();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Usuarios}/{action=Index}/{id?}");
			});
		}
	}
}
