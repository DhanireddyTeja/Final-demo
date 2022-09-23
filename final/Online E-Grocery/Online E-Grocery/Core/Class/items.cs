using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Online_E_Grocery.Core.Class
{
    public class items :IItems
    {
        private readonly GroceryDbContext _context;
        public items(GroceryDbContext _context)
        {
            this._context = _context;
        }
        public List<Items> Get()
        {
            var list = _context.item.ToList();
            return list;
        }
        public async Task<Items> GetItems(string itemName)
        {
            try
            {
                var result = await _context.item.FirstOrDefaultAsync(x => x.itemName == itemName);
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public Items Post(Items model)
        {
            _context.item.AddAsync(model);
            _context.SaveChangesAsync();
            return model;
        }
        public Items Put(Items items)
        {
            var itemsToEdit = _context.item.Where(x => x.itemId == items.itemId).FirstOrDefault();
            itemsToEdit.itemId = items.itemId;
            itemsToEdit.itemName = items.itemName;
            itemsToEdit.itemPrice = items.itemPrice;
            itemsToEdit.rating = items.rating;

            _context.SaveChanges();
            return itemsToEdit;
        }


        public bool Delete(int itemId)
        {
            var item = _context.item.Where(x => x.itemId == itemId).FirstOrDefault();
            _context.item.Remove(item);
            _context.SaveChanges();

            return true;
        }
    }
}
