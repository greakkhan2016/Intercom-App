using FluentAssertions;
using Intercom.BusinessLogic;
using Intercom.BusinessLogic.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Intercom.Unit.Tests
{
    /// <summary>
    /// This test reads in a customer record text file and transforms the mapping to invitees that are
    /// within a 100km distance from the office.
    /// </summary>
    public class DistanceFromCustomerLocationToDublinOfficeTest
    {
        private readonly string _path = "../../../Intercom.BusinessLogic.Tests/TestScenario/";
        private readonly string _mapperTestResultPath = "../../../Intercom.BusinessLogic.Tests/ExpectedResult/";

        [Theory]
        [InlineData(100, "CustomerRecords", "CustomerDistanceRecords")]
        public void TransformCustomerRecordToCustomerDistanceRecord(int maxDistanceFromLocation, string caseName, string caseNameOutput)
        {
            var customerRecordModel = File.ReadAllText($"{_path}{caseName}.json");
            var _sut = new CustomerDistanceFromDublinOffice(maxDistanceFromLocation);

            var customerRecordList = JsonConvert.DeserializeObject<List<CustomerRecord>>(customerRecordModel);
            var result = _sut.TransformCustomerRecordToInviteeDistanceRecord(customerRecordList);

            var customerRecordModel2 = File.ReadAllText($"{_mapperTestResultPath}{caseNameOutput}.json");
            var eswResponse = JsonConvert.DeserializeObject<List<InviteeRecord>>(customerRecordModel2);

            JsonConvert.SerializeObject(result).Should().BeEquivalentTo(JsonConvert.SerializeObject(eswResponse));

        }
    }
}
