using PriceChecker.VIEW.USER_VIEW;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

#pragma warning disable CA1707 // Identifiers should not contain underscores
namespace PriceChecker.VIEWMODEL.USER_VIEWMODEL
#pragma warning restore CA1707 // Identifiers should not contain underscores
{
    public class BarCodeScanViewModel:BaseProductViewModel
    {


        public BarCodeScanViewModel(INavigation navigation)
        {

            _Navigation = navigation;

        }


        public ZXing.Result Result { get; set; }

        private bool isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return this.isAnalyzing; }
            set
            {
                if (!bool.Equals(this.isAnalyzing, value))
                {
                    this.isAnalyzing = value;
                    OnpropertyChanged(nameof(IsAnalyzing));
                }
            }
        }

        private bool isScanning = true;
        public bool IsScanning
        {
            get { return this.isScanning; }
            set
            {
                if (!bool.Equals(this.isScanning, value))
                {
                    this.isScanning = value;
                    OnpropertyChanged(nameof(IsScanning));
                }
            }
        }

        public Xamarin.Forms.Command QRScanResultCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsAnalyzing = false;
                    IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        SearchText = Result.Text;
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
                        await _Navigation.PushAsync(new UserPage(SearchText));
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
                    });
                });
            }
        }
    }
}
