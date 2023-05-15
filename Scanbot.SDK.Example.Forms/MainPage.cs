using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScanbotSDK.Xamarin;
using ScanbotSDK.Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Scanbot.SDK.Example.Forms
{
    public class MainPage : ContentPage
    {
        StackLayout Container { get; set; }

        public MainPage()
        {
            BackgroundColor = Color.White;

            Title = "ePassport POC";

            Container = new StackLayout();
            Container.Orientation = StackOrientation.Vertical;
            Container.BackgroundColor = Color.White;

            var table = new TableView();
            table.BackgroundColor = Color.White;
            Container.Children.Add(table);

            table.Root = new TableRoot();


            table.Root.Add(new TableSection("DATA DETECTORS")
            {
                ViewUtils.CreateCell("MRZ Scanner", MRZScannerClicked),
            });
           
           

            Content = Container;
        }

        async void MRZScannerClicked(object sender, EventArgs e)
        {
            if (!SDKUtils.CheckLicense(this)) { return; }

            MrzScannerConfiguration configuration = new MrzScannerConfiguration
            {
                FinderWidthRelativeToDeviceWidth = 5,
                FinderHeightRelativeToDeviceWidth = 1,
            };

            var result = await SBSDK.UI.LaunchMrzScannerAsync(configuration);
            if (result.Status == OperationResult.Ok)
            {
                var message = SDKUtils.ParseMRZResult(result);
                ViewUtils.Alert(this, "MRZ Scanner result", message);
            }
        }

    }
}
