using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{

    [Table("Clients", Schema = "dbo")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "ClientId", TypeName = "int")]
        public int ClientId { get; set; }

        [Required]//makes it non nullable
        [Column(name: "ClientName", TypeName = "nvarchar")]
        public string ClientName { get; set; }
    }
}
