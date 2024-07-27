namespace examenDos.Dtos.Loan
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursementDate { get; set; }
    }
}
