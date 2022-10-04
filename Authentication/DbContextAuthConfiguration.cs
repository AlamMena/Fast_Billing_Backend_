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

                // getting the service of httpContextAccessor to handle the http request
                var currentSession = options.GetService<IHttpContextAccessor>();

                // request data to initialize the context
                var tenantRequest = new TenantRequest();

                // when the current session is not null then we proceed to handle the http request 
                if (currentSession?.HttpContext is not null)
                {
                    // getting the id from firebase
                    var userId = currentSession.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // initializing a new dbcontext without filter configurations to get the user in the db
                    using var context = new FbContext(builder.Options, config);

                    // query the transient context
                    var user = context.Users.IgnoreQueryFilters().FirstOrDefault(d => d.FirebaseId == userId && d.IsDeleted == false);

                    // cleaning the instance
                    context.Dispose();

                    // when the http containts a token and the user is not found we throw an unathorize exception
                    if (userId != null && user is null)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    // when user is not null we fill the tenant request to initialize the context
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
