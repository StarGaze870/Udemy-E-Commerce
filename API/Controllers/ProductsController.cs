using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController
    {
        private readonly StoreContext _context;

        /// <summary>
        /// ProductsController
        /// </summary>
        /// <param name="context">The database context.</param>        
        public ProductsController(StoreContext context)
        {
            _context = context;            
        }

        /// <summary>
        /// Gets a list of all products.
        /// </summary>
        /// <returns>The list of products.</returns>
        [HttpGet(Name = "Get Products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();            
        }

        /// <summary>
        /// Gets a single product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>        
        [HttpGet("{id}", Name = "GetSingleProduct")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            return await _context.Products.FindAsync(id);            
        }
    }
}
