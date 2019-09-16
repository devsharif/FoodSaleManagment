using CrystalDecisions.CrystalReports.Engine;
using FoodSaleManagment.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodSaleManagment
{
    
    public partial class RptCurrentMonth : Form
    {
        DataSet dsFoodDb = new DataSet();
        SqlDataAdapter daCust, daItem, daOrd, daOrdItem;
        public RptCurrentMonth()
        {
            InitializeComponent();
        }

        private void RptCurrentMonth_Load(object sender, EventArgs e)
        {
            int m = DateTime.Now.Month;
            int y = DateTime.Now.Year;

            var helper = new ConnectionHelper();
            SqlConnection conMain = helper.GetConnectionInstance();
            daCust = new SqlDataAdapter("SELECT * FROM Customers", conMain);
            daCust.Fill(dsFoodDb, "Customers");
            daItem = new SqlDataAdapter("SELECT * FROM FoodItems", conMain);
            daItem.Fill(dsFoodDb, "FoodItems");
            daOrd = new SqlDataAdapter($"SELECT OrderId, CONVERT(DATE, OrderDate) AS OrderDate, CustomerId FROM Orders WHERE Year(OrderDate)={y} AND Month(OrderDate)={m}", conMain);
            //MessageBox.Show($"SELECT * FROM Orders WHERE Year(OrderDate)={y} AND Month(OrderDate)={m}");
            daOrd.Fill(dsFoodDb, "Orders");
            //foreach(DataRow r in dsFoodDb.Tables["Orders"].Rows)
            //{
            //    Debug.WriteLine(r["OrderDate"].ToString());
            //}
            daOrdItem = new SqlDataAdapter(@"SELECT oi.OrderId, fi.ItemId, fi.ItemName, fi.ItemPrice, oi.Quantity, fi.ItemPrice*oi.Quantity as 'Amount'
                                    FROM OrderItems oi
                                    Inner Join FoodItems fi
                                    on oi.ItemId = fi.ItemId", conMain);
            daOrdItem.Fill(dsFoodDb, "OrderItems");
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Path.GetFullPath("..\\..\\") + "OrderCusrrentMonth.rpt");
            cryRpt.SetDataSource(dsFoodDb);
            TextObject t = cryRpt.ReportDefinition.ReportObjects["Text10"] as TextObject;
            t.Text = DateTime.Now.ToString("MMM, yyyy");
            crystalReportViewer1.ShowGroupTreeButton = false;
            crystalReportViewer1.ShowParameterPanelButton = false;
            
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
