namespace course_rename.services.NameStrategy;


public class NormalizedNameStrategy : INamingStrategy
{
    
    public NormalizedNameStrategy(int indexLength)
    {
        IndexLength = indexLength;
    }

    ///Inherit
    public string FormatName(int index, string filename, string extension)
    {
        var formatSpecifier = $"D{IndexLength}";
        return string.Format("{0} - {1}.{2}", index.ToString(formatSpecifier), filename, extension);
    }

        public int IndexLength { get; }
}