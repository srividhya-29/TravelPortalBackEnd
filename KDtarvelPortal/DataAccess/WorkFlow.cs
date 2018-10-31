using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("WorkFlows", Schema = "dbo")]
    public class WorkFlow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "WorkFlowId", TypeName = "int")]
        public int WorkFlowId { get; set; }

        [Required]//makes it non nullable
        [Column(name: "Role", TypeName = "nvarchar")]
        public string Role { get; set; }


      
        public byte? CurrentStatusId { get; set; }

     
        public byte? NextStatusId { get; set; }
        



        [ForeignKey("CurrentStatusId")]
        public virtual Status CurrentStatus { get; set; }

        [ForeignKey("NextStatusId")]
        public virtual Status NextStatus { get; set; }
















    }
}
