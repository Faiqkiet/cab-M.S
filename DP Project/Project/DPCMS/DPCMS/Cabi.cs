using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPCMS
{
    public partial class Cabi : Form, login
    {
        public Cabi()
        {
            InitializeComponent();
            button3.Enabled = false;
        }

        int user_id;
        string username;

        //Applying State Pattern (Behaverial Pattern)


        ContextOfState Context = new ContextOfState();
        StartState startstate = new StartState();
        StopState stopstate = new StopState();




        private void Cabi_Load(object sender, EventArgs e)
        {

        }
        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();



        public void setDGV()
        {
            connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

            connection.connect_open();
            SqlDataAdapter da = new SqlDataAdapter(" select * from c_user name", connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users ");
            dataGridView1.DataSource = ds.Tables[0];
            ds.Tables.Clear();
            connection.connect_close();

        }

        public void openform()
        {
            this.Show();
        }

        public void getUserInfo()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Turn on Cabi Mode")
            {
                Context.setState(startstate);
                State a = Context.getState();

                if (a.getState() == 1)
                { 
                    label2.Text = "Online";
                button1.Text = "Turn off Cabi Mode";
                button2.Text = "Check Rides Requests";
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                }
                
                
            }
            else
            {
                Context.setState(stopstate);
                State a = Context.getState();

                if (a.getState() == 0)
                { label2.Text = "Offline";
                button1.Text = "Turn on Cabi Mode";
                button2.Text = "Peek Passengers Traffic";
                button3.Enabled = false;
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
               
                }

              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //APPLYING STRATIGY PATTERN (BEHVAROL PATTERN)


            if (label2.Text == "Online")
            {
                ContextStratigy cs = new ContextStratigy(new Online());
                int status_checker = cs.execute_stratigy();
                setDGV();
                if (status_checker == 1)
                { 
                button3.Enabled = true;
                }
            }
            else if (label2.Text == "Offline")
            {
                ContextStratigy cs = new ContextStratigy(new Offline());
                int status_checker = cs.execute_stratigy();
                setDGV();
                if (status_checker == 0)
                {
                    button3.Enabled = false;
                }
            }
            else
            { 
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YOUR RIDE IS AWAY");
        }
    }
}
