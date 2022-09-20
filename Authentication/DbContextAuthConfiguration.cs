using API.DbModels.Contexts;
using API.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DbContextConfiguration
    {
        public static void BuildContext(this IServiceCollection services)
        {
            services.AddScoped(options =>
            {
                var config = options.GetService<IConfiguration>();
                var localConnectionString = config.GetConnectionString("Local");

                // configuring useful dbcontext
                var builder = new DbContextOptionsBuilder<FbContext>().UseSqlServer(localConnectionString);

                var currentSession = options.GetService<IHttpContextAccessor>();

                var tenantRequest = new TenantRequest();
                if (currentSession?.HttpContext is not null)
                {
                    var userId = currentSession.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // initializing a new dbcontext without filter configurations to get the user in the db
                    //using (var context = new FbContext(config!))
                    //{
                    //    var user = context?.Users.IgnoreQueryFilters()
                    //                               .FirstOrDefault(u => u.IdUsuario == userId
                    //                                                 && u.Estado == true
                    //                                                 && u.Empresa.Estado == true
                    //                                                 && u.Sucursal.Estado == true);
                    //    tenantRequest.CompanyId = user?.EmpresaId;
                    //    currentSucursalId = user?.SucursalId;
                    //    currentUser = user?.IdUsuario;
                    //    rolId = user?.RolId ?? 0;

                    //    //if (user is null)
                    //    //{
                    //    //    throw new UnathorizeException("No se ha encontrado el usuario");
                    //    //}
                    //};

                }
                return new FbContext(tenantRequest);
            });
        }
    }
}
