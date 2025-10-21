using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Abstractions
{
    public interface IMembershipService
    {
        Task<MembershipResponse> GetByIdAsync(long id);
        Task<IList<MembershipResponse>> GetAllAsync();
        Task InsertAsync(CreateMembershipRequest request);
        Task UpdateAsync(EditMembershipRequest request);
        void DeleteAsync(long id);
    }
}
