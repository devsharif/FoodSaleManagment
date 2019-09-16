using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSaleManagment.Helpers
{
    public class ConnectionHelper
    {
        public string ConnectionString
        {
            get => @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Path.GetFullPath(@"..\..\")+ "FoodSalesDb.mdf;Integrated Security = True";
        }
        public SqlConnection GetConnectionInstance() => new SqlConnection(this.ConnectionString);
    }
}
