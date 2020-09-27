using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace auditory_simulation
{
    class Auditory
    {
        private static int id=0;
        private string name;
        private List<Listener> Listeners;
        private int ListLimiter;

        public Auditory(string Name=null,int limit=0)
        {
            if (Name == null)
                name = id.ToString();
            else
                name = Name;
            ListLimiter = limit;
            Listeners = new List<Listener>();
        }
        
        protected string Echo(Listener obj, string info)
        {
            Console.Out.NewLine = "\n\t";
            Console.WriteLine($"Auditory {name}: {obj.Name} said: \"{info}\"\n\t  Listeners reaction log begin");
            
            foreach (Listener a in Listeners)
            { 
                if (!a.Equals(obj))
                    a.Listen(info);
            }
            Console.Out.NewLine = "\n";
            Console.WriteLine($"  Listeners reaction log end.");
            return "OK";
        }

        public Func<Listener,string, string> Controller(Listener obj)
        {
            if (obj is Professor)
                return Echo;
            else
                return null;
        }

        public Func<Listener, string> enter(Listener obj)
        {
            if (Listeners.Count < ListLimiter || obj is Professor)
            {
                Listeners.Add(obj);
                Console.WriteLine($"Auditory {name}: {obj.Name} entered");
                return leave;
            }
            else
                Console.WriteLine($"Auditory {name}: not enouth space for {obj.Name}");
            return null;
        }
        protected string leave(Listener obj)
        {
            Listeners.Remove(obj);
            Console.WriteLine($"Auditory {name}: {obj.Name} leaved");
            return "OK";
        }
    }
}
