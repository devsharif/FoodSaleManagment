using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSaleManagment
{
    public interface ISyncFormData
    {
        void ResfreshOrderData();
        void RefreshCustomerData();
        void RefreshItemData();
    }
}
