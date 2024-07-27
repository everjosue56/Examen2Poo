namespace examenDos.Dtos.Customers
{
    public class CreateCustomersDto
    {
      
        public string UserName { get; set; }
        public decimal CommissionRate { get; set; }
        public int InteresRate { get; set; }
        public int Term { get; set; }
        DateTime DisbursemenDate { get; set; }
        public DateTime FirstPayment { get; set; }
    }
}
