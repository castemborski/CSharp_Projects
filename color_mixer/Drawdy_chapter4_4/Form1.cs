using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_chapter4_4
{
    /// <summary>
    /// Represents the main form of the color mixer application.
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
        /// Handles the click event of the mix button.
        /// Determines the selected colors and changes the background color of the form accordingly.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnMix_Click(object sender, EventArgs e)
        {
            // Determine which radio buttons are checked
            if (rbFirstRed.Checked && rbSecondRed.Checked)
            {
                this.BackColor = Color.Red;
            }
            else if (rbFirstBlue.Checked && rbSecondBlue.Checked)
            {
                this.BackColor = Color.Blue;
            }
            else if (rbFirstYellow.Checked && rbSeconYellow.Checked)
            {
                this.BackColor = Color.Yellow;
            }
            else if ((rbFirstRed.Checked && rbSecondBlue.Checked) || (rbFirstBlue.Checked && rbSecondRed.Checked)) 
            {
                this.BackColor = Color.Purple;
            }
            else if ((rbFirstRed.Checked && rbSeconYellow.Checked) || (rbFirstYellow.Checked && rbSecondRed.Checked))
            {
                this.BackColor = Color.Orange;
            }
            else if ((rbFirstBlue.Checked && rbSeconYellow.Checked) || (rbFirstYellow.Checked && rbSecondBlue.Checked))
            {
                this.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// Handles the click event of the exit button.
        /// Closes the form when the exit button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Function that closes the form
            this.Close();
        }
    }
}