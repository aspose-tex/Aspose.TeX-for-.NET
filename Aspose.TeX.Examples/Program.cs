using Aspose.TeX;
using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Image;
using Aspose.TeX.Presentation.Pdf;
using Aspose.TeX.Presentation.Xps;
using Aspose.TeX.ResourceProviders;
using System;
using System.IO;
using System.Text;

namespace Aspose.TeX.Examples
{
    class Program
    {
        private static string BasePath = Directory.GetCurrentDirectory() + "\\..\\..\\";
        private static string _inputDirectory = Path.GetFullPath(Path.Combine(BasePath, "input"));
        private static string _outputDirectory = Path.GetFullPath(Path.Combine(BasePath, "output"));

        static void Main()
        {
            //new License().SetLicense(Path.GetFullPath(Path.Combine(BasePath, "License\\Aspose.TeX.NET.lic")));

            Sample1();

            Sample2();

            Sample2_1();

            Sample3();

            Sample4();

            Sample4_1();

            Sample5();

            Sample6();

            Sample7();
        }

        // Using file system directories for input and output, outputting to XPS device, writing terminal output to console.
        private static void Sample1()
        {
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);
            options.TerminalOut = new OutputConsoleTerminal(); // Default. Not necessary to specify.

            TeX.Typeset("hello-world", new XpsDevice(), options);

            options.TerminalOut.Writer.WriteLine();
        }

        // Using file system directories for input and output, outputting to XPS device, overriding the job name, writing terminal output to disk.
        private static void Sample2()
        {
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            options.JobName = "sample2";
            options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);
            options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

            TeX.Typeset("hello-world", new XpsDevice(), options);

            options.TerminalOut.Writer.WriteLine();
        }

        // Alternative way to obtain typeset document from XPS device.
        private static void Sample2_1()
        {
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            options.JobName = "sample2-1";
            options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);
            options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);

            using (Stream stream = File.Open(Path.Combine(_outputDirectory, options.JobName + ".xps"), FileMode.Create))
                TeX.Typeset("hello-world", new XpsDevice(stream), options);

            options.TerminalOut.Writer.WriteLine();
        }

        // Using ZIP directories for input and output, outputting to PDF device, writing terminal output to console.
        private static void Sample3()
        {
            using (Stream inZipStream = File.Open(Path.Combine(_inputDirectory, "zip-in.zip"), FileMode.Open))
            using (Stream outZipStream = File.Open(Path.Combine(_outputDirectory, "sample3-out.zip"), FileMode.Create))
            {
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                options.TerminalOut = new OutputConsoleTerminal(); // Default. Not necessary to specify.
                options.SaveOptions = new PdfSaveOptions();

                TeX.Typeset("hello-world", new PdfDevice(), options);

                options.TerminalOut.Writer.WriteLine();

                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
        }

        // Using ZIP directories for input and output, outputting to PDF device, overriding the job name, writing terminal output to ZIP.
        private static void Sample4()
        {
            using (Stream inZipStream = File.Open(Path.Combine(_inputDirectory, "zip-in.zip"), FileMode.Open))
            using (Stream outZipStream = File.Open(Path.Combine(_outputDirectory, "sample4-out.zip"), FileMode.Create))
            {
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                options.JobName = "sample4";
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);
                options.SaveOptions = new PdfSaveOptions();

                TeX.Typeset("hello-world", new PdfDevice(), options);

                options.TerminalOut.Writer.WriteLine();

                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
        }

        // Alternative way to obtain typeset document from PDF device.
        private static void Sample4_1()
        {
            using (Stream inZipStream = File.Open(Path.Combine(_inputDirectory, "zip-in.zip"), FileMode.Open))
            using (Stream outZipStream = File.Open(Path.Combine(_outputDirectory, "sample4-1-out.zip"), FileMode.Create))
            {
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
                options.JobName = "sample4-1";
                options.InputWorkingDirectory = new InputZipDirectory(inZipStream, "in");
                options.OutputWorkingDirectory = new OutputZipDirectory(outZipStream);
                options.TerminalOut = new OutputFileTerminal(options.OutputWorkingDirectory);
                options.SaveOptions = new PdfSaveOptions();

                using (Stream stream = File.Open(Path.Combine(_outputDirectory, "file-name.pdf"), FileMode.Create)) // writing PDF somewhere else
                //using (Stream stream = options.OutputWorkingDirectory.GetFile("file-name.pdf", out string fullName)) // writing PDF to the same ZIP
                    TeX.Typeset("hello-world", new PdfDevice(stream), options);

                options.TerminalOut.Writer.WriteLine();

                ((OutputZipDirectory)options.OutputWorkingDirectory).Finish();
            }
        }

        // Taking TeX input from a stream, using file system directory for output, outputting to image device,
        // writing terminal output to console, taking online input from console.
        private static void Sample5()
        {
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX());
            options.JobName = "sample5";
            options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);
            options.TerminalIn = new InputConsoleTerminal();  // Default. Not necessary to specify.
            options.TerminalOut = new OutputConsoleTerminal(); // Default. Not necessary to specify.
            options.SaveOptions = new PngSaveOptions() { Resolution = 300 };

            ImageDevice device = new ImageDevice();
            TeX.Typeset(new MemoryStream(Encoding.ASCII.GetBytes(
                    "\\hrule height 10pt width 95pt\\vskip10pt\\hrule height 5pt")),
                    device, options);

            // When console prompts the input, type "ABC", press Enter, then type "\end" and press Enter again.

            options.TerminalOut.Writer.WriteLine();

            // You can alternatively get images in form of array of byte arrays.
            // The first index means the page number (0-based, of course).
            byte[][] result = device.Result;
        }

        // Creating custom format.
        private static void Sample6()
        {
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectIniTeX);
            options.InputWorkingDirectory = new InputFileSystemDirectory(_inputDirectory);
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);

            TeX.CreateFormat("customtex", options);

            options.TerminalOut.Writer.WriteLine();
        }

        // Using custom format.
        private static void Sample7()
        {
            IWorkingDirectory wd = new InputFileSystemDirectory(_outputDirectory);
            FormatProvider formatProvider = new FormatProvider(wd, "customtex");
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectTeX(formatProvider));
            options.JobName = "custom-format";
            options.InputWorkingDirectory = wd;
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(_outputDirectory);

            TeX.Typeset(new MemoryStream(Encoding.ASCII.GetBytes(
                    "Congratulations! You have successfully typeset this text with your own TeX format!\\end")), new XpsDevice(), options);

            options.TerminalOut.Writer.WriteLine();
        }
    }
}