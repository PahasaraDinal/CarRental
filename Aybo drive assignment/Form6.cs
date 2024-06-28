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
    public partial class Form6 : Form
    {
        static string ConnectionString = @"Data Source=DESKTOP-STADLEU\PAHASARADINAL; initial Catalog=AyuboDrive;integrated security=true";
        SqlConnection con = new SqlConnection(ConnectionString);

        public Form6()
        {
            InitializeComponent();
            
        }
        
        String un, pw;


        private void groupBox1login_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            un = username.Text;
            pw = password.Text;
            
            if (!string.IsNullOrEmpty(un) && !string.IsNullOrEmpty(pw))
            {
                String ConnectionString;
                SqlConnection con;
                ConnectionString = @"Data Source=PAHASARADINAL; initial Catalog=AyuboDrive;integrated security=true";
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand command;
                SqlDataReader reader;
                string sql = "";
                sql = "select * from Username where un='" + un + "' and pw='" + pw + "'";
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        {
                            MessageBox.Show("Login Success!");
                            this.Hide();
                            Form5 f5 = new Form5();
                            f5.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("User Not Found!");
                }
            }
            else
            {
                MessageBox.Show("Username and Password is required!");
            }
        }
    }
}
