﻿using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Pdf;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Using ZIP directories for input and output, outputting to PDF device, overriding the job name, writing terminal output to ZIP.
    /// </summary>
    class OverriddenJobNameAndTerminalOutputWrittenToZip
    {
        public static void Run()
        {
            // ExStart:WriteTerminalOutputToZip
            // Open a stream on a ZIP archive that will serve as the input working directory.
            using (Stream inZipStream = File.Open(Path.Combine(RunExamples.InputDirectory, "zip-in.zip"), FileMode.Open))
            // Open a stream on a ZIP archive that will serve as the output working directory.
            using (Stream outZipStream = File.Open(Path.Combine(RunExamples.OutputDirectory, "terminal-out-to-zip.zip"), FileMode.Create))
            {
                // Create conversion options for default ObjectTeX format upon ObjectTeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                // Specify a job name.
                options.JobName = "terminal-output-to-zip";
                // Specify a ZIP archive working directory for the input. You can also specify a path inside the archive.
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                // Specify a ZIP archive working directory for the output.
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                // Specify that the terminal output must be written to a file in the output working directory.
                // The file name is <job_name>.trm.
                options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

                // Define the saving options.
                options.SaveOptions = new PdfSaveOptions();
                // Run the job.
                new TeXJob("hello-world", new PdfDevice(), options).Run();

                // Finalize output ZIP archive.
                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
            // ExEnd:WriteTerminalOutputToZip
        }
    }
}