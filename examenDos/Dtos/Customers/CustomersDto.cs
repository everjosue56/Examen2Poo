namespace examenDos.Dtos.Customers
{
    public class CustomersDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public decimal CommissionRate { get; set; }
        public int InteresRate { get; set; }
        public int Term { get; set; }
        public DateTime DisbursemenDate { get; set; }
        public DateTime FirstPayment { get; set; }
    }
}
