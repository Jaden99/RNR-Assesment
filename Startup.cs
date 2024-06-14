
using Microsoft.EntityFrameworkCore;
using RNR_WebAPI.Data;

namespace RNR_WebAPI
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
                services.AddDbContext<BreakdownContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
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

                app.UseCors("AllowAllOrigins");

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }


