
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
   
    [Table("Statuses", Schema = "dbo")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "StatusId", TypeName = "tinyint")]
        public byte StatusId { get; set; }

        [Required]//makes it non nullable
        [MaxLength]
        [Column(name: "Message", TypeName = "nvarchar")]
        public string Message { get; set; }
    }
}
