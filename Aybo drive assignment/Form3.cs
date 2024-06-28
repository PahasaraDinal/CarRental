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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");
        String days;
        String nights;

        private void btnCal_Click(object sender, EventArgs e)
        {
            int skm = Convert.ToInt32(textBox16.Text);
            int ekm = Convert.ToInt32(textBox17.Text);
            int akm = Convert.ToInt32(textBox15.Text);

            int tkm = ekm - skm;
            textBox18.Text = tkm.ToString();
            
            textBox15.Text = akm.ToString();
            int exkm = tkm - akm;
            textBox5.Text = exkm.ToString();
            if (exkm > 0)
            {
                float ekmc = exkm * 50;
                textBox6.Text = ekmc.ToString();
            }
            else
            {
                textBox6.Text = "0";
            }


            float bhc = Convert.ToInt32(txtdays.Text) * 1500;
            float npc = Convert.ToInt32(txtnights.Text) * 500;
            float onsf = Convert.ToInt32(txtnights.Text) * 2500;
            float tot = bhc + npc + onsf + exkm;


            String tot0 = tot.ToString();
            String bhc0 = bhc.ToString();
            String npc0 = npc.ToString();
            String onsf0 = onsf.ToString();

            textBox10.Text = tot0;
            textBox9.Text = bhc0;
            textBox4.Text = npc0;
            textBox7.Text = onsf0;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime start = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime end = Convert.ToDateTime(dateTimePicker2.Text);
            if (start < end)
            {
                days = end.Subtract(start).Days.ToString();
                txtdays.Text = days;
                int days1 = Convert.ToInt32(days);
                int nights1 = days1 - 1;
                nights = nights1.ToString();
                txtnights.Text = nights;
            }
            else if (start >= end)
            {
                MessageBox.Show("Invalid Date!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
            f5 = null;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LongTour values (@HireId,@CID,@VehicalNo,@Cname,@Contact,@startdate,@Enddate,@travelDays,@Night,@SKM,@EKm,@ExtraKm,@ExtraKMCharge,@Nightpack,@nightstayfee,@BHC,@AmountKm,@TravelKm,@TotalHire)", con);
            cmd.Parameters.AddWithValue("@HireId", (comboBox3.Text));
            cmd.Parameters.AddWithValue("@CID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cname", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Contact", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@startdate", (dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Enddate", (dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@travelDays", int.Parse(txtdays.Text));
            cmd.Parameters.AddWithValue("@Night", int.Parse(txtnights.Text));
            cmd.Parameters.AddWithValue("@SKM", int.Parse(textBox16.Text));
            cmd.Parameters.AddWithValue("@EKm", int.Parse(textBox17.Text));
            cmd.Parameters.AddWithValue("@ExtraKm", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@ExtraKMCharge", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Nightpack", int.Parse (textBox4.Text));
            cmd.Parameters.AddWithValue("@nightstayfee", int.Parse (textBox7.Text));
            cmd.Parameters.AddWithValue("@BHC", int.Parse(textBox9.Text));
            cmd.Parameters.AddWithValue("@AmountKm", int.Parse(textBox15.Text));
            cmd.Parameters.AddWithValue("@TravelKm", int.Parse(textBox18.Text));
            cmd.Parameters.AddWithValue("@TotalHire", int.Parse(textBox10.Text));
            

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Save SuccessFull");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update LongTour set  CID=@CID,VehicalNo=@VehicalNo,Cname=@Cname,Contact=@Contact,startdate=@startdate,Enddate=@Enddate,travelDays=@travelDays,Night=@Night,SKM=@SKM,EKm=@EKm,ExtraKm=@ExtraKm,ExtraKMCharge=@ExtraKMCharge,Nightpack=@Nightpack,nightstayfee=@nightstayfee,BHC=@BHC,AmountKm=@AmountKm,TravelKm=@TravelKm,TotalHire=@TotalHire where HireId = @HireId", con);
            cmd.Parameters.AddWithValue("@HireId", (comboBox3.Text));
            cmd.Parameters.AddWithValue("@CID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@VehicalNo", int.Parse(comboBox2.Text));
            cmd.Parameters.AddWithValue("@Cname", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Contact", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@startdate", (dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@Enddate", (dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@travelDays", int.Parse(txtdays.Text));
            cmd.Parameters.AddWithValue("@Night", int.Parse(txtnights.Text));
            cmd.Parameters.AddWithValue("@SKM", int.Parse(textBox16.Text));
            cmd.Parameters.AddWithValue("@EKm", int.Parse(textBox17.Text));
            cmd.Parameters.AddWithValue("@ExtraKm", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@ExtraKMCharge", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Nightpack", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@nightstayfee", int.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@BHC", int.Parse(textBox9.Text));
            cmd.Parameters.AddWithValue("@AmountKm", int.Parse(textBox15.Text));
            cmd.Parameters.AddWithValue("@TravelKm", int.Parse(textBox18.Text));
            cmd.Parameters.AddWithValue("@TotalHire", int.Parse(textBox10.Text));

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete LongTour where HireId=@HireId", con);
            cmd.Parameters.AddWithValue("@HireId", (comboBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted SucessFully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txtdays.Text = "";
            txtnights.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}
