//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 4 - Registration Simulation
//	File Name:		Registrant.cs
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

namespace Project4
{
    /// <summary>
    /// The class to create a new registrant
    /// </summary>
    class Registrant
    {
        // time arrived at checkout line
        public int ArrivalTime { get; private set; } // second
        public int AmtOfTimeNeeded { get; private set; } // seconds; when at reg, not in line
        public int ID { get; set; }

        private Random r = new Random(); //random created at supermarket creation

        /// <summary>
        /// default constructor
        /// </summary>
        public Registrant()
        {
            ArrivalTime = -1;
            AmtOfTimeNeeded = -1;
            ID = -1;
        }

        /// <summary>
        /// parameterized constructor (main one to be used)
        /// </summary>
        /// <param name="arrivalTime">time the registrant arrives in line</param>
        /// <param name="amtOfTime">the amount of time the registrant needs to checkout</param>
        /// <param name="iD">id number of registrant</param>
        public Registrant(int arrivalTime, int amtOfTime, int iD)
        {
            ArrivalTime = arrivalTime;
            AmtOfTimeNeeded = amtOfTime;
            ID = iD;
        }
    }
}
