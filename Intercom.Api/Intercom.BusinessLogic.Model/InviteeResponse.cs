namespace Intercom.BusinessLogic.Model
{
    /// <summary>
    /// The response on creating subscriptions
    /// </summary>
    public class InviteeResponse
    {
        /// <summary>
        /// The response status
        /// </summary>
        public ResponseStatus Status { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Events accepted by the document ingestion api
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Success result
        /// </summary>
        Success,
        /// <summary>
        /// Failed result
        /// </summary>
        Failed
    }
}
