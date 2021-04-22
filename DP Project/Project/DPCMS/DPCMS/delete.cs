using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class delete:Action
    {

        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();


       

        public void proceed(int id)
        {
            connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

            connection.connect_open();

            string delete = "delete c_user where c_user_id=" + id + "";
            SqlCommand com = new SqlCommand(delete, connection.con);
            com.ExecuteNonQuery();

            connection.connect_close();
        }


        public void proceed(string fname, string lname, string phone)
        {
            throw new NotImplementedException();
        }


        public void proceed(int id, string fname, string lname, string phone)
        {
            throw new NotImplementedException();
        }
    }
}
