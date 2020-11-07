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

namespace lab_matrix_bridge_gui
{
    public partial class MainWindow : Window
    {
        class BorderCBClickCommand : ACommands
        {
            MainWindow mw;
            public BorderCBClickCommand(MainWindow m)
            {
                mw = m;
            }
            public override lab_matrix_bridge.ICommand Clone() => new BorderCBClickCommand(mw);
            protected override void doExecute()
            {
                if(mw.CheckBox_BORDER.IsChecked == true)
                {
                    mw.rightBorder = "]";
                    mw.leftBorder = "[";
                    if(mw.print != null)
                        mw.print.setBorder(mw.leftBorder, mw.rightBorder);
                }
                else
                {
                    if(mw.print != null)
                        mw.print.setBorder();
                }
            }
        }
        class BridgeCommand : ACommands
        {
            MainWindow mw;
            int m_mode;
            public BridgeCommand(MainWindow m,int mode)
            {
                mw = m;
                m_mode = mode;
            }
            public override lab_matrix_bridge.ICommand Clone() => new BridgeCommand(mw,m_mode);
            protected override void doExecute()
            {
                switch(m_mode)
                {
                    case 0:
                        mw.print = new PrinterWPF(mw.MatrixView, (bool)mw.CheckBox_BORDER.IsChecked);
                        break;
                    case 1:
                        {
                            if(mw.bConsole)
                            {
                                AllocConsole();
                                mw.bConsole = false;
                            }
                            mw.print = new ConsolePrinter(mw.leftBorder, mw.rightBorder);
                            break;
                        }
                }
                mw.ApplyMatrix(mw.matr);
            }
        }
    }
}