using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawdy_Exam2
{
    /// <summary>
    /// Represents a product with a name, description, price, and quantity.
    /// </summary>
    internal class theProducts
    {
        // Kylie Drawdy

        // Declare properties / variables
        private string _name, _description;
        private double _price;
        private int _quantity;

        /// <summary>
        /// Initializes a new instance of the <see cref="theProducts"/> class with default values.
        /// </summary>
        public theProducts()
        {
            // assign appropriate default values to properties
            _name = "";
            _description = "";
            _price = 0;
            _quantity = 5;
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name
        {
            /// <summary>
            /// Gets the name of the product.
            /// </summary>
            /// <returns>The name of the product.</returns>
            get
            {
                return _name;
            }
            /// <summary>
            /// Sets the name of the product.
            /// </summary>
            /// <param name="value">The name to set for the product.</param>
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public double Price
        {
            /// <summary>
            /// Gets the price of the product.
            /// </summary>
            /// <returns>The price of the product.</returns>
            get
            {
                return _price;
            }
            /// <summary>
            /// Sets the price of the product.
            /// </summary>
            /// <param name="value">The price to set for the product.</param>
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description
        {
            /// <summary>
            /// Gets the description of the product.
            /// </summary>
            /// <returns>The description of the product.</returns>
            get
            {
                return _description;
            }
            /// <summary>
            /// Sets the description of the product.
            /// </summary>
            /// <param name="value">The description to set for the product.</param>
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantity
        {
            /// <summary>
            /// Gets the quantity of the product.
            /// </summary>
            /// <returns>The quantity of the product.</returns>
            get
            {
                return _quantity;
            }
            /// <summary>
            /// Sets the quantity of the product.
            /// </summary>
            /// <param name="value">The quantity to set for the product.</param>
            set
            {
                _quantity = value;
            }
        }

    }
}