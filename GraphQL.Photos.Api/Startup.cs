using GraphQL.Photos.Api.Database;
using GraphQL.Photos.Api.GraphQL.Queries;
using GraphQL.Photos.Api.GraphQL.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.Photos.Api
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<PhotosDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PhotosConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<PhotoQuery>()
                    .AddType<PhotoType>()
                    .Create(),
                new QueryExecutionOptions
                {
                    ForceSerialExecution = true,
                    TracingPreference = TracingPreference.Always
                });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PhotosDbContext>();
                context.Database.Migrate();
            }

            app.UseGraphQL().UsePlayground();
        }
    }
}
