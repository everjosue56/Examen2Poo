using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examenDos.DataBase.Entities
{

    [Table("customers", Schema = "dbo")]
    public class CustomersEntity
    {

        //id de usuario

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        //nombre de usuario

        [Column("username")]
        public string UserName { get; set; }

        //tasa de comision

        [StringLength(100)]
        [Column("commissionRate")]
        public decimal CommissionRate { get; set; }

        //tasa de interes 

        [Column("interesRate")]
        public int InteresRate { get; set; }

        // termino de meses

        [Column("term")]
        public int Term { get; set; }

        //fecha de desembolso

        [Column("disbursementDate")]
        public DateTime DisbursemenDate { get; set; }

        //primer pago 

        [Column("firstPaymentDate")]
        public DateTime FirstPayment { get; set; }
        

    }
}
