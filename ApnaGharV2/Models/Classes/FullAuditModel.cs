using ApnaGharV2.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models.Classes
{
    public abstract class FullAuditModel: IAuditedModel, IActivatableModel
    {
        public string? CreatedByUserId { get; set; }

        [Column(TypeName="datetime")]
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
