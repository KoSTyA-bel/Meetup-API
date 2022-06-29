namespace Meetup.BLL;

public static class StringExtensions
{
    public static DateTime FindDateTime(this string source)
    {
        DateTime date;

        try
        {
            date = DateTime.ParseExact(source, "dd.MM.yyyy HH:mm:ss", null);
        }
        catch (FormatException e)
        {
            date = DateTime.Now;
        }

        return date;
    }
}
