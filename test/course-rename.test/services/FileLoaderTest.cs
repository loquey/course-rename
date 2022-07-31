namespace course_rename.test.services;


public class File_LoaderTest : IClassFixture<TestDirectoryFixture>
{

    public File_LoaderTest(TestDirectoryFixture fixture)
    {
        _Fixture = fixture;
        _Loader = new FileLoader();
    }

    [Fact]
    public void LoadFiles_CanLoadfiles_ShouldPass()
    {


        // Then
        Assert.Equal(3, _Loader.LoadFiles(_Fixture.DirName));
    }

    [Fact]
    public void LoadFiles_DirectoryDoesNotExist_ShouldBeZero()
    {

        // Then
        Assert.Equal(0, _Loader.LoadFiles("doestnotexit"));
    }

    [Fact]
    public void FindFile_FileExist_ShouldReturnFile()
    {
          // Given
       _Loader.LoadFiles(_Fixture.DirName);

        // when
        var fileData = _Loader.FindFile(2);

        Assert.NotNull(fileData);
        Assert.Equal(2, fileData?.Index);
    }

    [Fact]
    public void FindFile_FileDoesNotExist_ShouldFail()
    {
        // Given
       _Loader.LoadFiles(_Fixture.DirName);

        // when
        var fileData = _Loader.FindFile(10);

        Assert.Null(fileData);
    }

    private readonly TestDirectoryFixture _Fixture;
    private readonly FileLoader _Loader;
}
