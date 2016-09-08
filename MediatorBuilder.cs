using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace ScrutorDecorator
{
	public static class MediatorBuilder
	{
		public static IMediator BuildMediator()
		{
			var services = new ServiceCollection();

			services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
			services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

			// Use Scrutor to scan and register all
			// classes as their implemented interfaces.
			services.Scan(scan => scan
				.FromAssembliesOf(typeof(IMediator), typeof(Ping))
				.AddClasses()
				.AsImplementedInterfaces());

			var provider = services.BuildServiceProvider();

			return provider.GetRequiredService<IMediator>();
		}

		private static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
		{
			return (IEnumerable<object>) provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
		} 
	}
}