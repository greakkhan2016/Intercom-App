using Intercom.BusinessLogic.Interface;
using Intercom.BusinessLogic.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Intercom.BusinessLogic
{
    public class SaveInviteeRecord:ISaveInviteeRecord
    {
        public string FilePath { get; }
        public SaveInviteeRecord(string filePath)
        {
            FilePath = filePath; 
        }

        /// <summary>
        /// Writes customer Invitees to dublin office
        /// </summary>
        /// <param name="invitees"></param>
        public InviteeResponse WriteToDiskInviteeToOffice(List<InviteeRecord> invitees)
        {
            var record = $"{FilePath}customerrecord{Guid.NewGuid()}.txt";
            try
            {
                var result = JsonConvert.SerializeObject(invitees, Formatting.Indented);
                var timestamp = DateTime.Today;
                using StreamWriter tw = new StreamWriter(record, true);
                tw.WriteLine(result.ToString());
                tw.Close();

                return new InviteeResponse()
                {
                    Description = $"Successfully created new invitee record- {record}",
                    Status = ResponseStatus.Success
                };
            }
            catch (JsonReaderException exception)
            {
                //log
                throw exception;

            }
            catch (Exception exception)
            {
                //log
                throw exception;
            }
        }
    }
}
