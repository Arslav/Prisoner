using Prisoner.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prisoner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
        private Answer _answer;

		public ResultPage ()
		{
			InitializeComponent ();
		}

        public ResultPage(Answer answer) : this()
        {
            resultLabel.Text = answer.ResultText;
            _answer = answer;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            App.Current.MainPage = new EndPage(_answer.Result);
        }
	}
}