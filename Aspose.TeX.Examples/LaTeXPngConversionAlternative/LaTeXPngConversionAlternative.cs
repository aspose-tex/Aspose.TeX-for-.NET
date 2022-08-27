using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Image;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXPngConversionAlternative
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToPng-Alternative
            // Create conversion options for Object LaTeX format upon Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Initialize the options for saving in PNG format.
            options.SaveOptions = new PngSaveOptions() { DeviceWritesImages = false };
            // Run LaTeX to PNG conversion.
            ImageDevice device = new ImageDevice();
            new TeXJob(Path.Combine(RunExamples.InputDirectory, "hello-world.ltx"), device, options).Run();

            // Save pages file by file.
            for (int i = 0; i < device.Result.Length; i++)
            {
                using (Stream fs = File.Open(Path.Combine(RunExamples.OutputDirectory, "page-" + (i + 1) + ".png"), FileMode.Create))
                    fs.Write(device.Result[i], 0, device.Result[i].Length);
            }
            // ExEnd:Conversion-LaTeXToPng-Alternative
        }
    }
}
