using ServerAPI.DA;
using ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerAPI.BL
{
    public class Singleton
    {
        //static Field
        private static Singleton _seInstance = null;
        private int _nCounter = 0;
        private Dictionary<string, Person> users;
        private SortedDictionary<string, List<string>> usersL;
        Repository repo = new Repository();
        // private constructor
        List<UserAD> list = new List<UserAD>();
        private Singleton() {
            _nCounter = 1;
            users = new Dictionary<string, Person>();
            usersL = new SortedDictionary<string, List<string>>();
        }

        //public static get(), with creating only one instance EVER
        public static Singleton SeInstance
        {
            get { return _seInstance ?? (_seInstance = new Singleton()); }
        }

        public Dictionary<string, Person> GetUsers()
        {
            return users;
        }

        public void AddUser(string key, Person per)
        {
            users.Add(key, per);
        }
        public void AddUsers(string ID, List<string> users)
        {
            usersL.Add(ID, users);
        }

        public List<UserAD> GetDBUsers()
        {
            return repo.GetAllUsers();
        }

        public void addUsers(UserAD user)

        {
            repo.AdUser(user);
        }
    }
}