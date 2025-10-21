using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Abstractions
{
   public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(long id);
        Task<IList<UserResponse>> GetAllAsync();
        Task<UserResponse> GetuserByEmailAsync(string email);
        Task InsertAsync(CreateUserRequest request);
        Task UpdateAsync(EditUserRequest request);
        void DeleteAsync(long id);
    }
}
