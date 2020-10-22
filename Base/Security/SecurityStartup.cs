using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Base.Security
{
    public static class SecurityStartup
    {

        public static void AddBaseSecurity(this IServiceCollection services, IConfiguration config)
        {
            var securitySection = config.GetSection("Security");
            var securityOptions = securitySection.Get<SecurityOptions>();
            services.Configure<SecurityOptions>(securitySection);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var keyBytes = Encoding.UTF8.GetBytes(securityOptions.JwtKey);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = securityOptions.JwtIssuer,
                        ValidAudience = securityOptions.JwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    };
                });

            services.AddHttpContextAccessor();

            services.AddSingleton<SecurityAuthenticator>();
            services.AddTransient<SecuritySession>();
            services.AddSingleton<LoginService>();
        }

        public static void UseBaseSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }

    }
}
