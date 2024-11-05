using DashboardApp.Data.Entity;


namespace DashboardApp.Data.Entity
{
    public class URL : BaseEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? SubTopicId { get; set; }

        // navigasyon
        public virtual SubTopic? SubTopic { get; set; }

    }
}
