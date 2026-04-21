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
        /// <value>
        /// The name of the product.
        /// </value>
        public string Name
        {
            // get and return variable
            get
            {
                return _name;
            }
            // set equal to value given to method
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// The price of the product.
        /// </value>
        public double Price
        {
            // get and return variable
            get
            {
                return _price;
            }
            // set equal to value given to method
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        /// <value>
        /// The description of the product.
        /// </value>
        public string Description
        {
            // get and return variable
            get
            {
                return _description;
            }
            // set equal to value given to method
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity of the product in stock.
        /// </summary>
        /// <value>
        /// The quantity of the product.
        /// </value>
        public int Quantity
        {
            // get and return variable
            get
            {
                return _quantity;
            }
            // set equal to value given to method
            set
            {
                _quantity = value;
            }
        }

    }
}