namespace course_rename.test.services;

public class TitleLoaderTest : IClassFixture<TestTitlteFixtures>
{

    public TitleLoaderTest(TestTitlteFixtures fixture)
    {
        _Fixture = fixture;
        _TitleLoader = new TitleLoader();

    }


    [Fact]
    public void LoadTitles_LoadTitlesFromFile_ShouldReturnTitleCount()
    {


        // Then
        Assert.Equal(3, _TitleLoader.LoadTitles(TestTitlteFixtures.FileName));
    }

    [Fact]
    public void LoadTitles_LoadTitlesFromEmptyFile_ShouldReturnZero()
    {


        // When

        // Then
        Assert.Equal(0, _TitleLoader.LoadTitles(TestTitlteFixtures.EmptyFile));
    }

    [Fact]
    public void LoadTitles_LoadTitleFromInvalidFile_ShouldThrowException()
    {

        // When

        // Then
        Assert.Throws<FileNotFoundException>(() => _TitleLoader.LoadTitles("Invalidfile.dat"));
    }

    [Fact]
    public void GetTitle_GetTitleByIndex_ShouldReturnTitle()
    {
        // Given
        _TitleLoader.LoadTitles(TestTitlteFixtures.FileName);

        // When
        var title = _TitleLoader.GetTitle(1);

        // Then
        Assert.NotNull(title);
        Assert.Equal(1, title.Index);
    }

    [Fact]
    public void GetTitle_UsingWrongIndex_ShouldReturnNoTitle()
    {
        // Given
        _TitleLoader.LoadTitles(TestTitlteFixtures.FileName);

        // When
        var title = _TitleLoader.GetTitle(20);

        // Then
        Assert.Null(title);
    }

    [Fact]
    public void GetTitle_UsingEmtpyFile_ShouldReturnNoTitle()
    {
        // Given

        // When
        var titles = _TitleLoader.LoadTitles(TestTitlteFixtures.EmptyFile);

        // Then
        Assert.Equal(0, titles);
    }

    private readonly TestTitlteFixtures _Fixture;
    private TitleLoader _TitleLoader;


}
