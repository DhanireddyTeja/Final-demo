using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_E_Grocery.Core.Interface
{
   public  interface IUser
    {
        List<User> displayUser();
        User Post(User user);
        User Put(User user);
        bool Delete(int userId);
    }
}
