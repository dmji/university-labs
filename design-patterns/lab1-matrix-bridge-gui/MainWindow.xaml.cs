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
using lab1_matrix_bridge;

namespace lab1_matrix_bridge_gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IMatrix matr;
        IPrinter print;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_SIMPLE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0)
                matr = new SimpleMatrix(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL));
        }

        private void BTN_SPARCE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0)
                matr = new SparseMatrix(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL));
        }

        private void CB_BOUNDS_Click(object sender, RoutedEventArgs e)
        {
            if(CB_BOUNDS.IsChecked == true)
            {

            }
        }

        private void DT_WPF_Checked(object sender, RoutedEventArgs e)
        {
            print = new PrinterWPF(MatrixSpace);
        }
    }
}
