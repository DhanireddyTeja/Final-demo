using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Interface
{
    public interface IOrderItem
    {
        List<Order> displayOrder();
        Order Post(Order order);
        Order Put(Order order);
        bool Delete(int orderId);
    }
}
