using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scanbot.SDK.Example.Forms
{
    public partial class App : Application
    {
        public static Color ScanbotRed = Color.FromRgb(200, 25, 60);

        public App()
        {
            InitializeComponent();
            MainPage = new Authenticate();
           /* var content = new Authenticate();
            MainPage = new NavigationPage(content)
            {
                BarBackgroundColor = ScanbotRed,
                BarTextColor = Color.White
            };*/
        }
    }
}
