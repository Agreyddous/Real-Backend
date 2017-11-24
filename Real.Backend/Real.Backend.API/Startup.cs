using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Real.Backend.Infra.Context;
using Real.Backend.Infra.Transactions;
using Real.Backend.Domain.Repositories;
using Real.Backend.Infra.Repositories;
using Microsoft.Extensions.Logging;
using Real.Backend.Shared;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Real.Backend.API.Security;

namespace Real.Backend.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		private const string Issuer = "";
		private const string Audience = "";
		private const string SecretKey = "";

		private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

		public Startup(IHostingEnvironment env)
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
			Configuration = configurationBuilder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(config =>
			{
				AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});
			services.AddCors();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("User", policy => policy.RequireClaim("Real", "User"));
			});

			services.Configure<TokenOptions>(options =>
			{
				options.Issuer = Issuer;
				options.Audience = Audience;
				options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
			});

			services.AddScoped<RealContext, RealContext>();
			services.AddTransient<IUow, Uow>();

			services.AddTransient<IUserRepository, UserRepository>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole();

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			TokenValidationParameters tokenvalidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = Issuer,

				ValidateAudience = true,
				ValidAudience = Audience,

				ValidateIssuerSigningKey = true,
				IssuerSigningKey = _signingKey,

				RequireExpirationTime = true,
				ValidateLifetime = true,

				ClockSkew = TimeSpan.Zero
			};

			app.UseJwtBearerAuthentication(new JwtBearerOptions
			{
				AutomaticAuthenticate = true,
				AutomaticChallenge = true,
				TokenValidationParameters = tokenvalidationParameters
			});

			app.UseCors(x =>
			{
				x.AllowAnyHeader();
				x.AllowAnyMethod();
				x.AllowAnyOrigin();
			});
			app.UseMvc();

			Runtime.ConnectionString = Configuration.GetConnectionString("CnnStr");
		}
	}
}