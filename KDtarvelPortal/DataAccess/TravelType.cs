
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
   
    [Table("TravelTypes", Schema = "dbo")]
    public class TravelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "TravelTypeId", TypeName = "tinyint")]
        public byte TravelTypeId { get; set; }

        [Required]//makes it non nullable
        [Column(name: "Type", TypeName = "nvarchar")]
        public string Type { get; set; }


    }
}
