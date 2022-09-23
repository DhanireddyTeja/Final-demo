using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Class
{
    public class itemRating : IItemRating
    {
        private readonly GroceryDbContext _context;
        public itemRating(GroceryDbContext _context)
        {
            this._context = _context;
        }
        public List<Rating> displayRating()
        {
            var list = _context.rating.ToList();
            return list;
        }

        public Rating Post(Rating rating)
        {
            _context.rating.AddAsync(rating);
            _context.SaveChangesAsync();
            return rating;
        }
        public Rating Put(Rating rating)
        {
            var ratingToEdit = _context.rating.Where(x => x.ratingId == rating.ratingId).FirstOrDefault();
            ratingToEdit.ratingId = rating.ratingId;
            ratingToEdit.ItemId = rating.ItemId;
            ratingToEdit.RatingItem = rating.RatingItem;

            _context.SaveChanges();
            return ratingToEdit;
        }


        public bool Delete(int ratingId)
        {
            var item = _context.rating.Where(x => x.ratingId == ratingId).FirstOrDefault();
            _context.rating.Remove(item);
            _context.SaveChanges();

            return true;
        }
    }
}
