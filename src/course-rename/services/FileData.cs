using course_rename.services.NameStrategy;
using course_rename.services.Parser;

namespace course_rename.services;


public struct FileData
{
    public int Index { get; private set; }
    public string IndexString { get; private set; }
    public string Filename { get; private set; }
    public string Extension { get; private set; }

    public FileData(FileInfo fileInfo, IEntryParser parser)
    {
        _FileInfo = fileInfo;
        var parseResult = parser.Parse(fileInfo.Name);
        Index = int.Parse(parseResult.Index);
        IndexString = parseResult.Index;
        Filename = parseResult.Filename;
        Extension = fileInfo.Extension;
        _DirPath = fileInfo.DirectoryName ?? string.Empty;
    }

    public FileInfo Rename(INamingStrategy namingStrategy)
    {
        var newName = namingStrategy.FormatName(Index, Filename, Extension);
        _FileInfo.MoveTo(Path.Combine(_DirPath, newName));
        return _FileInfo;
    }

    private readonly string _DirPath;
    private readonly FileInfo _FileInfo;

}