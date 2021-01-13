using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PriceChecker.Validation.Validators.Contracts;
using PriceChecker.Validation.Validators.Implementations;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PriceChecker.Validation.Behavior
{
    public class ValidationBehavior : Behavior<View>
    {
     
        
        IErrorStyle _style = new BasicErrorStyle();
        View _view;

        public string PropertyName { get; set; }


        //  public ValidationGroupBehavior Group { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public ObservableCollection<IValidator> Validators { get; set; } = new ObservableCollection<IValidator>();
#pragma warning restore CA2227 // Collection properties should be read only


        public bool Validate()
        {

           bool  isValid = true;    
            string errorMessage = "";

           
            foreach (IValidator validator in Validators)
            {
                bool result = validator.check(_view.GetType()
                                       .GetProperty(PropertyName)
                                       .GetValue(_view) as string);
                isValid = isValid && result;


                if (!result)
                {
                    errorMessage = validator.Message;
                    break;
                }
            }

            if (!isValid)
            {
                _style.ShowError(_view, errorMessage);

                return false;
            }
            else
            {
                _style.RemoveError(_view);

                return true;
            }

        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            _view = bindable as View;
            _view.PropertyChanged += OnPropertyChanged;
            _view.Unfocused += OnUnFocused;

          
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);

            _view.PropertyChanged -= OnPropertyChanged;
            _view.Unfocused -= OnUnFocused;

        
        }

        void OnUnFocused(object sender, FocusEventArgs e)
        {
            Validate();

        
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName)
            {
                Validate();
            }
        }
    }
}

