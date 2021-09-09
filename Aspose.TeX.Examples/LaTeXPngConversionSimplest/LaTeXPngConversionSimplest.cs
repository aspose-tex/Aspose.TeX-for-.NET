using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Image;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXPngConversionSimplest
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToPng-Simplest
            // Create conversion options for Object LaTeX format on Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
            // Specify the file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Initialize the options for saving in PNG format.
            options.SaveOptions = new PngSaveOptions();

            // ExStart:Aspose.TeX.Examples-Conversion-LaTeXToJpeg
            // Initialize the options for saving in JPEG format.
            //options.SaveOptions = new JpegSaveOptions();
            // ExEnd:Aspose.TeX.Examples-Conversion-LaTeXToJpeg

            // ExStart:Aspose.TeX.Examples-Conversion-LaTeXToTiff
            // Initialize the options for saving in TIFF format.
            //options.SaveOptions = new TiffSaveOptions();
            // ExEnd:Aspose.TeX.Examples-Conversion-LaTeXToTiff

            // ExStart:Aspose.TeX.Examples-Conversion-LaTeXToBmp
            // Initialize the options for saving in BMP format.
            //options.SaveOptions = new BmpSaveOptions();
            // ExEnd:Aspose.TeX.Examples-Conversion-LaTeXToBmp

            // Run LaTeX to PNG conversion.
            new TeXJob(Path.Combine(RunExamples.InputDirectory, "hello-world.ltx"), new ImageDevice(), options).Run();
            // ExEnd:Conversion-LaTeXToPng-Simplest
        }
    }
}
