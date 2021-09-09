using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXXpsConversionSimplest
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToXps-Simplest
            // Create conversion options for Object LaTeX format on Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);

            // ExStart:Aspose.TeX.Examples-Conversion-InteractionMode
            // Set interaction mode.
            //options.Interaction = Interaction.NonstopMode;
            // ExEnd:Aspose.TeX.Examples-Conversion-InteractionMode

            // ExStart:Aspose.TeX.Examples-Conversion-JobName
            // Set the job name.
            //options.JobName = "my-job-name";
            // ExEnd:Aspose.TeX.Examples-Conversion-JobName

            // Specify the file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);

            // ExStart:Aspose.TeX.Examples-Conversion-Repeat
            // Ask the engine to repeat the job.
            //options.Repeat = true;
            // Exend:Aspose.TeX.Examples-Conversion-Repeat

            // Initialize the options for saving in XPS format.
            options.SaveOptions = new XpsSaveOptions(); // Default value.
            // Run LaTeX to XPS conversion.
            new TeXJob(Path.Combine(RunExamples.InputDirectory, "hello-world.ltx"), new XpsDevice(), options).Run();

            // ExStart:Aspose.TeX.Examples-Conversion-InputStream
            // Run LaTeX to XPS conversion.
            //new TeXJob(new MemoryStream(Encoding.ASCII.GetBytes(@"\documentclass{article} \begin{document} Hello, World! \end{document}")),
            //    new XpsDevice(), options).Run();
            // ExEnd:Aspose.TeX.Examples-Conversion-InputStream

            // ExStart:Aspose.TeX.Examples-Conversion-MainInputTerminal
            // Run LaTeX to XPS conversion.
            //new TeXJob(new XpsDevice(), options).Run();
            // ExEnd:Aspose.TeX.Examples-Conversion-MainInputTerminal

            // ExEnd:Conversion-LaTeXToXps-Simplest
        }
    }
}
