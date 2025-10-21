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
    public class MembershipService(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork) : IMembershipService
    {
        public async void DeleteAsync(long id)
        {
            var findMembership = await membershipRepository.GetByIdAsync(id);
            if (findMembership == null)
            {
                throw new Exception($"Not Found Conference {id} this ID.");
            }
            membershipRepository.Remove(findMembership);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<MembershipResponse>> GetAllAsync()
        {
            return (IList<MembershipResponse>)await membershipRepository.GetAllAsync();
        }

        public async Task<MembershipResponse> GetByIdAsync(long id)
        {
            var c = await membershipRepository.GetByIdAsync(id);
            var response = new MembershipResponse
            {
                Id = c.Id,
                Type = c.Type,
                DiscountPercentage = c.DiscountPercentage,
            };
            return response;
        }

        public async Task InsertAsync(CreateMembershipRequest request)
        {
            var memebrship = new Membership();
            var isSuccess = memebrship.Initialize(
             request.Type,request.DiscountPercentage
            );
            if (isSuccess)
            {
                await membershipRepository.CreateAsync(memebrship);
                await unitOfWork.SaveChangesAsync();

            }

            throw new Exception();
        }

        public async Task UpdateAsync(EditConferenceRequest request)
        {
            var findMembership = await membershipRepository.GetByIdAsync(request.Id);
            if (findMembership == null)
            {
                throw new Exception("Not Found");
            }
            var isSuccess = findMembership.Initialize(request.Title,request.RegistrationFee);
            if (isSuccess)
            {
                await membershipRepository.UpdateAsync(findMembership);
                await unitOfWork.SaveChangesAsync();
            }
            throw new Exception();

        }
    }
}
