//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 4 - Registration Simulation
//	File Name:		ConventionRegistration.cs
//	Description:	The convention center to simulate
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Thursday, November 9, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project4
{

    /// <summary>
    /// The Convention Center To Simulate
    /// </summary>
    class ConventionRegistration
    {
        public int NumRegistrants { get; set; } //num of customers expected
        public int NumWindows { get; set; } //number of registration windows
        public double HoursOpen { get; set; } //the stores hours of operation
        public int AvgServiceTime { get; set; } // seconds
        public int MinServiceTime { get; set; } // seconds
        public PriorityQue<Event> Events { get; private set; }
        public static List<Queue<Registrant>> Lines { get; private set; }
        private static Random r = new Random(); //random for general supermarket use

        /// <summary>
        /// default constructor
        /// </summary>
        public ConventionRegistration()
        {
            NumRegistrants = 1000;
            NumWindows = 6;
            HoursOpen = 10;
            AvgServiceTime = 270;
            MinServiceTime = 90;
            Events = new PriorityQue<Event>();
            Lines = null;
        }

        /// <summary>
        /// Run the Convention Center Simulation
        /// </summary>
        public void Simulate()
        {
            Events = new PriorityQue<Event>();
            int secondsOpen = (int)(HoursOpen * 60 * 60);
            int maxWait = 0; // max amt of time somebody needed
            
            //Create the Registration Windows                 
            Lines = new List<Queue<Registrant>>(NumWindows);
            for (int i = 0; i < NumWindows; i++)
            {
                Lines.Add(new Queue<Registrant>());
            }
                

            // generate registrants and events			
            for (int i = 1; i <= NumRegistrants; i++)
            {
                Registrant cust = new Registrant(r.Next(0, secondsOpen),
                    (int)(MinServiceTime + NegExp(AvgServiceTime - MinServiceTime)),
                    i);
                Events.Enqueue(new Event(cust));
                // if current maxWait is smaller than the next, set maxWait to the new one
                if (maxWait < Events.Peek().reg.ArrivalTime)
                    maxWait = Events.Peek().reg.AmtOfTimeNeeded;
            }
            GenerateEvents(secondsOpen, maxWait);
            Console.ReadKey();
        }

        /// <summary>
        /// Generates the current events and queues
        /// </summary>
        /// <param name="secondsOpen">total number of seconds convention center is open</param>
        /// <param name="maxWait">maximum time somebody has to wait</param>
        private void GenerateEvents(int secondsOpen, int maxWait)
        {
            int processedEvents = 0;
            int secondsPassed = 0;
            int longestLineEver = 0;
            int arrivals = 0;
            int departures = 0;

            // every registrant has two events: an entrance and an exit.
            //thus, the number of processed events will be double the amount of customers			
            while (processedEvents < (NumRegistrants * 2))
            {
                Boolean diffEvent = false; //detects when an event type changes
                Event temp = Events.Peek();
                //Line enter event
                if ((temp.Time == secondsPassed) && temp.Type)
                {
                    Events.Dequeue();
                    processedEvents++;
                    arrivals++;
                    diffEvent = true;

                    int shortestIndex = FindSmallestLine();
                    // if shortest queue is empty, queue the new registrant there
                    //otherwise queue the registrant
                    if (Lines[shortestIndex].Count == 0)
                    {
                        Lines[shortestIndex].Enqueue(temp.reg);
                        Events.Enqueue(new Event(temp.reg, false, temp.reg.AmtOfTimeNeeded + secondsPassed));
                    }
                    else
                        Lines[shortestIndex].Enqueue(temp.reg);
                }
                //Line exit event
                else if ((temp.Time == secondsPassed) && !temp.Type)
                {
                    ExitEvent(secondsPassed, temp);
                    processedEvents++;
                    departures++;
                    diffEvent = true;
                }
                //accumulate the seconds passing
                if ((Events.Count != 0) && Events.Peek().Time != secondsPassed)
                    secondsPassed++;
                //if nothing changes don't reprint data
                //get the longest line ever
                if (diffEvent || (secondsPassed == 1))
                {
                    longestLineEver = DisplayEventData(maxWait, processedEvents, longestLineEver, arrivals, departures);
                }
            }//While
        }//GenerateEvents

        /// <summary>
        /// Display the processed event data
        /// </summary>
        /// <param name="maxWait">maximum time somebody waits</param>
        /// <param name="eventsProcessed">total number of events</param>
        /// <param name="longestEver">the longest recorded queue</param>
        /// <param name="arrivals">number of arrivals in line</param>
        /// <param name="departures">number of departures from line</param>
        /// <returns>the longest recorded queue in this sim</returns>
        private int DisplayEventData(int maxWait, int eventsProcessed, int longestEver, int arrivals, int departures)
        {
            int consoleLen = Console.WindowWidth;
            //get the longest recorded line
            int longestIndex = FindLongestLine();
            if (Lines[longestIndex].Count > longestEver)
                longestEver = Lines[longestIndex].Count;

            //clear the screen and print the header
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nWindows".PadLeft(45));

            for(int i = 0; i<consoleLen; i++)
                Console.Write("_");

            //print the registration windows
            for (int i = NumWindows; i > 0; i--)
            {
                Console.Write("W".PadLeft(7) + (i)); 
            }
            Console.WriteLine("\n\n");

            //set the cursor position to start below window number 1
            int row = 9;
            int col = 6;
            //Prints the currently queued registrants (slightly better formatting)
            //Now shows which windows the registrants belongs to, at least.
            for (int i = 0; i < NumWindows; i++)
            {
                foreach (Registrant r in Lines[i])
                {
                    Console.SetCursorPosition(row, col);
                    Console.Write(r.ID.ToString().PadRight(7));
                    //this very badly shows the registrants are entering the smallest queue and not leaving line.
                    col++; //comment this out for better screen readability
                }
                //the the current row number equals the maximum number of windows, increment column
                if (row == NumWindows * 7)
                {
                    row = 0;
                }
                row += 7;
            }
            #region Console Formatting
            Console.Write("\n\n");
            for(int i =0; i<consoleLen; i++)
                Console.Write("_");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Longest Queue: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(longestEver +"\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Registrations Processed: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(eventsProcessed.ToString().PadRight(7));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Arrivals: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(arrivals.ToString().PadRight(7));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Departures: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(departures.ToString().PadRight(7) +"\n");


            //if the total processed events = number of registrants * 2
            //this is the last loop, so print the final results
            if ((eventsProcessed) == (NumRegistrants * 2))
            {
                //convert the time variables to doubles, and divide by 60 to get the time in minutes instead of seconds
                double doubleTime = Convert.ToDouble(AvgServiceTime / 60.00);
                double doubleMinTime = Convert.ToDouble(MinServiceTime / 60.00);
                double doubleMaxTime = Convert.ToDouble(maxWait / 60.00);

                //display the registration times
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Registration times for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(NumRegistrants);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" registrants (in minutes).\n");

                //the average registration time
                Console.Write("Average: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(doubleTime, 2));

                //the fastest registration time
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nMinimum: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(doubleMinTime, 2));

                //the longest registration time
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nMaximum: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(doubleMaxTime, 2));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any key to continue!");
            }
            #endregion
            Thread.Sleep(100); //pause the screen so the data is readable
            return longestEver;
        }

        /// <summary>
        /// Process registrant exit events
        /// </summary>
        /// <param name="secondsPassed">number of seconds gone by</param>
        /// <param name="temp">event to compare against registrants at the end of the queues</param>
        /// <returns></returns>
        private void ExitEvent(int secondsPassed, Event temp)
        {
            Events.Dequeue();
            Boolean notFound = true;
            // find the queue with the customer and dq him
            for (int i = 0; (i < Lines.Count) && notFound; i++)
            {
                if ((Lines[i].Count > 0) && (Lines[i].Peek().ID == temp.reg.ID))
                {
                    Lines[i].Dequeue();
                    notFound = false; // flag when found
                                      // if there is somebody else in line, queue their event
                    if (Lines[i].Count > 0)
                    {
                        Registrant tempC = Lines[i].Peek();
                        Events.Enqueue(new Event(Lines[i].Peek(),
                            false, Lines[i].Peek().AmtOfTimeNeeded + secondsPassed));
                    }
                }
            }
        }

        /// <summary>
        /// Find the shortest registration line
        /// </summary>
        /// <returns>index of shortest line</returns>
        private int FindSmallestLine()
        {
            int smallestLine = 0;
            for (int i = 0; i < Lines.Count; i++)
                if (Lines[i].Count <= Lines[smallestLine].Count)
                    smallestLine = i;

            return smallestLine;
        }

        /// <summary>
        /// Find the longest registration line
        /// </summary>
        /// <returns>index of longest line</returns>
        private int FindLongestLine()
        {
            int longestLine = 0;
            for (int i = 0; i < Lines.Count; i++)
                if (Lines[i].Count >= Lines[longestLine].Count)
                    longestLine = i;

            return longestLine;
        }

        /// <summary>
        /// Create Negative Exponential value for use in the Convention Center Simulation
        /// </summary>
        /// <param name="expectedVal"></param>
        /// <returns></returns>
        private static double NegExp(double expectedVal)
        {
            return -expectedVal * Math.Log(r.NextDouble(), Math.E);
        }
    }
}
