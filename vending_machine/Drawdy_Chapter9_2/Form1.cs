using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter9_2
{
    /// <summary>
    /// Represents the main form of the vending machine application.
    /// </summary>
    public partial class Form1 : Form
    {
        // create structure
        /// <summary>
        /// Represents the data for a drink.
        /// </summary>
        struct DrinkData
        {
            /// <summary>
            /// Gets or sets the name of the drink.
            /// </summary>
            public string drinkName;

            /// <summary>
            /// Gets or sets the cost of the drink in cents.
            /// </summary>
            public int drinkCost;

            /// <summary>
            /// Gets or sets the available count of the drink.
            /// </summary>
            public int drinkCount;
        }

        // declare array to hold drink data
        /// <summary>
        /// An array that holds all available drinks.
        /// </summary>
        DrinkData[] allDrinks;

        // declare salesTotal variable as decimal for currency formatting
        /// <summary>
        /// The total sales amount in decimal format.
        /// </summary>
        decimal salesTotal = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // initialize drink array
            allDrinks = new DrinkData[]
            {
                new DrinkData { drinkName = "Cola", drinkCost = 100, drinkCount = 20 },
                new DrinkData { drinkName = "Lemon Lime", drinkCost = 100, drinkCount = 20 },
                new DrinkData { drinkName = "Cream Soda", drinkCost = 150, drinkCount = 20 },
                new DrinkData { drinkName = "Root Beer", drinkCost = 100, drinkCount = 20 },
                new DrinkData { drinkName = "Grape Soda", drinkCost = 150, drinkCount = 20 }
            };
        }

        /// <summary>
        /// Processes the drink selection based on the provided index.
        /// </summary>
        /// <param name="drinkIndex">The index of the selected drink.</param>
        private void ProcessDrink(int drinkIndex)
        {
            // Check if the drink is available
            if (allDrinks[drinkIndex].drinkCount > 0)
            {
                // subtract from chosen drink count
                allDrinks[drinkIndex].drinkCount--;
                // add to sales total and convert the number into dollars
                salesTotal += allDrinks[drinkIndex].drinkCost / 100m;
                // output sales total
                lblTotal.Text = salesTotal.ToString("C");
                // update drink counts
                lblColaCount.Text = allDrinks[0].drinkCount.ToString();
                lblLemonLCount.Text = allDrinks[1].drinkCount.ToString();
                lblCreamSCount.Text = allDrinks[2].drinkCount.ToString();
                lblRootBCount.Text = allDrinks[3].drinkCount.ToString();
                lblGrapeCount.Text = allDrinks[4].drinkCount.ToString();
            }
            else
            {
                MessageBox.Show(allDrinks[drinkIndex].drinkName + " is out of stock.");
            }
        }

        /// <summary>
        /// Handles the click event for the Cola picture box.
        /// </summary>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // pass the index of cola to the processdrink method
            ProcessDrink(0);
        }

        /// <summary>
        /// Handles the click event for the Lemon Lime picture box.
        /// </summary>
        private void picLemonLime_Click(object sender, EventArgs e)
        {
            // pass the index of lemon lime soda to the processdrink method
            ProcessDrink(1);
        }

        /// <summary>
        /// Handles the click event for the Cream Soda picture box.
        /// </summary>
        private void picCreamSoda_Click(object sender, EventArgs e)
        {
            // pass the index of cream soda to the processdrink method
            ProcessDrink(2);
        }

        /// <summary>
        /// Handles the click event for the Root Beer picture box.
        /// </summary>
        private void picRootBeer_Click(object sender, EventArgs e)
        {
            // pass the index of root beer to the processdrink method
            ProcessDrink(3);
        }

        /// <summary>
        /// Handles the click event for the Grape Soda picture box.
        /// </summary>
        private void picGrape_Click(object sender, EventArgs e)
        {
            // pass the index of grape soda to the processdrink method
            ProcessDrink(4);
        }

        /// <summary>
        /// Handles the click event for the Exit button.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close form on click
            this.Close();
        }

        /// <summary>
        /// Handles the click event for the title label.
        /// </summary>
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}