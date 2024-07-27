namespace examenDos.Dtos.Amortization
{
    public class AmortizationScheduleDto
    {
        public Guid LoanId { get; set; }
        public List<AmortizationDetailDto> AmortizationPlan { get; set; }
    }
}
