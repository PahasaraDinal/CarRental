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

namespace Aybo_drive_assignment
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");

        String ID;
        String i;


        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CustomerReg values (@CID,@CName,@DOB,@Gender,@ConNo,@NIC,@Email,@CAdd)", con);
            cmd.Parameters.AddWithValue("@CID", int.Parse(cmbzCid.Text));
            cmd.Parameters.AddWithValue("@CName", (Text2.Text));
            cmd.Parameters.AddWithValue("@DOB", (Text3.Text));
            cmd.Parameters.AddWithValue("@Gender", (Text5.Text));
            cmd.Parameters.AddWithValue("@ConNo", int.Parse(Text4.Text));
            cmd.Parameters.AddWithValue("@NIC", (Text6.Text));
            cmd.Parameters.AddWithValue("@Email", (Text7.Text));
            cmd.Parameters.AddWithValue("@CAdd", (text8.Text));


            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Save COMPLETE");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update CustomerReg set CName=@CName,DOB=@DOB,Gender=@Gender,ConNo=@ConNo,NIC=@NIC,Email=@Email,CAdd=@CAdd where CID = @CID", con);
            cmd.Parameters.AddWithValue("@CID", int.Parse(cmbzCid.Text));
            cmd.Parameters.AddWithValue("@CName", (Text2.Text));
            cmd.Parameters.AddWithValue("@DOB", (Text3.Text));
            cmd.Parameters.AddWithValue("@Gender", (Text5.Text));
            cmd.Parameters.AddWithValue("@ConNo", int.Parse(Text4.Text));
            cmd.Parameters.AddWithValue("@NIC", (Text6.Text));
            cmd.Parameters.AddWithValue("@Email", (Text7.Text));
            cmd.Parameters.AddWithValue("@CAdd", (text8.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete CustomerReg where CID=@CID", con);
            cmd.Parameters.AddWithValue("@CID", (cmbzCid.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Customer deleted");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            f5 = null;
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmbzCid.Text = "";
            Text2.Text = "";
            Text3.Text = "";
            Text4.Text = "";
            Text5.Text = "";
            Text6.Text = "";
            Text7.Text = "";
            text8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            {





            }


        }
    }
}
        

