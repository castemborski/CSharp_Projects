using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter3_11
{
    /// <summary>
    /// Represents the main form for calculating monthly and annual expenses.
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
        /// Handles the Click event of the btnCalc button.
        /// Calculates total monthly and annual expenses based on user input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            // declare variables
            double monthlyLoanPayment, monthlyInsurancePayment, monthlyGasPayment, monthlyOilPayment, monthlyTirePayment, monthlyMaintenancePayment;
            double totalMonthlyPayment, totalAnnualPayment;

            // Gather info on monthly payment entered
            try
            {
                monthlyLoanPayment = double.Parse(txtLoanPaymentEntry.Text);
            }
            catch 
            {
                MessageBox.Show("Invalid Monthly Loan Payment Entry!");
                return;
            }

            try
            {
                monthlyInsurancePayment = double.Parse(txtInsurancePaymentEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Monthly Insurance Payment Entry!");
                return;
            }

            try
            {
                monthlyGasPayment = double.Parse(txtGasPaymentEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Monthly Gas Payment Entry!");
                return;
            }

            try
            {
                monthlyOilPayment = double.Parse(txtOilPaymentEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Monthly Oil Payment Entry!");
                return;
            }

            try
            {
                monthlyTirePayment = double.Parse(txtTirePaymentEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Monthly Tire Payment Entry!");
                return;
            }

            try
            {
                monthlyMaintenancePayment = double.Parse(txtMaintenancePaymentEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Monthly Maintenance Payment Entry!");
                return;
            }

            // Calc total monthly expenses
            totalMonthlyPayment = monthlyLoanPayment + monthlyInsurancePayment + monthlyGasPayment + monthlyOilPayment + 
                monthlyTirePayment + monthlyMaintenancePayment;

            // Calc total annual expenses
            totalAnnualPayment = totalMonthlyPayment * 12;

            // Display totals
            lblTotalMonthly.Text = "Total Monthly Expenses: " + totalMonthlyPayment.ToString("c");
            lblTotalAnnual.Text = "Total Annual Expenses: " + totalAnnualPayment.ToString("c");
        }
    }
}