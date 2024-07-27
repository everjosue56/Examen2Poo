using examenDos.Dtos.common;
using examenDos.Dtos.Customers;

namespace examenDos.Service.Interface
{
    public interface ICustomersService
    {
        Task<ResponseDto<List<CustomersDto>>> GetCustomerAsync();
        Task<ResponseDto<CustomersDto>> GetCustomersByIdAsync(Guid id);
        Task<ResponseDto<CustomersDto>> CreateAsync(CreateCustomersDto dto);
       
    }
}
