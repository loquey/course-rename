using course_rename.services.NameStrategy;

namespace course_rename.test.services.NameStrategy;


public class NormalizedNamingStrategyTest
{
    [Fact]
    public void FormatName_ShouldGenerateCorrectFormat()
    {
        // Given
        var strategy = new NormalizedNameStrategy(3);

        // When
        var filename = strategy.FormatName(1, "fname", "mp4");

        // Then
        Assert.Equal("001", "001 - fname.mp4");
    }
}