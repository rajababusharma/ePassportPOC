using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScanbotSDK.Xamarin.Forms;
using Xamarin.Forms;

namespace Scanbot.SDK.Example.Forms
{
    public class SDKUtils
    {
        public static bool CheckLicense(ContentPage context)
        {
            if (!SBSDK.Operations.IsLicenseValid)
            {
                ViewUtils.Alert(context, "Oops!", "License expired or invalid");
            }
            return SBSDK.Operations.IsLicenseValid;
        }
 

        public static string ParseMRZResult(MrzScannerResult result)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"DocumentType: {result.DocumentType}");
            foreach (var field in result.Fields)
            {
                builder.AppendLine($"{field.Name}: {field.Value} ({field.Confidence:F2})");
            }
            return builder.ToString();
        }

      

        public static string ParseCheckResult(CheckRecognizerResult result)
        {
            return string.Join("\n", result.Document.Fields
                .Where((f) => f != null && f.Type != null && f.Type.Name != null && f.Value != null && f.Value.Text != null)
                .Select((f) => string.Format("{0}: {1}", f.Type.Name, f.Value.Text))
            );
        }
    }
}
