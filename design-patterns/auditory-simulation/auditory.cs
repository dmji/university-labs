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
        protected static int id = 0;
        protected string name;
        protected List<Listener> Listeners;
        protected int ListLimiter;
        protected static List<List<Func<Listener, string, bool>>> controlTable = null;

        public Auditory(string Name = null, int limit = 0)
        {
            if (controlTable == null)
                initTable();
            if (Name == null)
                name = id.ToString();
            else
                name = Name;
            ListLimiter = limit;
            Listeners = new List<Listener>();
        }

        public Func<Listener, string, bool> Controller(Listener obj)
        {
            if (obj is Professor)
                return Echo;
            else
                return null;
        }

        public List<Func<Listener, string, bool>> enter(Listener obj)
        {
            if (Listeners.Count < ListLimiter || obj is Professor)
            {
                Listeners.Add(obj);
                Console.WriteLine($"Auditory {name}: {obj.Name} entered");
                return control(obj);
            }
            else
                Console.WriteLine($"Auditory {name}: not enouth space for {obj.Name}");
            return null;
        }

        protected bool leave(Listener obj, string reason = null)
        {
            Listeners.Remove(obj);
            Console.WriteLine($"Auditory {name}: {obj.Name} leaved");
            return true;
        }

        protected bool getEmpty(Listener a = null, string b = null)
        {
            while (Listeners.Count > 0)
                Listeners[0].getFree();
            return true;
        }
        protected bool Echo(Listener obj, string info)
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
            return true;
        }

        protected List<Func<Listener,string,bool>> control(Listener obj)
        {
            if (obj is Students)
                return controlTable[0];
            if (obj is Professor)
                return controlTable[1];
            return null;
        }

        protected void initTable()
        {
            controlTable = new List<List<Func<Listener, string, bool>>>();
            controlTable.Add(new List<Func<Listener,string, bool>>());
            controlTable[0].Add(leave);
            controlTable.Add(new List<Func<Listener,string, bool>>(controlTable[0]));
            controlTable[1].Add(Echo);
            controlTable[1].Add(getEmpty);
            
        }
    }
}
