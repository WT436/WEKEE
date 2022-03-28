using Microsoft.AspNetCore.Mvc;
using Supplier.Application.Interface;
using Supplier.Domain.BoundedContext;
using Supplier.Domain.Shared.DataTransfer;
using System.Threading.Tasks;

namespace Product.API.Src.SupplierAreas
{
    public class RegistrationStoreController : Controller
    {
        private readonly IProcessSupplier _processSupplier;
        private readonly ISupplier _supplier;
        public RegistrationStoreController(IProcessSupplier processSupplier, ISupplier supplier)
        {
            _processSupplier = processSupplier;
            _supplier = supplier;
        }

        /// <summary>
        /// Check store
        /// </summary>
        [HttpGet]
        [Route("v1/api/check-show")]
        public async Task<IActionResult> Index()
        {
            var data = await _processSupplier.CheckAnyStoreIsBoss(1);
            return Ok(data);
        }

        /// <summary>
        /// Tạo mới Một empty Supplier
        /// </summary>
        [HttpPost]
        [Route("v1/api/registration-show")]
        public async Task<IActionResult> CreateStoreForBoss(SupplierCreateBasicDtos input)
        {
            TokenToJWT tokenToJWT = new TokenToJWT();
            var token = HttpContext.Request.Headers["Authorization"].ToString();
            input.IdAccount = tokenToJWT.DecryptionToken(token).Id;
            var data = await _supplier.CreateBasicStore(input);
            return Ok(data);
        }
    }
}
