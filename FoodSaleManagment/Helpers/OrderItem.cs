using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSaleManagment.Helpers
{
    public class OrderItem
    {
        public long OrderId { get; set; }
        public long ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
