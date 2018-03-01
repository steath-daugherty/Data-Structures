//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 5 - BTrees
//	File Name:		BTreeDriver.cs
//	Description:	The Driver for the BTree Project
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Saturday, November 26, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

using Projcet5_BTree;
using System;
using UtilityNamespace;

namespace Project5_BTree
{
    /// <summary>
    /// The driver class for the BTree
    /// </summary>
    class BTreeDriver
    {
        private static BTree b;
        private static int numNodes = 500;
        private static Random ran = new Random();

        /// <summary>
        /// Main method, displays the menu options for the user to use.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        /// <summary>
        /// Displays the menu of options
        /// </summary>
        private static void DisplayMenu()
        {
            int ScreenSize = Console.WindowWidth;
            Console.Title = "Project 5 - BTrees ©Steath Daugherty, ETSU, 2017";
            Console.ForegroundColor = ConsoleColor.Green;

            //Generate Menu options and title
            Menu menu = new Menu("BTree Menu");
            menu = menu +
                "Set Node Size and Create BTree" +
                "Display the BTree" +
                "Add a Value to the BTree" +
                "Find a Value in the BTree" +
                "Exit the Program";

            Choices choice = (Choices)menu.GetChoice();

            while (choice != Choices.QUIT)
            {
                //switch case to handle user input
                switch (choice)
                {
                    case Choices.SETSIZE:
                        SetNodeSize();
                        PauseScreen();
                        break;
                    case Choices.DISPLAY:
                        if (!IsTreeCreated())
                            break;
                        b.Display();
                        PauseScreen();
                        break;
                    case Choices.ADDNODE:
                        if (!IsTreeCreated())
                            break;
                        AddNode();
                        PauseScreen();
                        break;
                    case Choices.FINDNODE:
                        if (!IsTreeCreated())
                            break;
                        FindNode();
                        PauseScreen();
                        break;
                }
                choice = (Choices)menu.GetChoice();
            }
        }

        /// <summary>
        /// Determines if the BTree has been created yet. 
        /// </summary>
        /// <returns>true if btree has been created; false otherwise</returns>
        private static bool IsTreeCreated()
        {
            bool created = true;
            if (b == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                created = false;
                Console.WriteLine("You need to create the BTree before you can Add, Search, or Display the Tree.\n");
                Console.ForegroundColor = ConsoleColor.Green;
                PauseScreen();
            }
            return created;
        }
        /// <summary>
        /// Attempts to add a new value to the BTree if it does not already exists.
        /// (sometimes works, sometimes doesn't. I don't know.)
        /// </summary>
        public static void AddNode()
        {
            int nodeToAdd; //the node to be added
            Console.Write("Enter a value to add to the BTree: ");
            string str = Console.ReadLine();
            bool tryWorked = int.TryParse(str, out nodeToAdd);

            //if the value is already in the tree
            if (!b.AddValue(nodeToAdd))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That value is already in the BTree");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            //if the user enters bad input
            if(!tryWorked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input.");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            b.AddValue(nodeToAdd);
        }

        /// <summary>
        /// User enters a value to search, returns the path to the value if in the BTree
        /// </summary>
        private static void FindNode()
        {
            int nodeToSearch;
            Console.Write("Enter a value to search: ");
            string n = Console.ReadLine();
            bool tryWorked = int.TryParse(n, out nodeToSearch);

            if (!tryWorked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                return;
            }
            if(!b.FindValue(nodeToSearch))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Value is not in the BTree");
                return;
            }
            b.FindValue(nodeToSearch);
        }

        /// <summary>
        /// Sets the size of the node if greater than 2 but less than 21
        /// </summary>
        private static void SetNodeSize()
        {
            int result; //the arity of the BTree
            Console.WriteLine("What should the arity of the tree be?");
            string str = Console.ReadLine();
            bool tryWorked = int.TryParse(str, out result);

            if (tryWorked)
            {
                //the arity can not be less than 3 or greater than 20. If it is, set the arity to 3 instead.
                if (result < 3 || result > 20)
                {
                    Console.WriteLine("Invalid value. Arity set to 3");
                    result = 3;
                }
                b = new BTree(result);

                int attempts = 0; //the number of attempts it takes to insert all values (with no duplicates)
                int actualValues = 0; //the number of actual values added to the BTree
                while (actualValues < numNodes)
                {
                    if (b.AddValue(ran.Next(9999)))
                        actualValues++;
                    attempts++;
                }
                Console.WriteLine("Successfully Created the BTree. {0} values added in {1} attempts", actualValues, attempts);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Value.");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        /// <summary>
        /// Pauses the screen so the user can read the output; waits for keystroke
        /// </summary>
        private static void PauseScreen()
        {
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
