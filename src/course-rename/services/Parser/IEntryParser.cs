namespace course_rename.services.Parser;


public interface IEntryParser
{
    ParseResult Parse(string fileName);
}

public record ParseResult(string Index, string Filename);