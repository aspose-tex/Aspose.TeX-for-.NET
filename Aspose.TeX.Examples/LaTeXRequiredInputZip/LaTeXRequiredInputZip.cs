using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Image;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXRequiredInputZip
    {
        public static void Run()
        {
            // ExStart:Conversion-RequiredInput-Zip
            // Create conversion options for Object LaTeX format upon Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Initialize the options for saving in PNG format.
            options.SaveOptions = new PngSaveOptions();
            // Create a file stream for the ZIP archive containing the required package.
            // The ZIP archive may be located anywhere.
            using (Stream zipStream = File.Open(Path.Combine(RunExamples.InputDirectory, "packages\\pgfplots.zip"), FileMode.Open))
            {
                // Specify a ZIP working directory for the required input.
                options.RequiredInputDirectory = new InputZipDirectory(zipStream, "");

                // Run LaTeX to PNG conversion.
                new TeXJob(Path.Combine(RunExamples.InputDirectory, "required-input-zip.tex"), new ImageDevice(), options).Run();
            }
            // ExEnd:Conversion-RequiredInput-Zip
        }
    }
}
