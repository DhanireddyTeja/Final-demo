using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Models
{
    public class Rating
    {
        public int ratingId
        {
            get;
            set;
        }
        public int ItemId
        {
            get;
            set;
        }
        public int RatingItem
        {
            get;
            set;
        }
    }
}
