using Intercom.BusinessLogic.Model;
using System.Collections.Generic;

namespace Intercom.BusinessLogic.Interface
{
    /// <summary>
    /// Tranform the customer records text file to CustomerDistanceMode
    /// </summary>
    public interface ITranformToCustomerDistanceRecord
    {
        List<CustomerRecord> MappingFromTextFileToCustomerRecord(string filePath);
    }
}
