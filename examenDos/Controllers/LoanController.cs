using examenDos.Dtos.Amortization;
using examenDos.Dtos.common;
using examenDos.Dtos.Loan;
using examenDos.Service;
using examenDos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace examenDos.Controllers
{
     
        [ApiController]
        [Route("api/[controller]")]
        public class LoanController : ControllerBase
        {
            private readonly ILoanService _loanService;

            public LoanController(ILoanService loanService)
            {
                _loanService = loanService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateLoan([FromBody] CreateLoanDto dto)
            {
                if (dto == null)
                {
                    return BadRequest(new ResponseDto<AmortizationScheduleDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Data = null,
                        Message = "Datos de prestamo no validos"
                    });
                }

                var response = await _loanService.CreateLoanAsync(dto);
                return StatusCode(response.StatusCode, response);
            }

            [HttpGet("{clientId}")]
            public async Task<IActionResult> GetAmortizationSchedule(Guid clientId)
            {
                var response = await _loanService.GetAmortizationScheduleAsync(clientId);
                return StatusCode(response.StatusCode, response);
            }
        }

    }


