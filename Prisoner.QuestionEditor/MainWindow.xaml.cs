using Prisoner.QuestionEditor.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Prisoner.QuestionEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            panzomm.PanButton = PanAndZoom.ButtonName.Middle;
        }

        private void Windows_Loaded(object sender, EventArgs e)
        {
            var list = App.TestContext.Questions.ToList();
            foreach (var item in list)
            {
                var control = new QuestionControl(item);
                control.PreviewMouseDown += Element_MouseDown;
                control.PreviewMouseUp += Element_MouseUp;
                control.PreviewMouseMove += Element_MouseMove;
                canvas.Children.Add(control);
                control.SetValue(Canvas.LeftProperty, item.X);
                control.SetValue(Canvas.TopProperty, item.Y);
            }
        }

        bool isMoved = false;

        private Point p;

        private void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var c = sender as Control;
                isMoved = true;
                p = Mouse.GetPosition(c);
            }
        }
        private void Element_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {  
                isMoved = false;
            }
        }
        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoved)
            {
                if (sender is QuestionControl)
                {
                    var questionControl = sender as QuestionControl;
                    var question = questionControl.Question;
                    question.X = e.GetPosition(canvas).X - p.X;
                    question.Y = e.GetPosition(canvas).Y - p.Y;
                    questionControl.SetValue(Canvas.LeftProperty, question.X);
                    questionControl.SetValue(Canvas.TopProperty, question.Y);
                }
            }
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            var resultWindow = new ResultWindow();
            resultWindow.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            /*foreach(var item in canvas.Children)
            {
                if(item is QuestionControl)
                {
                    item.Save();
                }
            }*/
            App.TestContext.SaveChanges();
        }
    }
}
