using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.IServices;
using BEFOYS.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace BEFOYS.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_BefoysCors";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServiceContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            services.AddScoped<IBaseRoleService, BaseRoleService>();
            //Jwt
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = Configuration["Jwt:Issuer"],
              ValidAudience = Configuration["Jwt:Issuer"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
          };
      });
            // End Jwt

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://sarfeland.ir")
                    .WithOrigins("http://localhost:3000/")
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Befoys Api",
                    Version = "v1",
                   
                });

            });
            services.AddSingleton<IHostingEnvironment>(new HostingEnvironment());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Befoys Api");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),
                RequestPath = new PathString("/Uploads")
            });
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
