using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class ActionMaker
    {

        private Action insert;
        private Action update;
        private Action delete;

        public ActionMaker()
        {
            insert = new insert(); update = new update(); delete = new delete();
        }

        public void Insert(string fname , string lname , string phone)
        {
            insert.proceed(fname, lname, phone);
        
        }
        public void Delete(int id)
        {
            delete.proceed(id);

        }
        public void Update(int id , string fname, string lname, string phone)
        { 
            update.proceed(id,fname, lname, phone);

        }


    }
}
