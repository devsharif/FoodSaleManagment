﻿using CrystalDecisions.CrystalReports.Engine;
using FoodSaleManagment.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodSaleManagment
{
    public partial class OrderPrintForm : Form
    {
        DataSet dsFoodDb = new DataSet();
        SqlDataAdapter daCust, daItem, daOrd, daOrdItem;
        public OrderPrintForm()
        {
            InitializeComponent();
        }
        public long OrderId { get; set; }
        private void OrderPrintForm_Load(object sender, EventArgs e)
        {
            ConnectionHelper helper = new ConnectionHelper();
            SqlConnection conMain = helper.GetConnectionInstance();
            daCust = new SqlDataAdapter("SELECT * FROM Customers", conMain);
            daCust.Fill(dsFoodDb, "Customers");
            daItem = new SqlDataAdapter("SELECT * FROM FoodItems", conMain);
            daItem.Fill(dsFoodDb, "FoodItems");
            daOrd = new SqlDataAdapter($"SELECT * FROM Orders WHERE OrderId={this.OrderId}", conMain);
            daOrd.Fill(dsFoodDb, "Orders");
            daOrdItem = new SqlDataAdapter(@"SELECT oi.OrderId, fi.ItemId, fi.ItemName, fi.ItemPrice, oi.Quantity, fi.ItemPrice*oi.Quantity as 'Amount'
                                    FROM OrderItems oi
                                    Inner Join FoodItems fi
                                    on oi.ItemId = fi.ItemId", conMain);
            daOrdItem.Fill(dsFoodDb, "OrderItems");
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Path.GetFullPath("..\\..\\") + "OrderPrint.rpt");
            cryRpt.SetDataSource(dsFoodDb);
            
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
