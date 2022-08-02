using course_rename.services.Parser;

namespace course_rename.test.services.Parsers;

public class IndexLastParserTest
{
      [Theory]
    [InlineData("lesson1.mp4",  "1", "lesson.mp4")]
    [InlineData("lesson - 1.mp4",  "1", "lesson.mp4")]
    [InlineData("lesson 1.mp4",  "1", "lesson.mp4")]
    [InlineData("lesson01.mp4",  "01", "lesson.mp4")]
    [InlineData("lesson - 01.mp4",  "01", "lesson.mp4")]
    [InlineData("lesson 01.mp4",  "01", "lesson.mp4")]
    [InlineData("lesson001.mp4",  "001", "lesson.mp4")]
    [InlineData("lesson 001.mp4",  "001", "lesson.mp4")]
    [InlineData("lesson - 001.mp4",  "001", "lesson.mp4")]
    public void IndexLastParse_ParseCorrectFilename_ShouldPass(string filename, string index, string parsedName)
    {
        // Given
        var parser = new IndexLastParser();

        // When
        var parseResult = parser.Parse(filename);

        // Then
        Assert.Equal(index, parseResult.Index);
        Assert.Equal(parsedName, parseResult.Filename);
    }

    [Fact]
    public void IndexLastParse_ParseWrongFileName_ShouldFail()
    {
         // Given
        var parser = new IndexLastParser();

        // When
        var parseResult = parser.Parse("lesson01.mp4");

        // Then
        Assert.NotEqual("1", parseResult.Index);
        Assert.NotEqual("lesson.mp4", parseResult.Filename);
    }
}
