using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Pdf;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Using ZIP directories for input and output, outputting to PDF device, writing terminal output to console.
    /// </summary>
    class ZipFileInputOuputAndPdfOutput
    {
        public static void Run()
        {
            // ExStart:TakeInputFromZip-WriteOutputToZip
            // Open the stream on the ZIP archive that will serve as the input working directory.
            using (Stream inZipStream = File.Open(Path.Combine(RunExamples.InputDirectory, "zip-in.zip"), FileMode.Open))
            // Open the stream on the ZIP archive that will serve as the output working directory.
            using (Stream outZipStream = File.Open(Path.Combine(RunExamples.OutputDirectory, "zip-pdf-out.zip"), FileMode.Create))
            {
                // Create conversion options for default ObjectTeX format on ObjectTeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                // Specify a ZIP archive working directory for the input.
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                // Specify a ZIP archive working directory for the output.
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                // Specify the console as the output terminal.
                options.TerminalOut = new OutputConsoleTerminal(); // Default. Not necessary to specify.

                // Define the saving options.
                options.SaveOptions = new PdfSaveOptions();
                // Run the job.
                TeXJob job = new TeXJob("hello-world", new PdfDevice(), options);
                job.Run();

                // For consequent output to look write. 
                options.TerminalOut.Writer.WriteLine();

                // Finalize output ZIP archive.
                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
            // ExEnd:TakeInputFromZip-WriteOutputToZip
        }
    }
}