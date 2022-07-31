using course_rename.services.Parser;

namespace course_rename.services;

public class FileLoader
{

    /// <summary>
    /// Load the files within the specified directory, User a parser to parse the file name an 
    /// extract the required information
    /// </summary>
    /// <param name="dirPath">Full or relative path to the directory</param>
    /// <returns>Number of files loaded</returns>
    public int LoadFiles(string dirPath)
    {
        if (!Directory.Exists(dirPath)) return 0;

        var parser = new IndexLastParser();
        var dir = new DirectoryInfo(dirPath);

        _FileList = dir.EnumerateFiles().Select(f =>
            new FileData(f, parser));

        return _FileList.Count();
    }

    /// <summary>
    /// Searches the list of files to find a matching file with the 
    /// specified index
    /// </summary>
    /// <param name="index">Index of file to be searched</param>
    /// <returns>Matching file or null if the file is not found</returns>
    public FileData? FindFile(int index)
    {
        return _FileList?
            .Where(f => f.Index == index)
            .FirstOrDefault();
    }

    /// <summary>
    /// List of files loaded from the directory
    /// </summary>
    private IEnumerable<FileData>? _FileList;
}