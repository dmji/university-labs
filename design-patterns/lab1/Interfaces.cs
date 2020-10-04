using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public interface IPrinter
    {
        void Print(string obj);
        void Print(char obj);
    }

    public interface IPrinterDelegate : IPrinter
    {
        public void Print(IPrintable obj);
    }

    public interface IPrintable
    {
        void Print(IPrinter obj);
    }

}
