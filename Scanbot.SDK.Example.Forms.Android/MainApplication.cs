using System;
using System.IO;
using Android.App;
using Android.Runtime;
using Android.Util;
using ScanbotSDK.Xamarin.Forms;

namespace Scanbot.SDK.Example.Forms.Droid
{
   
    [Application(LargeHeap = true)]
    public class MainApplication : Application
    {
        static string LOG_TAG = typeof(MainApplication).Name;
        const string LICENSE_KEY = null;


        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer) { }

        public override void OnCreate()
        {
            base.OnCreate();

            Log.Debug(LOG_TAG, "Initializing Scanbot SDK...");

            // Initialization with a custom, public(!) "StorageBaseDirectory"
            var configuration = new SBSDKConfiguration
            {
                EnableLogging = true,
                // If no StorageBaseDirectory is specified, the default will be used
                StorageBaseDirectory = GetDemoStorageBaseDirectory(),
                DetectorType = DocumentDetectorType.MLBased,
                Encryption = new ScanbotSDK.Xamarin.SBSDKEncryption
                {
                    Mode = ScanbotSDK.Xamarin.EncryptionMode.AES256,
                    Password = "S0m3W3irDL0ngPa$$w0rdino!!!!"
                }
            };
            SBSDKInitializer.Initialize(this, LICENSE_KEY, configuration);
        }

        string GetDemoStorageBaseDirectory()
        {
            var directory = GetExternalFilesDir(null).AbsolutePath;
            var externalPublicPath = Path.Combine(directory, "my-custom-storage");
            Directory.CreateDirectory(externalPublicPath);
            return externalPublicPath;
        }
    }
}
