using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models.Classes
{
    public abstract class FullAuditModel: IAuditedModel, IActivatableModel
    {
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
