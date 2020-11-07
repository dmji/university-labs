using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using lab_matrix_bridge;

namespace lab_matrix_bridge_gui
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

        IMatrix<int> matr=null;
        IPrinter print=null;

        public MainWindow()
        {
            InitializeComponent();
            new BackupCommand(this,matr, TB_nROW.Text, TB_nCOL.Text,TB_nZero.Text,TB_maxRnd.Text,(bool)CheckBox_BORDER.IsChecked,/*(bool)DT_CONSOLE.IsChecked ? 1 :*/ 0, rightBorder, leftBorder).Execute();
        }

        private void TB_nROW_TextChanged(object sender, TextChangedEventArgs e)
        {
            new UtilCommand(this, TB_nROW.Text, (MainWindow mw,string s) => { mw.TB_nROW.Text = s; return false; }).Execute();
        }

        private void TB_nCOL_TextChanged(object sender, TextChangedEventArgs e)
        {
            new UtilCommand(this, TB_nCOL.Text, (MainWindow mw, string s) => { mw.TB_nCOL.Text = s; return false; }).Execute();
        }

        private void TB_nZero_TextChanged(object sender, TextChangedEventArgs e)
        {
            new UtilCommand(this, TB_nZero.Text, (MainWindow mw, string s) => { mw.TB_nZero.Text = s; return false; }).Execute();
        }

        private void TB_maxRnd_TextChanged(object sender, TextChangedEventArgs e)
        {
            new UtilCommand(this, TB_maxRnd.Text, (MainWindow mw, string s) => { mw.TB_maxRnd.Text = s; return false; }).Execute();
        }
    }
}
