using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter8_1
{
    /// <summary>
    /// Represents the main form of the application that allows users to input a string and count the number of words in it.
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
        /// Handles the click event of the submit button. It retrieves the text from the input box, counts the words, and displays the result.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Kylie Drawdy

            //Declare variables
            string enteredString;
            int totalWords;

            // get text from text box and put into string
            enteredString = txtString.Text;

            // call countWord method and place returned value into total words
            totalWords = countWords(enteredString);

            // output
            lblResult.Text = "Number of Words: " + totalWords.ToString();
        }

        /// <summary>
        /// Counts the number of words in the specified string.
        /// </summary>
        /// <param name="str">The string to count words in.</param>
        /// <returns>The number of words in the string.</returns>
        private int countWords(string str)
        {
            // Declare variables 
            int numWords = 0;
            bool wordBegin = false;

            // loop to run through string
            for (int i = 0; i < str.Length; i++)
            {
                // if statement to see if it is the first character of the string and not a space
                if (i == 0 && !char.IsWhiteSpace(str[i]))
                {
                    wordBegin = true;
                }
                // if statement to check for second word in string
                else if (i > 0 && char.IsWhiteSpace(str[i - 1]))
                {
                    wordBegin = true;
                }
                else
                {
                    wordBegin = false;
                }
                // if statement to see if wordBegin is true
                if (wordBegin == true && (char.IsLetterOrDigit(str[i]) || char.IsPunctuation(str[i])))
                {
                    // add to word count
                    numWords++;
                }
            }

            // return value back to main
            return numWords;
        }
    }
}