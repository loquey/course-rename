using course_rename.services.Parser;

namespace course_rename.test.services;

public class TitleTest
{
    public TitleTest()
    {
        _EntryParser = new IndexFirstParser();
    }

    [Fact]
    public void Constructor_ParsingValidString_ShouldPass()
    {
        // Given
        var td = new TitleData("001 - filename.mp4", _EntryParser);

        // When

        // Then
        Assert.Equal(1, td.Index);
        Assert.Equal("filename", td.Name);
    }

[Fact]
public void Constructor_ParsingInvalidString_ShouldFail()
{
        // When
        Assert.Throws<ArgumentException>(() => new TitleData(string.Empty, _EntryParser));
}

    private readonly IEntryParser _EntryParser;
}