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
        class MatrixCommand : ACommands
        {
            MainWindow mw;
            IMatrix<int> mx;
            int m_Append;
            public MatrixCommand(MainWindow m, IMatrix<int> matr, int append = 0)
            {
                mw = m;
                mx = matr.Clone();
                m_Append = append;
            }
            public override lab_matrix_bridge.ICommand Clone() => new MatrixCommand(mw, mx.Clone(), m_Append);
            protected override void doExecute()
            {
                HorisontalCompositeMatrix<int> ex;
                IMatrix<int> res=mx;
                switch(m_Append)
                {
                    case 1:
                        if(mw.matr is HorisontalCompositeMatrix<int>)
                            ex = (HorisontalCompositeMatrix<int>)mw.matr;
                        else
                            ex = new HorisontalCompositeMatrix<int>(mw.matr);
                        ex.Append(mx);
                        res = ex;
                        break;
                    case 2:
                        if(mw.matr is HorisontalCompositeMatrix<int>)
                        {
                            ex = (HorisontalCompositeMatrix<int>)mw.matr;
                            ex.TransponceGroup();
                        }
                        else
                            ex = new HorisontalCompositeMatrix<int>(new TransposeMatrix<int>(mw.matr));
                        HorisontalCompositeMatrix<int> hex =new HorisontalCompositeMatrix<int>(new TransposeMatrix<int>(ex));
                        hex.Append(new TransposeMatrix<int>(mx));

                        res = new TransposeMatrix<int>(hex);
                        ex.TransponceGroup();
                        break;
                }
                mw.ApplyMatrix(res);
            }
        }
    }
}