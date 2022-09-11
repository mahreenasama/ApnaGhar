using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Interfaces
{
    public interface IAuditedModel
    {
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
