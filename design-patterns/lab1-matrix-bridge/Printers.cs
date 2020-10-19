using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace lab1_matrix_bridge
{
    public interface IPrinter
    {
        public void PrintBoard();
        public void NewLine();
        void Print(object m);
        void setAF(string a);
        void setAL(string a);
        void setEF(string a);
        void setEL(string a);
    }
    
    public class PrinterConsole : IPrinter
    {
        bool A=true;
        bool E=true;
        string AF;
        string AL;
        string EF;
        string EL;
        public PrinterConsole(string bF="", string bL="", string ebF="", string ebL="")
        {
            AF = bF+" ";
            AL = bL;
            EF = ebF;
            EL = ebL;
        }

        public void PrintBoard() 
        {
            Console.Write(A ? AF : AL);
            A = !A;
        }
        private void PrintBoardElement()
        {
            Console.Write(E ? EF : EL);
            E = !E;
        }
        public void Print(object m)
        {
            PrintBoardElement();
            Console.Write(m.ToString() + ' ');
            PrintBoardElement();
        }
        void IPrinter.NewLine()
        {
            Console.WriteLine();
        }

        public void setAF(string a)
        { 
            AF = a; 
        }
        public void setAL(string a)
        {
            AL = a;
        }
        public void setEF(string a)
        {
            EF = a;
        }
        public void setEL(string a)
        {
            EL = a;
        }
    }
}
