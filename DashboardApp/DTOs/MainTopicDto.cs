namespace DashboardApp.DTOs;

public class MainTopicDto
{
    public int Id { get; set; }
    public string? Tittle { get; set; }
    public List<SubTopicDto>? SubTopics { get; set; }
}
