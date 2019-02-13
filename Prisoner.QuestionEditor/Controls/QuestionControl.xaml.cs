using Prisoner.Test;
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

namespace Prisoner.QuestionEditor.Controls
{
    /// <summary>
    /// Логика взаимодействия для QuestionControl.xaml
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        private Question question;
        public Question Question
        {
            get => question;
            set
            {
                question = value;
                questionLabel.Content = $"Вопрос Id={Question.Id}";
                questionTextBox.Text = question.Text;
                try
                {
                    var list = App.TestContext.Answers.Where(a => a.Question.Id == question.Id).ToList();
                    foreach(var item in list)
                    {
                        questionStack.Children.Add(new AnswerControl(item));
                    }
                }
                catch { }

            }
        }
        public QuestionControl()
        {
            InitializeComponent();
            Question = new Question();
        }

        public QuestionControl(Question question)
        {
            InitializeComponent();
            Question = question;
        }

        public void Save()
        {
         /*   var element = App.TestContext.Questions.Where(q => q.Id == question.Id).First();
            element.Id = question.Id;
            element.*/
        }
    }
}
