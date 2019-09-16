using FoodSaleManagment.Helpers;
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

namespace FoodSaleManagment
{
    public partial class NewCustomerForm : Form
    {
        public NewCustomerForm()
        {
            InitializeComponent();
        }
        public ISyncFormData FormToRefresh { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionHelper helper = new ConnectionHelper();
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CustomerId,CustomerName, CustomerAddress, CustomerPhone) VALUES (@i,@n, @a, @p)", con);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@i", SqlDbType.BigInt){ Value= cidTxt.Text},
                 new SqlParameter("@n", SqlDbType.NVarChar){ Value= cnTxt.Text},
                new SqlParameter("@a", SqlDbType.NVarChar){ Value= caTxt.Text},
                new SqlParameter("@p", SqlDbType.NVarChar){ Value= cpTxt.Text}
            });
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
            ConnectionHelper helper = new ConnectionHelper();
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand("SELECT MAX(CustomerId) From Customers", con);
            con.Open();
            long i = (long)cmd.ExecuteScalar();
            con.Close();
            cidTxt.Text = $"{i + 1}";
        }

        private void NewCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormToRefresh.RefreshCustomerData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
