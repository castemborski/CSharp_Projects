using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_chapter_10
{
    /// <summary>
    /// Represents the main form for the Rock, Paper, Scissors game.
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

        // Declare variables
        string compChoice;  // variables outside voids = global variable

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// Calls the method to set the computer's choice when the form loads.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // call method to get computer choice
            setCompChoice();
        }

        /// <summary>
        /// Sets the computer's choice randomly to Rock, Paper, or Scissors.
        /// </summary>
        private void setCompChoice()
        {
            // Set up random number generator object
            Random randomGen = new Random();

            // Generate random number between 1 and 3
            int randomChoice = randomGen.Next(1, 4);

            // determine which was chosen
            switch (randomChoice)
            {
                case 1:
                    compChoice = "Rock";
                    break;
                case 2:
                    compChoice = "Paper";
                    break;
                case 3:
                    compChoice = "Scissors";
                    break;
            }
        }

        /// <summary>
        /// Determines the winner of the game based on the user's choice and the computer's choice.
        /// </summary>
        /// <param name="uChoice">The user's choice, which can be "Rock", "Paper", or "Scissors".</param>
        private void decideWinner(string uChoice) // method is looking for a string, uChoice is parameter, userChoice is argument (passing through)
        {
            // Determine winner 
            string winner;
            if (uChoice == "Rock" && compChoice == "Scissors" || uChoice == "Paper" && compChoice == "Rock" || uChoice == "Scissors" && compChoice == "Paper")
            {
                winner = "Player";
            }
            else if (uChoice == "Rock" && compChoice == "Paper" || uChoice == "Paper" && compChoice == "Scissors" || uChoice == "Scissors" && compChoice == "Rock")
            {
                winner = "Computer";
            }
            else
            {
                winner = "Tie";
            }

            // Display results
            lblResults.Text = "Computers choice: " + compChoice + "\n" + "Users choice: " + uChoice + "\n" + "Winner: " + winner;
        }

        /// <summary>
        /// Handles the Click event of the picBoxRock control.
        /// Sets the user's choice to Rock and determines the winner.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picBoxRock_Click(object sender, EventArgs e)
        {
            // Declare variables
            string userChoice = "Rock";

            // Call method to determine winner
            decideWinner(userChoice);

            // call method to reset user choice
            setCompChoice();
        }

        /// <summary>
        /// Handles the Click event of the picBoxPaper control.
        /// Sets the user's choice to Paper and determines the winner.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picBoxPaper_Click(object sender, EventArgs e)
        {
            // Declare variables
            string userChoice = "Paper";

            // Call method to determine winner
            decideWinner(userChoice);

            // call method to reset user choice
            setCompChoice();
        }

        /// <summary>
        /// Handles the Click event of the picBoxScissors control.
        /// Sets the user's choice to Scissors and determines the winner.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void picBoxScissors_Click(object sender, EventArgs e)
        {
            // Declare variables
            string userChoice = "Scissors";

            // Call method to determine winner
            decideWinner(userChoice);

            // call method to reset user choice
            setCompChoice();
        }
    }
}