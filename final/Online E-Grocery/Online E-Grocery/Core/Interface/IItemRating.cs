using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Interface
{
    public interface IItemRating
    {
        List<Rating> displayRating();
        Rating Post(Rating rating);
        Rating Put(Rating rating);
        bool Delete(int ratingId);
    }
}
