using examenDos.Dtos.common;
using examenDos.Dtos.Customers;
using examenDos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace examenDos.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        
            private readonly ICustomersService _customersService;

            public CustomersController(ICustomersService customersService)
            {
                _customersService = customersService;
            }

            [HttpGet]
            public async Task<ActionResult<ResponseDto<List<CustomersDto>>>> GetAll()
            {
                var response = await _customersService.GetCustomerAsync();
                return StatusCode(response.StatusCode, response);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ResponseDto<CustomersDto>>> Get(Guid id)
            {
                var response = await _customersService.GetCustomersByIdAsync(id);
                return StatusCode(response.StatusCode, response);
            }

            [HttpPost]
            public async Task<ActionResult<ResponseDto<CustomersDto>>> Create(CreateCustomersDto dto)
            {
                var response = await _customersService.CreateAsync(dto);
                return StatusCode(response.StatusCode, response);
            }
         
        }
    }

