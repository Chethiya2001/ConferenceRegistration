using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Services
{
    internal class PaymentService(IPaymentRepository paymentRepository,IUnitOfWork unitOfWork) : IPaymentService
    {
        public async void DeleteAsync(long id)
        {
           var payment = await paymentRepository.GetByIdAsync(id);
            if (payment == null) {
                throw new Exception();
            }
            paymentRepository.Remove(payment);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<IList<PaymentResponse>> GetAllAsync()
        {
            return (IList<PaymentResponse>)await paymentRepository.GetAllAsync();
        }

        public async Task<PaymentResponse> GetByIdAsync(long id)
        {
             var payment = await paymentRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new Exception("Not Found!");
            }
            var response = new PaymentResponse
            {
                Id = id,
                Amount = payment.Amount,
                PaymentStatus = payment.IsSuccessful,
                RegistrationId = payment.RegistrationId,
                
                           };
            return response;
        }

     
        public async Task InsertAsync(CreatePaymentRequest request)
        {
            var payment = new Payment();
            var isSuccess = payment.Initialize(request.RegistrationId, request.Amount,request.IsSuccessful);
            if (isSuccess)
            {
                await paymentRepository.CreateAsync(payment);
                await unitOfWork.SaveChangesAsync();
            }
            throw new Exception();
        }

        public async Task UpdateAsync(EditPaymentRequest request)
        {
            var findPayment = await paymentRepository.GetByIdAsync(request.Id);
            if (findPayment  == null)
            {
                throw new Exception("Not Found user");
            }
            var isSuccess = findPayment.UpdatePayment( request.Amount, request.IsSuccessful);
            if (isSuccess)
            {
                await paymentRepository.UpdateAsync(findPayment);
                await unitOfWork.SaveChangesAsync();
            }

            throw new Exception();
        }
    }
}
