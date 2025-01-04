using Core.Entities;
using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class ProductController(IProductRepositry repo) : BaseController
    {
  

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct()
        {
            return Ok(await repo.GetProductAsyn());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsyn(id);

            if (product == null) { return NotFound(); }

            return product;
            
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            
            repo.AddProduct(product);

            if (await repo.SaveChangesAsyn())
            {
                return CreatedAtAction("GetProduct", new { Id = product.Id }, product);
            }

            return BadRequest("Problem Creating Product");
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateProduct(int id,[FromBody]  Product  product)
        {
            
                
            if(!ProductExist(id))
            {
                return BadRequest("Can not update Product");
            }
            
            repo.UpdateProduct(product);
            if (await repo.SaveChangesAsyn())
            {
                return NoContent();
            }
            return BadRequest("Can not update Product");
        }

        private bool ProductExist(int id)
        {
            return repo.Productexists(id);
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product =  await repo.GetProductByIdAsyn(id);

            if (product == null) { return NotFound(); }
            repo.DeleteProduct(product);

            if (await repo.SaveChangesAsyn())
            {
                return NoContent();
            }
            return BadRequest("Can not delete Product");
        }

      
    }
}
