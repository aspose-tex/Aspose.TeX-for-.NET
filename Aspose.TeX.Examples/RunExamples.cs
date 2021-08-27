using Aspose.TeX.Examples.CSharp.TeXTypesetting;
using System;
using System.IO;

namespace Aspose.TeX.Examples.CSharp
{
    class RunExamples
    {
        internal static string BasePath = Directory.GetCurrentDirectory() + "\\..\\..\\";
        internal static string InputDirectory = Path.GetFullPath(Path.Combine(BasePath, "input"));
        internal static string OutputDirectory = Path.GetFullPath(Path.Combine(BasePath, "output"));

        static void Main()
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            //// Instantiate an instance of license and set the license file through its path
            new License().SetLicense(Path.GetFullPath(Path.Combine(BasePath, "License\\Aspose.TeX.NET.lic")));

            // Uncomment the example that you want to run.

            //// =====================================================
            //// =====================================================
            ////  Typeset a TeX file 
            //// =====================================================
            //// =====================================================

            //LoadLicenseFromFile.Run();

            //LoadLicenseFromStream.Run();

            //FileSystemInputOutputAndXpsOutput.Run();

            //OverridenJobNameAndTerminalOutputWrittenToDisk.Run();

            //TypesetXpsWrittenToExternalStream.Run();

            //ZipFileInputOuputAndPdfOutput.Run();

            //OverridenJobNameAndTerminalOutputWrittenToZip.Run();

            //TypesetPdfWrittenToExternalStream.Run();

            //StreamInputImageOutputAndTerminalInput.Run();

            //CustomTeXFormatFileCreation.Run();

            TypesetWithCustomTeXFormat.Run();
        }
    }
}