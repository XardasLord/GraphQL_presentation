using System;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.Stitching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.Stitching.Server
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

            services.AddHttpClient("users",
                (sp, client) =>
                {
                    client.BaseAddress = new Uri(Configuration.GetSection("GraphQL:UserServiceEndpoint").Value);
                });
            services.AddHttpClient("photos",
                (sp, client) =>
                {
                    client.BaseAddress = new Uri(Configuration.GetSection("GraphQL:PhotoServiceEndpoint").Value);
                });

            services.AddDataLoaderRegistry();

            services.AddGraphQL(sp => SchemaBuilder.New().AddType<Query>().Create());

            services.AddGraphQLSubscriptions();

            services.AddStitchedSchema(builder => builder
                .AddSchemaFromHttp("users")
                .AddSchemaFromHttp("photos"));
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

            app
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground();
        }
    }
}
