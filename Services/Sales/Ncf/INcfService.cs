using API.DbModels.Ncf;
using static API.Services.Sales.Ncf.NcfService;

namespace API.Services.Sales.Ncf
{
    public interface INcfService
    {
        Task<NcfResponse> GenerateNcfAsync(int type);
    }

}