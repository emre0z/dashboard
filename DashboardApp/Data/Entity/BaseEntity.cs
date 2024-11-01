namespace DashboardApp.Data.Entity
{
    public class BaseEntity
    {
        public string? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; } // Değişiklik tarihi için
        public string? UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; } // Değişiklik tarihi için

    }
}
