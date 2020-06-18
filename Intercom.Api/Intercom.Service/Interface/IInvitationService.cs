using Intercom.BusinessLogic.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Intercom.Service.Interface
{
    public interface IInvitationService
    {
       Task<InviteeResponse> InviteToDublinOfficeAsync(IFormFile file);
    }
}
