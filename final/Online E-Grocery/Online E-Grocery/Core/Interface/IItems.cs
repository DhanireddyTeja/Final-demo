using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Interface
{
    public interface IItems
    {
        List<Items> Get();
        Items Post(Items items);
        Items Put(Items items);
        bool Delete(int itemId);
        Task<Items> GetItems(string itemName);
    }
}
