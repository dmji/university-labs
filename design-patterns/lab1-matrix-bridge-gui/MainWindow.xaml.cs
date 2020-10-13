using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using lab1_matrix_bridge;

namespace lab1_matrix_bridge_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        
        bool bconsole = true;
        IMatrix matr=null;
        IPrinter print=null;
        string DL = "", DF = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_SIMPLE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length>0 && TB_maxRnd.Text.Length>0)
            {
                matr = new SimpleMatrix(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                InicializeMatrix.init(matr, Convert.ToInt32(TB_nZero.Text), Convert.ToInt32(TB_maxRnd.Text));
                MatrixSpace.Text = "";
                matr.Print(print);
            }
        }

        private void BTN_SPARCE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0)
            {
                matr = new SparseMatrix(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                InicializeMatrix.init(matr, Convert.ToInt32(TB_nZero.Text), Convert.ToInt32(TB_maxRnd.Text));
                MatrixSpace.Text = "";
                matr.Print(print);
            }
        }

        private void CB_BOUNDS_Click(object sender, RoutedEventArgs e)
        {
            if(CB_BOUNDS.IsChecked == true)
            {
                DL = "]";
                DF = "[";
                if(print != null)
                {
                    print.SetDF(DF);
                    print.SetDL(DL);
                }
            }
            else
            {
                DL = "";
                DF = "";
                if(print != null)
                {
                    print.SetDF(DF);
                    print.SetDL(DL);
                }
            }
        }

        private void DT_WPF_Checked(object sender, RoutedEventArgs e)
        {
            MatrixSpace.Text = "";
            print = new PrinterWPF(MatrixSpace,DF,DL);
            if(matr!=null)
                matr.Print(print);
        }

        private void DT_CONSOLE_Checked(object sender, RoutedEventArgs e)
        {
            if(bconsole) { AllocConsole(); bconsole = false; }
            MatrixSpace.Text = "";
            print = new PrinterConsole(DF,DL);
            if(matr != null)
                matr.Print(print);
        }
    }
}
