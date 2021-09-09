using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Alternative way to obtain typeset document from XPS device.
    /// </summary>
    class TypesetXpsWrittenToExternalStream
    {
        public static void Run()
        {
            // ExStart:WriteOutputXpsToExternalStream
            // Create conversion options for default ObjectTeX format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            // Specify a job name.
            options.JobName = "external-file-stream";
            // Specify a file system working directory the for input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory the for output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify that the terminal output must be written to a file in the output working directory.
            // The file name is <job_name>.trm.
            options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

            // Open the stream to write typeset XPS document. The file name is not necessarily the same as the job name.
            using (Stream stream = File.Open(Path.Combine(RunExamples.OutputDirectory, options.JobName + ".xps"), FileMode.Create))
                // Run typesetting.
                new TeXJob("hello-world", new XpsDevice(stream), options).Run();
            // ExEnd:WriteOutputXpsToExternalStream
        }
    }
}