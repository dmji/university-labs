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
        string rightBorder = "", leftBorder = "";
        bool bConsole = true;

        private void CheckBox_BORDER_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            if(CheckBox_BORDER.IsChecked == true)
            {
                rightBorder = "]";
                leftBorder = "[";
                if(print != null)
                    print.setBorder(leftBorder, rightBorder);
            }
            else
            {
                if(print != null)
                    print.setBorder();
            }
        }

        private void DT_WPF_Checked(object sender, RoutedEventArgs e)
        {
            ClearAll();
            print = new PrinterWPF(MatrixView, (bool)CheckBox_BORDER.IsChecked);
            if(matr != null) 
                matr.Print(print);
        }

        private void DT_CONSOLE_Checked(object sender, RoutedEventArgs e)
        {
            if(bConsole)
            {
                AllocConsole();
                bConsole = false;
            }
            ClearAll();
            print = new ConsolePrinter(leftBorder, rightBorder);
            if(matr != null)
                matr.Print(print);
        }
    }
}