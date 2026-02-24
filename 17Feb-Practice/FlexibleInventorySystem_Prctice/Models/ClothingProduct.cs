using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    
        /// <summary>
        /// TODO: Implement clothing product class
        /// </summary>
        public class ClothingProduct : Product
        {
            // TODO: Add these properties
            // - Size (string)
            // - Color (string)
            // - Material (string)
            // - Gender (string) - "Men", "Women", "Unisex"
            // - Season (string) - "Summer", "Winter", "All-season"

            /// <summary>
            /// TODO: Override GetProductDetails for clothing items
            /// </summary>
            public override string GetProductDetails()
            {
                // TODO: Return formatted string with size, color, material
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Check if size is available
            /// Valid sizes: XS, S, M, L, XL, XXL
            /// </summary>
            public bool IsValidSize()
            {
                // TODO: Validate size against allowed values
                throw new NotImplementedException();
            }

            /// <summary>
            /// TODO: Override CalculateValue to apply seasonal discount
            /// Apply 15% discount for off-season items
            /// </summary>
            public override decimal CalculateValue()
            {
                // TODO: Apply seasonal discount logic
                throw new NotImplementedException();
            }
        }   
}