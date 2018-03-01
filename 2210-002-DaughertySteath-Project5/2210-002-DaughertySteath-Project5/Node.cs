//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 5 - BTrees
//	File Name:		Node.cs
//	Description:	The Node class that initializes the size of the node, and the list of values each node contains
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Monday, November 20, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace Project5_BTree
{
    /// <summary>
    /// The Node class that initializes the size of the node, and the list of values each node contains
    /// </summary>
    class Node
    {
        public int NodeSize { get; private set; }
        public List<int> Value { get; set; }

        /// <summary>
        /// Default constructor. Sets the Node size to 5 initially.
        /// </summary>
        public Node()
        {
            NodeSize = 3;
            Value = new List<int>(5);
        }

        /// <summary>
        /// The primary constructor for the node class
        /// </summary>
        /// <param name="NodeSize"></param>
        public Node(int nodeSize)
        {
            NodeSize = nodeSize;
            Value = new List<int>(this.NodeSize);
        }

        /// <summary>
        /// Overridden ToString method to return formatted output
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            double pctFull = Value.Count * 100.00 / NodeSize;
            string values = "";
            string str = "\nNode Type: ";

            if (this is Leaf)
            {
                str += "Leaf";
            }
            else
                str += "Node";

            str += "\nNumber of Values: " + Value.Count + " (";
            str += pctFull.ToString("#.00") + "% full) \nValues: ";
            
            for (int i = 0; i < Value.Count; i++)
            {
                if (!(this is Index) || i != 0)
                    values += Value[i].ToString() +" ";
                else
                    values += " ** ";
            }
            return str + values;
        }
    }
}
