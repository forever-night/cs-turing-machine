using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class Tape
    {
        public Stack<string> lhs;
        public Stack<string> rhs;

        public string inputSymbol;


        public Tape(string input)
        {
            this.lhs = new Stack<string>();
            this.rhs = new Stack<string>();

            if (input.Length > 1)
            {
                char[] inputChar = input.ToCharArray();

                for (int i = (inputChar.Length - 1); i >= 0; i--)
                    rhs.Push(inputChar[i].ToString());
            }
            else
                rhs.Push(input);

            // set start symbol
            inputSymbol = rhs.Pop();
        }


        public void MoveLeft()
        {
            if (lhs.Count != 0)
            {
                rhs.Push(inputSymbol);
                inputSymbol = lhs.Pop();
            }
        }


        public void MoveRight()
        {
            if (rhs.Count == 0)
                rhs.Push("_");

            string nextSymbol = rhs.Pop();
            lhs.Push(inputSymbol);
            inputSymbol = nextSymbol;
        }


        public string Read()
        {
            return inputSymbol;
        }


        public void Write(string input)
        {
            // '*' doesn't write new symbol
            if (!input.Equals("*"))
                inputSymbol = input;
        }


        public void PrintTape()
        {
            string[] lhsArray = new string[lhs.Count];
            string[] rhsArray = new string[rhs.Count];

            lhs.CopyTo(lhsArray, 0);
            rhs.CopyTo(rhsArray, 0);

            Console.WriteLine("");

            if (lhsArray.Length > 0)
                for (int i = lhsArray.Length - 1; i >= 0; i--)
                    Console.Write(lhsArray[i]);

            Console.Write(" [{0}] ", inputSymbol);

            if (rhsArray.Length > 0)
                for (int i = 0; i < rhsArray.Length; i++)
                    Console.Write(rhsArray[i]);

            Console.WriteLine("");
        }
    }
}
