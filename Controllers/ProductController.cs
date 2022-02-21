using BLL.DTO.Product;
using BLL.Repo;
using DLL.Data;
using DLL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API__DesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _product.GetProducts();
            return Ok(products);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _product.GetProduct(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product currentProduct)
        {
            var product = await _product.PutProduct(id, currentProduct);
            if (id != product.Id) return BadRequest();

            if (product == null) return BadRequest();

            return Ok(product);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            await _product.PostProduct(productDto);
            return Ok();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product product = await _product.DeleteProduct(id);
            if (product == null) return NotFound();
            return Ok();
        }

    }
}
