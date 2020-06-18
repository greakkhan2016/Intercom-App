using Intercom.BusinessLogic.Interface;
using Intercom.BusinessLogic.Model;
using Intercom.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Intercom.Service
{
    /// <summary>
    /// Service layer for calcuclating customers that are within 100km for the dublin office
    /// </summary>
    public class InvitationService : IInvitationService
    {
        private readonly ITranformToCustomerDistanceRecord _customerRecordFileReader;
        private readonly ISaveInviteeRecord _customerRecordFileOutputWriter;
        private readonly ICustomerDistanceFromDublinOffice _distanceFromDublinOffice;
        private readonly ISaveCustomerRecord _saveCustomerRecordTextFile;

        public InvitationService(
            ITranformToCustomerDistanceRecord customerRecordFileReader, 
            ISaveInviteeRecord customerRecordFileOutputWriter,
            ICustomerDistanceFromDublinOffice distanceFromDublinOffice,
            ISaveCustomerRecord saveCustomerRecordTextFile)
        {   
            _customerRecordFileReader = customerRecordFileReader ?? throw new ArgumentNullException(nameof(customerRecordFileReader)); 
            _customerRecordFileOutputWriter = customerRecordFileOutputWriter ?? throw new ArgumentNullException(nameof(customerRecordFileOutputWriter));
            _distanceFromDublinOffice = distanceFromDublinOffice ?? throw new ArgumentNullException(nameof(distanceFromDublinOffice));
            _saveCustomerRecordTextFile = saveCustomerRecordTextFile ?? throw new ArgumentNullException(nameof(saveCustomerRecordTextFile));
            
        }
        public async Task<InviteeResponse> InviteToDublinOfficeAsync(IFormFile file)
        {
           var filepath =  await _saveCustomerRecordTextFile.WriteToDiskCustomerRecordAsync(file);
           var customerRecords = _customerRecordFileReader.MappingFromTextFileToCustomerRecord(filepath);
           var customerRecordsWithDistance = _distanceFromDublinOffice.TransformCustomerRecordToInviteeDistanceRecord(customerRecords);
           return  _customerRecordFileOutputWriter.WriteToDiskInviteeToOffice(customerRecordsWithDistance);
        }
    }
}
