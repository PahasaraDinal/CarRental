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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");

        String driver;
        String paid;
        String date;

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            f2 = null;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rtd = Int32.Parse(date);
            int m = rtd / 30;
            int r = rtd % 30;
            int w = r / 7;
            int r1 = r % 7;
            float rent = 20000 * m + 8000 * w + 4000 * r1;
            float driver = 0;
            float total = 0;

            if (rbwithdriver.Checked == true)
            {
                driver = (1000 * 10);
                total = rent + driver;

            }
            else
            {
                total = rent;
            }
            textfee.Text = rent.ToString();
            textdrivercost.Text = driver.ToString();
            texttotal.Text = total.ToString();
        }

        private void return1_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(Rent.Text);
            DateTime end = Convert.ToDateTime(return1.Text);
            if (start < end)
            {
                date = end.Subtract(start).Days.ToString();
                days.Text = date;
            }
            else if (start >= end)
            {
                MessageBox.Show("Invalid Date!");
            }
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
            days.Text = "";
            textfee.Text = "";
            textdrivercost.Text = "";
            texttotal.Text = "";
            rbwithdriver.Checked = false;
            checkBox2.Checked = false;
            textdrivercost.Text = "";
            texttotal.Text = "";
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox3.Text = "";
            textBox5.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rbwithdriver.Checked == true) { driver = "with driver"; }
            else if (checkBox2.Checked == true) { driver = "without driver"; }

            if (checkBox3.Checked == true) { paid = "paid"; }
            else if (checkBox4.Checked == true) { paid = "unpaid"; }

            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CarRent values (@rent_id,@CID,@Cus_name,@VehicalNo,@Vehical_type,@Driver_Status,@Rentdate,@ReturnDate,@N_O_D,@vehicalfee,@drivercost,@T_R_A,@Paidstatus)", con);
            cmd.Parameters.AddWithValue("@rent_id",(comboBox1.Text));
            cmd.Parameters.AddWithValue("@CID", int.Parse (comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cus_name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox3.Text));
            cmd.Parameters.AddWithValue("@Vehical_type", (textBox5.Text));
            cmd.Parameters.AddWithValue("@Driver_Status", (driver));
            cmd.Parameters.AddWithValue("@Rentdate", (Rent.Text));
            cmd.Parameters.AddWithValue("@ReturnDate", (return1.Text));
            cmd.Parameters.AddWithValue("@N_O_D", int.Parse (days.Text));
            cmd.Parameters.AddWithValue("@vehicalfee", int.Parse (textfee.Text));
            cmd.Parameters.AddWithValue("@drivercost", int.Parse (textdrivercost.Text));
            cmd.Parameters.AddWithValue("@T_R_A", int.Parse (texttotal.Text));
            cmd.Parameters.AddWithValue("@Paidstatus", (paid));


            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Save SuccessFull");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update CarRent set  CID=@CID,Cus_name=@Cus_name,VehicalNo=@VehicalNo,Vehical_type=@Vehical_type,Driver_Status=@Driver_Status,Rentdate=@Rentdate,ReturnDate=@ReturnDate,N_O_D=@N_O_D,vehicalfee=@vehicalfee,drivercost=@drivercost,T_R_A=@T_R_A,Paidstatus=@Paidstatus where rent_id = @rent_id", con);
            cmd.Parameters.AddWithValue("@rent_id", (comboBox1.Text));
            cmd.Parameters.AddWithValue("@CID", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cus_name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox3.Text));
            cmd.Parameters.AddWithValue("@Vehical_type", (textBox5.Text));
            cmd.Parameters.AddWithValue("@Driver_Status", (driver));
            cmd.Parameters.AddWithValue("@Rentdate", (Rent.Text));
            cmd.Parameters.AddWithValue("@ReturnDate", (return1.Text));
            cmd.Parameters.AddWithValue("@N_O_D", int.Parse(days.Text));
            cmd.Parameters.AddWithValue("@vehicalfee", int.Parse(textfee.Text));
            cmd.Parameters.AddWithValue("@drivercost", int.Parse(textdrivercost.Text));
            cmd.Parameters.AddWithValue("@T_R_A", int.Parse(texttotal.Text));
            cmd.Parameters.AddWithValue("@Paidstatus", (paid));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete CarRent where rent_id=@rent_id", con);
            cmd.Parameters.AddWithValue("@rent_id", (comboBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted SucessFully");
        }
    }
}
