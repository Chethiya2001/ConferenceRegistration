using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using ConfReg.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Services
{
    internal class RegistrationService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork) : IRegistrationService
    {
        public void DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<RegistrationResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(CreateRegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EditRegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
