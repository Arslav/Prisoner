using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prisoner.Test
{
    class AnswerButton : Button
    {
        public Answer Answer { get; set; }

        public AnswerButton(Answer answer)
        {
            Answer = answer;
            Text = answer.Text;
            Clicked += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {

        }
    }
}
