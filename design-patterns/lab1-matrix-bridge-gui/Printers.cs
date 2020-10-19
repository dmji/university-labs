using System;
using System.Collections.Generic;
using System.Text;
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
        TextBlock t;

        public PrinterWPF(TextBlock p,string bF = "", string bL = "", string ebF = "", string ebL = "")
        {
            AF = bF + " ";
            AL = bL;
            EF = ebF;
            EL = ebL;
            t = p;
        }

        public void PrintBoard()
        {
            t.Text+=(A ? AF : AL);
            A = !A;
        }
        private void PrintBoardElement()
        {
            t.Text+=(E ? EF : EL);
            E = !E;
        }
        public void Print(object m)
        {
            PrintBoardElement();
            t.Text+=(m.ToString() + ' ');
            PrintBoardElement();
        }
        void IPrinter.NewLine()
        {
            t.Text += "\n";
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