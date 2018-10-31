
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    

    [Table("Employees", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "EmployeeId", TypeName = "int")]
        public int EmployeeId { get; set; }

        [Required]//makes it non nullable
        [MaxLength(50)]
        [Column(name: "EmployeeName", TypeName = "nvarchar")]
        public string EmployeeName { get; set; }

        

        [Required]//makes it non nullable
        [MaxLength(25)]
        [Column(name: "WorkLocation", TypeName = "nvarchar")]
        public string WorkLocation { get; set; }

        [Required]//makes it non nullable
        [MaxLength]
        [Column(name: "Address", TypeName = "nvarchar")]
        public string Address { get; set; }

        [Required]//makes it non nullable
        [Column(name: "MobNo", TypeName = "varchar")]
        public string MobNo { get; set; }

        [Required]//makes it non nullable
        [Column(name: "FatherName", TypeName = "nvarchar")]
        public string FatherName { get; set; }

        [Required]//makes it non nullable
        [Column(TypeName = "nvarchar")]
        public string MotherName { get; set; }


        [MaxLength]
        [Column(TypeName = "nvarchar")]
        public string PortalPassword { get; set; }



        public byte DesignationId { get; set; }
        [Required]//makes it non nullable
        [ForeignKey("DesignationId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Designation Designation { get; set; }
    }
}
