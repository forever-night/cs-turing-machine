using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class TuringMachine
    {
        public Tape tape;
        public Control control;
        public State currentState;

        public string currentSymbol;
        public int steps;


        public TuringMachine(string input)
        {
            this.tape = new Tape("_" + input);
            this.control = new Control();
            this.currentState = control.GetState();
        }


        public void TurnOn()
        {
            this.currentState = control.GetState();
            Transition t;

            while (!currentState.IsHalt)
            {
                this.currentSymbol = tape.Read();
                t = control.FindTransition(currentState, currentSymbol);

                if (t == null)
                {
                    this.control.SetState(this.control.FindState("halt"));
                    break;
                }

                DoTransition(t);
                steps++;
                tape.PrintTape();

                this.currentState = control.GetState();

                if (currentState.IsHalt)
                    break;
            }


            Console.WriteLine("steps: {0}", steps);

            if (currentState.IsHalt)
                Console.WriteLine("halt");
            if (currentState.IsAccept)
                Console.WriteLine("accept");
        }


        private void DoTransition(Transition t)
        {
            this.tape.Write(t.GetWrite());
            this.control.SetState(t.GetNextState());

            if (t.direction == Transition.Move.Left)
                tape.MoveLeft();
            else if (t.direction == Transition.Move.Right)
                tape.MoveRight();
        }
    }
}
