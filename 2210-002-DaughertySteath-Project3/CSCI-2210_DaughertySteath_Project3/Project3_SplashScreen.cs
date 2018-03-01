//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 3 - Infix To Postfix Conversion
//	File Name:		Project3_SplashScreen.cs
//	Description:	Displays the splash screen until the timer reaches zero
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCI_2210_DaughertySteath_Project3
{
    /// <summary>
    /// Displays the splash screen for the designated amount of time and then transitions to the main form.
    /// </summary>
    public partial class Project3_SplashScreen : Form
    {
        public int timeLeft { get; set; } //the amount of time the splash screen should stay active

        /// <summary>
        /// initializes the splash screen
        /// </summary>
        public Project3_SplashScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the splash screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Project3_SplashScreen_Load(object sender, EventArgs e)
        {
            timeLeft = 30;
            timer1.Start();
        }

        /// <summary>
        /// While the timer has not reached zero, keep the splash screen up,
        /// once it reaches zero, display the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
                timeLeft--;
            else
            {
                timer1.Stop();                      //stop the timer
                new InfixToPostfixForm().Show();    //display the main form
                this.Hide();                        //hide the splash screen
            }
        }
    }
}
