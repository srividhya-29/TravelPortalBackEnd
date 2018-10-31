
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("FinanceDetails", Schema = "dbo")]
    public class FinanceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }


        [Column(name: "CashInAdvance", TypeName = "money")]
        public decimal CashInAdvance { get; set; }

        [Column(name: "BudgetAllocated", TypeName = "money")]
        public decimal BudgetAllocated { get; set; }

        public int TravelId { get; set; }

        [ForeignKey("TravelId")]//Id is the column name on which the foreigh key is being implemnted
                                 //foreign keys are usually virtual

        public virtual TravelRequest TravelRequest { get; set; }
    }
}
