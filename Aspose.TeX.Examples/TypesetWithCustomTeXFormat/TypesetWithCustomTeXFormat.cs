using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;
using Aspose.TeX.ResourceProviders;
using System.IO;
using System.Text;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    /// <summary>
    /// Typesetting a TeX file using a custom TeX format.
    /// </summary>
    class TypesetWithCustomTeXFormat
    {
        public static void Run()
        {
            // ExStart:TypesetWithCustomTeXFormat
            // Create the file system input working directory.
            IInputWorkingDirectory wd = new InputFileSystemDirectory(RunExamples.OutputDirectory);
            // Create the format provider.
            using (FormatProvider formatProvider = new FormatProvider(wd, "customtex"))
            {
                // Create conversion options for a custom format on ObjectTeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX(formatProvider));
                options.JobName = "typeset-with-custom-format";
                // Specify the input working directory.
                options.InputWorkingDirectory = wd;
                // Specify a file system working directory for the output.
                options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);

                // Run the job.
                new TeXJob(new MemoryStream(Encoding.ASCII.GetBytes(
                        "Congratulations! You have successfully typeset this text with your own TeX format!\\end")),
                        new XpsDevice(), options).Run();

                // For further output to look write.
                options.TerminalOut.Writer.WriteLine();
            }
            // ExEnd:TypesetWithCustomTeXFormat
        }
    }
}