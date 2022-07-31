using System.Security.AccessControl;

namespace course_rename.test.services.TestFixtures;

public class TestTitlteFixtures : IDisposable
{

    public static string FileName => "title.dat";
    public static string EmptyFile => "empty.dat";

    /// <summary>
    /// Create the test files with the sample titles
    /// </summary>
    public TestTitlteFixtures()
    {
        // Create an empty file 
         var emptyFile = new FileInfo(EmptyFile);

        var emptyStream = emptyFile.Create();
        emptyStream.Close();

        //Create a file with 3 titles;
        var fileinfo = new FileInfo(FileName);
        var fileStream = fileinfo.Create();
       

        var textWriter = new StreamWriter(fileStream);
        textWriter.WriteLine("1 Start Public Introduction");
        textWriter.WriteLine("2 Start Site Tools and Features");
        textWriter.WriteLine("3 Start Finding and Using the Course Resources");
        textWriter.Flush();
        textWriter.Close();

    }

    public void Dispose()
    {
        if (File.Exists(FileName))
            File.Delete(FileName);

        if (File.Exists(EmptyFile))
            File.Delete(EmptyFile);
    }

}