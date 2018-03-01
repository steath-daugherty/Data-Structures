//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 3 - Infix To Postfix Conversion
//	File Name:		InfixToPostfix.cs
//	Description:	This class initializes the main form and houses all the methods for button clicks, toolstrip menus, etc.
//                  Also performs logic to validate the input.
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		Sunday, October 29, 2017
//	Copyright:	    Steath Daugherty, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCI_2210_DaughertySteath_Project3
{

    /// <summary>
    /// Initializes the main form with button logic, validation logic, and toolstrip functionality.
    /// </summary>
    public partial class InfixToPostfixForm : Form
    {
        Postfix pf = new Postfix();
        public string output;


        /// <summary>
        /// Initializes the InfixToPostFix Form.
        /// </summary>
        public InfixToPostfixForm()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }



        /// <summary>
        /// when the user clicks the convert button, if the infix text box is empty, display an error message
        /// otherwise display the appropriate output in the outfix text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertInfix_Click(object sender, EventArgs e)
        {
            string output = null;
            //If the input box is empty, display an error message
            if (infixTextBox.Text.Length<1)
            {
                
                MessageBox.Show("Infix Equation box can not be empty. Either:\n"
                               + "1. Type an equation in the Infix Equation box below.\n"
                               + "2. Import a list and select an equation to convert"
                               +"\n    This can be done under File >> Input Infix File", "No Equation Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            //otherwise, operate on the string from the input box
            else
            {
                pf.InfixExpression = infixTextBox.Text;

                if (CheckIfValid(pf.InfixExpression, out output))
                {
                    string postfixOutput = pf.Convert();
                    postfixTextBox.ForeColor = Color.Blue;
                    postfixTextBox.Text = postfixOutput;
                } 
                else
                {
                    postfixTextBox.ForeColor = Color.Red;
                    postfixTextBox.Text = output;
                }
                    
            }
        }//btnConvertInfix



        /// <summary>
        /// The toolstrip menu option to import a list of equations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputInfixFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> equations = new List<string>();
            Stream stream = null;
            string line;


            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.InitialDirectory = "C:\\Documents";
            openDlg.Filter = "txt files (*.txt)|*.txt";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;


            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openDlg.FileName);

                if ((stream = openDlg.OpenFile()) != null)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        equations.Add(line);
                    }//while

                }//if
                foreach (string s in equations)
                {
                    EquationsListBox.DataSource = equations;
                }
            }//if
        }


        /// <summary>
        /// if the user selects another equation from the list box, update the infix equation text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            infixTextBox.Text = EquationsListBox.SelectedItem.ToString();
        }


        /// <summary>
        /// the toolstrip menu option to view details about the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutInfixToPostfixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }

        /// <summary>
        /// if the user clicks the clear button, clear the infix and outfix text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            infixTextBox.Clear();
            postfixTextBox.Clear();
        }

        /// <summary>
        /// if the user clicks the exit button, exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Check to see if the input equation is valid. If true, return the outfix equation, otherwise
        /// return the reason why it is invalid.
        /// </summary>
        /// <param name="input">the infix equation</param>
        /// <param name="output">String containing the error message</param>
        /// <returns></returns>
        private static bool CheckIfValid(string input, out string output)
        {
            output = null;
            int start = 0, end = 0;

            //if the infix equation contains a decimal
            if (input.Contains("."))
            {
                output = "Error: Equation can not contain decimals";
                return false;
            }
            //or if the infix equation starts with any of the following: +-/*%  
            else if (input.StartsWith("+") || input.StartsWith("-") || input.StartsWith("/") || input.StartsWith("*") || input.StartsWith("%"))
            {
                output = "Error: Equation must start with a letter or digit";
                return false;
            }


            //get the number of opening and closing parentheses    
            foreach (char c in input)
            {
                if (c == '(')
                    start++;
                else if (c == ')')
                    end++;
            }
            //if there are unequal amount of parentheses
            if (start > end)
            {
                output = "Error: Unclosed parenthesis";
                return false;
            }
            else if (start < end)
            {
                output = "Error: Too many closing parenthesis";
                return false;
            }
            
            return true;
        }
    }//Form 1 class
}
