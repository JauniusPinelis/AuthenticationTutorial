using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiOne
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			//services.AddAuthentication(o =>
			//{
			//    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//})
			//  .AddJwtBearer("Bearer", config =>
			//  {
			//      config.Authority = "http://localhost:57313/";
			//      config.Audience = "ApiOne";
			//      config.RequireHttpsMetadata = false;
			//  });


			services.AddAuthentication("Bearer")
				.AddJwtBearer("Bearer", config =>
				{
					config.Authority = "http://localhost:57313/";

					config.Audience = "ApiOne";
                    config.RequireHttpsMetadata = false;
                });

			services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
