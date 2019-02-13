using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Prisoner.Test
{
    class AnswerButton : Button
    {
        public Answer Answer { get; set; }

        private readonly Random _rand;

        public AnswerButton(Answer answer)
        {
            Answer = answer;
            Text = answer.Text;
            Clicked += OnClick;
            _rand = new Random();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (Answer.Result == null)
            {
                if(Answer.NextQuestion == null)
                {
                    var state = Answer.Question.State + 1;
                    var list = App.DB.Questions.Where(q => q.State == state).ToList();
                    var question = list.ElementAt(_rand.Next(list.Count()));
                    App.Current.MainPage = new TestPage(question)
                    {
                        Appeal = Answer.ResultText
                    };
                    return;
                }
                else
                {
                    App.Current.MainPage = new TestPage(Answer.NextQuestion)
                    {
                        Appeal = Answer.ResultText
                    };
                    return;
                }
            }
            App.Current.MainPage = new ResultPage(Answer);
        }
    }
}
