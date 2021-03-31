using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Pdf;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Using ZIP directories for input and output, outputting to PDF device, overriding the job name, writing terminal output to ZIP.
    /// </summary>
    class OverridenJobNameAndTerminalOutputWrittenToZip
    {
        public static void Run()
        {
            // ExStart:WriteTerminalOutputToZip
            // Open a stream on a ZIP archive that will serve as the input working directory.
            using (Stream inZipStream = File.Open(Path.Combine(RunExamples.InputDirectory, "zip-in.zip"), FileMode.Open))
            // Open a stream on a ZIP archive that will serve as the output working directory.
            using (Stream outZipStream = File.Open(Path.Combine(RunExamples.OutputDirectory, "terminal-out-to-zip.zip"), FileMode.Create))
            {
                // Create typesetting options for default ObjectTeX format on ObjectTeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                // Specify the job name.
                options.JobName = "terminal-output-to-zip";
                // Specify a ZIP archive working directory for input.
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                // Specify a ZIP archive working directory for output.
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                // Specify that the terminal output must be written to a file in the output working directory.
                // The file name is <job_name>.trm.
                options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

                // Create and specify saving options.
                options.SaveOptions = new PdfSaveOptions();
                // Run typesetting.
                TeX.Typeset("hello-world", new PdfDevice(), options);

                // Finalize output ZIP archive.
                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
            // ExEnd:WriteTerminalOutputToZip
        }
    }
}