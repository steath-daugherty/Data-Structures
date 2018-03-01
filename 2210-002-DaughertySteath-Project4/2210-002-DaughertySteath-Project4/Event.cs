//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 4 - Registration Simulation
//	File Name:		Event.cs
//	Description:	The Event class to create and compare events
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

namespace Project4
{

    /// <summary>
    /// event for the supermarket simulation queues
    /// </summary>
    class Event : IComparable
    {
        public Registrant reg { get; set; }
        public Boolean Type { get; set; }//true = Enter event. False = Exit event.
        public double Time { get; set; } // time the event starts

        /// <summary>
        /// default constructor
        /// </summary>
        public Event()
        {
            reg = new Registrant();
            Type = true;
            Time = -1;
        }

        /// <summary>
        /// constructor: passing only a customer, is a line enter event
        /// </summary>
        /// <param name="reg"></param>
        public Event(Registrant reg)
        {
            this.reg = reg;
            Type = true;
            Time = reg.ArrivalTime;
        }

        /// <summary>
        /// constructor to set all fields
        /// </summary>
        /// <param name="reg">the registrant to use</param>
        /// <param name="type">type to use</param>
        /// <param name="time">time to use</param>
        public Event(Registrant reg, Boolean type, double time)
        {
            this.reg = reg;
            Type = type;
            Time = time;
        }

        /// <summary>
        /// compare two event objects
        /// </summary>
        /// <param name="obj">object to comapre against</param>
        /// <returns>-1 if this is less, 0 if equal, 1 if this is greater</returns>
        public int CompareTo(Object obj)
        {
            if (!(obj is Event))
                throw new ArgumentException("The arg is not an Event obj.");
            Event e = (Event)obj;
            if (Time > e.Time)
                return -1;
            else if (Time == e.Time)
                return 0;
            else
                return 1;
        }
    }//Event
}//Project4
