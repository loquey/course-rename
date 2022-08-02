using System.Text;

namespace course_rename.services.Parser;

public class IndexFirstParser : IEntryParser
{
    public ParseResult Parse(string filename)
    {
        StringBuilder indexStr = new();
        StringBuilder filenameStr = new();
        bool nonDigitfound = false;

        foreach (var ch in filename)
        {
            if (char.IsDigit(ch) && !nonDigitfound)
            {
                indexStr.Append(ch);
                continue;
            }

            nonDigitfound = true;

            if (char.IsLetter(ch) || filenameStr.Length > 0) filenameStr.Append(ch);
        }

        return new ParseResult(indexStr.ToString(), filenameStr.ToString());
    }
}