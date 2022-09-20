using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Authentication
{
    public static class JwtAuthConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/fast-billing-775f5";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/fast-billing-775f5",
                    ValidateAudience = true,
                    ValidAudience = "fast-billing-775f5",
                    ValidateLifetime = true
                };
            });
        }

    }
}
