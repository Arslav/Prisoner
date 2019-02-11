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
	public partial class EndPage : ContentPage
	{
		public EndPage()
		{
			InitializeComponent ();
		}

        public EndPage(int? id) : this()
        {
            var result = App.DB.Results.First(r => r.Id == id);
            descLabel.Text = result.Text;
            posLabel.Text = result.Name;
        }

        private void AgainBut_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new StartPage();
        }
    }
}