using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application;
using Loja.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loja.React.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IEntityCrudHandler<Product> productHandler;
        private IEntityCrudHandler<StockSize> stockSizeHandler;

        public ProductsController(
             IEntityCrudHandler<Product> productHandler,
             IEntityCrudHandler<StockSize> stockSizeHandler
        ){
            this.productHandler = productHandler;
            this.stockSizeHandler = stockSizeHandler;
        }

        // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await productHandler.Get(id);
            return new JsonResult(
                new
                {
                    product.ProductID,
                    product.Title,
                    product.Name,
                    product.Description,
                    product.Type,
                    product.Gender,
                    product.Price,
                }

            );;
        }

        // GET api/<ProductsController>/5
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productHandler.GetAll(1);
            var stockSize = await stockSizeHandler.GetAll(1);

            return new JsonResult(
                products.Select(p => 
                    new 
                    {
                        p.ProductID,
                        p.Title,
                        p.Name,
                        p.Description,
                        p.Type,
                        p.Gender,
                        p.Price,
                        StockSize = stockSize
                                    .Where(c => c.ProductID == p.ProductID)
                                    .Select(c =>
                                        new
                                        {
                                            c.StockSizeID,
                                            c.Size,
                                            c.Stock,
                                        }
                                     ) 
                    }
                 )
            );
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(Product entity)
        {
            await productHandler.Post(entity);
            return new JsonResult(new { entity.isActive });
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
