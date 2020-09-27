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

        public string enterTo(Auditory obj)
        {
            getFree();
            leaver = obj.enter(this);
            if (leaver ==null)
                return "NOSPACE";
            sender = obj.Controller(this);
            return "OK";
        }

        public void say(string info)
        {
            if(sender!=null)
            {
                sender(this, info);
            }
        }
    }
}
