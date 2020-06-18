using Intercom.BusinessLogic.Model;
using System.Collections.Generic;

namespace Intercom.BusinessLogic.Interface
{
    /// <summary>
    /// Writes Customer invited to office into a text file
    /// </summary>
    public interface ISaveInviteeRecord
    {
        InviteeResponse WriteToDiskInviteeToOffice(List<InviteeRecord> invitees);
    }
}
