using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Class
{
    public class orderItem :IOrderItem
    {
        private readonly GroceryDbContext _context;
        public orderItem(GroceryDbContext _context)
        {
            this._context = _context;
        }
        public List<Order> displayOrder()
        {
            var list = _context.order.ToList();
            return list;
        }

        public Order Post(Order order)
        {
            _context.order.AddAsync(order);
            _context.SaveChangesAsync();
            return order;
        }
        public Order Put(Order order)
        {
            var orderToEdit = _context.order.Where(x => x.orderId == order.orderId).FirstOrDefault();
            orderToEdit.orderId = order.orderId;
            orderToEdit.itemName = order.itemName;
            orderToEdit.orderPlace = order.orderPlace;

            _context.SaveChanges();
            return orderToEdit;
        }


        public bool Delete(int orderId)
        {
            var item = _context.order.Where(x => x.orderId == orderId).FirstOrDefault();
            _context.order.Remove(item);
            _context.SaveChanges();

            return true;
        }
    }
}
