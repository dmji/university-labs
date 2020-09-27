using System;
using System.Collections.Generic;
using System.Text;

namespace auditory_simulation
{
    class Listener
    {
        protected static int id;
        protected string name;
        protected List<Func<Listener, string,bool>> Controls;

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

        public virtual bool getFree()
        {
            if (Controls != null)
            {
                Controls[0](this,null);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool enterTo(Auditory obj)
        {
            getFree();
            Controls = obj.enter(this);
            if (Controls.Count == null)
                return false;
            return true;
        }

    }
}
