using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
  
    [Table("Notifications", Schema = "dbo")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "NotificationId", TypeName = "int")]
        public int NotificationId { get; set; }

        [Required]//makes it non nullable
        [MaxLength]
        [Column(name: "Message", TypeName = "nvarchar")]
        public string Message { get; set; }

        [Required]//makes it non nullable
        [Column(name: "RecievedAt", TypeName = "datetime")]
        public DateTime RecievedAt { get; set; }

        public int TravelId { get; set; }

        [ForeignKey("TravelId")]//Id is the column name on which the foreigh key is being implemnted
        //foreign keys are usually virtual
        public virtual TravelRequest TravelRequest { get; set; }

    }
}
