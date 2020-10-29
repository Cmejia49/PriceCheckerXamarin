using System;
using System.Collections.Generic;
using System.Text;
using PriceChecker.Validation.Validators.Contracts;
using Xamarin.Forms;

namespace PriceChecker.Validation.Validators.Implementations
{
    public class BasicErrorStyle : IErrorStyle
    {

        public void RemoveError(View view)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            StackLayout layout = view.Parent as StackLayout;
#pragma warning restore CA1062 // Validate arguments of public methods
            int viewIndex = layout.Children.IndexOf(view);

            if (viewIndex + 1 < layout.Children.Count)
            {
                View sibling = layout.Children[viewIndex + 1];
                string siblingStyleId = view.Id.ToString();

                if (sibling.StyleId == siblingStyleId)
                {
                    sibling.IsVisible = false;
                }
            }
        }
        public void ShowError(View view, string message)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            StackLayout layout = view.Parent as StackLayout;
#pragma warning restore CA1062 // Validate arguments of public methods
            int viewIndex = layout.Children.IndexOf(view);

            if (viewIndex + 1 < layout.Children.Count)
            {
                View sibling = layout.Children[viewIndex + 1];
                string siblingStyleId = view.Id.ToString();

                if (sibling.StyleId == siblingStyleId)
                {
                    Label errorLabel = sibling as Label;
                    errorLabel.Text = message;
                    errorLabel.IsVisible = true;

                    return;
                }
            }

            layout.Children.Insert(viewIndex + 1, new Label
            {
                Text = message,
                FontSize = 10,
                StyleId = view.Id.ToString(),
                TextColor = Color.Red
            });

        }
    }
}
