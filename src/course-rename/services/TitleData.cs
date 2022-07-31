using course_rename.services.Parser;

namespace course_rename.services;

public class TitleData
{
    public int Index { get; private set; }
    public string Name { get; private set; }

    public TitleData(string titleLine, IEntryParser parser)
    {
        throw new NotImplementedException();
    }
}