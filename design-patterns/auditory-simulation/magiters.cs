using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace auditory_simulation
{
    class Magiters : Listener
    {
        public Magiters(string Name):base(Name) {}
        private bool log = true;

        public override void takeMsg(string info)
        {
            base.takeMsg(info);
            if (log)
                Console.WriteLine($"{this.GetType().Name} \"{name}\" wrote: {info}");
            log = !log;
        }
    }
}
