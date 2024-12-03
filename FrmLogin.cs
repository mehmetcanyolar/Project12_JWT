using Project12_JWT.JWT;
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

namespace Project12_JWT
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        SqlConnection sqlconnection =new SqlConnection("Server=(localdb)\\MSSQLLocalDB;initial catalog=Db12Project20;integrated security=true");

        private void btnLogin_Click(object sender, EventArgs e)
        {
           TokenGenerator tokenGenerator = new TokenGenerator();

            sqlconnection.Open();
            SqlCommand command = new SqlCommand("Select * from TblUsers where UserName = @username and Password=@password", sqlconnection);

            command.Parameters.AddWithValue("@username",txtUsername.Text);
            command.Parameters.AddWithValue("@password",txtPassword.Text);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string token = tokenGenerator.GenerateJwtToken2(txtUsername.Text);
               // MessageBox.Show(token);

                FrmEmployee employeeFrm = new FrmEmployee();
                employeeFrm.tokenGet = token;
                employeeFrm.Show();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI YA DA ŞİFRESİ, LÜTFEN TEKRAR DENEYİN");
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
            }
            
            sqlconnection.Close();
        }
    }
}
