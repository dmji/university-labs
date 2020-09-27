using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace auditory_simulation
{
    class Magiters : Students
    {
        public Magiters(string Name):base(Name) {}
        private bool log = true;

        protected override void AfterListenDo(string info)
        {
            if (log)
                Console.WriteLine($"{this.GetType().Name} \"{name}\" wrote: {info}");
            log = !log;
        }
    }
}
