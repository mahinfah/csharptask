using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace task
{
    public partial class Form1 : Form
    {
        private object id;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  

              
            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

           


            //id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();



        }

        

        public void Show()
        {
            //   string connectionString = @"Data Source=MAHIN;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";

           string connectionString = @"Data Source=MAHIN;Initial Catalog=testing_db;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string q = "select *from Table_4";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt= ds.Tables[0];
           // adp.Fill(ds);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;





        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void btn1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Clear()
       {
 txt_id.Text = ""; 

                 txt_name.Text = "";
          
           
            // comboBox1.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //clear
            string connectionString = @"Data Source=MAHIN;Initial Catalog=testing_db;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string Q = "DELETE FROM Table_4 WHERE id="+txt_id.Text;
            SqlCommand cmd= new SqlCommand(Q, conn);
            cmd.ExecuteNonQuery();
            Show();
            Clear();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            
            string connectionString = @"Data Source=MAHIN;Initial Catalog=testing_db;Integrated Security=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string q = "UPDATE Table_4 SET name='"+ txt_name.Text + "'WHERE id=" + txt_id.Text ;
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            Show();
            Clear();
            
           /*tring connectionString = @"Data Source=MAHIN;Initial Catalog=testing_db;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "UPDATE Table_4 SET NAME = @name WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                    cmd.Parameters.AddWithValue("@id", txt_id.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            Show();
            Clear();
           */

        }
    }
}
