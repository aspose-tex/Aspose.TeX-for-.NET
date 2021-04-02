using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LoadLicenseFromStream
    {
        public static void Run()
        {
            // ExStart:LoadLicenseFromStream
            // Initialize license object
            License license = new License();
            // Load license in FileStream
            FileStream myStream = new FileStream("D:\\Aspose.Total.NET.lic", FileMode.Open);
            // Set license
            license.SetLicense(myStream);
            Console.WriteLine("License set successfully.");
            // ExEnd:LoadLicenseFromStream
        }
    }
}