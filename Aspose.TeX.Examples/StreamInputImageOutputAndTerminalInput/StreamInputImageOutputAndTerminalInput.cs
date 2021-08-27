using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Image;
using System.IO;
using System.Text;

/// <summary>
/// Taking TeX input from a stream, using file system directory for output, outputting to image device,
/// writing terminal output to console, taking online input from console.
/// </summary>
namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class StreamInputImageOutputAndTerminalInput
    {
        public static void Run()
        {
            // ExStart:TakeMainInputFromStream-AuxFromFileSystem-TakeTerminalInputFromConsole-AlternativeImagesStorage
            // Create typesetting options for default ObjectTeX format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            // Specify the job name.
            options.JobName = "stream-in-image-out";
            // Specify a file system working directory for input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory for output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify console as input terminal.
            options.TerminalIn = new InputConsoleTerminal();  // Default. No need to specify.
            // Specify console as output terminal.
            options.TerminalOut = new OutputConsoleTerminal(); // Default. No need to specify.

            // Create and specify saving options.
            options.SaveOptions = new PngSaveOptions() { Resolution = 300 };
            // Create image device.
            ImageDevice device = new ImageDevice();
            // Run typesetting.
            TeXJob job = new TeXJob(new MemoryStream(Encoding.ASCII.GetBytes(
                    "\\hrule height 10pt width 95pt\\vskip10pt\\hrule height 5pt")),
                    device, options);
            job.Run();

            // When console prompts the input, type "ABC", press Enter, then type "\end" and press Enter again.

            // For further output to look write. 
            options.TerminalOut.Writer.WriteLine();

            // You can alternatively get images in form of array of byte arrays.
            // The first index for the page number (0-based, of course).
            byte[][] result = device.Result;
            // ExEnd:TakeMainInputFromStream-AuxFromFileSystem-TakeTerminalInputFromConsole-AlternativeImagesStorage
        }
    }
}