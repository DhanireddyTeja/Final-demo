using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Models
{
    public class Items
    {
        [Key]
        public int itemId
        {
           
            get;
            set;
        }
        public int rating
        {
            get;
            set;
        }
        public string itemName
        {
            get;
            set;
        }
        public int itemPrice
        {
            get;
            set;
        }
    }
}
