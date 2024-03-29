using System.ComponentModel.DataAnnotations;
using System.Data;
using API.DbModels.Contexts;
using API.DbModels.Ncf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Sales.Ncf
{
    public class NcfService : INcfService
    {
        private readonly FbContext _context;

        public NcfService(FbContext context)
        {
            _context = context;
        }

        public record NcfResponse(string Ncf, object? ExpirationDate);
        public async Task<NcfResponse> GenerateNcfAsync(int type)
        {

            var parameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "type",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = type
                },

                new SqlParameter()
                {
                    ParameterName = "company",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = 1,
                },

                new SqlParameter()
                {
                    ParameterName = "branch",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input,
                    Value = 1
                },

                new SqlParameter()
                {
                    ParameterName = "ncf",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Direction = ParameterDirection.Output,
                },

                new SqlParameter()
                {
                    ParameterName = "expirationDate",
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Output,
                }
            };
            var sequence = await _context.Database
                .ExecuteSqlRawAsync($"sp_get_ncf_sequence @type,@company,@branch,@ncf OUTPUT,@expirationDate OUTPUT", parameters);

            var ncf = parameters[3].Value.GetType() == typeof(DBNull) ? throw new ValidationException("There is not ncf avaliable") : (string)parameters[3].Value;
            // var expirationDate = != null ? (DateTime?)parameters[4].Value : null;

            return new NcfResponse(ncf, parameters[4].Value);

        }
    }
}