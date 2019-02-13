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
        private List<AnswerQuestionLine> aqlines;
        private bool isMoved = false;
        private Point p;

        public MainWindow()
        {
            aqlines = new List<AnswerQuestionLine>();
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

                control.SetValue(Canvas.LeftProperty, item.X + 400);
                control.SetValue(Canvas.TopProperty, item.Y + 400);
            }
            CreateLines();
        }
        
        private void CreateLines()
        {
            var questionControlList = new List<QuestionControl>();

            foreach (var item in canvas.Children)
                if (item is QuestionControl)
                    questionControlList.Add(item as QuestionControl);
             
            for(var i = 0; i < questionControlList.Count; i++)
            {
                var currentQuestionControl = questionControlList[i];
                var currentQuestion = currentQuestionControl.Question;
                var answers = App.TestContext.Answers.Where(a => a.Question.Id == currentQuestion.Id).ToList();
                foreach(var item in answers)
                {
                    for (var j = 0; j < questionControlList.Count; j++)
                    {
                        var targetQuestionControl = questionControlList[j];
                        var targetQuestion = targetQuestionControl.Question;
                        if(item.NextQuestion != null)
                        {
                            if (item.NextQuestion.Id == targetQuestion.Id)
                            {
                                var line = new Line()
                                {
                                    Stroke = Brushes.Black,
                                    StrokeDashArray = { 10, 4 },
                                    StrokeThickness = 1,
                                    X1 = (double)currentQuestionControl.GetValue(Canvas.LeftProperty) + 400,
                                    Y1 = (double)currentQuestionControl.GetValue(Canvas.TopProperty) + 400,
                                    X2 = (double)targetQuestionControl.GetValue(Canvas.LeftProperty),
                                    Y2 = (double)targetQuestionControl.GetValue(Canvas.TopProperty),
                                };
                                canvas.Children.Add(line);
                                aqlines.Add(new AnswerQuestionLine()
                                {
                                    Question1 = currentQuestionControl,
                                    Question2 = targetQuestionControl,
                                    Line = line,
                                });
                            }
                        }
                    }
                }
            }
        }

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
                    var q1 = aqlines.Find(aql => aql.Question1 == questionControl);
                    if(q1 != null)
                    {
                        q1.Line.X1 = question.X + 400;
                        q1.Line.Y1 = question.Y + 400;
                    }
                    var q2 = aqlines.Find(aql => aql.Question2 == questionControl);
                    if (q2 != null)
                    {
                        q2.Line.X2 = question.X;
                        q2.Line.Y2 = question.Y;
                    }
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
            App.TestContext.SaveChanges();
        }
    }
}
