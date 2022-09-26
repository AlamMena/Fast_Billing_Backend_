using API.DbModels.Contexts;

namespace API.Services.Inventory
{
    public class InventoryTransactionService
    {
        private readonly FbContext _context;
        public InventoryTransactionService(FbContext context)
        {
            _context = context;
        }

    }
}
