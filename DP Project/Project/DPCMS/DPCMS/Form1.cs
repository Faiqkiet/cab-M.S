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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");
            connection.connect_open();
        }

        //APPLYING SINGLETON PATTERNED (Creational pattern) BASED CONNECTION CLASS

        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
     

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //APPLYING FACTORY PATTERN  (Creational pattern) TO GENERATE USERS ,STAFF OR CABI

            String sql = "select * from c_login where username='" + textBox1.Text + "' and pword = '" + textBox2.Text + "'";

             
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, connection.con);


                    SqlDataReader dr = cmd.ExecuteReader();

                    LoginFactory lf = new LoginFactory();


                    if (dr.Read())
                    {
                        //string j_i = dr["job_id"].ToString();
                        int id = Convert.ToInt16(dr["login_id"]);
                        string designation = dr["designation"].ToString();
                        if (designation == "User")
                        {
                            login l1 = lf.getLogin(designation);
                            l1.openform();
                            connection.con.Close();
                            this.Hide();

                        }
                        else if (designation == "Staff")
                        {
                            login l1 = lf.getLogin(designation);
                            l1.openform();
                            connection.con.Close();
                            this.Hide();

                        }
                        else if (designation == "Cabi")
                        {
                            login l1 = lf.getLogin(designation);
                            l1.openform();
                            connection.con.Close();
                            this.Hide();

                        }
                        

                        // dr.Close();

                        connection.connect_close();
                    }
                    else
                    {
                        MessageBox.Show("YOU USENAME OR PASSWORD IS INCORRECT");
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
