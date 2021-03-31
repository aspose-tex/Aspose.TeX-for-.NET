using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Using file system directories for input and output, outputting to XPS device, overriding the job name, writing terminal output to disk.
    /// </summary>
    class OverridenJobNameAndTerminalOutputWrittenToDisc
    {
        public static void Run()
        {
            // ExStart:OverrideJobName-WriteTerminalOutputToFileSystem
            // Create typesetting options for default ObjectTeX format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            // Specify the job name. Otherwise, TeX.Typeset()'s method first argument will be taken as a job name.
            options.JobName = "overriden-job-name";
            // Specify a file system working directory for input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory for output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify that the terminal output must be written to a file in the output working directory.
            // The file name is <job_name>.trm.
            options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

            // Run typesetting.
            TeX.Typeset("hello-world", new XpsDevice(), options);
            // ExEnd:OverrideJobName-WriteTerminalOutputToFileSystem
        }
    }
}