using Intercom.BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Intercom.BusinessLogic
{
    public class SaveCustomerRecord : ISaveCustomerRecord
    {
        public string FilePath { get; }

        public SaveCustomerRecord(string filepath)
        {
            FilePath = filepath;
        }

        /// <summary>
        /// Save Customers inviteed to office to file 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteToDiskCustomerRecordAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception();
                //log it out 
            }

            FileDirectoryLocationExist();

            var savedCustomerRecord = $"{FilePath}inviteerecord{Guid.NewGuid()}.txt";

            using FileStream fileStream = File.Create(savedCustomerRecord);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();

            return savedCustomerRecord;
        }

        private void FileDirectoryLocationExist()
        {
            try
            {
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
