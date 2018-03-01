//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 5 - BTrees
//	File Name:		Leaf.cs
//	Description:	The leaf values contained in each Node
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Monday, November 20, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

namespace Project5_BTree
{
    /// <summary>
    /// The Leaf of each Node, primarily set to the same size as the Node.
    /// </summary>
    class Leaf : Node
    {
        /// <summary>
        /// Primary Constructor
        /// </summary>
        /// <param name="NodeSize">The leaf size is equal to the node size</param>
        public Leaf(int NodeSize) : base(NodeSize)
        {
        }

        /// <summary>
        /// Gets the INSERT value depending on: if the value is already contained in the Node,
        /// or if the Node is full. Otherwise, throw it in.
        /// </summary>
        /// <param name="n">the integer value to add</param>
        /// <returns></returns>
        public INSERT Insert(int n)
        {
            if (Value.Contains(n))
                return INSERT.DUPLICATE;
            else if (Value.Count == NodeSize)
                return INSERT.NEEDSPLIT;
            Value.Add(n);
            return INSERT.SUCCESS;
        }
    }
}
