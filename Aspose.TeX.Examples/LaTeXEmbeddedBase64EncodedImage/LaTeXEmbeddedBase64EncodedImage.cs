using Aspose.TeX.Examples.CSharp;
using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Pdf;
using System.IO;

namespace Aspose.TeX.Examples.CShar.LaTeXEmbeddedBase64EncodedImage
{
    class LaTeXEmbeddedBase64EncodedImage
    {
        public static void Run()
        {
            // ExStart:Conversion-EmbeddedBase64EncodedImage
            // Create conversion options for Object LaTeX format upon Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Initialize the options for saving in PDF format.
            options.SaveOptions = new PdfSaveOptions();
            // Enable the shell command execution.
            options.ShellMode = ShellMode.ShellRestricted;
            // Run LaTeX to PDF conversion.
            new TeXJob(Path.Combine(RunExamples.InputDirectory, "embedded-base64-image.tex"), new PdfDevice(), options).Run();
            // ExEnd:Conversion-EmbeddedBase64EncodedImage
        }
    }
}
