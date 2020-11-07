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
        private void BTN_SPARCE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null)
            {
                SparseMatrix<int> mx = new SparseMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mx);
                new MatrixCommand(this, mx).Execute();
            }
        }
        private void BTN_SIMPLE_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null)
            {
                SimpleMatrix<int> mx = new SimpleMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mx);
                new MatrixCommand(this, mx).Execute();
            }
        }
        private void BTN_Undo_Click(object sender, RoutedEventArgs e)
        {
            lab_matrix_bridge.CommandManager.GetInstance().Undo();
        }
        private void BTN_SPARCE_ExDown_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null && matr != null)
            {
                SparseMatrix<int> mNew = new SparseMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                new MatrixCommand(this, mNew, 2).Execute();
            }
        }
        private void BTN_SIMPLE_ExDown_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null && matr != null)
            {
                SimpleMatrix<int> mNew = new SimpleMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                new MatrixCommand(this, mNew, 2).Execute();
            }
        }
        private void BTN_SPARCE_Ex_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print != null && matr!=null)
            {
                SparseMatrix<int> mNew = new SparseMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                new MatrixCommand(this, mNew, 1).Execute();
            }
        }
        private void BTN_SIMPLE_Ex_Click(object sender, RoutedEventArgs e)
        {
            if(TB_nCOL.Text.Length > 0 && TB_nROW.Text.Length > 0 && TB_nZero.Text.Length > 0 && TB_maxRnd.Text.Length > 0 && print!=null && matr != null)
            {
                SimpleMatrix<int> mNew = new SimpleMatrix<int>(Convert.ToInt32(TB_nROW.Text), Convert.ToInt32(TB_nCOL.Text));
                MatrixInit(mNew);
                new MatrixCommand(this, mNew, 1).Execute();
            }
        }
        private void BTN_Restore_Click(object sender, RoutedEventArgs e)
        {
            new OperationCommand(this,1).Execute();
        }
        private void BTN_Transpose_Click(object sender, RoutedEventArgs e)
        {
            new OperationCommand(this,0).Execute();
        }
        private void BTN_Renumber_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            new RenumbCommand(this, rnd.Next(0, matr.nCol()), rnd.Next(0, matr.nCol()), rnd.Next(0, matr.nRow()), rnd.Next(0, matr.nRow())).Execute();
        }
    }
}