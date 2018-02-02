using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Demo.StronglyTypedConfig {

	public class Startup {

		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration) =>
			this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

		public void ConfigureServices(IServiceCollection services) {
			services.AddOptions();
			services.Configure<AppSettings>(configuration);
		}

		public void Configure(IApplicationBuilder app, IOptions<AppSettings> appSettings) {
			app.Run(async context => await context.Response.WriteAsync(appSettings.Value.Message));
		}
	}
}