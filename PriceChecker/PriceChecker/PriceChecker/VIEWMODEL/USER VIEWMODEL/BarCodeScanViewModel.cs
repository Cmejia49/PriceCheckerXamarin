using PriceChecker.VIEW.USER_VIEW;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PriceChecker.VIEWMODEL.USER_VIEWMODEL
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
                        await _Navigation.PushAsync(new UserPage(SearchText));
                    });
                });
            }
        }
    }
}
