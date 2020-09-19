using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace auditory_simulation
{
    class Students : Listener
    {
        public Students(string Name):base(Name) {}

        public override void takeMsg(string info) 
        {
            base.takeMsg(info);
            Console.WriteLine($"{this.GetType().Name} \"{name}\" wrote: {info}");
        }
    }
}
