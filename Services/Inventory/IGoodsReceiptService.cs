using API.DbModels.Inventory.GoodsReceipt;

namespace API.Services.Inventory
{
    public interface IGoodReceiptService
    {
        Task<GoodReceipt> PostGoodReceiptAsync(GoodReceipt receipt);

    }

}