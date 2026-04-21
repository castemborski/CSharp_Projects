using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter6_5
{
    /// <summary>
    /// Represents the main form for the repair calculator application.
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

        // Declare global variable
        const double OIL_CHANGE = 26, LUBE_JOB = 18, RADIATOR_FLUSH = 30, TRANS_FLUSH = 80, INSPECTION_FEE = 15, MUFFLER_REPLACE = 100;
        const double TIRE_ROTATE = 20, TAX_FEE = 0.06;

        double partsTaxFee = 0, partsCharge = 0, laborFee = 0;

        /// <summary>
        /// Calculates the total charges for oil and lube services.
        /// </summary>
        /// <returns>The total oil and lube charges.</returns>
        private double OilLubeCharges()
        {
            // create placeholder variable for if statement
            double oilLubeFees = 0;

            // if statements to check which boxes are checked and to add to placeholder
            if (chkOilChange.Checked == true)
            {
                oilLubeFees += OIL_CHANGE;
            }
            if (chkLubeJob.Checked == true)
            {
                oilLubeFees += LUBE_JOB;
            }

            // return oil lube fees total
            return oilLubeFees;
        }

        /// <summary>
        /// Calculates the total charges for flush services.
        /// </summary>
        /// <returns>The total flush charges.</returns>
        private double FlushCharges()
        {
            // create placeholder variable for if statement
            double flushFees = 0;

            // If statements to check which boxes are checked and add to variable
            if (chkRadiatorFlush.Checked == true)
            {
                flushFees += RADIATOR_FLUSH;
            }
            
            if (chkTransFlush.Checked == true)
            {
                flushFees += TRANS_FLUSH;
            }

            // return flush fees total
            return flushFees;
        }

        /// <summary>
        /// Calculates the total charges for miscellaneous services.
        /// </summary>
        /// <returns>The total miscellaneous charges.</returns>
        private double MiscCharges()
        {
            // create placeholder variable for if statement
            double miscFees = 0;

            // If statements to check which boxes are checked and add to variable
            if (chkInspection.Checked == true)
            {
                miscFees += INSPECTION_FEE;
            }
            
            if (chkReplaceMuffler.Checked == true)
            {
                miscFees += MUFFLER_REPLACE;
            }
            
            if (chkTireRotation.Checked == true)
            {
                miscFees += TIRE_ROTATE;
            }

            // return misc fees total
            return miscFees;
        }

        /// <summary>
        /// Calculates the total charges for other services including labor and parts.
        /// </summary>
        /// <returns>The total other charges.</returns>
        private double OtherCharges()
        {
            // create placeholder variable for if statement
            double otherFees = 0;

            // If statement to parse user input for labor fee and add to variable
            if (double.TryParse(txtLabor.Text, out laborFee))
            {
                otherFees += laborFee;
            }
            else
            {
                MessageBox.Show("Please Enter Acceptable Labor Amount!");
            }

            // If statement to parse user input for parts fee and display to label output
            if (double.TryParse(txtParts.Text, out partsCharge))
            {
                // add parts charge and otherFees to get otherFees total
                otherFees += partsCharge;
                // get tax on parts
                partsTaxFee = TaxCharges(partsCharge);
                // Display total of parts to parts label result
                lblTaxResult.Text = partsTaxFee.ToString("c");
            }

            // Return total of other fees
            return otherFees;
        }

        /// <summary>
        /// Calculates the tax charges based on the total parts amount.
        /// </summary>
        /// <param name="partsTotal">The total amount of parts.</param>
        /// <returns>The calculated tax on parts.</returns>
        private double TaxCharges(double partsTotal)
        {
            // multiply parts by tax to get total
            return partsTotal * TAX_FEE;
        }

        /// <summary>
        /// Calculates the grand total of all charges.
        /// </summary>
        /// <param name="oilLubeFees">The total oil and lube fees.</param>
        /// <param name="flushFees">The total flush fees.</param>
        /// <param name="miscFees">The total miscellaneous fees.</param>
        /// <param name="otherFees">The total other fees.</param>
        /// <param name="partsTax">The total tax on parts.</param>
        /// <returns>The grand total of all charges.</returns>
        private double TotalCharges(double oilLubeFees, double flushFees, double miscFees, double otherFees, double partsTax)
        {
            // add up all charges for the grand total
            return oilLubeFees + flushFees + miscFees + otherFees + partsTax;
        }

        /// <summary>
        /// Clears the selected oil and lube checkboxes.
        /// </summary>
        private void ClearOilLube()
        {
            // Clear check boxes in Oil and Lube group
            chkOilChange.Checked = false;
            chkLubeJob.Checked = false;
        }

        /// <summary>
        /// Clears the selected flush checkboxes.
        /// </summary>
        private void ClearFlushes()
        {
            // Clear check boxes in Flushes group
            chkRadiatorFlush.Checked = false;
            chkTransFlush.Checked = false;
        }

        /// <summary>
        /// Clears the selected miscellaneous checkboxes.
        /// </summary>
        private void ClearMisc()
        {
            // Clear check boxes in Misc group
            chkInspection.Checked = false;
            chkReplaceMuffler.Checked = false;
            chkTireRotation.Checked = false;
        }

        /// <summary>
        /// Clears the input fields for parts and labor.
        /// </summary>
        private void ClearOther()
        {
            // Clear all text boxes in Parts and Labor group
            txtLabor.Text = string.Empty;
            txtParts.Text = string.Empty;
        }

        /// <summary>
        /// Clears all labels displaying the calculated fees.
        /// </summary>
        private void ClearFees()
        {
            // Clear all labels in Summary group
            LblServiceLaborResult.Text = string.Empty;
            lblPartsResult.Text = string.Empty;
            lblTaxResult.Text = string.Empty;
            lblTotalResult.Text = string.Empty;
        }

        /// <summary>
        /// Calculates and displays the total charges when the calculate button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Declare variables and run them through methods
            double oilLubeFees = OilLubeCharges();
            double flushFees = FlushCharges();
            double miscFees = MiscCharges();
            double otherFees = OtherCharges();

            // Output total for service and labor to label result
            double servLabTotal = oilLubeFees + flushFees + miscFees + laborFee;
            LblServiceLaborResult.Text = servLabTotal.ToString("c");

            // Output the total for parts and the tax on parts to label result
            lblPartsResult.Text = partsCharge.ToString("c");
            lblTaxResult.Text = partsTaxFee.ToString("c");

            // Run all charges through total charges method and output to label result
            double grandTotal = TotalCharges(oilLubeFees, flushFees, miscFees, otherFees, partsTaxFee);
            lblTotalResult.Text = grandTotal.ToString("c");
        }

        /// <summary>
        /// Clears all input fields and labels when the clear button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // On click clear all groups
            ClearFees();
            ClearFlushes();
            ClearOther();
            ClearOilLube();
            ClearMisc();
        }

        /// <summary>
        /// Closes the form when the exit button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close form on press
            this.Close();
        }
    }
}