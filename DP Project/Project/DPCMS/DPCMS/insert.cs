using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class insert : Action
    {
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();


       

        public void proceed(int id)
        {
            throw new NotImplementedException();
        }

        public void proceed(string fname, string lname, string phone)
        {
            connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

            connection.connect_open();

            string insert = "INSERT INTO c_user values ('" + fname + "','" + lname + "','" + phone + "')";
            SqlCommand com = new SqlCommand(insert, connection.con);
            com.ExecuteNonQuery();

            connection.connect_close();
        }


        public void proceed(int id, string fname, string lname, string phone)
        {
            throw new NotImplementedException();
        }
    }
}
