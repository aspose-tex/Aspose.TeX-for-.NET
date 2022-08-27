using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;
using System.IO;
using System.Text;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXXpsConversionSimplest
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToXps-Simplest
            // Create conversion options for Object LaTeX format upon Object TeX engine extension.
            TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
            options.InputWorkingDirectory = new InputFileSystemDirectory(RunExamples.InputDirectory);

            // ExStart:Aspose.TeX.Examples-Conversion-InteractionMode
            // Set interaction mode.
            options.Interaction = Interaction.NonstopMode;
            // ExEnd:Aspose.TeX.Examples-Conversion-InteractionMode

            // ExStart:Aspose.TeX.Examples-Conversion-JobName
            // Set the job name.
            // options.JobName = "my-job-name";
            // ExEnd:Aspose.TeX.Examples-Conversion-JobName

            // ExStart:Aspose.TeX.Examples-Conversion-DateTime
            // Force the TeX engine to output the specified date in the title.
            // options.DateTime = new System.DateTime(2022, 12, 18);
            // ExEnd:Aspose.TeX.Examples-Conversion-DateTime

            // ExStart:Aspose.TeX.Examples-Conversion-IgnoreMissingPackages
            // Set to true to make the engine skip missing packages (when your file references one) without errors.
            // options.IgnoreMissingPackages = true;
            // ExEnd:Aspose.TeX.Examples-Conversion-IgnoreMissingPackages

            // ExStart:Aspose.TeX.Examples-Conversion-NoLigatures
            // Set to true to make the engine not construct ligatures where normally it would.
            // options.NoLigatures = true;
            // ExEnd:Aspose.TeX.Examples-Conversion-NoLigatures

            // ExStart:Aspose.TeX.Examples-Conversion-Repeat
            // Ask the engine to repeat the job.
            // options.Repeat = true;
            // Exend:Aspose.TeX.Examples-Conversion-Repeat

            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);

            // Initialize the options for saving in XPS format.
            options.SaveOptions = new XpsSaveOptions(); // Default value. Arbitrary assignment.

            // ExStart:Aspose.TeX.Examples-Conversion-RasterizeFormulas
            // Set to true if you want math formulas to be converted to raster images.
            // options.SaveOptions.RasterizeFormulas = true;
            // ExEnd:Aspose.TeX.Examples-Conversion-RasterizeFormulas

            // ExStart:Aspose.TeX.Examples-Conversion-RasterizeIncludedGraphics
            // Set to true if you want included graphics (if it contains vector elements) to be converted to raster images.
            // options.SaveOptions.RasterizeIncludedGraphics = true;
            // ExEnd:Aspose.TeX.Examples-Conversion-RasterizeIncludedGraphics

            // ExStart:Aspose.TeX.Examples-Conversion-SubsetFonts
            // Set to true to make the device subset fonts used in the document.
            // options.SaveOptions.SubsetFonts = true;
            // ExEnd:Aspose.TeX.Examples-Conversion-SubsetFonts

            // Run LaTeX to XPS conversion.
            new TeXJob(Path.Combine(RunExamples.InputDirectory, "sample.ltx"), new XpsDevice(), options).Run();

            // ExStart:Aspose.TeX.Examples-Conversion-InputStream
            // Run LaTeX to XPS conversion.
            // new TeXJob(new MemoryStream(Encoding.ASCII.GetBytes(@"\documentclass{article} \begin{document} Hello, World! \end{document}")),
            //     new XpsDevice(), options).Run();
            // ExEnd:Aspose.TeX.Examples-Conversion-InputStream

            // ExStart:Aspose.TeX.Examples-Conversion-MainInputTerminal
            // Run LaTeX to XPS conversion.
            // new TeXJob(new XpsDevice(), options).Run();
            // ExEnd:Aspose.TeX.Examples-Conversion-MainInputTerminal

            // ExEnd:Conversion-LaTeXToXps-Simplest
        }
    }
}
