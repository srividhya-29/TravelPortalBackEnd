using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;

namespace DataAccess
{
    
    [Table("TravelRequests", Schema = "dbo")]
    public class TravelRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "TravelId", TypeName = "int")]
        public int TravelId { get; set; }


        [Required]//makes it non nullable
        [Column(name: "TravelRequestName", TypeName = "nvarchar")]
        public string TravelRequestName { get; set; }


        [Required]//makes it non nullable
        [Column(name: "StartDate", TypeName = "datetime")]
        public DateTime StartDate { get; set; }


        [Required]//makes it non nullable
        [Column(name: "EndDate", TypeName = "datetime")]
        public DateTime EndDate { get; set; }


        [Required]//makes it non nullable
        [Column(name: "Place", TypeName = "nvarchar")]
        public string Place { get; set; }

        [Column(name: "InvitationLetterPath", TypeName = "nvarchar")]
        [DefaultValue("")]
        public string InvitationLetterPath { get; set; }

        public byte TravelTypeId { get; set; }
        [Required]
        [ForeignKey("TravelTypeId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual TravelType TravelType { get; set; }


        

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Client Client { get; set; }


        public byte StatusId { get; set; }
        [Required]
        [ForeignKey("StatusId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Status Status { get; set; }

        public int EmployeeProjectId { get; set; }
        [Required]
        [ForeignKey("EmployeeProjectId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual Employee_Project Employee_Project { get; set; }




    }
}
