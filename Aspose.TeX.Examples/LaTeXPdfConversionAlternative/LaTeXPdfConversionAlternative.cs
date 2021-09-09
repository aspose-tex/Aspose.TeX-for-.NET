using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Pdf;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXPdfConversionAlternative
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToPdf-Alternative
            // Create the stream to write the PDF file to.
            using (Stream pdfStream = File.Open(Path.Combine(RunExamples.OutputDirectory, "any-name.pdf"), FileMode.Create))
            {
                // Create conversion options for Object LaTeX format on Object TeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
                // Specify the file system working directory for the output.
                options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
                // Initialize the options for saving in PDF format.
                options.SaveOptions = new PdfSaveOptions();
                // Run LaTeX to PDF conversion.
                new TeXJob(Path.Combine(RunExamples.InputDirectory, "hello-world.ltx"), new PdfDevice(pdfStream), options).Run();
            }
            // ExEnd:Conversion-LaTeXToPdf-Alternative
        }
    }
}
