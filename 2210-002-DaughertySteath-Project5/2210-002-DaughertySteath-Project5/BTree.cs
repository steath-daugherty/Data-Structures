//////////////////////////////////////////////////////////////////////////////////////////
//	Project:		Project 5 - BTrees
//	File Name:		BTree.cs
//	Description:	The Driver for the BTree Project
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu
//	Created:		Saturday, November 26, 2017
//	Copyright:		Steath Daugherty, 2017
//////////////////////////////////////////////////////////////////////////////////////////

using Project5_BTree;
using System;
using System.Collections.Generic;

namespace Projcet5_BTree
{
    /// <summary>
    /// The model for the BTree
    /// </summary>
    class BTree
    {
        public int Count { get; set; }
        public int IndexCount { get; set; }
        public int LeafCount { get; set; }
        public int NodeSize { get; set; }
        public Node Root { get; set; }
        private Stack<Node> stack { get; set; }
        public bool Trace { get; set; }

        /// <summary>
        /// Primary BTree constructor
        /// </summary>
        /// <param name="n"></param>
        public BTree(int n)
        {
            IndexCount = 0;
            Count = 0;
            NodeSize = n;
            Root = new Index(NodeSize);
            stack = new Stack<Node>();
            int num = (int)((Index)Root).Insert(0, new Leaf(NodeSize));
        }





        /// <summary>
        /// Sorts the BTree
        /// </summary>
        /// <param name="ints">the list of values to sort</param>
        /// <param name="thisNode">the current node</param>
        private void Sort(List<int> ints, List<Node> thisNode)
        {
            bool finished = false;
            int n = 0;

            while (!finished)
            {
                for (int i=0; i < ints.Count - n; i++)
                {
                    if (ints[i] > ints[i + 1])
                    {
                        //swap values
                        int j = ints[i];
                        ints[i] = ints[i + 1];
                        ints[i + 1] = j;

                        //swap nodes
                        Node node = thisNode[i];
                        thisNode[i] = thisNode[i + 1];
                        thisNode[i + 1] = node;

                        //reset flag to false to continue loop
                        finished = false;
                    }
                    n++;
                }
                finished = true;
            }
        }

        /// <summary>
        /// Attempts to add a value to the BTree
        /// if the node it is to be added to is full, split it; otherwise add it.
        /// if it's a duplicate value, return false.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>true if the value was added; false if duplicate value found</returns>
        public bool AddValue(int n)
        {
            //find the leaf to insert the value into and get the INSERT value
            Leaf leaf = FindLeaf(n);
            INSERT insert = leaf.Insert(n);
            Count++;

            //if the insert was successful
            if (insert == INSERT.SUCCESS)
            {
                //pop the current index from the stack and get the next one
                stack.Pop();
                Index nextIndex = (Index)stack.Peek();

                for (int i = 0; i < nextIndex.Indexes.Count; i++)
                {
                    if (nextIndex.Indexes[i] == leaf)
                        nextIndex.Value[i] = leaf.Value[0];
                }
                return true;
            }
            //if it's a duplicate value, don't add it
            if (insert == INSERT.DUPLICATE)
                return false;
            //otherwise, it needs to be split
            if (insert == INSERT.NEEDSPLIT)
                SplitLeaf(leaf, n);
            return true;
        }

        /// <summary>
        /// Method to display the BTree and statistics of the BTree
        /// </summary>
        public void Display()
        {
            int width = Console.WindowWidth;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Root node:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            RecursiveDisplay(Root, 0);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n");
            for (int i = 0; i < width; i++)
                Console.Write("-");
            Console.WriteLine("\nStats:");
            Console.WriteLine(Stats());
            for (int i = 0; i < width; i++)
                Console.Write("-");
        }

        /// <summary>
        /// The recursive display method to print all nodes, leaves, and values
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeLevel"></param>
        public void RecursiveDisplay(Node node, int nodeLevel)
        {
            //if the node is null, escape recursive display
            if (node == null)
                return;

            //print leaves in green text
            if (node is Leaf)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(node);

            //print index nodes in Cyan colored text
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (!(node is Index))
            {
                LeafCount++;
            }
            else
            {
                nodeLevel++; //increment the nodeLevel to start at 1 instead of 0
                IndexCount++;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Level of Index: {0}\n", nodeLevel);
                Console.WriteLine(node);
                Console.ForegroundColor = ConsoleColor.Cyan;

                for (int i = 0; i < ((Index)node).Indexes.Count; i++)
                {
                    if (((Index)node).Indexes[i] != null)
                        RecursiveDisplay(((Index)node).Indexes[i], nodeLevel);
                }
            }
        }

        /// <summary>
        /// Finds the depth of the BTree from the Root to the furthest leaf
        /// </summary>
        /// <returns></returns>
        private int FindDepth()
        {
            //start from the root node
            Node node = Root;
            int n = 0;
            //count to the deepest Index node
            while (node is Index)
            {
                node = ((Index)node).Indexes[0];
                n++;
            }
            return n;
        }

        /// <summary>
        /// searches for the user specified value in the BTree
        /// </summary>
        /// <param name="n"></param>
        /// <returns>the value</returns>
        public bool FindValue(int n)
        {
            Trace = true;
            int num = FindLeaf(n).Value.IndexOf(n);
            if (num != 0)
                Trace = true;
            else
                Trace = false;
            return Trace;
        }


        /// <summary>
        /// Method to find a leaf containing the integer value 'n'
        /// </summary>
        /// <param name="n">the value to search</param>
        /// <returns>the leaf containing the value</returns>
        public Leaf FindLeaf(int n)
        {
            //remove all objects from the stack
            stack.Clear();

            int j;
            Index index=null;
            Node node = Root;

            for (; node is Index; node = index.Indexes[j - 1])
            {
                if (Trace != false)
                    Console.WriteLine(node);
                index = (Index)node;
                j = 1;

                //add the current node to the stack
                stack.Push(node);
                while (j < index.Value.Count && n >= index.Value[j])
                    j++;
            }
            stack.Push(node);

            //if trace = true, print the node
            if (Trace)
                Console.WriteLine(node);
            return (Leaf)node;
        }

        /// <summary>
        /// Takes a leaf that needs to be split, splits it.
        /// Determines if the next node needs to be split.
        /// </summary>
        /// <param name="leaf"></param>
        /// <param name="n"></param>
        public void SplitLeaf(Leaf leaf, int n)
        {
            Leaf newLeaf = new Leaf(NodeSize);
            List<int> intList = new List<int>(leaf.Value);

            //clear the current leaf values
            leaf.Value.Clear();
            //add the value to the list of integers and sort it
            intList.Add(n);
            intList.Sort();

            //reinsert the sorted values into the leaves
            for (int i = 0; i <= NodeSize / 2; i++)
                leaf.Value.Add(intList[i]);
            for (int i = (NodeSize + 1) / 2; i <= NodeSize; i++)
                newLeaf.Value.Add(intList[i]);


            //Pop the top of the stack; determine if the next node needs to be split
            stack.Pop();
            Index nodeToBeSplit = (Index)stack.Peek();

            if (nodeToBeSplit.Insert(newLeaf.Value[0], newLeaf) == INSERT.NEEDSPLIT)
                SplitIndex(nodeToBeSplit, newLeaf, newLeaf.Value[0]);
            else
                return;
        }

        /// <summary>
        /// Splits the index. If index is root, create a new root.
        /// </summary>
        /// <param name="nodeToSplit">the node to be split</param>
        /// <param name="nodeToAdd">the node to add</param>
        /// <param name="valueToAdd">the value to add</param>
        public void SplitIndex(Index nodeToSplit, Node nodeToAdd, int valueToAdd)
        {
            List<int> intList = new List<int>();
            List<Node> nodeList = new List<Node>();
            Index idx = new Index(NodeSize);


            //put the values to add in appropriate lists
            intList.Add(valueToAdd);
            nodeList.Add(nodeToAdd);

            //get the values from the node to be split and store them in their respective lists
            for (int i = 0; i < NodeSize; i++)
            {
                intList.Add(nodeToSplit.Value[i]);
                nodeList.Add(nodeToSplit.Indexes[i]);
            }

            //clear the current node values
            nodeToSplit.Value.Clear();
            nodeToSplit.Indexes.Clear();

            //sort the lists
            Sort(intList, nodeList);
            //add the sorted values back to the node
            for (int i = 0; i <= NodeSize / 2; i++)
            {
                nodeToSplit.Indexes.Add(nodeList[i]);
                nodeToSplit.Value.Add(intList[i]);
            }

            for (int i = (NodeSize + 1) / 2; i <= NodeSize; i++)
            {
                idx.Indexes.Add(nodeList[i]);
                idx.Value.Add(intList[i]);
            }
            //if the root needs to be split
            if (Root == nodeToSplit)
            {
                //create a new root node
                Root = new Index(NodeSize);
                int n = (int)((Index)Root).Insert(nodeToSplit.Value[0], nodeToSplit);
                int j = (int)((Index)Root).Insert(idx.Value[0], idx);
            }
            //if the root does not need to be split, check the next node
            else
            {
                //pop the current node from the stack, and check the next
                stack.Pop();
                Index nextNode = (Index)stack.Peek();

                //if the next node needs to be split, split it.
                if (nextNode.Insert(idx.Value[0], idx) == INSERT.NEEDSPLIT)
                    SplitIndex(nextNode, idx, idx.Value[0]);
                
                //otherwise, it does not need to be split.
                return; 
            }
        }

        /// <summary>
        /// Returns some basic statistics of the current BTree
        /// </summary>
        /// <returns>String of BTree statistics</returns>
        private string Stats()
        {
            double leafPCT = Count * 100.00 / (LeafCount * NodeSize);
            string str = "Total Index nodes: " + IndexCount;
            str += "\nTotal Leaf nodes: " + LeafCount;
            str += "\nNodes average: " + leafPCT.ToString("0.##") + "% full";
            str += "\nDepth of the tree: " + FindDepth();
            str += "\nThe total number of values in the tree is " + Count;

            return str;
        }
    }
}

