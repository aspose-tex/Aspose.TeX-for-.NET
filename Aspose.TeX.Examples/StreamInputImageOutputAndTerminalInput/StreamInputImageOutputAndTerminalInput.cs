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
            // Create conversion options for default ObjectTeX format upon ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            // Specify a job name.
            options.JobName = "stream-in-image-out";
            // Specify a file system working directory for the input.
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify the console as the input terminal.
            options.TerminalIn = new InputConsoleTerminal();  // Default value. Arbitrary assignment.
            // Specify the console as the output terminal.
            options.TerminalOut = new OutputConsoleTerminal(); // Default value. Arbitrary assignment.

            // Define the saving options.
            options.SaveOptions = new PngSaveOptions() { Resolution = 300 };
            // Create the image device.
            ImageDevice device = new ImageDevice();
            // Run the job.
            TeXJob job = new TeXJob(new MemoryStream(Encoding.ASCII.GetBytes(
                    "\\hrule height 10pt width 95pt\\vskip10pt\\hrule height 5pt")),
                    device, options);
            job.Run();

            // When the console prompts the input, type "ABC", press Enter, then type "\end" and press Enter again.

            // For further output to look fine. 
            options.TerminalOut.Writer.WriteLine();

            // You can alternatively get images in form of array of byte arrays.
            // The first index for the page number (0-based, of course).
            byte[][] result = device.Result;
            // ExEnd:TakeMainInputFromStream-AuxFromFileSystem-TakeTerminalInputFromConsole-AlternativeImagesStorage
        }
    }
}