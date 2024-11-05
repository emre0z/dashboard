namespace DashboardApp.DTOs;

public class SubTopicDto
{
    public int Id { get; set; }
    public string? Tittle { get; set; }
    public int MainTopicId { get; set; }
    public List<UrlDto>? URLs { get; set; }
    public List<InfoDto>? Infos { get; set; }
}
