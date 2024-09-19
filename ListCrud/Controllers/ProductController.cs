using ListCrud.Interface;
using ListCrud.Model;
using ListCrud.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ListCrud.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductInterface productInterface;


        public ProductController(IProductInterface productInterface)
        {
            this.productInterface = productInterface;
        }
        [HttpGet("getAllProducts")]
        public IActionResult getAllProducts()
        {
            return Ok(productInterface.getAllProducts());
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = productInterface.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost("AddProducts")]
        public IActionResult AddProducts(Product product)
        {

            productInterface.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            productInterface.UpdateProduct(id, updatedProduct);
            return NoContent();
        }

        // DELETE: api/products/{id} - Delete a product
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            productInterface.deleteProductById(id);
            return Ok();
        }
    }
}