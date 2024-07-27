using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examenDos.DataBase.Entities
{
    public class AmortizationDetailEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        //id del prestamo 

        [ForeignKey("LoanEntity")]
        [Column("loanId")]
        public Guid LoanId { get; set; }

        //orden de pago

        [Column("installmentNumber")]
        public int InstallmentNumber { get; set; }

        //fecha de pago

        [Column("paymentDate")]
        public DateTime PaymentDate { get; set; }

        // numero de dias 

        [Column("days")]
        public int Days { get; set; }

        //tasa de interes

        [Column("interest")]
        public decimal Interest { get; set; }

        //monto original del prestamo

        [Column("principal")]
        public decimal Principal { get; set; }

        //monto fijo

        [Column("levelPaymentWithoutSVSD")]
        public decimal LevelPaymentWithoutSVSD { get; set; }

        //total que debe pagar cada cierto periodo

        [Column("levelPaymentWithSVSD")]
        public decimal LevelPaymentWithSVSD { get; set; }

        //monto restante a pagar

        [Column("principalBalance")]
        public decimal PrincipalBalance { get; set; }

        //prestamo
        public LoanEntity Loan { get; set; }
    }
}
