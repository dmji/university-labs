using System.Windows.Controls;
using lab1_matrix_bridge;

namespace lab1_matrix_bridge_gui
{
    public class PrinterWPF : IPrinter
    {
        bool A = true;
        bool E = true;
        string AF;
        string AL;
        string EF;
        string EL;
        Grid t;

        public PrinterWPF(Grid p,string bF = "", string bL = "", string ebF = "", string ebL = "")
        {
            AF = bF + " ";
            AL = bL;
            EF = ebF;
            EL = ebL;
            t = p;
        }

        public void PrintBoard(bool bNoSkipSign = true)
        {
            t.Resources.Add()
            t.Text+=(A ? AF : AL);
            A = !A;
        }
        public void PrintBoardElement(bool bNoSkipSign = true)
        {
            t.Text+=(E ? EF : EL);
            E = !E;
        }
        public void Print<T>(T m)
        {
            PrintBoardElement();
            t.Text+=(m.ToString() + ' ');
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