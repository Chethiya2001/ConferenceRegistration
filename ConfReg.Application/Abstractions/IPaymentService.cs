using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Abstractions
{
    public interface IPaymentService
    {
        Task<PaymentResponse> GetByIdAsync(long id);
        Task<IList<PaymentResponse>> GetAllAsync();
        Task InsertAsync(CreatePaymentRequest request);
        Task UpdateAsync(EditPaymentRequest request);
        void DeleteAsync(long id);
    }
}
