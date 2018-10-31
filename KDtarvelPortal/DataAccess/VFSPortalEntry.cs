using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    
    [Table("VFSPortalEntries", Schema = "dbo")]
    public class VFSPortalEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]//makes it non nullable
        [Column(name: "VFSLoginId", TypeName = "nvarchar")]
        public string VFSLoginId { get; set; }

        [Required]//makes it non nullable
        [MaxLength]
        [Column(name: "VFSLoginPassword", TypeName = "nvarchar")]
        public string VFSLoginPassword { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Employee Employee { get; set; }


    }
}
