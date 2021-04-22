using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    public interface Action
    {
        void proceed(int id);

        void proceed(string fname, string lname, string phone);

        void proceed(int id, string fname, string lname, string phone);
    }
}
