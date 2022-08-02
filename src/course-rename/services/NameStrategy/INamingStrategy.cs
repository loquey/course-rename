namespace course_rename.services.NameStrategy;


public interface INamingStrategy
{
    
    public string FormatName(int index, string filename, string extension);
}