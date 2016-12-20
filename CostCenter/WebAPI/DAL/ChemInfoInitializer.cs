using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DAL
{
    public class ChemInfoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ChemInfoContext>

    {
        protected override void Seed(ChemInfoContext context)
        {
            var persons = new List<Person>();
            for (int i = 0; i < 3000; i++)
            {

                Person per = new Person
                {
                    ID = 10 + i,
                    Name = "Adi Works " + i.ToString(),
                    Position = "Same" + i.ToString(),
                    Office = "Dubai" + i.ToString(),
                    ChemCost = "44646 IT" + i.ToString(),
                    FMCCost = " Not implemented " + i.ToString(),
                    Phone = "46446" + i.ToString()
                };
                persons.Add(per);      
            }
            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();
        }
    }
}