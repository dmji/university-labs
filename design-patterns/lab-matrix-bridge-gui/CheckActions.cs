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

namespace lab_matrix_bridge_gui
{
    public partial class MainWindow : Window
    {
        string rightBorder = "", leftBorder = "";
        bool bConsole = true;

        private void CheckBox_BORDER_Click(object sender, RoutedEventArgs e)
        {
            new BorderCBClickCommand(this).Execute();
        }

        private void DT_WPF_Checked(object sender, RoutedEventArgs e)
        {
            new BridgeCommand(this, 0).Execute();
        }

        private void DT_CONSOLE_Checked(object sender, RoutedEventArgs e)
        {
            new BridgeCommand(this, 1).Execute();
        }
    }
}