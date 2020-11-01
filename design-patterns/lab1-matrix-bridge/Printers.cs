using System;

namespace lab1_matrix_bridge
{
    public interface IPrinter
    {
        void PrintBoard(bool bNoSkipSign = true);
        void PrintBoardElement(bool bNoSkipSign = true);
        void Print<T>(T m);
        void setAF(string a);
        void setAL(string a);
        void setEF(string a);
        void setEL(string a);
    }
    
    public class PrinterConsole : IPrinter
    {
        bool A = true, E = true;
        string AF, AL, EF, EL;

        public PrinterConsole(string bF="", string bL="", string ebF="", string ebL="")
        {
            AF = bF+" ";
            AL = bL;
            EF = ebF;
            EL = ebL;
        }

        public void PrintBoard(bool bNoSkipSign = true) 
        {
            if(bNoSkipSign)
                Console.Write(A ? AF : AL+"\n");
            A = !A;
        }
        public void PrintBoardElement(bool bNoSkipSign = true)
        {
            if(bNoSkipSign)
                Console.Write(E ? EF : EL);
            E = !E;
        }
        public void Print<T>(T m)
        {
            PrintBoardElement();
            Console.Write(m.ToString() + ' ');
            PrintBoardElement();
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
