using Aspose.TeX.Features;

namespace Aspose.TeX.Examples.CSharp.LaTeXMathRendering
{
    class PngLaTeXMathRenderer
    {
        public static void Run()
        {
            // ExStart:Features-PngLaTeXMathRendering
            // Create rendering options setting the image resolution to 150 dpi.
            PngMathRendererOptions options = new PngMathRendererOptions();
            options.Resolution = 150;
            // Specify the preamble.
            options.Preamble = @"\usepackage{amsmath}
\usepackage{amsfonts}
\usepackage{amssymb}
\usepackage{color}";
            // Specify the scaling factor 300%.
            options.Scale = 3000;
            // Specify the foreground color.
            options.TextColor = System.Drawing.Color.Black;
            // Specify the background color.
            options.BackgroundColor = System.Drawing.Color.White;
            // Specify the output stream for the log file.
            options.LogStream = new System.IO.MemoryStream();
            // Specify whether to show the terminal output on the console or not.
            options.ShowTerminal = true;

            // Create the output stream for the formula image.
            using (System.IO.Stream stream = System.IO.File.Open(
                System.IO.Path.Combine(RunExamples.OutputDirectory, "math-formula.png"), System.IO.FileMode.Create))
            {
                // Run rendering.
                System.Drawing.SizeF size = new PngMathRenderer().Render(@"\begin{equation*}
e^x = x^{\color{red}0} + x^{\color{red}1} + \frac{x^{\color{red}2}}{2} + \frac{x^{\color{red}3}}{6} + \cdots = \sum_{n\geq 0} \frac{x^{\color{red}n}}{n!}
\end{equation*}", stream, options);

                // Show other results.
                System.Console.Out.WriteLine(options.ErrorReport);
                System.Console.Out.WriteLine();
                System.Console.Out.WriteLine($"Size: {size}"); // Dimensions of the resulting image.
            }
            // ExEnd:Features-PngLaTeXMathRendering
        }
    }
}
