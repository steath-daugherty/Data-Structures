//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 4 - Registration Simulation
//	File Name:		RegistrationDriver.cs
//	Description:	Model of registrant to be registered
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Thursday, November 9, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4;

namespace Project4
{
    /// <summary>
    /// The driver class for the registration simulation
    /// </summary>
    class RegistrationDriver
    {
        static void Main(string[] args)
        {
            ConventionRegistration cv = new ConventionRegistration();
            Console.Title = "Project 4: Registration Simulation";
            //Generate Menu options and title
            UtilityNamespace.Menu menu = new UtilityNamespace.Menu("Registration Simulation Menu");
            menu = menu +
                "Set the number of registrants" +
                "Set the number of hours of operation" +
                "Set the number of registration windows" +
                "Set the expected average registration duration" +
                "Set the expected minimim registration duration" +
                "Run the simulation" +
                "End the program";

            //
            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.QUIT)
            {
                int result = 0;
                double dResult = 0.0;
                Boolean worked = true; // if the tryparse is successful

                //Switch case to handle user input
                switch (choice)
                {
                    case Choices.SETREG:
                        Console.Write("How many registrants are expected? ");
                        result = 0;
                        worked = int.TryParse(Console.ReadLine(), out result);
                        if (worked && (result > 0))
                        {
                            cv.NumRegistrants = result;
                            break;
                        }
                        DisplayErrorMessage();
                        break;
                        

                    case Choices.SETHOURS:
                        Console.Write("How many hours will the business be open? ");
                        dResult = 0.0;
                        worked = double.TryParse(Console.ReadLine(), out dResult);
                        if (worked && (dResult > 0))
                        {
                            cv.HoursOpen = dResult;
                            break;
                        }
                        DisplayErrorMessage();
                        break;

                    case Choices.SETWINDOWS:
                        Console.Write("How many registration windows are there? ");
                        result = 0;
                        worked = int.TryParse(Console.ReadLine(), out result);
                        if (worked && (result > 0))
                        {
                            cv.NumWindows = result;
                            break;
                        }
                        DisplayErrorMessage();
                        break;

                    case Choices.SETAVG:
                        Console.Write("What is the expected average registration duration (in seconds)? ");
                        result = 0;
                        worked = int.TryParse(Console.ReadLine(), out result);
                        if (worked && (result > 0))
                        {
                            cv.AvgServiceTime = result;
                            break;
                        }
                        DisplayErrorMessage();
                        break;

                    case Choices.SETMIN:
                        Console.Write("What is the expected minimum registration duration (in seconds)? ");
                        result = 0;
                        worked = int.TryParse(Console.ReadLine(), out result);
                        if (worked && (result > 0))
                        {
                            cv.MinServiceTime = result;
                            break;
                        }
                        DisplayErrorMessage();
                        break;

                    case Choices.SIMULATE:
                        cv.Simulate();
                        break;
                }
                choice = (Choices)menu.GetChoice();
            }//while
        }//main

        /// <summary>
        /// If the user inputs incorrect data, this will display an error message.
        /// </summary>
        public static void DisplayErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("Invalid value!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadKey();
        }

    }//RegistrationDriver
}
