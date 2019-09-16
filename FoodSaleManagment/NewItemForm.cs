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
    public partial class NewItemForm : Form
    {
        public NewItemForm()
        {
            InitializeComponent();
        }
        public ISyncFormData FormToRefresh { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionHelper helper = new ConnectionHelper();
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand("INSERT INTO FoodItems (ItemId,ItemName, ItemPrice) VALUES (@i,@n, @p)", con);
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@i", SqlDbType.BigInt){ Value= fidTxt.Text},
                 new SqlParameter("@n", SqlDbType.NVarChar){ Value= fnTxt.Text},
                new SqlParameter("@p", SqlDbType.NVarChar){ Value= fpTxt.Text}
            });
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {
            ConnectionHelper helper = new ConnectionHelper();
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand("SELECT MAX(ItemId) From FoodItems", con);
            con.Open();
            long i = (long)cmd.ExecuteScalar();
            con.Close();
            fidTxt.Text = $"{i + 1}";
        }

        private void NewItemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormToRefresh.RefreshItemData();
        }
    }
}
