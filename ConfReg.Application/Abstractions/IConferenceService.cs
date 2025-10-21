using ConfReg.Application.DTOs.Request;
using ConfReg.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfReg.Application.Abstractions
{
    public interface IConferenceService
    {
        Task<ConferenceResponse> GetByIdAsync(long id);
        Task<IList<ConferenceResponse>> GetAllAsync();
        Task InsertAsync(CreateConferenceRequest request);
        Task UpdateAsync(EditConferenceRequest request);
        void DeleteAsync(long id);
    }
}
