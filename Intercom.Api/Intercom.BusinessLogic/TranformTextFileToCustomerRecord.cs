using Intercom.BusinessLogic.Interface;
using Intercom.BusinessLogic.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Intercom.BusinessLogic
{
    public class TranformTextFileToCustomerRecord : ITranformToCustomerDistanceRecord
    {
        private List<CustomerRecord> customerRecords;

        /// <summary>
        /// Parse file and tranform to customerRecord
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<CustomerRecord> MappingFromTextFileToCustomerRecord(string filePath)
        {
            try
            {
                customerRecords =
                File.ReadAllLines(filePath)
                .Select(line => JsonConvert.DeserializeObject<CustomerRecord>(line))
                .ToList();
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

            return customerRecords;
        }
    }
}
