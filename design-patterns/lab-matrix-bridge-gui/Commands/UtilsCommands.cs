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
        class UtilCommand : ACommands
        {
            MainWindow mw;
            Func<MainWindow, string, bool> m_fn;
            string m_val;
            public UtilCommand(MainWindow m, string sval, Func<MainWindow, string, bool> fn)
            {
                mw = m;
                m_val = sval;
                m_fn = fn;
            }
            public override lab_matrix_bridge.ICommand Clone() => new UtilCommand(mw, m_val, m_fn);
            protected override void doExecute()
            {
                m_fn(mw, m_val);
            }
        }
        class BackupCommand : ACommands
        {
            MainWindow mw;
            IMatrix<int> m_mx;
            string m_nROW;
            string m_nCOL;
            string m_nZero;
            string m_maxRnd;
            string m_left;
            string m_right;
            bool bBorder;
            int bridge;
            public BackupCommand(MainWindow m, IMatrix<int> mx, string nROW, string nCOL, string nZero, string maxRnd, bool Border, int Bridge, string right, string left)
            {
                mw = m;
                m_mx = mx == null ? null : mx.Clone();
                m_nROW = nROW;
                m_nCOL = nCOL;
                m_nZero = nZero;
                m_maxRnd = maxRnd;
                bBorder = Border;
                bridge = Bridge;
                m_right = right;
                m_left = left;
            }
            public override lab_matrix_bridge.ICommand Clone() => new BackupCommand(mw, m_mx, m_nROW, m_nCOL, m_nZero, m_maxRnd, bBorder, bridge, m_right, m_left);
            protected override void doExecute()
            {
                mw.TB_nROW.Text = m_nROW;
                mw.TB_nCOL.Text = m_nCOL;
                mw.TB_nZero.Text = m_nZero;
                mw.TB_maxRnd.Text = m_maxRnd;
                mw.rightBorder = m_right;
                mw.leftBorder = m_left;
                mw.CheckBox_BORDER.IsChecked = bBorder;
                switch(bridge)
                {
                    case 0:
                        mw.DT_WPF.IsChecked = true;
                        break;
                    case 1:
                        mw.DT_CONSOLE.IsChecked = true;
                        break;
                }
                if(m_mx == null) mw.ApplyMatrix(m_mx); else mw.ApplyMatrix(m_mx.Clone());
            }
        }
    }
}