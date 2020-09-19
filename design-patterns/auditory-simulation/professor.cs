using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace auditory_simulation
{
    class Professor : Listener
    {
        public Professor(string Name):base(Name) {}
        protected Func<Listener,string, string> sender = null; 

        public override void takeMsg(string info) 
        {
            base.takeMsg(info);
            Console.WriteLine($"{this.GetType().Name} \"{name}\" wrote: {info}");
        }

        public string enterTo(Auditory obj)
        {
            getFree();
            leaver = obj.enter(this);
            if (leaver ==null)
                return "NOSPACE";
            sender = obj.takeControl(this);
            return "OK";
        }

        public void sendMsg(string info)
        {
            if(sender!=null)
            {
                sender(this, info);
            }
        }
    }
}
