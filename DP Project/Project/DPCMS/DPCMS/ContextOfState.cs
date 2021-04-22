using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class ContextOfState
    {
        private  State state;
        private int OriginalState;
        public ContextOfState(){
        state=null;
        }

        public void setState(State state)
        {
            this.state = state; this.state.doAction();

        }

        public State getState()
        {
            return state;
        }
    }
}
