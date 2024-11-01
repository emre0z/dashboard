namespace DashboardApp.Data.Entity
{
    public class SubTopic : BaseEntity
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        public int? MainTopicId { get; set; }

        //navigasyon
        public virtual MainTopic MainTopic { get; set; }
        public virtual ICollection<URL> URLs { get; set; }
        public virtual ICollection<Info> Infos { get; set; }
        

    }
}
