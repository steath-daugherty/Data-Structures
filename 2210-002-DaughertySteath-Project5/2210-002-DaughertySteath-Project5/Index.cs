//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 5 - BTrees
//	File Name:		Index.cs
//	Description:	The Node class that initializes the size of the node, and the list of values each node contains
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Monday, November 20, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace Project5_BTree
{
    /// <summary>
    /// The index class creates the list of indexes and functionality to insert values and sort
    /// </summary>
    class Index : Node
    {
        public List<Node> Indexes { get; set; }

        /// <summary>
        /// Default empty constructor
        /// </summary>
        public Index()
        {
        }

        /// <summary>
        /// Primary Index Constructor
        /// </summary>
        /// <param name="n">the size of the list</param>
        public Index(int n) : base(n)
        {
            Indexes = new List<Node>(NodeSize);
        }

        /// <summary>
        /// takes in a value and determines if it's a duplicate, or if the relevant node is full and needs to be split
        /// </summary>
        /// <param name="n">the value to be inserted</param>
        /// <param name="node">the node to insert the value in to</param>
        /// <returns></returns>
        public INSERT Insert(int n, Node node)
        {
            //if the value is already in the tree, return DUPLICATE
            if (Value.IndexOf(n) == n)
                return INSERT.DUPLICATE;
            //if the relevant node is full, return NEEDSPLIT
            if (Value.Count == this.NodeSize)
                return INSERT.NEEDSPLIT;
            //otherwise insert the new value
            else
            {
                Value.Add(n);
                Indexes.Add(node);
            }
            return INSERT.SUCCESS;
        }

        /// <summary>
        /// The method to sort the BTree
        /// </summary>
        public void Sort()
        {
            bool finished = false; //flag to determine if the sorting is finished.
            int count = 0;

            //while there are still values to check, and sorting is not complete
            while (count < Value.Count && !finished)
            {
                finished = true;
                for (int i = 0; i < Value.Count - count; i++)
                {
                    //if the current value is greater than the next, swap them
                    if (Value[i] > Value[i + 1])
                    {
                        //get the current node and index
                        int prevIndex = Value[i];
                        Node prevNode = Indexes[i];

                        //swap the current node and index values with the next
                        Value[i] = Value[i + 1];
                        Value[i + 1] = prevIndex;
                        Indexes[i] = Indexes[i + 1];
                        Indexes[i + 1] = prevNode;
                        finished = false;
                    }
                }
                count++;
            }
                
        }
    }
}
