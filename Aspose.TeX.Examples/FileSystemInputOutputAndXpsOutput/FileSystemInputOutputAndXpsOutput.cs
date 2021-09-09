using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Using file system directories for input and output, outputting to XPS device, writing terminal output to console.
    /// </summary>
    class FileSystemInputOutputAndXpsOutput
    {
        public static void Run()
        {
            // ExStart:TakeInputFromFileSystem-WriteOutputToFileSystem-WriteTerminalOutputToConsole
            // Create conversion options for default ObjectTeX format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            // Specify a file system working directory for the input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify console as output terminal.
            options.TerminalOut = new OutputConsoleTerminal(); // Default. No need to specify.
            // Specify a memory stream as output terminal, if you don't want the terminal output to be written to the console.
            //options.TerminalOut = new OutputMemoryTerminal();
            // Run typesetting.
            TeXJob job = new TeXJob("hello-world", new XpsDevice(), options);
            job.Run();

            // For further output to look write.
            options.TerminalOut.Writer.WriteLine(); // The same as Console.Out.WriteLine();
            // ExEnd:TakeInputFromFileSystem-WriteOutputToFileSystem-WriteTerminalOutputToConsole
        }
    }
}