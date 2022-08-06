using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Models
{
    public interface IBomDatabase
    {
        /// <summary>
        /// Returns the customers repository.
        /// </summary>
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Returns the orders repository.
        /// </summary>
        IOrderRepository Orders { get; }

        /// <summary>
        /// Returns the products repository.
        /// </summary>
        IProductRepository Products { get; }
    }
}
