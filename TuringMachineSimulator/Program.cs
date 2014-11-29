using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            string input;            

            TuringMachine tm = new TuringMachine("");
            Program p = new Program();


            Console.WriteLine("1. replace 1 with 0 and vice versa\n2.\n3.\n\nenter number of chosen TM:");

            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("enter input");
                    input = Console.ReadLine();
                    tm = p.ReplacingTM(input);
                    break;
            }

            tm.TurnOn();
            
            Console.WriteLine("finished");
            Console.Read();            
        }


        public TuringMachine ReplacingTM(string input)
        {
            TuringMachine tm = new TuringMachine(input);

            // replaces 1 with 0 and 0 with 1
            tm.control.AddTransition("start", "*", "*", "*", "q0");
            tm.control.AddTransition("q0", "0", "1", "r", "q0");
            tm.control.AddTransition("q0", "1", "0", "r", "q0");
            tm.control.AddTransition("q0", "_", "*", "*", "accept");

            return tm;
        }
    }
}
