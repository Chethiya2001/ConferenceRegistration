using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;


namespace ConfReg.Application.Services
{
    internal class RegistrationService(IMembershipRepository membershipRepository,IUserRepository userRepository,IPaymentRepository paymentRepository, IUnitOfWork unitOfWork,IRegistrationRepository registrationRepository,IConferenceRepository conferenceRepository) : IRegistrationService
    {
        public void DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<RegistrationResponse>> GetAllAsync()
        {
            return (IList<RegistrationResponse>)await registrationRepository.GetAllAsync();
        }

        public async Task<RegistrationResponse> GetByIdAsync(long id)
        {
            var registration = await registrationRepository.GetByIdAsync(id);
            if (registration == null)
            {
                throw new Exception("Not Found!");
            }
            var registerdPerson = await userRepository.GetByIdAsync(registration.PersonId);
            if (registerdPerson == null)
            {
                throw new Exception("Not Found registerd user!");
            }
            var registedConference = await conferenceRepository.GetByIdAsync(registration.ConferenceId);
            if (registedConference == null) {
                throw new Exception($"Not found registed conference by this ID : {registedConference!.Id}");
            }
            var response = new RegistrationResponse
            {
                Id = registration.Id,
                ConferenceId = registration.ConferenceId,
                ConsferenceTitle = registedConference.Title,
                MembershipId = registration.MembershipId,
                MembershipTypeName = registerdPerson.Name ,
                PersonId = registration.PersonId,
                
            };
            return response;
        }

        public async Task InsertAsync(CreateRegistrationRequest request)
        {
            var registration = new Registration();
            var person = await userRepository.GetByIdAsync(request.PersonId);
            if (person == null)
            {
                throw new Exception("Not Found registerd user!");
            }
            var conference = await conferenceRepository.GetByIdAsync(request.ConferenceId);
            if (conference == null)
            {
                throw new Exception($"Not found conference by this ID : {conference!.Id}");
            }
            var membership = await membershipRepository.GetByIdAsync(request.MembershipId);
            if (membership == null)
            {
                throw new Exception($"Not found Membership by this ID : {membership!.Id}");
            }
            var isSuccess = registration.Initialize(conference.Id,person.Id,membership.Id);
            await registrationRepository.CreateAsync(registration);
            await unitOfWork.SaveChangesAsync();


        }

        public Task UpdateAsync(EditRegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
