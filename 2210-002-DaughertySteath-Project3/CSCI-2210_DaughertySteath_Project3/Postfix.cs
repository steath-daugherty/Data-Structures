//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 3 - Infix To Postfix Conversion
//	File Name:		Postfix.cs
//	Description:	This class retrieves the infix expression from the InfixToPostfix.cs Form and converts it to its Postfix equivalent
//	Course:			CSCI 2210-002 - Data Structures
//	Author:			Steath Daugherty, daughertyb@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		Sunday, October 29, 2017
//	Copyright:	    Steath Daugherty, 2017
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCI_2210_DaughertySteath_Project3
{
    /// <summary>
    /// The Postfix class to set and retrieve the infix expression, convert it, and
    /// return the Postfix result.
    /// </summary>
    class Postfix
    {
        public string InfixExpression { get;  set; }
        public string PostfixExpression { get; private set; }
        Operator Op = new Operator();

        /// <summary>
        /// Default empty constructor
        /// </summary>
        public Postfix()
        {
        }

        /// <summary>
        /// Constructor to set the Infix Expression.
        /// </summary>
        /// <param name="input"></param>
        public Postfix(string input)
        {
            this.InfixExpression = input;
        }

        /// <summary>
        /// This method takes the Infix Expression and Converts it to the 
        /// Postfix Expression.
        /// </summary>
        /// <returns>The Postfix Expression</returns>
        public string Convert()
        {
            StringBuilder postFix = new StringBuilder();
            Stack<char> equationOperator = new Stack<char>(); //stack of operators
            char arrival; //The beginning Character of the Infix Expression
            
            //loop through each character in the Infix Expression
            foreach (char c in InfixExpression.ToCharArray())
            {
                //if the current character is a number or letter, keep appending
                //if it is a '(', push it to the stack
                //if it is a ')' keep popping characters from the stack until it reaches its accompanying (
                if (Char.IsNumber(c) || Char.IsLetter(c) || Char.IsWhiteSpace(c))
                    postFix.Append(c);
                else if (c == '(')
                    equationOperator.Push(c);
                else if (c == ')')
                {
                    arrival = equationOperator.Pop();
                    while (arrival != '(')
                    {
                        postFix.Append(arrival);
                        arrival = equationOperator.Pop();
                    }//while
                }//else if
                else
                {
                    //Create the Postfix equation
                    if (equationOperator.Count != 0 && Op.Operators(equationOperator.Peek(), c))
                    {
                        arrival = equationOperator.Pop();
                        while (Op.Operators(arrival, c))
                        {
                            postFix.Append(arrival);

                            if (equationOperator.Count == 0)
                                break;

                            arrival = equationOperator.Pop();
                        }//while
                        equationOperator.Push(c);
                    }//if
                    else
                    {
                        equationOperator.Push(c);
                    }//else
                }//else
            }//foreach
            while (equationOperator.Count > 0)
            {
                arrival = equationOperator.Pop();
                postFix.Append(arrival);
            }
            return postFix.ToString();
        }//Convert
    }//Postfix
}
