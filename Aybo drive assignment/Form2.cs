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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCal_Click(object sender, EventArgs e)
        {

            
            {
                
                
                int wc = 0;
                int ekc = 0;
                int tot = 0;
                int bhc = 0;
                int endkm = Convert.ToInt32(textBox17.Text);
                int startkm = Convert.ToInt32(textBox16.Text);


                int travel = endkm - startkm;
                textBox18.Text = travel.ToString();


                int tl = Convert.ToInt32(text3.Text);
                int tl0 = Convert.ToInt32(tl);
                int nh = Convert.ToInt32(textBox4.Text);

                int h = nh - tl0;

                if (h > 1)
                {
                    wc = h * 500;
                    textBox7.Text = h.ToString();
                }
                else
                {
                    textBox7.Text = "0";
                }

                int km = Int32.Parse(textBox18.Text) - Int32.Parse(text1.Text);

                if (km > 0)
                {
                    ekc = km * 1000;
                    textBox5.Text = km.ToString();
                }
                else
                {
                    textBox5.Text = "0";
                }
                tot =  wc + ekc + bhc;

                String ekc0 = ekc.ToString();
                String wc0 = wc.ToString();
                String tot0 = tot.ToString();
                String bhc0 = bhc.ToString();

                textBox6.Text = ekc0;
                textBox8.Text = wc0;
                textBox1.Text = bhc0;
                textBox10.Text = tot0;
                

            }
            
            {
                
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Parse(dateTimePicker1.Value.ToString());
            DateTime endTime = DateTime.Parse(dateTimePicker2.Value.ToString());

            int timeDiff = endTime.Subtract(startTime).Hours;
            textBox4.Text = timeDiff.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            f3 = null;
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox5.Text = "";
            text3.Text = "";
            text1.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox10.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DayTour values (@Hire_Id,@CID,@VehicalNo,@Cus_name,@Contact,@starttime,@endtime,@N_hours,@EK,@EKC,@EH,@Waitingcharge,@basehire,@pack_type,@vehical_type,@timelimit,@amountKM,@StartKM,@EndKM,@travelKM,@totalhire)", con);
            cmd.Parameters.AddWithValue("@Hire_Id", (comboBox3.SelectedItem));
            cmd.Parameters.AddWithValue("@CID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cus_name", (textBox9.Text));
            cmd.Parameters.AddWithValue("@Contact",int .Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@starttime", (dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@endtime", (dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@N_hours", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@EK", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@EKC", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@EH", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@Waitingcharge", int.Parse (textBox8.Text));
            cmd.Parameters.AddWithValue("@basehire", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@pack_type", (comboBox6.SelectedItem));
            cmd.Parameters.AddWithValue("@vehical_type", (comboBox5.SelectedItem));
            cmd.Parameters.AddWithValue("@timelimit",int.Parse (text3.Text));
            cmd.Parameters.AddWithValue("@amountKM", int.Parse (text1.Text));
            cmd.Parameters.AddWithValue("@StartKM", int.Parse (textBox16.Text));
            cmd.Parameters.AddWithValue("@EndKM", int.Parse (textBox17.Text));
            cmd.Parameters.AddWithValue("@travelKM", int.Parse (textBox18.Text));
            cmd.Parameters.AddWithValue("@totalhire", int.Parse (textBox10.Text));

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Save SuccessFull");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update DayTour set  CID=@CID,VehicalNo=@VehicalNo,Cus_name=@Cus_name,Contact=@Contact,starttime=@starttime,endtime=@endtime,N_hours=@N_hours,EK=@EK,EKC=@EKC,EH=@EH,Waitingcharge=@Waitingcharge,basehire=@basehire,pack_type=@pack_type,vehical_type=@vehical_type,timelimit=@timelimit,amountKM=@amountKM,StartKM=@StartKM,EndKM=@EndKM,travelKM=@travelKM,totalhire=@totalhire where Hire_Id = @Hire_Id", con);
            cmd.Parameters.AddWithValue("@Hire_Id", (comboBox3.SelectedItem));
            cmd.Parameters.AddWithValue("@CID", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cus_name", (textBox9.Text));
            cmd.Parameters.AddWithValue("@Contact", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@starttime", (dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@endtime", (dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@N_hours", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@EK", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@EKC", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@EH", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@Waitingcharge", int.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@basehire", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@pack_type", (comboBox6.SelectedItem));
            cmd.Parameters.AddWithValue("@vehical_type", (comboBox5.SelectedItem));
            cmd.Parameters.AddWithValue("@timelimit", int.Parse(text3.Text));
            cmd.Parameters.AddWithValue("@amountKM", int.Parse(text1.Text));
            cmd.Parameters.AddWithValue("@StartKM", int.Parse(textBox16.Text));
            cmd.Parameters.AddWithValue("@EndKM", int.Parse(textBox17.Text));
            cmd.Parameters.AddWithValue("@travelKM", int.Parse(textBox18.Text));
            cmd.Parameters.AddWithValue("@totalhire", int.Parse(textBox10.Text));

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete DayTour where Hire_Id=@Hire_Id", con);
            cmd.Parameters.AddWithValue("@Hire_Id", (comboBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted SucessFully");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
  
                
        
            
            




