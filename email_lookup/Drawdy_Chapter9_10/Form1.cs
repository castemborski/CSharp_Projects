using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawdy_Chapter9_10
{
    /// <summary>
    /// Represents the main form for the email lookup application.
    /// </summary>
    public partial class Form1 : Form
    {
        // dictionary to hold contacts with names as keys and emails as values
        static Dictionary<string, string> contacts = new Dictionary<string, string>();
        // file for saving and retrieving contacts
        const string dictFile = "Dictionary.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            // method to retrieve contacts and put into dictionary when form is loaded
            LoadContacts();
        }

        /// <summary>
        /// Handles the Click event of the btnEnter control.
        /// Looks up the email entered by the user and displays the associated name.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            // get email from lookup textbox
            string lookupEmail = txtLookupEmail.Text.Trim();

            // check if email is in dictionary
            if (contacts.ContainsValue(lookupEmail))
            {
                // find name associated with email
                string emailName = GetNameByEmail(lookupEmail);
                // display name
                lblLookupResult.Text = "Name: " + emailName;
            } 
            else
            {
                // display that email was not found
                lblLookupResult.Text = "Email not found!";
            }

            // clear input after result so user can look up different email
            txtLookupEmail.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// Closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// Adds a new contact to the dictionary based on user input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get name from textbox
            string userName = txtAddName.Text.Trim();
            // Get email from textbox
            string userEmail = txtAddEmail.Text.Trim();

            // check if textboxes are empty
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEmail))
            {
                // Show error message
                lblAddResult.Text = "Please Enter An Email and Name to Add!";
                return;
            }

            // call method to add contact to dictionary
            AddContact(userName, userEmail);

            // clear input after result
            txtAddName.Clear();
            txtAddEmail.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnChange control.
        /// Changes the email of an existing contact based on user input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            // Get users current email
            string currentEmail = txtChangeCurrentEmail.Text.Trim();
            // Get new email
            string newEmail = txtChangeNewEmail.Text.Trim();

            // check if either field is empty
            if (string.IsNullOrWhiteSpace(currentEmail) || string.IsNullOrWhiteSpace(newEmail))
            {
                // Show error message
                lblChangeResult.Text = "Please Enter a Current and New Email Address!";
                return;
            }

            // check if current email exists in contacts
            if (contacts.ContainsValue(currentEmail))
            {
                // call method to change email
                ChangeEmail(currentEmail, newEmail);
                // output result
                lblChangeResult.Text = "Email Updated.";
            }
            else
            {
                // Show error message
                lblChangeResult.Text = "Current Email Not Found!";
            }

            // clear both fields for new input
            txtChangeCurrentEmail.Clear();
            txtChangeNewEmail.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// Deletes a contact from the dictionary based on user input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // get user entered name
            string userName = txtNameDelete.Text.Trim();
            // get user entered email
            string userEmail = txtEmailDelete.Text.Trim();

            // check if either field is empty
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEmail))
            {
                // show error message
                lblDeleteResult.Text = "Please Enter a Name and Email to Delete!";
                return;
            }

            // check if contact exists and call method to delete contact
            if (DeleteContact(userName, userEmail))
            {
                // output result
                lblDeleteResult.Text = "Contact Deleted!";
            }
            else
            {
                // Display error
                lblDeleteResult.Text = "Contact Not Found!";
            }

            // clear input fields for new input
            txtEmailDelete.Clear();
            txtNameDelete.Clear();
        }

        /// <summary>
        /// Adds a new contact to the dictionary.
        /// </summary>
        /// <param name="userName">The name of the user to add.</param>
        /// <param name="userEmail">The email of the user to add.</param>
        private void AddContact(string userName, string userEmail)
        {
            // add or update contact in dict
            contacts[userName] = userEmail;
            // display result
            lblAddResult.Text = "Contact Added!";
        }

        /// <summary>
        /// Changes the email of an existing contact.
        /// </summary>
        /// <param name="currentEmail">The current email of the user.</param>
        /// <param name="newEmail">The new email to assign to the user.</param>
        private void ChangeEmail(string currentEmail, string newEmail)
        {
            // find information associated with current email
            string userName = GetNameByEmail(currentEmail);
            // update dictionary
            contacts[userName] = newEmail;
        }

        /// <summary>
        /// Deletes a contact from the dictionary.
        /// </summary>
        /// <param name="userName">The name of the user to delete.</param>
        /// <param name="userEmail">The email of the user to delete.</param>
        /// <returns><c>true</c> if the contact was successfully deleted; otherwise, <c>false</c>.</returns>
        private bool DeleteContact(string userName, string userEmail) 
        {
            // check if contact exists and if userEmail matches
            if (contacts.TryGetValue(userName, out string storedEmail) && storedEmail == userEmail)
            { 
                // delete contact
                contacts.Remove(userName);
                // return true if successful
                return true;
            }
            else
            {
                // return false if failed
                return false;
            }
        }

        /// <summary>
        /// Retrieves the name associated with the specified email.
        /// </summary>
        /// <param name="userEmail">The email to look up.</param>
        /// <returns>The name associated with the email, or <c>null</c> if not found.</returns>
        private string GetNameByEmail(string userEmail)
        {
            // loop through contacts
            foreach (var contact in contacts)
            {
                // check if email is in contacts
                if (contact.Value == userEmail)
                {
                    // return name associated with email
                    return contact.Key;
                }
            }

            // return null if no value is found
            return null;
        }

        /// <summary>
        /// Loads contacts from a file when the form loads.
        /// </summary>
        private void LoadContacts()
        {
            // try catch statement to catch if there is an error accessing the file
            try
            {
                // check if file exists
                if (File.Exists("Dictionary.txt"))
                {
                    // open file for reading
                    using (StreamReader dictFile = new StreamReader("Dictionary.txt"))
                    {
                        string linesOfFile;

                        // read each line from file
                        while ((linesOfFile = dictFile.ReadLine()) != null)
                        {
                            // split line using comma to separate name and email
                            string[] lineSplit = linesOfFile.Split(',');

                            // check to make sure lines only split into name and email
                            if (lineSplit.Length == 2)
                            {
                                // get name
                                string nameKey = lineSplit[0].Trim();
                                // get email
                                string emailValue = lineSplit[1].Trim();

                                // add name and email to dictionary
                                contacts[nameKey] = emailValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // display error message
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Saves contacts to a file when the form closes.
        /// </summary>
        private void SaveContact()
        {
            // try catch statement to catch error accessing file
            try
            {
                // open file for writing
                using (StreamWriter dictFile = new StreamWriter("Dictionary.txt"))
                {
                    // loop through contacts
                    foreach (var contact in contacts)
                    {
                        // write contacts to file with comma in between
                        dictFile.WriteLine($"{contact.Key}, {contact.Value}");
                    }
                }
            } 
            catch (Exception ex)
            {
                // display error message
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Ensures contacts are saved before the form closes.
        /// </summary>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // save contacts to file
            SaveContact(); 
            // make sure form closes correctly
            base.OnFormClosing(e); 
        }
    }
}