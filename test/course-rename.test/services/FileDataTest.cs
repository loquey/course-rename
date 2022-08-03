using course_rename.services.NameStrategy;
using course_rename.services.Parser;

namespace course_rename.services;

public class FileDataTest : IDisposable
{
    public FileDataTest()
    {
        _Parser = new IndexLastParser();
        _TestFile = new FileInfo("first1.mp4");
        if (!_TestFile.Exists)
            _TestFile.Create();
    }

    [Fact]
    public void Constructor_ShouldPass()
    {
        // Given
        var fileData = new FileData(_TestFile, _Parser);

        // Then
        Assert.Equal(1, fileData.Index);
        Assert.Equal("first.mp4", fileData.Filename);

        Assert.Equal(".mp4", fileData.Extension);
    }

    [Fact]
    public void RenameFile_FileNameShouldChange_Pass()
    {
        // Given
        var fileData = new FileData(_TestFile, _Parser);

        // Then
        var newFile = fileData.Rename(new NormalizedNameStrategy(3));

        Assert.Equal("001 - first.mp4", newFile.Name);
    }

    public void Dispose()
    {
        if (_TestFile.Exists)
            _TestFile.Delete();
    }

    private readonly IEntryParser _Parser;
    private readonly FileInfo _TestFile;
}