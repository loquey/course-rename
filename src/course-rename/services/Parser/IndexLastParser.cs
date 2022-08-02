using System.Text;

namespace course_rename.services.Parser;

public class IndexLastParser : IEntryParser
{
    public ParseResult Parse(string filename)
    {
        var extensionMarker = filename.LastIndexOf('.');

        StringBuilder indexStr = new();
        StringBuilder filenameStr = new(filename[extensionMarker..]);
        bool nonDigitfound = false;

        for (int i = --extensionMarker; i >= 0; i--)
        {
            var ch = filename[i];
            if (char.IsDigit(ch) && !nonDigitfound)
            {
                indexStr.Insert(0, ch);
                continue;
            }

            nonDigitfound = true;

            if (char.IsLetter(ch) && filenameStr.Length > 0) filenameStr.Insert(0, ch);
        }

        return new ParseResult(indexStr.ToString(), filenameStr.ToString());
    }
}