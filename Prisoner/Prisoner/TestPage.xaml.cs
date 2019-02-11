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
        public TestPage()
        {
            InitializeComponent();

            var question = App.DB.Questions.First(q => q.Id == 1);
            var answers = App.DB.Answers.Where(a => a.Question == question);
            foreach(var ans in answers)
            {
                answersStackLayout.Children.Add(new AnswerButton(ans));
            }
            questionLabel.Text = question.Text;


        }
    }
}
