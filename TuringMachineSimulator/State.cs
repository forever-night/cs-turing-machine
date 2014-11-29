using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
    class State
    {
        private string name;

        private bool isHalt;
        private bool isAccept;


        public State(string name)
        {
            this.name = name;
        }


        /// <summary>
        /// State constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type">used only for halt/accept states</param>
        public State(string name, string type)
        {
            this.name = name;
            
            if (type.Equals("H", StringComparison.OrdinalIgnoreCase))
                this.IsHalt = true;
            else if (type.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                this.IsHalt = true;
                this.IsAccept = true;
            }
        }


        public string GetName()
        {
            return name;
        }


        public bool IsHalt
        {
            get { return isHalt; }
            set { isHalt = value; }
        }


        public bool IsAccept
        {
            get { return isAccept; }
            set { isAccept = value; }
        }
    }
}
