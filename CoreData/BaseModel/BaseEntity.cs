using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
           //CreatedDate = Helpers.Utilities.FormatDateForDB(DateTime.UtcNow);
           //FlgStatus = 1;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        /*
        public int? CreatedBy { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public int FlgStatus { get; set; }
        */
    }
}