using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Services;
using Microsoft.AspNetCore.SignalR;
using praca_magisterska_API.Hubs;

namespace praca_magisterska_API
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
            services.AddDbContextPool<DiaryDataSourceContext>(options =>
                options
                    .UseSqlServer(Configuration["ConnectionStrings:DiaryDatabase"])
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            );
            services.AddSignalR();
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", cors =>
                    cors
                        .WithOrigins(Configuration.GetValue<string>("AllowedOrigins").Split(","))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                );
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGradeService, GradeService>();

            var connection = @"Server=(localdb)\\MSSQLLocalDB;Database=DiaryDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";
            
            services.AddDbContext<DiaryDataSourceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(connection))
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
               // c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "praca_magisterska_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "praca_magisterska_API v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }
    }
}
