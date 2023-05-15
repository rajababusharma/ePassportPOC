using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scanbot.SDK.Example.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Authenticate : ContentPage
	{
		public Authenticate ()
		{
			InitializeComponent ();
		}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync(
                    new AuthenticationRequestConfiguration("Login", "Access your account"));
                if (result.Authenticated)
                {
                    await DisplayAlert("Success", "Authenticated", "OK");
                    App.Current.MainPage=new MainPage();
                   
                }
                else
                {
                    await DisplayAlert("Failure", "Not Authenticated", "OK");
                }
            }
            else
            {
                await DisplayAlert("Failure", "Biometrics not available", "OK");
               // App.Current.MainPage = new MainPage();
            }
        }
    }
}