using Aspose.TeX.IO;
using System.Collections.Generic;
using System.IO;

namespace Aspose.TeX.Examples.RequiredInputDirectory
{
    // ExStart:Conversion-RequiredInputDirectory
    // This is an implementation of IInputWorkingDirectory that is suitable for the TeX job's RequiredInputDirectory option
    // in case required input contains fonts provided by external packages.
    // The class additionally implements IFileCollector, which provides access to file collections by extension.
    // This is necessary to load external font maps, which are files (outside TeX syntax) that map TeX's
    // internal font names to file names of physical fonts.
    public class RequiredInputDirectory : IInputWorkingDirectory, IFileCollector
    {
        private Dictionary<string, Dictionary<string, string>> _fileNames =
            new Dictionary<string, Dictionary<string, string>>();

        public RequiredInputDirectory()
        {
        }

        // This method should preliminarily be called for each file entry that is supposed to be located inside
        // the required input directory. Inside is an example of how the dictionary of file names could be organized
        // for easy collection of file names by extension.
        // Here fileName is a full file name. This can be a file path on a file system, a URL, or whatever else (theoretically).
        public void StoreFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string name = Path.GetFileNameWithoutExtension(fileName);

            Dictionary<string, string> files;
            if (!_fileNames.TryGetValue(extension, out files))
                _fileNames.Add(extension, files = new Dictionary<string, string>());

            files[name] = fileName;
        }

        // The IInputWorkingDirectory implementation.
        public NamedStream GetFile(string fileName, bool searchSubdirectories = false)
        {
            return new NamedStream(null, fileName); // Here we actually return a stream for the file requested by its name.
        }

        // Here is how we gather file collections by extension.
        public string[] GetFileNamesByExtension(string extension, string path = null)
        {
            Dictionary<string, string> files;
            if (!_fileNames.TryGetValue(extension, out files))
                return new string[0];

            return new List<string>(files.Values).ToArray();
        }

        public void Dispose()
        {
            _fileNames.Clear();
        }
    }
    // ExEnd:Conversion-RequiredInputDirectory
}
