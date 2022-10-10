using API.DbModels.Core;
using API.DbModels.Inventory.GoodsReceipt;
using API.DbModels.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Services.Inventory
{
    public interface IGoodReceiptService
    {
        Task<GoodReceipt> PostGoodReceiptAsync(GoodReceipt receipt);

    }
    
}