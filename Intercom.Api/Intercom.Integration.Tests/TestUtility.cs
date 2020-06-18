using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;

namespace Intercom.Integration.Tests
{
    /// <summary>
    /// Helper class for integration tests
    /// </summary>
    public class TestUtility
    {
        public static string GetServerUri()
        {
            return "https://localhost:44309";
        }

        /// <summary>
        /// Helper HttpClient method for uploading texting file
        /// </summary>
        /// <param name="client"></param>
        /// <param name="stream"></param>
        /// <param name="url"></param>
        /// <param name="uploadName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Upload(HttpClient client, Stream stream, string url, string uploadName, string fileName)
        {
            using var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture))
            {
                { new StreamContent(stream), uploadName, fileName }
            };
            var message = await client.PostAsync(url, content);
            return message;
        }

        /// <summary>
        /// Using reflection to get the file path location of where the textfiles are loaded from
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        public static string GetPath(string relativePath)
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;

            return Path.Combine(assemblyPath, "../../../../", relativePath);
        }
    }
}
