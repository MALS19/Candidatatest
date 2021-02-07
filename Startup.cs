using CandidatesPortal.Models;
using CandidatesPortal.Pattern;
using CandidatesPortal.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesPortal
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
            services.AddControllers();
            services.AddMvc();
           services.AddScoped<ICandidateDataRepository, CandidateDataRepository>();
           services.AddDbContext<DataBaseContext>(options => options.UseInMemoryDatabase(databaseName: "CandidateDatas"));                           
                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
          

           
        }

        private static void AddTestData(DataBaseContext context)
        {
            context.CandidateDatas.AddRange(
                    new CandidateData
                    {
                        Id = 1,
                        FirstName = "Luke",
                        LastName = "Skywalker",
                        IsSelected = true
                    },
                    new CandidateData
                    {
                        Id = 1,
                        FirstName = "Josh",
                        LastName = "Smith",
                        IsSelected = false
                    },
                    new CandidateData
                    {
                        Id = 1,
                        FirstName = "Ray",
                        LastName = "Hope",
                        IsSelected = false
                    },
                    new CandidateData
                    {
                        Id = 1,
                        FirstName = "Valentina",
                        LastName = "Palker",
                        IsSelected = true
                    });    
                          

            context.SaveChanges();
        }
    }
}
