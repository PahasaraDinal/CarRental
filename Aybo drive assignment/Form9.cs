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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into packages values (@VehicalNO,@package_type,@Vehical_type,@AmountKM,@Time_Of_pack,@EKC,@EHC,@EDC,@NDC,@NPC)", con);
            cmd.Parameters.AddWithValue("@VehicalNO", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@package_type", (comboBox1.SelectedItem));
            cmd.Parameters.AddWithValue("@Vehical_type", (comboBox2.SelectedItem));
            cmd.Parameters.AddWithValue("@AmountKM", int.Parse (textBox3.Text));
            cmd.Parameters.AddWithValue("@Time_Of_pack", (comboBox3.SelectedItem));
            cmd.Parameters.AddWithValue("@EKC", (comboBox4.SelectedItem));
            cmd.Parameters.AddWithValue("@EHC", (comboBox5.SelectedItem));
            cmd.Parameters.AddWithValue("@EDC", (comboBox6.SelectedItem));
            cmd.Parameters.AddWithValue("@NDC", (comboBox7.SelectedItem));
            cmd.Parameters.AddWithValue("@NPC", (comboBox8.SelectedItem));
            

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Save SuccessFull");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update packages set  package_type=@package_type,Vehical_type=@Vehical_type,AmountKM=@AmountKM,Time_Of_pack=@Time_Of_pack,EKC=@EKC,EHC=@EHC,EDC=@EDC,NDC=@NDC,NPC=@NPC where VehicalNO = @VehicalNO", con);
            cmd.Parameters.AddWithValue("@VehicalNO", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@package_type", (comboBox1.SelectedItem));
            cmd.Parameters.AddWithValue("@Vehical_type", (comboBox2.SelectedItem));
            cmd.Parameters.AddWithValue("@AmountKM", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Time_Of_pack", (comboBox3.SelectedItem));
            cmd.Parameters.AddWithValue("@EKC", (comboBox4.SelectedItem));
            cmd.Parameters.AddWithValue("@EHC", (comboBox5.SelectedItem));
            cmd.Parameters.AddWithValue("@EDC", (comboBox6.SelectedItem));
            cmd.Parameters.AddWithValue("@NDC", (comboBox7.SelectedItem));
            cmd.Parameters.AddWithValue("@NPC", (comboBox8.SelectedItem));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete packages where VehicalNO=@VehicalNO", con);
            cmd.Parameters.AddWithValue("@VehicalNO", (textBox1.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Pacakge deleted");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedItem = 0;
            comboBox2.SelectedItem = 0;
            textBox3.Text = "";
            comboBox3.SelectedItem = 0;
            comboBox4.SelectedItem = 0;
            comboBox5.SelectedItem = 0;
            comboBox6.SelectedItem = 0;
            comboBox7.SelectedItem = 0;
            comboBox8.SelectedItem = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
            f5 = null;
            this.Show();
        }
    }
}
