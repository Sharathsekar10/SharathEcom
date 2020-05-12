using System.Linq;
using API.Error;
using Core.Interface;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppExtensionService( this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

             services.Configure<ApiBehaviorOptions>(option=>
             {
                 option.InvalidModelStateResponseFactory = actionContext =>
                 {
                     var errors =actionContext.ModelState
                                .Where(x=>x.Value.Errors.Count >0)
                                .SelectMany(y=>y.Value.Errors)
                                .Select(z=>z.ErrorMessage)
                                .ToArray();

                     var errorResponse = new ApiValidation()
                                    {
                                        Errors = errors
                                    };

                    return new BadRequestObjectResult(errorResponse);
                 };

                 
             });

             return services;
        }
    }
}