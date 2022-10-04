using API.DbModels.Contexts;
using API.Dtos.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    public static class DbContextConfiguration
    {
        public static void BuildContext(this IServiceCollection services)
        {
            services.AddScoped(options =>
            {
                var config = options.GetRequiredService<IConfiguration>();
                var localConnectionString = config.GetConnectionString("Local");

                // configuring useful dbcontext
                var builder = new DbContextOptionsBuilder<FbContext>().UseSqlServer(localConnectionString);

                var currentSession = options.GetService<IHttpContextAccessor>();

                var tenantRequest = new TenantRequest();
                if (currentSession?.HttpContext is not null)
                {
                    var userId = currentSession.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // initializing a new dbcontext without filter configurations to get the user in the db
                    using var context = new FbContext(builder.Options, config);
                    var user = context.Users.IgnoreQueryFilters().FirstOrDefault(d => d.FirebaseId == userId && d.IsDeleted == false);
                    context.Dispose();

                    if (userId != null && user is null)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    else if (user is not null)
                    {
                        tenantRequest.CompanyId = user.CompanyId;
                        tenantRequest.BranchId = user.BranchId;
                        tenantRequest.UserId = user.Id;
                    }
                };

                return new FbContext(builder.Options, tenantRequest);
            });

        }
    }
}
