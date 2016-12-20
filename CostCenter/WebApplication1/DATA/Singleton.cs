using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DATA
{
    public sealed class Singleton
    {
        //static Field
        private static Singleton _seInstance = null;
        private int _nCounter = 0;
        private List<string> Messagess;
        // private constructor
        private Singleton() { _nCounter = 1; Messagess = new List<string>(); }

        //public static get(), with creating only one instance EVER
        public static Singleton SeInstance
        {
            get { return _seInstance ?? (_seInstance = new Singleton()); }
        }



        public void addMessage(string v)
        {
            Messagess.Add(v);
        }

        public List<string> GetMessages()
        {
            return Messagess;
        }
    }
}