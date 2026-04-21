using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_chapter4_5
{
    /// <summary>
    /// Represents the main form for the distance converter application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the convert button.
        /// Converts the input distance from one unit to another based on user selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Declare variables
            double numberToConvert;
            double convertedNumber;
            string fromUnit, toUnit;

            // Get units of measurement from list boxes

            // Check to see if the selected index is -1
            if (lstFrom.SelectedIndex != -1 && lstTo.SelectedIndex != -1)
            {
                fromUnit = lstFrom.SelectedItem.ToString();
                toUnit = lstTo.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("ERROR: Invalid Conversion Units Selected!");
                return;
            }

            // Get number to convert from input text box
            try
            {
                numberToConvert = double.Parse(txtEntry.Text);
            }
            catch
            {
                MessageBox.Show("ERROR: Invalid Number to Convert Entered!");
                return;
            }

            // If statement block to determine which units were selected
            if (fromUnit == toUnit)
            {
                convertedNumber = numberToConvert;
            }
            else if (fromUnit == "Yards" && toUnit == "Feet")
            {
                convertedNumber = numberToConvert * 3;
            }
            else if (fromUnit == "Feet" && toUnit == "Yards")
            {
                convertedNumber = numberToConvert / 3;
            }
            else if (fromUnit == "Yards" && toUnit == "Inches")
            {
                convertedNumber = numberToConvert * 3 * 12;
            }
            else if (fromUnit == "Inches" && toUnit == "Yards")
            {
                convertedNumber = numberToConvert / 3 / 12;
            }
            else if (fromUnit == "Feet" && toUnit == "Inches")
            {
                convertedNumber = numberToConvert * 12;
            }
            else if (fromUnit == "Inches" && toUnit == "Feet")
            {
                convertedNumber = numberToConvert / 12;
            }
            else
            {
                convertedNumber = -1;
            }

            // Store converted number in output text box
            txtOutput.Text = convertedNumber.ToString();
        }

        /// <summary>
        /// Handles the click event of the exit button.
        /// Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}