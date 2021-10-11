using FluentValidation;
using HubStore.Application.Common.Behaviours;
using HubStore.Application.Services;
using HubStore.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HubStore.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			services.AddScoped(typeof(IProductService), typeof(ProductService));
			services.AddScoped(typeof(IOrderService), typeof(OrderService));

			return services;
		}
	}
}
