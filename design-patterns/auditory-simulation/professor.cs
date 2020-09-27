using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace auditory_simulation
{
    class Professor : Listener
    {
        public Professor(string Name):base(Name) {}


        public bool say(string info)
        {
            return Controls[1](this, info);
        }

        public bool ReleaseRoom()
        {
            return Controls[2](null, null);

        }
    }
}
