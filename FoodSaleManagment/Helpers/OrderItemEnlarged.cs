using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSaleManagment.Helpers
{
    public class OrderItemEnlarged
    {
        public long OrderId { get; set; }
        public long ItemId { private get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public long GetItemId()
        {
            return ItemId;
        }
    }
}
