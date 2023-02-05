using API.DbModels.Contexts;
using API.DbModels.Inventory.GoodsReceipt;
using API.Dtos.Inventory.GoodReceipt;
using API.Services.Inventory;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GoodReceiptController : CoreController<GoodReceipt, GoodReceiptDto>
    {
        private readonly IGoodReceiptService _goodReceiptService;

        public GoodReceiptController(FbContext context, IMapper mapper, IGoodReceiptService goodReceiptService)
            : base(context, mapper)
        {
            _goodReceiptService = goodReceiptService;
        }

        public override async Task<IActionResult> PostAsync(GoodReceiptDto request)
        {
            var receipt = _mapper.Map<GoodReceipt>(request);
            await _goodReceiptService.PostGoodReceiptAsync(receipt);
            var response = _mapper.Map<GoodReceiptDto>(receipt);

            return Ok(response);
        }
    }
}
