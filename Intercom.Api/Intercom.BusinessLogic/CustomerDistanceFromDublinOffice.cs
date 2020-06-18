using Intercom.BusinessLogic.Interface;
using Intercom.BusinessLogic.Model;
using Intercom.Common;
using System.Collections.Generic;
using System.Linq;

namespace Intercom.BusinessLogic
{
    public class CustomerDistanceFromDublinOffice : ICustomerDistanceFromDublinOffice
    {
        public int MaxDistanceFromLocation { get; }

        public CustomerDistanceFromDublinOffice(int maxDistancefromLocation)
        {
            MaxDistanceFromLocation = maxDistancefromLocation;
        }
        
        /// <summary>
        /// Transforms customerRecords into InviteeRecord
        /// </summary>
        /// <param name="customerRecords"></param>
        /// <returns></returns>
        public List<InviteeRecord> TransformCustomerRecordToInviteeDistanceRecord(List<CustomerRecord> customerRecords)
        {
            return customerRecords.Select(c => new InviteeRecord
            {
                UserId = c.UserId,
                Name = c.Name,
                DistanceFromOfficeLocation = new Utilities()
                                            .CalculateDistanceBetweenTwoLocations(c.Latitude,c.Longitude,DublinOfficeLocation.Latitude,DublinOfficeLocation.Longitude)
            })
              .Where(c => c.DistanceFromOfficeLocation < MaxDistanceFromLocation || c.DistanceFromOfficeLocation == MaxDistanceFromLocation)
              .OrderBy(c => c.UserId)
              .ToList();
        }
    }
}
