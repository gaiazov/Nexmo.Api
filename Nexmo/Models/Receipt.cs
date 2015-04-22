using Newtonsoft.Json;
using System.ComponentModel;

namespace Nexmo.Model
{
    public enum ReceiptStatusCode
    {
        [Description("Message arrived to handset")]
        delivered,
        [Description("Message timed out after we waited 48h to receive status from mobile operator")]
        expired,
        [Description("Message failed to be delivered")]
        failed,
        [Description("Message has been rejected by the mobile operator")]
        rejected,
        [Description("Message has been accepted by the mobile operator")]
        accepted,
        [Description("Message is being delivered")]
        buffered,
        [Description("Undocumented status from the mobile operator")]
        unknown
    }

    public enum ReceiptErrorCode
    {
        Delivered = 0,
        Unknown = 1,
        [Description("Absent Subscriber - Temporary")]
        AbsentSubscriberTemporary = 2,
        [Description("Absent Subscriber - Permanent")]
        AbsentSubscriberPermanent = 3,
        [Description(" Call barred by user")]
        CallBarredByUser = 4,
        [Description("Portability Error")]
        PortabilityError = 5,
        [Description("Anti-Spam Rejection")]
        AntiSpamRejection = 6,
        [Description("Handset Busy")]
        HandsetBusy = 7,
        [Description("Network Error")]
        NetworkError = 8,
        [Description("Illegal Number")]
        IllegalNumber = 9,
        [Description("Invalid Message")]
        InvalidMessage = 10,
        Unroutable = 11,
        [Description("estination Un-Reachable")]
        DestinationUnReachable = 12,
        [Description("Subscriber Age Restriction")]
        SubscriberAgeRestriction = 13,
        [Description("Number Blocked by Carrier")]
        NumberBlockedByCarrier = 14,
        [Description("Pre-Paid - Insufficent funds")]
        PrePaidInsufficentFunds = 15,
        [Description("General Error")]
        GeneralError = 99
    }

    public class NexmoDeliveryReciept
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("network-code")]
        public string NetworkCode { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("msisdn")]
        public string MSISDN { get; set; }

        [JsonProperty("status")]
        public ReceiptStatusCode Status { get; set; }

        [JsonProperty("err-code")]
        public ReceiptErrorCode ErrCode { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("scts")]
        public string SCTS { get; set; }

        [JsonProperty("message-timestamp")]
        public string MessageTimestamp { get; set; }

        [JsonProperty("client-ref")]
        public string ClientRef { get; set; }
    }
}
