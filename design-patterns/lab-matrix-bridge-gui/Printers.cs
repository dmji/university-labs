using System.Windows.Controls;
using lab_matrix_bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data;
using System.Globalization;

namespace lab_matrix_bridge_gui
{
    public class PrinterWPF : IPrinter
    {
        Image t;
        bool bElemendBorder = false, bBorder = false, bBorderActive = false;
        List<stack> toRelease = new List<stack>();
        int padding = 0;

        struct stack
        {
            static Brush GetColor(int i)
            {
                switch(i % 11)
                {
                    case 0:
                        return Brushes.Black;
                    case 1:
                        return Brushes.Red;
                    case 2:
                        return Brushes.Green;
                    case 3:
                        return Brushes.Brown;
                    case 4:
                        return Brushes.Blue;
                    case 5:
                        return Brushes.Orange;
                    case 6:
                        return Brushes.Salmon;
                    case 7:
                        return Brushes.Plum;
                    case 8:
                        return Brushes.Pink;
                    case 9:
                        return Brushes.Khaki;
                    case 10:
                        return Brushes.Silver;
                    default:
                        return Brushes.Black;
                }

            }
            public string val;
            public int group;
            public stack(string value, int group)
            {
                val = value;
                this.group = group;
            }
            public void Print(ref DrawingContext drawingContext, double startX, ref double X, ref double Y, double FontSize, int padding, double curTextWidth, double curTextHeight)
            {
                if(val.Contains('\n'))
                {
                    Y += curTextHeight + 1;
                    X = startX;
                }
                else
                {
                    FormattedText text = new FormattedText(val,
                       new CultureInfo("en-us"),
                       FlowDirection.LeftToRight,
                       new Typeface(""),
                       FontSize,
                       GetColor(group));
                    text.TextAlignment = TextAlignment.Right;
                    drawingContext.DrawText(text, new Point(X, Y));
                    X += curTextWidth * (padding + 2);
                    curTextHeight = text.Height;
                }
            }
        }

        public PrinterWPF(Image p, bool border = false, bool elementBorder = false)
        {
            t = p;
            bBorder = border;
            bElemendBorder = elementBorder;
        }

        public void ReleasePrint()
        {
            var dpiX = 96.0 * VisualTreeHelper.GetDpi(t).DpiScaleX;
            var dpiY = 96.0 * VisualTreeHelper.GetDpi(t).DpiScaleY;
            double FontSize = 12,
                startX = 30, startY = 20,
                curX = 30, curY = 20,
                maxX = 0,
                curTextHeight = new FormattedText("0", new CultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(""), FontSize, Brushes.Black).Height,
                curTextWidth = new FormattedText("0", new CultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface(""), FontSize, Brushes.Black).Width
                ;
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)t.Width, (int)t.Height, dpiX, dpiY, PixelFormats.Pbgra32);
            DrawingVisual drawingVisual = new DrawingVisual();

            DrawingContext drawingContext = drawingVisual.RenderOpen();
            foreach(stack a in toRelease)
            {
                a.Print(ref drawingContext, startX, ref curX, ref curY, FontSize, padding, curTextWidth, curTextHeight);
                if(maxX < curX) maxX = curX;
            }
            if(bBorder)
            {
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 2), new Rect(startX - padding * curTextWidth - 15, startY, 2, curY - curTextHeight));
                drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 2), new Rect(maxX, startY, 2, curY - curTextHeight));
            }
            drawingContext.Close();
            bmp.Render(drawingVisual);
            t.Source = bmp;
            t.UpdateLayout();
            toRelease.Clear();
        }

        public void PrintBorder()
        {
            if(bBorderActive)
                toRelease.Add(new stack("\n", 0));
            bBorderActive = !bBorderActive;
        }

        public void PrintBorderElement()
        {
        }

        public void Print<T>(T m, int group = 0)
        {
            if(padding < m.ToString().Length)
                padding = m.ToString().Length;
            toRelease.Add(new stack(m.ToString(), group));
        }

        public void setElementBorder(string left = "", string right = "")
        {
        }

        public void setBorder(string left = "", string right = "")
        {
            bBorder = left != "" || right != "";
        }
    }
}