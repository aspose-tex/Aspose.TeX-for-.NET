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
            // Create a file system input working directory.
            IWorkingDirectory wd = new InputFileSystemDirectory(RunExamples.OutputDirectory);
            // Create a format provider.
            FormatProvider formatProvider = new FormatProvider(wd, "customtex");
            // Create typesetting options for a custom format on ObjectTeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX(formatProvider));
            options.JobName = "typeset-with-custom-format";
            // Specify the input working directory.
            options.InputWorkingDirectory = wd;
            // Specify a file system working directory for output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);

            // Run typesetting.
            TeX.Typeset(new MemoryStream(Encoding.ASCII.GetBytes(
                    "Congratulations! You have successfully typeset this text with your own TeX format!\\end")), new XpsDevice(), options);

            // For further output to look write.
            options.TerminalOut.Writer.WriteLine();
            // ExEnd:TypesetWithCustomTeXFormat
        }
    }
}