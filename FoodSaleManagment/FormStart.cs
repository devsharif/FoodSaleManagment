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
    public partial class FormStart : Form, ISyncFormData
    {
        DataSet dsFoodDb = new DataSet();
        SqlDataAdapter daCust, daItem, daOrd, daOrdItem;
        SqlConnection conMain;

        /////////////////Navigation
        BindingSource bsOrd = new BindingSource();
        BindingSource bsOrdItem = new BindingSource();
        BindingSource bsCust = new BindingSource();
        BindingSource bsItems = new BindingSource();
        public FormStart()
        {
            InitializeComponent();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            
            SetupDataSets();
            SetupConstraints();
            SetupCommands();

            bsOrd.DataSource = dsFoodDb;
            bsOrd.DataMember = "Orders";
            bsOrdItem.DataSource = bsOrd;
            bsOrdItem.DataMember = "FK_O_OI";

            bsCust.DataSource = dsFoodDb;
            bsCust.DataMember = "Customers";
            bsItems.DataSource = dsFoodDb;
            bsItems.DataMember = "FoodItems";
            //comboitems
            cIdCbo.DataSource = dsFoodDb.Tables["Customers"];
            cIdCbo.ValueMember = "CustomerId";
            cIdCbo.DisplayMember = "CustomerName";

            SetUpDataBindings();
            //MessageBox.Show( $"{bsOrd.Position} of {bsOrd.Count}");

            dgOrderItems.DataSource = bsOrdItem;

            bsOrd.PositionChanged += BsOrd_PositionChanged;
            bsCust.PositionChanged += BsCust_PositionChanged;
            bsItems.PositionChanged += BsItems_PositionChanged;
        }

        private void BsItems_PositionChanged(object sender, EventArgs e)
        {
            fiPos.Text = $"{bsItems.Position + 1} of {bsItems.Count}";
        }

        private void BsCust_PositionChanged(object sender, EventArgs e)
        {
            cPos.Text = $"{bsCust.Position + 1} of {bsCust.Count}";
        }

        private void SetUpDataBindings()
        {
            oiTxt.DataBindings.Add("Text", bsOrd, "OrderId");
            odDtp.DataBindings.Add("Value", bsOrd, "OrderDate");
            cIdCbo.DataBindings.Add("SelectedValue", bsOrd, "CustomerId");
            lblPosition.Text = $"{bsOrd.Position + 1} of {bsOrd.Count}";

            cidTxt.DataBindings.Add("Text", bsCust, "CustomerId");
            cnTxt.DataBindings.Add("Text", bsCust, "CustomerName");
            caTxt.DataBindings.Add("Text", bsCust, "CustomerAddress");
            cpTxt.DataBindings.Add("Text", bsCust, "CustomerPhone");
            cPos.Text = $"{bsCust.Position + 1} of {bsCust.Count}";

            fidTxt.DataBindings.Add("Text", bsItems, "ItemId");
            fnTxt.DataBindings.Add("Text", bsItems, "ItemName");
            fpTxt.DataBindings.Add("Text", bsItems, "ItemPrice");
            fiPos.Text = $"{bsItems.Position + 1} of {bsItems.Count}";
        }

        private void BsOrd_PositionChanged(object sender, EventArgs e)
        {
            lblPosition.Text = $"{bsOrd.Position + 1} of {bsOrd.Count}";
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            new NewOrderForm { FormToSync = this }.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bsOrd.Position < bsOrd.Count - 1)
                bsOrd.MoveNext();
        }

        private void bPrev_Click(object sender, EventArgs e)
        {
            if (bsOrd.Position > 0)
                bsOrd.MovePrevious();
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            bsOrd.MoveFirst();
        }

        private void bLast_Click(object sender, EventArgs e)
        {
            bsOrd.MoveLast();
        }

        private void SetupCommands()
        {
            SqlCommandBuilder cb1 = new SqlCommandBuilder(daCust);
            SqlCommandBuilder cb2 = new SqlCommandBuilder(daItem);
            SqlCommandBuilder cb3 = new SqlCommandBuilder(daOrd);
            //SqlCommandBuilder cb4 = new SqlCommandBuilder(daOrdItem);
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            bsOrd.EndEdit();
            DataRow r= dsFoodDb.Tables["Orders"].Rows.Find(int.Parse(oiTxt.Text));
            r[1] = odDtp.Value;
            r[2] = cIdCbo.SelectedValue;
            daOrd.Update(dsFoodDb.Tables["Orders"]);
            dsFoodDb.AcceptChanges();
        }

        private void bcFirst_Click(object sender, EventArgs e)
        {
            bsCust.MoveFirst();
        }

        private void bcPrevious_Click(object sender, EventArgs e)
        {

        }

        private void cNext_Click(object sender, EventArgs e)
        {
            if (bsCust.Position < bsCust.Count - 1) bsCust.MoveNext();
        }

        private void bcLast_Click(object sender, EventArgs e)
        {
            bsCust.MoveLast();
        }

        private void fiFirst_Click(object sender, EventArgs e)
        {
            bsItems.MoveFirst();
        }

        private void bcPrevious_Click_1(object sender, EventArgs e)
        {
            if (bsCust.Position > 0) bsCust.MovePrevious();
        }

        private void cNext_Click_1(object sender, EventArgs e)
        {
            if (bsCust.Position < bsCust.Count -1) bsCust.MoveNext();
        }

        private void fiPrevous_Click(object sender, EventArgs e)
        {
            if (bsItems.Position > 0) bsItems.MovePrevious();
        }

        private void fiNext_Click(object sender, EventArgs e)
        {
            if (bsItems.Position < bsItems.Count - 1) bsItems.MoveNext();
        }

        private void fiLast_Click(object sender, EventArgs e)
        {
            bsItems.MoveLast();
        }

        private void bcNew_Click(object sender, EventArgs e)
        {
            new NewCustomerForm { FormToRefresh = this }.ShowDialog();
        }

        private void SetupConstraints()
        {
            dsFoodDb.Tables["Customers"].PrimaryKey = new DataColumn[] { dsFoodDb.Tables["Customers"].Columns[0] };
            dsFoodDb.Tables["FoodItems"].PrimaryKey = new DataColumn[] { dsFoodDb.Tables["FoodItems"].Columns[0] };
            dsFoodDb.Tables["Orders"].PrimaryKey = new DataColumn[] { dsFoodDb.Tables["Orders"].Columns[0] };
            dsFoodDb.Tables["OrderItems"].PrimaryKey = new DataColumn[] { dsFoodDb.Tables["OrderItems"].Columns[0], dsFoodDb.Tables["OrderItems"].Columns[1] };

            DataRelation relCustOrd = new DataRelation("FK_C_O", dsFoodDb.Tables["Customers"].Columns[0], dsFoodDb.Tables["Orders"].Columns[2]);
            DataRelation relOrdItem = new DataRelation("FK_O_OI", dsFoodDb.Tables["Orders"].Columns[0], dsFoodDb.Tables["OrderItems"].Columns[0]);
            DataRelation relOrdItemFood = new DataRelation("FK_OI_F", dsFoodDb.Tables["FoodItems"].Columns[0], dsFoodDb.Tables["OrderItems"].Columns[1]);
            dsFoodDb.Relations.AddRange(new DataRelation[] { relCustOrd, relOrdItem, relOrdItemFood });
        }

        private void bcUpdate_Click(object sender, EventArgs e)
        {
            bsCust.EndEdit();
            DataRow r = dsFoodDb.Tables["Customers"].Rows.Find(long.Parse(cidTxt.Text));
            r[1] = cnTxt.Text;
            r[2] = caTxt.Text;
            r[3] = cpTxt.Text;
            daCust.Update(dsFoodDb.Tables["Customers"]);
            dsFoodDb.AcceptChanges();
        }

        private void fiNew_Click(object sender, EventArgs e)
        {

        }

        private void SetupDataSets()
        {
            ConnectionHelper helper = new ConnectionHelper();
            conMain = helper.GetConnectionInstance();
            daCust = new SqlDataAdapter("SELECT * FROM Customers", conMain);
            daCust.Fill(dsFoodDb, "Customers");
            daItem = new SqlDataAdapter("SELECT * FROM FoodItems", conMain);
            daItem.Fill(dsFoodDb, "FoodItems");
            daOrd = new SqlDataAdapter("SELECT * FROM Orders", conMain);
            daOrd.Fill(dsFoodDb, "Orders");
            daOrdItem = new SqlDataAdapter(@"SELECT oi.OrderId, fi.ItemId, fi.ItemName, fi.ItemPrice, oi.Quantity, fi.ItemPrice*oi.Quantity as 'Amount'
                                    FROM OrderItems oi
                                    Inner Join FoodItems fi
                                    on oi.ItemId = fi.ItemId", conMain);
            daOrdItem.Fill(dsFoodDb, "OrderItems");

        }

        private void fiUpdate_Click(object sender, EventArgs e)
        {
            bsItems.EndEdit();
            DataRow r = dsFoodDb.Tables["FoodItems"].Rows.Find(int.Parse(fidTxt.Text));
            r[1] = fnTxt.Text;
            r[2] = fpTxt.Text;
            daItem.Update(dsFoodDb.Tables["FoodItems"]);
            dsFoodDb.AcceptChanges();
        }

        private void currentMonthOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RptCurrentMonth().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (bsOrd.Position < bsOrd.Count - 1) bsOrd.MoveNext();
        }

        private void salesByItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SalesSummaryForm().ShowDialog();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        public void ResfreshOrderData()
        {
            daCust.Fill(dsFoodDb, "Customers");
            daOrd.Fill(dsFoodDb, "Orders");
            daOrd.Fill(dsFoodDb, "Orders");
            daOrdItem.Fill(dsFoodDb, "OrderItems");
            bsOrd.Position = bsOrd.Count - 1;
            //MessageBox.Show(dsFoodDb.Tables["Orders"].Rows.Count + "");
        }

        public void RefreshCustomerData()
        {
            daCust.Fill(dsFoodDb, "Customers");
            bsCust.Position = bsCust.Count - 1;
        }

        public void RefreshItemData()
        {
            daItem.Fill(dsFoodDb, "FoodItems");
            daCust.Fill(dsFoodDb, "Customers");
           
            daOrd.Fill(dsFoodDb, "Orders");
            daOrdItem.Fill(dsFoodDb, "OrderItems");
            bsItems.Position = bsItems.Count - 1;
        }
    }
}
