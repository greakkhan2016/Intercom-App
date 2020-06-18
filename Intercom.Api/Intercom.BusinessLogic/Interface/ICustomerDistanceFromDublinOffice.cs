using Intercom.BusinessLogic.Model;
using System.Collections.Generic;

namespace Intercom.BusinessLogic.Interface
{
    /// <summary>
    /// Transforms customers records  object into customerDistanceRecord with distance to travel from honme location to work
    /// </summary>
    public interface ICustomerDistanceFromDublinOffice
    {
        List<InviteeRecord> TransformCustomerRecordToInviteeDistanceRecord(List<CustomerRecord> customerRecords);
    }
}
