﻿using Aspose.TeX.Features;

namespace Aspose.TeX.Examples.CSharp.LaTeXFigureRenderer
{
    class SvgLaTeXFigureRenderer
    {
        public static void Run()
        {
            // ExStart:SvgLaTeXFigureRenderer
            // Create rendering options.
            FigureRendererOptions options = new SvgFigureRendererOptions();
            // Specify the preamble.
            options.Preamble = "\\usepackage{pict2e}";
            // Specify the scaling factor 300%.
            options.Scale = 3000;
            // Specify the background color.
            options.BackgroundColor = System.Drawing.Color.White;
            // Specify the output stream for the log file.
            options.LogStream = new System.IO.MemoryStream();
            // Specify whether to show the terminal output on the console or not.
            options.ShowTerminal = true;

            // The variable in which the dimensions of the resulting image will be written.
            System.Drawing.SizeF size = new System.Drawing.SizeF();
            // Create the output stream for the figure image.
            using (System.IO.Stream stream = System.IO.File.Open(
               System.IO.Path.Combine(RunExamples.OutputDirectory, "text-and-formula.svg"), System.IO.FileMode.Create))
            {
                // Run rendering.
                new SvgFigureRenderer().Render(@"\setlength{\unitlength}{0.8cm}
\begin{picture}(6,5)
\thicklines
\put(1,0.5){\line(2,1){3}} \put(4,2){\line(-2,1){2}} \put(2,3){\line(-2,-5){1}} \put(0.7,0.3){$A$} \put(4.05,1.9){$B$} \put(1.7,2.95){$C$}
\put(3.1,2.5){$a$} \put(1.3,1.7){$b$} \put(2.5,1.05){$c$} \put(0.3,4){$F=\sqrt{s(s-a)(s-b)(s-c)}$} \put(3.5,0.4){$\displaystyle s:=\frac{a+b+c}{2}$}
\end{picture}", stream, options, out size);
            }

            // Show other results.
            System.Console.Out.WriteLine(options.ErrorReport);
            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Size: " + size);
            // ExEnd:PngLaTeXFigureRenderer
        }
    }
}