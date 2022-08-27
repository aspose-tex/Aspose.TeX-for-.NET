using Aspose.TeX.IO;
using Aspose.TeX.Presentation.Xps;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.TeXTypesetting
{
    class LaTeXXpsConversionAlternative
    {
        public static void Run()
        {
            // ExStart:Conversion-LaTeXToXps-Alternative
            // Create the stream to write the XPS file to.
            using (Stream xpsStream = File.Open(Path.Combine(RunExamples.OutputDirectory, "any-name.xps"), FileMode.Create))
            {
                // Create conversion options for Object LaTeX format upon Object TeX engine extension.
                TeXOptions options = TeXOptions.ConsoleAppOptions(TeXConfig.ObjectLaTeX);
                // Specify a file system working directory for the output.
                options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
                // Initialize the options for saving in XPS format.
                options.SaveOptions = new XpsSaveOptions(); // Default value. Arbitrary assignment.
                // Run LaTeX to XPS conversion.
                new TeXJob(Path.Combine(RunExamples.InputDirectory, "hello-world.ltx"), new XpsDevice(xpsStream), options).Run();
            }
            // ExEnd:Conversion-LaTeXToXps-Alternative
        }
    }
}
