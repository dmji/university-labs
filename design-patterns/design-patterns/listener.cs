using System;
using System.Collections.Generic;
using System.Text;

namespace auditory_simulation
{
    class Listener
    {
        protected string name;
        protected Func<Listener, string> leaver;

        public string Name { get { return name; } }

        public Listener(string Name)
        {
            name = Name;
        }

        public virtual void takeMsg(string info)
        {
            Console.WriteLine($"{this.GetType().Name} \"{name}\" heard: {info}");
        }

        public string getFree()
        {
            if (leaver != null)
            {
                leaver(this);
                return "OK";
            }
            else
            {
                return "ALREADYFREE";
            }
        }

        public string enterTo(Auditory obj)
        {
            getFree();
            leaver = obj.enter(this);
            if (leaver ==null)
                return "NOSPACE";
            return "OK";
        }

    }
}
