namespace Meetup.Model;

public class MeetingViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Speaker { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public string Place { get; set; } = string.Empty;
}
