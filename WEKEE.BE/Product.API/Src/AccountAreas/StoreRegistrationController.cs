using Microsoft.AspNetCore.Mvc;
using Supplier.Application.Service;
using Supplier.Domain.BoundedContext;
using Supplier.Domain.Shared.DataTransfer;
using System.Threading.Tasks;

namespace Product.API.Src.AccountAreas
{
    public class StoreRegistrationController : Controller
    {
        private readonly IProcessSupplier _processSupplier;
        private readonly ISupplier _supplier;
        public StoreRegistrationController(IProcessSupplier processSupplier, ISupplier supplier)
        {
            _processSupplier = processSupplier;
            _supplier = supplier;
        }

        /// <summary>
        /// Check store
        /// </summary>
        [HttpGet]
        [Route("check-account-store")]
        public async Task<IActionResult> Index()
        {
            var data = await _processSupplier.CheckAnyStoreIsBoss(1);
            return Ok(data);
        }

        /// <summary>
        /// Tạo mới Một empty Supplier
        /// </summary>
        [HttpPost]
        [Route("registration-account-store")]
        public async Task<IActionResult> CreateStoreForBoss(SupplierCreateBasicDtos input)
        {
            TokenToJWT tokenToJWT = new TokenToJWT();
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            //input.IdAccount = tokenToJWT.DecryptionToken(token).Id;
            var data = await _supplier.CreateBasicStore(input);
            return Ok(data);
        }
    }
}
