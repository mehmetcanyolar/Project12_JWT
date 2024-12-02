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
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }


        SqlConnection sqlconnection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;initial catalog=Db12Project20;integrated security=true");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
             sqlconnection.Open();
            SqlCommand command = new SqlCommand("Select * from TblEmployees", sqlconnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlconnection.Close();

        }
    }
}
