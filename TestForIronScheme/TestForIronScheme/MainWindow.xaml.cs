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

namespace TestForIronScheme
{

    using IronScheme; // the extension methods are exported from this namespace
    using Newtonsoft.Json;
    public class SchemeHandler
    {
        public object Evaluate(string input)
        {
            return input.Eval(); // calls IronScheme.RuntimeExtensions.Eval(string)
        }
    }
    public partial class Window1 : Window
    {
        private SchemeHandler schemeHandler;
        public Window1()
        {
            InitializeComponent();
            schemeHandler = new SchemeHandler();
            //string text = System.IO.File.ReadAllText(@"D:\Dropbox\IHA\Civ 1.semester\Paradigms\ComprehensionTest.ss");
            //schemeHandler.Evaluate(text);
        }

        private void Input_KeyUp(object sender, KeyEventArgs e)
        {
            if (/*(Keyboard.Modifiers == ModifierKeys.Control) && */(e.Key == Key.Enter))
            {
                try
                {
                    DisplayArea.Text = schemeHandler.Evaluate(Input.Text).ToString();
                }
                catch(Exception ex)
                {
                    var json = JsonConvert.SerializeObject(ex, Formatting.Indented);
                    DisplayArea.Text = json;
                }
            }
        }

        private void makeDot(double x, double y)
        {
            var centerX = myCanvas.ActualWidth / 2;
            var centerY = myCanvas.ActualHeight / 2;

            var myLine1 = new Line();
            myLine1.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine1.X1 = centerX - 30;
            myLine1.X2 = centerX + 30;
            myLine1.Y1 = centerY + 0;
            myLine1.Y2 = centerY + 0;

            myLine1.StrokeThickness = 1;
            myCanvas.Children.Add(myLine1);

            var myLine2 = new Line();
            myLine2.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine2.X1 = centerX + 0;
            myLine2.X2 = centerX + 0;
            myLine2.Y1 = centerY - 30;
            myLine2.Y2 = centerY + 30;

            myLine2.StrokeThickness = 1;
            myCanvas.Children.Add(myLine2);

            Ellipse myEllipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.Red;
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 1;
            myEllipse.Stroke = Brushes.White;
            myEllipse.Width = 5;
            myEllipse.Height = 5;
            Canvas.SetTop(myEllipse, centerY - y);
            Canvas.SetLeft(myEllipse, centerX + x);
            myCanvas.Children.Add(myEllipse);
        }
    }
}
