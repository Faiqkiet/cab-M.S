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
    public partial class Manager : Form ,DecisionAPI
    {
        public Manager()
        {
            InitializeComponent();
            setDGV();
        }

        DPCMS_CONNECTION connection = DPCMS_CONNECTION.getinst();
        string fname, lname, phone;

        int id;

        public void setDGV()
        {
            connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

            connection.connect_open();
            SqlDataAdapter da = new SqlDataAdapter(" select * from c_manager name", connection.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "c_manager ");
            dataGridView1.DataSource = ds.Tables[0];
            ds.Tables.Clear();
            connection.connect_close();

        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }

        public void getworker()
        {
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                id = Convert.ToInt16(row.Cells["c_manager_id"].Value);
                fname = row.Cells["f_name"].Value.ToString();
                lname = row.Cells["l_name"].Value.ToString();
                phone = row.Cells["salary"].Value.ToString();

                textBox6.Text = row.Cells["f_name"].Value.ToString();
                textBox5.Text = row.Cells["l_name"].Value.ToString();
                textBox4.Text = row.Cells["salary"].Value.ToString();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

                connection.connect_open();

                string insert = "INSERT INTO c_manager values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                SqlCommand com = new SqlCommand(insert, connection.con);
                com.ExecuteNonQuery();

                connection.connect_close();

                setDGV();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

                connection.connect_open();
                string update = "update c_manager set f_name ='" + textBox6.Text + "' ,l_name ='" + textBox5.Text + "',salary ='" + textBox4.Text + "'   where c_manager_id = " + id + "";
                SqlCommand com = new SqlCommand(update, connection.con);
                com.ExecuteNonQuery();

                connection.connect_close();
                setDGV();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.insert_Connection_string("Data Source=INTEL\\SQLEXPRESS;Initial Catalog=DPCMS;Integrated Security=True");

                connection.connect_open();

                string delete = "delete c_manager where c_manager_id=" + id + "";
                SqlCommand com = new SqlCommand(delete, connection.con);
                com.ExecuteNonQuery();

                connection.connect_close();

                setDGV();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
