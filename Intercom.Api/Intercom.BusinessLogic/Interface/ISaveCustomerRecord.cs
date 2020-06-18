using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Intercom.BusinessLogic.Interface
{
    /// <summary>
    /// Saves Customer Record text file 
    /// </summary>
    public interface ISaveCustomerRecord
    {
        Task<string> WriteToDiskCustomerRecordAsync(IFormFile file);
    }
}
