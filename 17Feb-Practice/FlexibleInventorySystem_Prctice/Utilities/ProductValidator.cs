using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Utilities
{
    
        /// <summary>
        /// TODO: Implement validation helper class
        /// </summary>
        public static class ProductValidator
        {
            /// <summary>
            /// TODO: Validate product data
            /// Check:
            /// - ID not null/empty
            /// - Name not null/empty
            /// - Price > 0
            /// - Quantity >= 0
            /// </summary>
            public static bool ValidateProduct(Product product, out string errorMessage)
            {
                // TODO: Implement validation
                errorMessage = null;
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Validate electronic product specific rules
            /// </summary>
            public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
            {
                // TODO: Implement electronic validation
                errorMessage = null;
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Validate grocery product specific rules
            /// </summary>
            public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
            {
                // TODO: Implement grocery validation
                errorMessage = null;
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Validate clothing product specific rules
            /// </summary>
            public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
            {
                // TODO: Implement clothing validation
                errorMessage = null;
                throw new NotImplementedException();
            }
        }
}
