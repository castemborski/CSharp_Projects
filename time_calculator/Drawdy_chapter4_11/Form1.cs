using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_chapter4_11
{
    /// <summary>
    /// Represents the main form of the application that calculates time conversions from seconds.
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
        /// Converts the number of seconds entered by the user into minutes, hours, and days, and displays the results.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// If the input is not a valid number, an error message is displayed.
        /// </remarks>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Declare variables
            const double SECONDS_IN_MINUTE = 60;
            const double SECONDS_IN_HOUR = 3600;
            const double SECONDS_IN_DAY = 86400;
            double secondsEntered;

            // Determine number of seconds entered and assign to variable
            try
            {
                secondsEntered = double.Parse(txtSecondsEntry.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Number of Seconds Entered!");
                return;
            }

            // Determine time of seconds entered and display output
            if (secondsEntered >= SECONDS_IN_MINUTE && (secondsEntered < SECONDS_IN_HOUR))
            {
                lblResult.Text = "There are " + secondsEntered / SECONDS_IN_MINUTE + " Minutes in " + secondsEntered + " Seconds";
            }
            else if (secondsEntered >= SECONDS_IN_HOUR && (secondsEntered < SECONDS_IN_DAY))
            {
                lblResult.Text = "There are " + secondsEntered / SECONDS_IN_MINUTE + " Minutes in " + secondsEntered + " Seconds" + 
                    "\nThere are " + secondsEntered / SECONDS_IN_HOUR + " Hours in " + secondsEntered + " Seconds";
            }
            else if (secondsEntered >= SECONDS_IN_DAY)
            {
                lblResult.Text = "There are " + secondsEntered / SECONDS_IN_MINUTE + " Minutes in " + secondsEntered + " Seconds" +
                    "\nThere are " + secondsEntered / SECONDS_IN_HOUR + " Hours in " + secondsEntered + " Seconds" + 
                    "\nThere are " + secondsEntered / SECONDS_IN_DAY + " Days in " + secondsEntered + " Seconds";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit button. 
        /// Closes the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}