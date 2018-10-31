using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;

namespace DataAccess
{
    [Table("Projects", Schema = "dbo")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "ProjectId", TypeName = "int")]
        public int ProjectId { get; set; }

        [Required]//makes it non nullable
        [MaxLength(50)]
        [Column(name: "ProjectName", TypeName = "nvarchar")]
        public string ProjectName { get; set; }

        
        public int? InchargeId { get; set; }
       
        [ForeignKey("InchargeId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Employee Employee { get; set; }
    }
}
