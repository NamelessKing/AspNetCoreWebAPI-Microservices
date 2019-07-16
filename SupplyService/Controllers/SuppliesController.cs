using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using OrderService.Repositories;
using SupplyService.Model;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;

namespace SupplyService.Controllers
{
    public class SuppliesController : ControllerBase
    {


        private  IHttpContextAccessor httpContextAccessor;
        public void IPAddressController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }





        [HttpPost]
        public IActionResult GetProductBySKU(string sku)
        {
            SuppliesRepository repository = new SuppliesRepository(Program.connectionString);

            var product = repository.GetById(sku);

            if (product == null)
                return new JsonResult(new Fault("Product does not exists"));

            return new JsonResult(new SuccessWithResult<ProductData>(product));
        }

        [HttpPost]
        public IActionResult GetAll(int sku)
        {
            SuppliesRepository repository = new SuppliesRepository(Program.connectionString);

            var products = repository.GetAll();

            return new JsonResult(new SuccessWithResult<IEnumerable<ProductData>>(products));
        }


        [HttpPost]
        public IActionResult Save([FromBody] ProductData data)
        {
            if (data.Availability<=0)
                return new JsonResult(new Fault("Product is non available"));

            var productData = new ProductData
            {

                Description = data.Description,
                Availability = data.Availability,
                Categories = data.Categories
                //Id = ObjectId.GenerateNewId(),
                //Address = data.Address,
                //Items = from item in data.Items
                //        select new OrderItem { SKU = new ObjectId(item.Key), Quantity = item.Value }
            };

            SuppliesRepository repository = new SuppliesRepository(Program.connectionString);

            repository.SaveProduct(productData);


            //var ip = this.;
            return new JsonResult(new SuccessWithResult<string>(productData.Id.ToString()));
            //return new JsonResult(new SuccessWithResult<string>(new ProductResponse().URI=));
        }





    }
}
