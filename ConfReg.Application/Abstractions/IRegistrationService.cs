using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Abstractions
{
    public interface IRegistrationService
    {
        Task<RegistrationResponse> GetByIdAsync(long id);
        Task<IList<RegistrationResponse>> GetAllAsync();
        Task InsertAsync(CreateRegistrationRequest request);
        Task UpdateAsync(EditRegistrationRequest request);
        void DeleteAsync(long id);
    }
}
