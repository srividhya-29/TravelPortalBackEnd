using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("EmployeesProjects", Schema = "dbo")]
    public class Employee_Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [Required]
        [ForeignKey("EmployeeId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Employee Employee { get; set; }

        public int ProjectId { get; set; }
        [Required]
        [ForeignKey("ProjectId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Project Project { get; set; }
    }
}
