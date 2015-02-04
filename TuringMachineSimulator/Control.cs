using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class Control
    {
        private Dictionary<string, State> states;
        private Dictionary<string, Transition> transitions;
        private State currentState;


        public Control()
        {
            this.states = new Dictionary<string, State>();
            this.transitions = new Dictionary<string, Transition>();

            // configure three basic states
            // halt and accept states are to be created and added explicitly
            this.AddState(new State("start"));
            this.AddState(new State("accept", "A"));
            this.AddState(new State("halt", "H"));

            this.SetState(FindState("start"));
        }


        public State GetState() { return currentState; }


        public void SetState(State newState) { this.currentState = newState; }
        
        
        public void AddState(State state) { states.Add(state.GetName(), state); }


        public void AddTransition(
            string inStateName, string inSymbol, string finSymbol, string dir, string finStateName)
        {
            Transition t;
            Transition.Move direction;

            State inState = FindState(inStateName);
            State finState = FindState(finStateName);


			//if (inState == null)
			//	Console.WriteLine("initial state not found: {0}", inStateName);

            if (finState == null)
            {
                AddState(new State(finStateName));
                finState = FindState(finStateName);
            }


            if (dir.Equals("l", StringComparison.OrdinalIgnoreCase))
                direction = Transition.Move.Left;
            else if (dir.Equals("r", StringComparison.OrdinalIgnoreCase))
                direction = Transition.Move.Right;
            else
                direction = Transition.Move.Stay;


            t = new Transition(inState, inSymbol, finSymbol, direction, finState);

            transitions.Add((inState.GetName() + inSymbol), t);
        }


        public Transition FindTransition(State initState, string initSymbol)
        {
            Transition t;

            bool exists = transitions.TryGetValue((initState.GetName() + initSymbol), out t);
            
            // check for transitions with inputSymbol '*'
            if (!exists)
                exists = transitions.TryGetValue((initState.GetName() + "*"), out t);

            if (t == null)
                Console.WriteLine("instruction not found: {0}", initState.GetName() + initSymbol);
            
            return t;
        }

                        
        public State FindState(string stateName)
        {
            State state;
            bool exists = states.TryGetValue(stateName, out state);

            if (!exists)
                Console.WriteLine("state not found: {0}", stateName);
            
            return state;
        }        
    }
}
