using Microsoft.AspNetCore.Mvc;
using Product.Application.Interface;
using Product.Domain.Shared.DataTransfer.ProductDTO;
using System;
using System.Threading.Tasks;

namespace Product.API.Src.ProductAreas
{
    public class ProductStoreController : Controller
    {
        private readonly IProductContainer _productContainer;

        public ProductStoreController(IProductContainer productContainer)
        {
            _productContainer = productContainer;
        }

        /*
         {
  "productInsertDto": {
    "name": "string",
    "fragile": true,
    "origin": "string",
    "unitAttributeId": 0,
    "shortDescription": "string",
    "fullDescription": "string",
    "isShipEnabled": true,
    "isFreeShipping": true,
    "shipSeparately": true,
    "additionalShippingCharge": 0,
    "deliveryDateId": 0,
    "productAvailabilityRangeId": 0,
    "useMultipleWarehouses": true,
    "displayStockAvailability": true,
    "displayStockQuantity": true,
    "minStockQuantity": 0,
    "lowStockActivityId": 0,
    "notifyAdminForQuantityBelow": 0,
    "backorderModeId": 0,
    "allowBackInStockSubscriptions": true,
    "orderMinimumQuantity": 0,
    "orderMaximumQuantity": 0,
    "allowAddingOnlyExistingAttributeCombinations": true,
    "notReturnable": true,
    "viewReceived": true,
    "disableBuyButton": true,
    "disableWishlistButton": true,
    "hasTierPrices": true,
    "hasDiscountsApplied": true,
    "createBy": 0
  },
  "productTagDto": {
    "name": "string",
    "createBy": 0
  },
  "imageRoot": [
    "string"
  ],
  "specificationProductDto": {},
  "categoryProduct": {
    "idActegory": [
      "string"
    ],
    "categoryMain": 0
  },
  "featureProductInsertDtos": [
    {}
  ]
}
         */

        [HttpPost]
        [Route("v1/api/create-product")]
        public async Task<IActionResult> Index([FromBody] ProductContainerInsertDto input)
        {
            var idAccount = Convert.ToInt32(HttpContext.Items["idAccount"]);
            var data = await _productContainer.ProcessProductContainer(input: input, idAccount: idAccount);
            return Ok();
        }
    }
}
