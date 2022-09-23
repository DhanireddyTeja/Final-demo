using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.DataAccess;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Class
{
    public class user :IUser
    {
        private readonly GroceryDbContext _context;
        public user(GroceryDbContext _context)
        {
            this._context = _context;
        }
        public List<User> displayUser()
        {
            try
            {
                var result = _context.user.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public User Post(User user)
        {
            try
            {
                _context.user.AddAsync(user);
                _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex) { throw ex; }
        }
        public User Put(User model)
        {
            var userToEdit = _context.user.Where(x => x.userId == model.userId).FirstOrDefault();
            userToEdit.userId = model.userId;
            userToEdit.userName = model.userName;
            userToEdit.email = model.email;
            userToEdit.passWord = model.passWord;

            _context.SaveChanges();
            return userToEdit;
        }


        public bool Delete(int id)
        {
            var employees = _context.user.Where(x => x.userId == id).FirstOrDefault();
            _context.user.Remove(employees);
            _context.SaveChanges();

            return true;
        }
    }
}
