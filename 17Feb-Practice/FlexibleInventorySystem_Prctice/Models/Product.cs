using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
         // Base Product Class
    
        /// <summary>
        /// TODO: Implement abstract base class for all products
        /// </summary>
        public abstract class Product
        {
            // TODO: Add these properties
            // - Id (string)
            // - Name (string)
            // - Price (decimal)
            // - Quantity (int)
            // - Category (string)
            // - DateAdded (DateTime)

            /// <summary>
            /// TODO: Implement abstract method to get product-specific details
            /// </summary>
            public abstract string GetProductDetails();

            /// <summary>
            /// TODO: Implement virtual method to calculate inventory value
            /// Default: Price * Quantity
            /// </summary>
            public virtual decimal CalculateValue()
            {
                // TODO: Return Price * Quantity
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Override ToString() to return product summary
            /// </summary>
            public override string ToString()
            {
                // TODO: Return formatted string with Id, Name, Price, Quantity
                throw new NotImplementedException();
            }
        }
    }
}

   

   

    
}
