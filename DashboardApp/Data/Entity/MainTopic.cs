namespace DashboardApp.Data.Entity;

public class MainTopic : BaseEntity
{
    public int Id { get; set; }
    public string? Tittle { get; set; }

    // Navigasyon Özelliği (İlişki)
    public virtual ICollection<SubTopic>? SubTopics { get; set; }

    /*
public MainTopic()
{
    CreatedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); 
    UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}

// UpdateDate'i güncelleyen metot
public void UpdateTimestamp()
{
    UpdateDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
*/
}
