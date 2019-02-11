using Prisoner.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prisoner
{
    public partial class TestPage : ContentPage
    {
        public string Appeal { get; set; }
        public TestPage()
        {
            InitializeComponent();
        }

        public TestPage(int id) : this(App.DB.Questions.First(q => q.Id == id)) { }

        public TestPage(Question question) : this()
        {
            var answers = App.DB.Answers.Where(a => a.Question.Id == question.Id);
            foreach (var ans in answers)
            {
                answersStackLayout.Children.Add(new AnswerButton(ans));
            }
            questionLabel.Text = question.Text;
        }
    }
}
