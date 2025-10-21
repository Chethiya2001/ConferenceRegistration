using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Services
{
    public class ConferenceService(IConferenceRepository conferenceRepository,IUnitOfWork unitOfWork) : IConferenceService
    {
        public async void DeleteAsync(long id)
        {
            var findConference = await conferenceRepository.GetByIdAsync(id);
            if (findConference == null)
            {
                throw new Exception($"Not Found Conference {id} this ID.");
            }
            conferenceRepository.Remove(findConference);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<ConferenceResponse>> GetAllAsync()
        {
            return (IList<ConferenceResponse>)await conferenceRepository.GetAllAsync();
        }

        public async Task<ConferenceResponse> GetByIdAsync(long id)
        {
           var c = await conferenceRepository.GetByIdAsync(id);
            var response  =  new ConferenceResponse
            {
                Id = c.Id,
                Title = c.Title,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                RegistrationFee = c.RegistrationFee
            };
            return response;
        }

        public async Task InsertAsync(CreateConferenceRequest request)
        {
            var conference = new Conference();
            var isSuccess = conference.Initalize(
                request.Title,
                request.StartDate,
                request.EndDate,
                request.RegistrationFee
            );
            if (isSuccess)
            {
                await conferenceRepository.CreateAsync(conference);
                await unitOfWork.SaveChangesAsync();

            }
           
            throw new Exception();
            
        }

        public async Task UpdateAsync(EditConferenceRequest request)
        {
            var findConference = await conferenceRepository.GetByIdAsync(request.Id);
            if (findConference == null)
            {
                throw new Exception("Not Found");
            }
             var isSuccess = findConference.Initalize(request.Title,request.StartDate,request.EndDate,request.RegistrationFee);
            if (isSuccess)
            {
                await conferenceRepository.UpdateAsync(findConference);
                await unitOfWork.SaveChangesAsync();
            }
            throw new Exception();



        }
    }
}
