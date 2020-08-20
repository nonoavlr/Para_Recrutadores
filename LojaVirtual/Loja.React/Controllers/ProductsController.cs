using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loja.React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IEntityCrudHandler<Product> handler;
        public ProductsController(IEntityCrudHandler<Product> handler) => this.handler = handler;
        // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await handler.Get(id);
            return new JsonResult(
                new
                {
                    product.ProductID,
                    product.Title,
                    product.Name,
                    product.Description,
                    product.Type,
                    product.Gender,
                    product.Stock,
                    product.Price,
                }
            );
        }

        // GET api/<ProductsController>/5
        [HttpGet("{userID}")]
        public async Task<IActionResult> Get(string userID)
        {
            var products = await handler.GetAll(userID);
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
                        p.Stock,
                        p.Price
                    }
                 )
            );
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post(Product entity)
        {

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
