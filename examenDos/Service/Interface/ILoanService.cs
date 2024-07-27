using examenDos.Dtos.Amortization;
using examenDos.Dtos.common;
using examenDos.Dtos.Loan;

namespace examenDos.Service.Interface
{
    public interface ILoanService
    {

        Task<ResponseDto<AmortizationScheduleDto>> CreateLoanAsync(CreateLoanDto dto);
        Task<ResponseDto<AmortizationScheduleDto>> GetAmortizationScheduleAsync(Guid clientId);
    }
}
