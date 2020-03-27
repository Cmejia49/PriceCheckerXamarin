﻿using PriceChecker.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceChecker.VIEW
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FrontPage : ContentPage
	{
		public FrontPage ()
		{
			InitializeComponent ();
            this.BindingContext = new TheViewModel(Navigation);
        }
	}
}