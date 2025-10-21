using ConfReg.Application.Abstractions;
using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using ConfReg.Domain.Abstractions;
using ConfReg.Domain.Entity;


namespace ConfReg.Application.Services
{
    public class UserService(IUserRepository userRepository,IUnitOfWork unitOfWork) : IUserService
    {
        public async void DeleteAsync(long id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) {
                throw new Exception("Not Found!");
             }
            userRepository.Remove(user);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<UserResponse>> GetAllAsync()
        {
            return (IList<UserResponse>)await userRepository.GetAllAsync();
        }

        public async Task<UserResponse> GetByIdAsync(long id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Not Found!");
            }
            var response = new UserResponse
            {
                Id = id,
                Email = user.Email,
                Name = user.Name,
            };
            return response;
        }

        public async Task<UserResponse> GetuserByEmailAsync(string email)
        {
            var user = await userRepository.GetAllAsync();
            var byEmail = user.FirstOrDefault(x => x.Email == email);
            if (byEmail == null) throw new Exception("Not found user with  provided email");
            var response = new UserResponse
            {
                Id = byEmail.Id,
                Email = byEmail.Email,
                Name = byEmail.Name,
            };
            return response;

        }

        public async Task InsertAsync(CreateUserRequest request)
        {
            var user = new User();
            var isSuccess = user.Initialize(request.Name, request.Password, request.Name);
            if (isSuccess) {
                await userRepository.CreateAsync(user);
                await unitOfWork.SaveChangesAsync();
            }
            throw new Exception();

        }

        public async Task UpdateAsync(EditUserRequest request)
        {
            var findUser = await userRepository.GetByIdAsync(request.Id);
            if (findUser == null)
            {
                throw new Exception("Not Found user");
            }
            var isSuccess = findUser.UserUpdate(request.Name,request.Email);
            if (isSuccess) {
                await userRepository.UpdateAsync(findUser);
                await unitOfWork.SaveChangesAsync();
            }
          
            throw new Exception();
        }
    }
}
