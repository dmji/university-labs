using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace lab1_matrix_bridge
{
    public class PrinterConsole : IPrinter
    {
        public string df { get; set; }
        public string dl { get; set; }
        public PrinterConsole(string begin="", string end="")
        {
            df = begin;
            dl = end;
        }
        public void Print(string a,bool spaceInc=true)
        {            
            if(spaceInc)
                Console.Write(a + " ");
            else
                Console.Write(a);
        }
        public void Print(IVector v)
        {
            Print(df);
            v.Print(this);
            Print(dl+'\n',false);
        }
    }
}
