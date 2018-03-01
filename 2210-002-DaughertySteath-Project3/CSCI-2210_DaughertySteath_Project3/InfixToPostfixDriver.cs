//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 3 - Infix To Postfix Conversion
//	File Name:		InfixToPostfixDriver.cs
//	Description:	This class runs the forms
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		Sunday, October 29, 2017
//	Copyright:	    Steath Daugherty, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCI_2210_DaughertySteath_Project3
{
    /// <summary>
    /// InfixToPostfixDriver runs the splash screen and initalizes the main form.
    /// </summary>
    static class InfixToPostfixDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// Runs the splash screen and transitions into the main form
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Project3_SplashScreen());
            Application.Run(new InfixToPostfixForm());
        }
    }
}
