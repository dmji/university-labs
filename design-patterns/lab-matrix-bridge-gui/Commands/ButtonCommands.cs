﻿using System;
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
        
        class OperationCommand : ACommands
        {
            MainWindow mw;
            int m_mode;
            public OperationCommand(MainWindow m, int mode)
            {
                mw = m;
                m_mode = mode;
            }
            public override lab_matrix_bridge.ICommand Clone() => new OperationCommand(mw,m_mode);
            protected override void doExecute()
            {
                switch(m_mode)
                {
                    case 0:
                        mw.ApplyMatrix(new TransposeMatrix<int>(mw.matr));
                        break;
                    case 1:
                        mw.ApplyMatrix(mw.matr.getOriginal());
                        break;
                }
                
            }
        }
        class RenumbCommand : ACommands
        {
            MainWindow mw;
            int col1, col2, row1, row2;
            public RenumbCommand(MainWindow m, int colFirst=-1, int colSecond=-1, int rowFirst=-1, int rowSecond=-1)
            {
                mw = m;
                col1 = colFirst;
                col2 = colSecond;
                row1 = rowFirst;
                row2 = rowSecond;
            }
            public override lab_matrix_bridge.ICommand Clone() => new RenumbCommand(mw, col1,col2,row1,row2);
            protected override void doExecute()
            {
                ReAssignMatrix<int> mx;
                if(mw.matr is ReAssignMatrix<int>)
                    mx = (ReAssignMatrix<int>)mw.matr;
                else 
                    mx = new ReAssignMatrix<int>(mw.matr);
                if(col1 != -1 && col2 != -1)
                    mx.SwapCols(col1, col2);
                if(row1 != -1 && row2 != -1)
                    mx.SwapRows(row1,row2);
                mw.ApplyMatrix(mx);
            }
        }
    }
}