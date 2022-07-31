using course_rename.services.NameStrategy;
using course_rename.services.Parser;

namespace course_rename.services;

public class FileDataTest
{
    public FileDataTest()
    {
        _Parser = new IndexLastParser();
    }

    [Fact]
    public void Constructor_ShouldPass()
    {
        // Given
        var fileData = new FileData(new FileInfo("first1.mp4"), _Parser);

        // Then
        Assert.Equal(1, fileData.Index);
        Assert.Equal("first.mp4", fileData.Filename);

        Assert.Equal("mp4", fileData.Extension);
    }

    [Fact]
    public void RenameFile_FileNameShouldChange_Psss()
    {
        // Given
         var fileData = new FileData(new FileInfo("first1.mp4"), _Parser);

        // Then
        var newFile = fileData.Rename(new NormalizedNameStrategy(3));

        Assert.Equal("001 - first.mp4", newFile.Name);
    }

    private readonly IEntryParser _Parser;
}