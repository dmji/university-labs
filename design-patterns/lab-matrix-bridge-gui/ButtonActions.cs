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
        private void ClearAll()
        {
            if(!bConsole)
                Console.Clear();
            MatrixView.Source = null;
        }
        private void MatrixInit(IMatrix<int> mx)
        {
            int nZ = Convert.ToInt32(TB_nZero.Text);
            InicializeMatrix.init(mx, nZ > mx.nCol()*mx.nRow() ? mx.nCol() * mx.nRow() : nZ, Convert.ToInt32(TB_maxRnd.Text));
        }
        private void BTN_SPARCE_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null)
            {
                matr = new SparseMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(matr);
                matr.Print(print);
            }
        }
        private void BTN_SIMPLE_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null)
            {
                matr = new SimpleMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(matr);
                matr.Print(print);
            }
        }

        private void BTN_SPARCE_Ex_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null && matr!=null)
            {
                HorisontalCompositeMatrix<int> ex;
                if(matr is HorisontalCompositeMatrix<int>)
                    ex = (HorisontalCompositeMatrix<int>)matr;
                else
                    ex = new HorisontalCompositeMatrix<int>(matr);
                SparseMatrix<int> mNew = new SparseMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                ex.Append(mNew);
                matr = ex;
                matr.Print(print);
            }
        }
        private void BTN_SIMPLE_Ex_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print!=null && matr != null)
            {
                HorisontalCompositeMatrix<int> ex;
                if(matr is HorisontalCompositeMatrix<int>)
                    ex = (HorisontalCompositeMatrix<int>)matr;
                else
                    ex = new HorisontalCompositeMatrix<int>(matr);
                SimpleMatrix<int> mNew = new SimpleMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                ex.Append(mNew);
                matr = ex;
                matr.Print(print);
            }
        }

        private void BTN_Restore_Click(object sender, RoutedEventArgs e)
        {
            matr = matr.getOriginal();
            matr.Print(print);
        }

        private void BTN_Transpose_Click(object sender, RoutedEventArgs e)
        {
            matr = new TransposeMatrix<int>(matr);
            matr.Print(print);
        }

        private void BTN_Renumber_Click(object sender, RoutedEventArgs e)
        {
            ReAssignMatrix<int> mx = new ReAssignMatrix<int>(matr);
            Random rnd = new Random();
            mx.SwapCols(rnd.Next(0, mx.nCol()), rnd.Next(0, mx.nCol()));
            mx.SwapRows(rnd.Next(0, mx.nRow()), rnd.Next(0, mx.nRow()));
            matr = mx;
            matr.Print(print);
        }
    }
}