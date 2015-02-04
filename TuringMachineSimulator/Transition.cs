using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class Transition
    {
        public enum Move { Left, Right, Stay };

        public Move direction;
        private State initialState, finalState;
        private string initialSymbol, finalSymbol;


        public Transition(State inState, string inSymbol, string finSymbol, Move direction, State finState)
        {
            this.initialState = inState;
            this.finalState = finState;
            this.initialSymbol = inSymbol;
            this.finalSymbol = finSymbol;
            this.direction = direction;
        }


        public string GetWrite() { return this.finalSymbol; }


        public State GetNextState() { return this.finalState; }
    }
}
