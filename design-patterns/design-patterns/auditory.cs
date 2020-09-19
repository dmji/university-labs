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
        private int id;
        private List<Listener> list;
        private int limiter;

        public Auditory(int Id=0,int limit=0)
        {
            id = Id;
            limiter = limit;
            list = new List<Listener>();
        }
        
        protected string msgSpace(Listener obj, string info)
        {
            Console.Out.NewLine = "\n\t";
            Console.WriteLine($"Auditory {id}: {obj.Name} said: \"{info}\"\n\t  Listeners reaction log begin");
            
            foreach (Listener a in list)
            { 
                if (!a.Equals(obj))
                    a.takeMsg(info);
            }
            Console.Out.NewLine = "\n";
            Console.WriteLine($"  Listeners reaction log end.");
            return "OK";
        }

        public Func<Listener,string, string> takeControl(Listener obj)
        {
            if (obj is Professor)
                return msgSpace;
            else
                return null;
        }

        public Func<Listener, string> enter(Listener obj)
        {
            if (list.Count < limiter || obj is Professor)
            {
                list.Add(obj);
                Console.WriteLine($"Auditory {id}: {obj.Name} entered");
                return leave;
            }
            else
                Console.WriteLine($"Auditory {id}: not enouth space for {obj.Name}");
            return null;
        }
        protected string leave(Listener obj)
        {
            list.Remove(obj);
            Console.WriteLine($"Auditory {id}: {obj.Name} leaved");
            return "OK";
        }
    }
}
