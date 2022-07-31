using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bom.Models
{
    /// <summary>
    /// Defines methods for interacting with the products backend.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Returns all products. 
        /// </summary>
        Task<IEnumerable<Product>> GetAsync();

        /// <summary>
        /// Returns the product with the given Id. 
        /// </summary>
        Task<Product> GetAsync(Guid id);

        /// <summary>
        /// Returns all products with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Product>> GetAsync(string search);
    }
}
