using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter5_10
{
    /// <summary>
    /// Represents the main form of the random number guessing game.
    /// </summary>
    public partial class Form1 : Form
    {
        // declare variables and generate random number
        private Random rand = new Random();
        private int numGenerated;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // generate random number when form opens
            numGenerated = rand.Next(1, 101);
        }

        /// <summary>
        /// Handles the Click event of the btnCheck control.
        /// Checks the user's input against the generated number and updates the result label.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            // get user input from text box
            int userNum = int.Parse(txtGuess.Text);

            if (userNum == numGenerated)
            {
                lblResult.Text = "Correct! Good Job! A New Number is Now Generated!";
                txtGuess.Text = "";
                numGenerated = rand.Next(1, 101);
            } 
            else if (userNum > numGenerated)
            {
                lblResult.Text = "Incorrect! Too High!";
                txtGuess.Text = "";
            } 
            else if (userNum < numGenerated)
            {
                lblResult.Text = "Incorrect! Too Low!";
                txtGuess.Text = "";
                txtGuess.Text = "";
            }
            else
            {
                lblResult.Text = "Error! Please Try Again!";
                txtGuess.Text = "";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// Closes the form when the exit button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}