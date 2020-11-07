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
using lab_matrix_bridge;
using System.Threading;

namespace lab_matrix_bridge_gui
{
    public partial class MainWindow : Window
    {
        private void MatrixInit(IMatrix<int> mx)
        {
            int nZ = Convert.ToInt32(TB_nZero.Text);
            InicializeMatrix.init(mx, nZ > mx.nCol()*mx.nRow() ? mx.nCol() * mx.nRow() : nZ, Convert.ToInt32(TB_maxRnd.Text));
        }

        private void ApplyMatrix(IMatrix<int> mx)
        {
            matr = mx;
            if(!bConsole)
                Console.Clear();
            MatrixView.Source = null;
            if(print != null && matr != null)
                matr.Print(print);
        }
    }
}