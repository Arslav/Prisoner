﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prisoner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
		}

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TestPage(1);
        }
    }
}