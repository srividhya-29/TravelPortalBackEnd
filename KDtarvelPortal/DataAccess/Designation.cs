
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
   


    [Table("Designations", Schema = "dbo")]
    public class Designation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "DesignationId", TypeName = "tinyint")]
        public byte DesignationId { get; set; }

        [Required]//makes it non nullable
        [MaxLengthAttribute(50)]
        [Column(name: "DesignationType", TypeName = "nvarchar")]
        public string DesignationType { get; set; }
    }
}
