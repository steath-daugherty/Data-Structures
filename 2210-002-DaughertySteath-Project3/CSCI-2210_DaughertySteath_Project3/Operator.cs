//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Project 3 - Infix To Postfix Conversion
//	File Name:		Operator.cs
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
using System.Threading.Tasks;

namespace CSCI_2210_DaughertySteath_Project3
{
    /// <summary>
    /// The Operator class finds the operators in the equation and assigns a precedence value
    /// </summary>
    class Operator
    {
        public string Op { get; private set; }
        public int Precedence { get; private set; }



        /// <summary>
        /// Default empty constructor
        /// </summary>
        public Operator() { }



        /// <summary>
        /// Constructor that sets the operator
        /// </summary>
        /// <param name="Op"></param>
        public Operator(string Op)
        {
            this.Op = Op;
        }



        /// <summary>
        /// Finds the current and next operator, and assigns a precedence value to each
        /// the higher the number, the greater the precedence (e.g. * has precedence over +)
        /// </summary>
        /// <param name="lhs">the first operator</param>
        /// <param name="rhs">the second operator</param>
        /// <returns></returns>
        public bool Operators(char lhs, char rhs)
        {
            string operators = "=(+-*/%";

            int positionOne, positionTwo;

            int[] operatorPrecedence = { 0, 0, 12, 12, 13, 13, 13 };

            positionOne = operators.IndexOf(lhs);
            positionTwo = operators.IndexOf(rhs);

            return (operatorPrecedence[positionOne] >= operatorPrecedence[positionTwo]) ? true : false;
        }
    }
}
