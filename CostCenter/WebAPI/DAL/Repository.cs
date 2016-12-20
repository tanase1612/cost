using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class Repository
    {
        public List<Person> GetAll()
        {
            using (var db = new ChemInfoContext())
            {
                return db.Persons.ToList();
            }
        }
    }
}