using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PriceChecker.VIEWMODEL.ADMIN_VIEWMODEL;
using Xamarin.Forms;


namespace PriceChecker.VIEWMODEL.ValidationCommands

{
    public class ValidationCommand : BaseProductViewModel
    {
        BaseProductViewModel baseproductviewmodel;
        public NewProductViewModel NewProductViewModel { get; set; }

        public ICommand AddCommand {  set; get; }
        public ValidationCommand()
        {




            AddCommand = new Command(
                execute: () =>
                {
          
                    //NewProductViewModel.AddCommand();
                    baseproductviewmodel = null;
                  
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return baseproductviewmodel != null &&
                           baseproductviewmodel.ProductName != null &&
                           baseproductviewmodel.ProductName.Length > 1 &&
                           baseproductviewmodel.ProductCode != null &&
                            baseproductviewmodel.ProductCode.Length > 0 &&
                             baseproductviewmodel.ProductPrice != null &&
                              baseproductviewmodel.ProductPrice.Length > 1;
                });


        }




        void OnPersonEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (AddCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (AddCommand as Command).ChangeCanExecute();

        }
       
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnpropertyChanged(propertyName);
            return true;
        }

   

     
    }
}
