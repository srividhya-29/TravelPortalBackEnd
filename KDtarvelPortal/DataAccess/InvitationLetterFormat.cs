
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    
    [Table("InvitationLetterFormats", Schema = "dbo")]
    public class InvitationLetterFormat
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "InvitationLetterFormatId", TypeName = "tinyint")]
        public byte InvitationLetterFormatId { get; set; }

        [Required]//makes it non nullable
        [MaxLength]
        [Column(name: "LetterContent", TypeName = "nvarchar")]
        public string LetterContent { get; set; }

        public byte DesignationId { get; set; }

        [ForeignKey("DesignationId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Designation Designation { get; set; }
    }
}
