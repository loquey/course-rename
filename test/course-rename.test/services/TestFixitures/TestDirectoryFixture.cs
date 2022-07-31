namespace course_rename.test.services.TestFixtures;

public class TestDirectoryFixture : IDisposable
{
    public string DirName => "test_dir";

    /// <summary>
    /// Setup test directory for running the test
    /// </summary>
    public TestDirectoryFixture()
    {
        Directory.CreateDirectory(DirName);
        var dir = Directory.CreateDirectory(DirName);
        File.Create(Path.Combine(dir.Name, "first.mp4")).Close();
        File.Create(Path.Combine(dir.Name, "second.mp4")).Close();
        File.Create(Path.Combine(dir.Name, "third.mp4")).Close();

    }

    public void Dispose()
    {
        Directory.Delete(DirName, true);
    }
}
