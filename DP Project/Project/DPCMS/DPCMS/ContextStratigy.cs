using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class ContextStratigy
    {
        CabiBehaviour stratigy;

        public ContextStratigy(CabiBehaviour stratigy)
        {
            this.stratigy = stratigy;  
        }

        public int execute_stratigy()
        {
            return stratigy.doBehave();
        }
    }

}
