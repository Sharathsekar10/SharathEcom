using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extension
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                 c=>{
                     c.SwaggerDoc("v1",new OpenApiInfo{ Title="Ecom Api", Version ="v1"});
                 }
             );

             return services;
        }

        public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Ecom API");
            });

            return app;
        }
    }
}