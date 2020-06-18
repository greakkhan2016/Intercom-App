using FluentAssertions;
using Intercom.BusinessLogic;
using Newtonsoft.Json;
using Xunit;

namespace Intercom.Unit.Tests
{
    /// <summary>
    /// not too sure about this i have been reading up and alot of people say to do integration tests
    /// </summary>
    public class TranformTextFileToCustomerRecordTest
    {
        private readonly string _path = "../../../Intercom.BusinessLogic.Tests/TestScenario/";
     
        [Theory]
        [InlineData("CustomerRecords")]
        public void TranformTextFileToCustomerRecordTest_return_32_customerecord(string caseName)
        {
            var file = new TranformTextFileToCustomerRecord();
            
            var customerRecordsResult = file.MappingFromTextFileToCustomerRecord($"{_path}{caseName}.txt"); 
            customerRecordsResult.Should().HaveCount(c => c == 32);
        }

        [Theory]
        [InlineData("CustomerRecords2")]
        public void ReadFromJson_with_wrong_type_customerRecordModel_raises_exception(string caseName)
        {
            var eventModelJson = new { a = 1 };
            var file = new TranformTextFileToCustomerRecord();
            Assert.Throws<JsonReaderException>(() => file.MappingFromTextFileToCustomerRecord($"{_path}{caseName}.txt"));
        }


        [Fact]
        public void ReadFromJson_with_incorrect_textFile_location_raises_exception()
        {
            var file = new TranformTextFileToCustomerRecord();
            Assert.Throws<System.IO.FileNotFoundException>(() => file.MappingFromTextFileToCustomerRecord("c:/textt.txt"));
        }
    }
}
