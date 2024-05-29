using Aspose.TeX.Features;
using Aspose.TeX.IO;
using System.Collections.Generic;
using System.IO;

namespace Aspose.TeX.Examples.CSharp.LaTeXRepairer
{
    class LaTeXRepairerExample
    {
        public static void Run()
        {
            // ExStart:Features-LaTeXRepairer
            // Create repair options.
            LaTeXRepairerOptions options = new LaTeXRepairerOptions();
            // Specify a file system working directory for the output.
            options.OutputWorkingDirectory = new OutputFileSystemDirectory(RunExamples.OutputDirectory);
            // Specify a file system working directory for the required input.
            // The directory containing packages may be located anywhere.
            options.RequiredInputDirectory = new InputFileSystemDirectory(Path.Combine(RunExamples.InputDirectory, "packages"));
            // Specify the callback class to externally guess packages required for undefined commands or environments.
            options.GuessPackageCallback = new PackageGuesser();
            // Run the repair process.
            new Features.LaTeXRepairer(Path.Combine(RunExamples.InputDirectory, "invalid-latex.tex"), options).Run();
            // ExEnd:Features-LaTeXRepairer
        }

        // ExStart:Features-LaTeXRepairer-PackageGuessingCallback
        // The callback class to externally guess packages required for undefined commands or environments.
        public class PackageGuesser : IGuessPackageCallback
        {
            private Dictionary<string, string> _map = new Dictionary<string, string>();

            public PackageGuesser()
            {
                _map.Add("lhead", "fancyhdr"); // Defines the mapping between the \lhead command and the fancyhdr package.
            }

            public string GuessPackage(string commandName, bool isEnvironment)
            {
                string packageName;
                if (!isEnvironment)
                {
                    _map.TryGetValue(commandName, out packageName);
                    return packageName ?? ""; // It's better to return an empty stream to avoid consequent calls for the same command name.
                }

                // Some code for environments
                // ...

                return "";
            }
        }
        // ExEnd:Features-LaTeXRepairer-PackageGuessingCallback
    }
}
