using examenDos.DataBase.Entities;
using examenDos.DataBase;
using examenDos.Dtos.common;
using Microsoft.AspNetCore.Mvc;
using examenDos.Dtos.Loan;
using examenDos.Service.Interface;
using Microsoft.EntityFrameworkCore;
using examenDos.Dtos.Amortization;

namespace examenDos.Service
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext _context;

        public LoanService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> CreateLoanAsync(CreateLoanDto dto)
        {
            var loan = new LoanEntity
            {
                Id = Guid.NewGuid(),
                CustomerId = dto.CustomerId,
                Amount = dto.Amount,
                InterestRate = dto.InterestRate,
                Term = dto.Term,
                DisbursementDate = dto.DisbursementDate
            };

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            var amortizationPlan = CalculateAmortizationSchedule(loan);

            var amortizationScheduleDto = new AmortizationScheduleDto
            {
                LoanId = loan.Id,
                AmortizationPlan = amortizationPlan
            };

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 201,
                Status = true,
                Data = amortizationScheduleDto,
                Message = "Loan and amortization plan successfully created."
            };
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> GetAmortizationScheduleAsync(Guid clientId)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.CustomerId == clientId);
            if (loan == null)
            {
                return new ResponseDto<AmortizationScheduleDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Message = "Loan not found for the client"
                };
            }

            var schedule = await _context.AmortizationDetails
                .Where(a => a.LoanId == loan.Id)
                .ToListAsync();

            var scheduleDto = new AmortizationScheduleDto
            {
                LoanId = loan.Id,
                AmortizationPlan = schedule.Select(a => new AmortizationDetailDto
                {
                    InstallmentNumber = a.InstallmentNumber,
                    PaymentDate = a.PaymentDate,
                    Days = a.Days,
                    Interest = a.Interest,
                    Principal = a.Principal,
                    LevelPaymentWithoutSVSD = a.LevelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = a.LevelPaymentWithSVSD,
                    PrincipalBalance = a.PrincipalBalance
                }).ToList()
            };

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 200,
                Status = true,
                Data = scheduleDto,
                Message = "Amortization schedule retrieved successfully"
            };
        }

        private List<AmortizationDetailDto> CalculateAmortizationSchedule(LoanEntity loan)
        {
            var schedule = new List<AmortizationDetailDto>();

            decimal principalBalance = loan.Amount;
            decimal monthlyInterestRate = loan.InterestRate / 100 / 12m; // Usa 'm' para asegurar que es decimal
            double interestRateDouble = (double)monthlyInterestRate;

            // Calcular el pago nivelado sin SVSD
            double denominator = Math.Pow(1 + interestRateDouble, -loan.Term);
            decimal levelPaymentWithoutSVSD = (loan.Amount * (decimal)interestRateDouble) / (1 - (decimal)denominator);

            for (int i = 1; i <= loan.Term; i++)
            {
                decimal interest = principalBalance * monthlyInterestRate;
                decimal principal = levelPaymentWithoutSVSD - interest;
                principalBalance -= principal;

                schedule.Add(new AmortizationDetailDto
                {
                    InstallmentNumber = i,
                    PaymentDate = loan.DisbursementDate.AddMonths(i),
                    Days = (loan.DisbursementDate.AddMonths(i) - loan.DisbursementDate).Days,
                    Interest = interest,
                    Principal = principal,
                    LevelPaymentWithoutSVSD = levelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = levelPaymentWithoutSVSD + 10, // Placeholder para con SVSD
                    PrincipalBalance = principalBalance
                });

                // Guardar cada detalle de amortización en la base de datos
                _context.AmortizationDetails.Add(new AmortizationDetailEntity
                {
                    Id = Guid.NewGuid(),
                    LoanId = loan.Id,
                    InstallmentNumber = i,
                    PaymentDate = loan.DisbursementDate.AddMonths(i),
                    Days = (loan.DisbursementDate.AddMonths(i) - loan.DisbursementDate).Days,
                    Interest = interest,
                    Principal = principal,
                    LevelPaymentWithoutSVSD = levelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = levelPaymentWithoutSVSD + 10, // Placeholder para con SVSD
                    PrincipalBalance = principalBalance
                });
            }

            _context.SaveChangesAsync();
            return schedule;
        }
    }
}