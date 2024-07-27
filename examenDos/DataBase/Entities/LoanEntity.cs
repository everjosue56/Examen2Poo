using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examenDos.DataBase.Entities
{

    [Table("loans", Schema = "dbo")]
    public class LoanEntity
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        //id del cliente

        [Column("customerId")]
        public Guid CustomerId { get; set; }

        // monto 

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("interestRate")]

        //tasa de interes
        public decimal InterestRate { get; set; }

        //plazo de pago 

        [Column("term")]
        public int Term { get; set; }

        //fecha limite de pago de prestamo 

        [Column("disbursementDate")]
        public DateTime DisbursementDate { get; set; }
    }
}
