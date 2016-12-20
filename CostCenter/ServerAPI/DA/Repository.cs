using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerAPI.DA
{
    public class Repository
    {
        public List<UserAD> GetAllUsers()
        {
            using (var db = new UsersADEntities1())
            {
               return db.UserADs.ToList();
            }
        }

        public void AdUser(UserAD user)
        {
            using (var db = new UsersADEntities1())
            {
                db.UserADs.Add(user);
                db.SaveChangesAsync();
            }
        }
    }
}