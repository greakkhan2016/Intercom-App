using Intercom.BusinessLogic.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Intercom.Integration.Tests
{
    public class InviteeTests
    {
        [Fact]
        public async Task CreateInviteeReturnsSuccess()
        {
            //https://localhost:44309/api/invitee

            //Arrange
            var filePath = TestUtility.GetPath("TestScenarios/CustomerRecords.txt");
            var createUri = $"{TestUtility.GetServerUri()}/api/invitee";
            InviteeResponse result = null; 
            
            //Act
            using (var fileStream = File.OpenRead(filePath))
            using (HttpClient client = new HttpClient())
            {
                var response = await TestUtility.Upload(client, fileStream, createUri, "file", filePath);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<InviteeResponse>(responseString);
            }

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResponseStatus.Success, result.Status);
        }

        [Fact]
        public async Task CreateInviteeReturnsFailureForInvalidData()
        {
            //https://localhost:44309/api/invitee

            //Arrange
            var filePath = TestUtility.GetPath("TestScenarios/CustomerRecords2.txt");
            var createUri = $"{TestUtility.GetServerUri()}/api/invitee";

            //Act
            using (var fileStream = File.OpenRead(filePath))
            using (HttpClient client = new HttpClient())
            {
                var response = await TestUtility.Upload(client, fileStream, createUri, "file", filePath);

                //Assert
                Assert.False(response.IsSuccessStatusCode);
            }
        }
    }
}
