using Aspose.TeX.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Creating a custom TeX format file.
    /// </summary>
    class CustomTeXFormatFileCreation
    {
        public static void Run()
        {
            // ExStart:CreateCustomTeXFormatFile
            // Create TeX engine options for no format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectIniTeX);
            // Specify a file system working directory for the input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);

            // Run format creation.
            TeXJob.CreateFormat("customtex", options);

            // For further output to look write.
            options.TerminalOut.Writer.WriteLine();
            // ExEnd:CreateCustomTeXFormatFile
        }
    }
}