using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class Employ:Worker
    {
        public Employ(DecisionAPI decisionAPI) : base(decisionAPI) { }

        public override void open()
        {
            designAPI.getworker();
        }
    }
}
