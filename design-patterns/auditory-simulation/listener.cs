using System;
using System.Collections.Generic;
using System.Text;

namespace auditory_simulation
{
    class Listener
    {
        protected static int id;
        protected string name;
        protected Func<Listener, string> leaver;

        public string Name { get { return name; } }

        public Listener(string Name="Unknown")
        {
            name = Name;
            if (name == "Unknown")
                name += id.ToString();
            id++;
        }

        public virtual void Listen(string info)
        {
            Console.WriteLine($"{this.GetType().Name} \"{name}\" heard: {info}");
            AfterListenDo(info);
        }

        protected virtual void AfterListenDo(string info)
        {

        }

        public bool getFree()
        {
            if (leaver != null)
            {
                leaver(this);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool enterTo(Auditory obj)
        {
            getFree();
            leaver = obj.enter(this);
            if (leaver ==null)
                return false;
            return true;
        }

    }
}
