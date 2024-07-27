using AutoMapper;
using examenDos.DataBase;
using examenDos.DataBase.Entities;
using examenDos.Dtos.common;
using examenDos.Dtos.Customers;
using examenDos.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace examenDos.Service
{
    public class CustomerService : ICustomersService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<CustomersDto>>> GetCustomerAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            var CustomersDtos = customers.Select(a => new CustomersDto
            {
                Id = a.Id,
                UserName = a.UserName,
                CommissionRate = a.CommissionRate,
                InteresRate= a.InteresRate,
                Term = a.Term,            
                FirstPayment = a.FirstPayment

            }).ToList();

            return new ResponseDto<List<CustomersDto>>
            {
                StatusCode = 200,
                Status = true,
                Data = CustomersDtos,
                Message = "Customers retrieved successfully",

            };
        }

        public async Task<ResponseDto<CustomersDto>> GetCustomersByIdAsync(Guid id)
        {
            var customers = await _context.Customers.FindAsync(id);

            if (customers == null)
            {
                return new ResponseDto<CustomersDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Data = null,
                    Message = "Customers not found",

                };
            }

            var customersDto = new CustomersDto
            {
                Id = customers.Id,
                UserName = customers.UserName,
                CommissionRate = customers.CommissionRate,
                InteresRate = customers.InteresRate,
                Term = customers.Term,
                FirstPayment = customers.FirstPayment
            };

            return new ResponseDto<CustomersDto>
            {
                StatusCode = 200,
                Status = true,
                Data = customersDto,
                Message = "Customers retrieved successfully",

            };
        }

        public async Task<ResponseDto<CustomersDto>> CreateAsync(CreateCustomersDto dto)
        {
            var customers = new CustomersEntity
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                CommissionRate = dto.CommissionRate,
                InteresRate = dto.InteresRate,
                Term = dto.Term,
                FirstPayment = dto.FirstPayment
            };

            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();

            var customersDto = new CustomersDto
            {
                Id = customers.Id,
                UserName =customers.UserName,
                CommissionRate = customers.CommissionRate,
                InteresRate = customers.InteresRate,
                Term = customers.Term,
                FirstPayment = customers.FirstPayment
            };

            return new ResponseDto<CustomersDto>
            {
                StatusCode = 201,
                Status = true,
                Data = customersDto,
                Message = "Customers created successfully",

            };
        }





    }

}



