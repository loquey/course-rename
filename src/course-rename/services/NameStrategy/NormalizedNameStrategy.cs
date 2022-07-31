namespace course_rename.services.NameStrategy;

public class NormalizedNameStrategy : INamingStrategy
{
    public NormalizedNameStrategy(int indexLength)
    {
        IndexLength = indexLength;
    }

    public string FormatName(int index, string filename, string extension)
    {
        throw new NotImplementedException();
    }

        public int IndexLength { get; }
}