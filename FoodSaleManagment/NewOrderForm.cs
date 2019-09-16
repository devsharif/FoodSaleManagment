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
    public partial class NewOrderForm : Form
    {
        ConnectionHelper helper = new ConnectionHelper();
        //////////////////////////////////////////
     
        Order ord = new Order();
        List<OrderItemEnlarged> orderItems = new List<OrderItemEnlarged>();
        List<FoodItem> items = new List<FoodItem>();
        BindingSource bs = new BindingSource();
    
        /// //////////////////
      
        public NewOrderForm()
        {
            InitializeComponent();
        }
        public ISyncFormData FormToSync { get; set; }
        private void NewOrderForm_Load(object sender, EventArgs e)
        {
           
            
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand("SELECT MAX(OrderId) FROM Orders", con);
            con.Open();
            long i = (long)cmd.ExecuteScalar();
            
            oiTxt.Text = (i + 1).ToString();
            cmd.CommandText = "Select CustomerId, CustomerName FROM Customers";
            SqlDataReader dr = cmd.ExecuteReader();
            List<Customer> custs = new List<Customer>();
            while (dr.Read())
            {
                custs.Add(new Customer { Id = dr.GetInt64(0), Name = dr.GetString(1) });
            }
            
            cmd.CommandText = "Select ItemId, ItemName, ItemPrice FROM FoodItems";
            dr.Close();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                items.Add(new FoodItem { ItemId=dr.GetInt64(0),ItemName=dr.GetString(1), Price=dr.GetDecimal(2)  });
            }
            con.Close();
            cIdCbo.DataSource = custs;
            cIdCbo.ValueMember = "Id";
            cIdCbo.DisplayMember = "Name";

            fiCbo.DataSource = items;
            fiCbo.ValueMember = "ItemId";
            fiCbo.DisplayMember = "ItemName";

            bs.DataSource = orderItems;
            dgOrderItems.DataSource = bs;
            ord.OrderId = long.Parse(oiTxt.Text);
            bs.ListChanged += Bs_ListChanged;
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            totalLbl.Text = orderItems.Sum(x => x.Amount).ToString("0.00");
        }

        private void bAddToOrder_Click(object sender, EventArgs e)
        {
            var p = items.First(x => x.ItemId == long.Parse(fiCbo.SelectedValue.ToString()));
            int q = (int)numericUpDown1.Value;
            decimal a = p.Price * q;
            OrderItemEnlarged item = new OrderItemEnlarged { ItemId = long.Parse(fiCbo.SelectedValue.ToString()), OrderId = long.Parse(oiTxt.Text), Quantity = q, ItemPrice=p.Price, ItemName=p.ItemName, Amount=a };
           
            //orderItems.Add(new OrderItem { ItemId = long.Parse(fiCbo.SelectedValue.ToString()), OrderId = long.Parse(oiTxt.Text), Quantity = (int)numericUpDown1.Value });
            bs.Insert(bs.Count,item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.EndEdit();

            ord.OrderDate = odDtp.Value;
            ord.CustomerId = long.Parse(cIdCbo.SelectedValue.ToString());
            SqlConnection con = helper.GetConnectionInstance();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "INSERT INTO Orders (OrderID, OrderDate, CustomerId) VALUES (@id, @date, @cid)",
                Connection = con
            };
            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@id", SqlDbType.BigInt){ Value=ord.OrderId},
                new SqlParameter("@date", SqlDbType.DateTime){ Value=ord.OrderDate},
                new SqlParameter("@cid", SqlDbType.NVarChar){ Value=ord.CustomerId}
            });
            con.Open();
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("OrderId", typeof(long)));
            dt.Columns.Add(new DataColumn("ItemId", typeof(long)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(int)));

            foreach (var entry in orderItems)
                dt.Rows.Add(entry.OrderId, entry.GetItemId(), entry.Quantity);

            using (SqlBulkCopy bc = new SqlBulkCopy(con))
            {   
                // the following 3 lines might not be neccessary
                bc.DestinationTableName = "OrderItems";
                bc.ColumnMappings.Add("OrderId", "OrderId");
                bc.ColumnMappings.Add("ItemId", "ItemId");
                bc.ColumnMappings.Add("Quantity", "Quantity");

                bc.WriteToServer(dt);
            }
            con.Close();
            //MessageBox.Show("Order Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new OrderPrintForm { OrderId = ord.OrderId }.Show();
        }

        private void NewOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormToSync.ResfreshOrderData();
        }
    }
}
