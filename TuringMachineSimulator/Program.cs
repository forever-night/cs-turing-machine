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


            Console.WriteLine(
                "1. replace 1s with 0s in a string and vice versa\n" +
                "2. concatenate 2 strings of symbols x, y,z\n" +
                "3. reverse a string of 0s and 1s\n" +
                "\nenter number of chosen TM:"
                );

            option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("enter input\nuse only 0s and 1s");
                    input = Console.ReadLine();
                    tm = p.ReplacingTM(input);
                    break;
                case 2:
                    Console.WriteLine("enter input\nuse only x, y and z, separate strings with '_'");
                    input = Console.ReadLine();
                    tm = p.ConcatenatingTM(input);
                    break;
                case 3:
                    Console.WriteLine("enter input\nuse only 0s and 1s");
                    input = Console.ReadLine();
                    tm = p.ReversingTM(input);
                    break;
            }

            tm.TurnOn();
            
            Console.WriteLine("finished");
            Console.Read();            
        }


        public TuringMachine ReplacingTM(string input)
        {
            TuringMachine tm = new TuringMachine(input);

            tm.control.AddTransition("start", "_", "*", "r", "q0");
            tm.control.AddTransition("q0", "0", "1", "r", "q0");
            tm.control.AddTransition("q0", "1", "0", "r", "q0");
            tm.control.AddTransition("q0", "_", "*", "*", "accept");

            return tm;
        }


        public TuringMachine ConcatenatingTM(string input)
        {
            TuringMachine tm = new TuringMachine(input);

            tm.control.AddTransition("start", "_", "*", "r", "q0");
            tm.control.AddTransition("q0", "_", "#", "r", "q1");
            tm.control.AddTransition("q0", "*", "*", "r", "q0");
            tm.control.AddTransition("q1", "_", "*", "*", "q4");
            tm.control.AddTransition("q1", "x", "0", "l", "q2x");
            tm.control.AddTransition("q1", "y", "1", "l", "q2y");
            tm.control.AddTransition("q1", "z", "2", "l", "q2z");
            tm.control.AddTransition("q2x", "#", "x", "r", "q3");
            tm.control.AddTransition("q2x", "*", "*", "l", "q2x");
            tm.control.AddTransition("q2y", "#", "y", "r", "q3");
            tm.control.AddTransition("q2y", "*", "*", "l", "q2y");
            tm.control.AddTransition("q2z", "#", "z", "r", "q3");
            tm.control.AddTransition("q2z", "*", "*", "l", "q2z");
            tm.control.AddTransition("q3", "*", "#", "r", "q1");
            tm.control.AddTransition("q4", "*", "*", "l", "q4");
            tm.control.AddTransition("q4", "#", "_", "*", "accept");

            return tm;
        }


        public TuringMachine ReversingTM(string input)
        {
            TuringMachine tm = new TuringMachine(input);

            tm.control.AddTransition("start", "_", "*", "r", "q0");
            tm.control.AddTransition("q0", "*", "*", "r", "q0");
            tm.control.AddTransition("q0", "_", "#", "l", "q1");
            tm.control.AddTransition("q1", "0", "#", "r", "q2x");
            tm.control.AddTransition("q1", "1", "#", "r", "q2y");
            tm.control.AddTransition("q1", "#", "*", "l", "q1");
            tm.control.AddTransition("q1", "_", "*", "*", "accept");
            tm.control.AddTransition("q2x", "_", "0", "l", "q3");
            tm.control.AddTransition("q2y", "_", "1", "l", "q3");
            tm.control.AddTransition("q2x", "*", "*", "r", "q2x");
            tm.control.AddTransition("q2y", "*", "*", "r", "q2y");
            tm.control.AddTransition("q3", "*", "*", "l", "q3");
            tm.control.AddTransition("q3", "#", "*", "l", "q1");

            return tm;
        }
    }
}
