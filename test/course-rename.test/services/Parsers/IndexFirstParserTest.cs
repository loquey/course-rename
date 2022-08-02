using course_rename.services.Parser;

namespace course_rename.test.services.Parsers;


public class IndexFirstParserTest
{
    [Theory]
    [InlineData("01lesson.mp4",  "01", "lesson.mp4")]
    [InlineData("01 lesson.mp4",  "01", "lesson.mp4")]
    [InlineData("01 - lesson.mp4",  "01", "lesson.mp4")]
    [InlineData("1lesson.mp4",  "1", "lesson.mp4")]
    [InlineData("1  lesson.mp4",  "1", "lesson.mp4")]
    [InlineData("1 - lesson.mp4",  "1", "lesson.mp4")]
    [InlineData("001lesson.mp4",  "001", "lesson.mp4")]
    [InlineData("001  lesson.mp4",  "001", "lesson.mp4")]
    [InlineData("001 - lesson.mp4",  "001", "lesson.mp4")]
    public void IndexFirstParse_ParseCorrectFilename_ShouldPass(string filename, string index, string parsedName)
    {
        // Given
        var parser = new IndexFirstParser();

        // When
        var parseResult = parser.Parse(filename);

        // Then
        Assert.Equal(index, parseResult.Index);
        Assert.Equal(parsedName, parseResult.Filename);
    }

    [Fact]
    public void IndexFirstParse_ParseWrongFileName_ShouldFail()
    {
         // Given
        var parser = new IndexFirstParser();

        // When
        var parseResult = parser.Parse("lesson01.mp4");

        // Then
        Assert.NotEqual("1", parseResult.Index);
        Assert.NotEqual("lesson.mp4", parseResult.Filename);
    }
}