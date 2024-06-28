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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlDataAdapter SqlDa = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(@"Data Source=PAHASARADINAL;Initial Catalog= AyuboDrive;Integrated Security=True");
        String Vtype;

        private void button3_Click(object sender, EventArgs e)
        {
            
            
                if (rbCommutervan.Checked == true) { Vtype = "Commuter Van"; }
                else if (rbJeep.Checked == true) { Vtype = "Jeep (4WD) "; }
                else if (rbSedancar.Checked == true) { Vtype = "Sedan Car"; }
                else if (rbSevenseatervan.Checked == true) { Vtype = "7 Seater Van"; }
                else if (rbSmallercar.Checked == true) { Vtype = "Small Car"; }
                else if (rbSUV.Checked == true) { Vtype = "SUV"; }



                SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
                con.Open();
            SqlCommand cmd = new SqlCommand("insert into VehicleReg values (@VehicalNO,@model,@brand,@M_year,@colour,@Fualtype,@Vehicaltype)", con);
                cmd.Parameters.AddWithValue("@VehicalNO", int.Parse(txtVNo.Text));
                cmd.Parameters.AddWithValue("@model", (txtxVModel.Text));
                cmd.Parameters.AddWithValue("@brand", (txtVBrand.Text));
                cmd.Parameters.AddWithValue("@M_year", (txtMYear.Text));
                cmd.Parameters.AddWithValue("@colour", (txtVColour.Text));
                cmd.Parameters.AddWithValue("@Fualtype", (cmbFT.SelectedItem));
                cmd.Parameters.AddWithValue("@Vehicaltype", (Vtype));

                cmd.ExecuteNonQuery();

                con.Close();
            MessageBox.Show("Register SuccessFull");

            }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rbCommutervan.Checked == true) { Vtype = "Commuter Van"; }
            else if (rbJeep.Checked == true) { Vtype = "Jeep (4WD) "; }
            else if (rbSedancar.Checked == true) { Vtype = "Sedan Car"; }
            else if (rbSevenseatervan.Checked == true) { Vtype = "7 Seater Van"; }
            else if (rbSmallercar.Checked == true) { Vtype = "Small Car"; }
            else if (rbSUV.Checked == true) { Vtype = "SUV"; }



            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update VehicleReg set  model=@model,brand=@brand,M_year=@M_year,colour=@colour,Fualtype=@Fualtype,Vehicaltype=@Vehicaltype where VehicalNO = @VehicalNO", con);
            cmd.Parameters.AddWithValue("@VehicalNO", int.Parse(txtVNo.Text));
            cmd.Parameters.AddWithValue("@model", (txtxVModel.Text));
            cmd.Parameters.AddWithValue("@brand", (txtVBrand.Text));
            cmd.Parameters.AddWithValue("@M_year", (txtMYear.Text));
            cmd.Parameters.AddWithValue("@colour", (txtVColour.Text));
            cmd.Parameters.AddWithValue("@Fualtype", (cmbFT.SelectedItem));
            cmd.Parameters.AddWithValue("@Vehicaltype", (Vtype));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("UPDATE COMPLETE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=PAHASARADINAL;Initial Catalog=AyuboDrive;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete VehicleReg where VehicalNO=@VehicalNO", con);
            cmd.Parameters.AddWithValue("@VehicalNO", (txtVNo.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted SucessFully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtVNo.Text = "";
            txtxVModel.Text = "";
            txtVColour.Text = "";
            txtMYear.Text = "";
            txtRegYear.Text = "";
            txtVBrand.Text = "";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            f5 = null;
            this.Show();
        }

        private void cmbFT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
            
            
    




            

