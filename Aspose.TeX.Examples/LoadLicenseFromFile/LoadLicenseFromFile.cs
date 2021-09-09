using System;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LoadLicenseFromFile
    {
        public static void Run()
        {
            // ExStart:LoadLicenseFromFile
            // Initialize license object.
            License license = new License();
            // Set license.
            license.SetLicense("D:\\Aspose.Total.NET.lic");
            Console.WriteLine("License set successfully.");
            // ExEnd:LoadLicenseFromFile
        }
    }
}