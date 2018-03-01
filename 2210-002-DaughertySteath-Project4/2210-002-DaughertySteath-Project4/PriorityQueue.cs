//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 4 - Registration Simulation
//	File Name:		PriorityQueue.cs
//	Description:	The priority queue class to manage enter and exit events
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
    /// The interface for the priority queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPriorityQueue<T> : IContainer<T>
        where T : IComparable
    {
        void Enqueue(T item);
        void Dequeue();
        T Peek();

    }

    /// <summary>
    /// The interface for object containers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T>
    {
        //remove all objects from the container
        void Clear();
        //returns true if container is empty
        bool IsEmpty();
        //returns the number of entries in the container
        int Count { get; set; }
    }

    /// <summary>
    /// Priority Queue for line enter and exit events
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQue<T> : IPriorityQueue<T>
        where T : IComparable
    {
        private Node top;
        public int Count { get; set; }

        /// <summary>
        /// Removes all objects from container
        /// </summary>
        public void Clear()
        {
            top = null;
        }


        /// <summary>
        /// Determines if the container is empty
        /// </summary>
        /// <returns>True: if empty. False: if not empty</returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }

        /// <summary>
        /// removes the next item in the queue
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty queue");
            }
            else
            {
                Node oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null;
            }
        }//Dequeue

        /// <summary>
        /// Insert items by priority
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                top = new Node(item, null);
            }
            else
            {
                Node current = top;
                Node previous = null;

                while (current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node newNode = new Node(item, current);

                if (previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }
            }//else
            Count++;
        }

        /// <summary>
        /// Looks at the next item in the queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return top.Item;
            }
            else
                throw new InvalidOperationException("Cannot obtain top of empty queue");
        }

        /// <summary>
        /// The nodes to use in this priority queue
        /// </summary>
        private class Node
        {
            //after implementing new constructor
            private T item;
            private object p;

            //current code
            public T Item { get; set; }
            public Node Next { get; set; }

            /// <summary>
            /// Node Constructor
            /// </summary>
            /// <param name="value">the value of the node</param>
            /// <param name="link">the node to link to</param>
            public Node(T value, Node link)
            {
                Item = value;
                Next = link;
            }

            /// <summary>
            /// Node Constructor
            /// </summary>
            /// <param name="item">The T item</param>
            /// <param name="p">the object</param>
            public Node(T item, object p)
            {
                this.item = item;
                this.p = p;
            }
        }//Node
    }//PriorityQue
}
