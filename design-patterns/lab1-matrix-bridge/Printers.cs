using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace lab1_matrix_bridge
{
    public interface IPrinter
    {
        void Print(string a, bool spaceInc = true);
        void Print(IBaseElement m);
        void SetDF(string df);
        void SetDL(string dl);
    }

    public class PrinterConsole : IPrinter
    {
        string df;
        string dl;

        public void SetDF(string DF) { df = DF; }
        public void SetDL(string DL) { dl = DL; }
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

        public void Print(IBaseElement v)
        {
            if(v is IVector)
            {
                Print(df);
                v.Print(this);
                Print(dl + '\n', false);
            }
            else
                v.Print(this);
        }
    }
}
