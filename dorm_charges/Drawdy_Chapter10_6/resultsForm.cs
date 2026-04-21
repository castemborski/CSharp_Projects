using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter10_6
{
    /// <summary>
    /// Represents a form that displays the results of a calculation or operation.
    /// </summary>
    public partial class resultsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="resultsForm"/> class.
        /// </summary>
        public resultsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Exit button.
        /// Closes the form when the button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }
    }
}