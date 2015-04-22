using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nexmo.Model
{
    public class Response
    {
        [JsonProperty("message-count")]
        public int MessageCount { get; set; }
        public List<ResponseMessage> Messages { get; set; }
    }

    public class ResponseMessage
    {
        public ResponseStatus Status { get; set; }
        [JsonProperty("message-id")]
        public string MessageId { get; set; }
        public string To { get; set; }
        [JsonProperty("client-ref")]
        public string ClienRef { get; set; }
        [JsonProperty("remaining-balance")]
        public string RemainingBalance { get; set; }
        [JsonProperty("message-price")]
        public string MessagePrice { get; set; }
        [JsonProperty("error-text")]
        public string ErrorText { get; set; }
    }

    public enum ResponseStatus
    {
        [Description("The message was successfully accepted for delivery by Nexmo")]
        Success = 0,

        [Description("You have exceeded the submission capacity allowed on this account, please back-off and retry")]
        Throttled = 1,

        [Description("Your request is incomplete and missing some mandatory parameters")]
        MissingParams = 2,

        [Description("The value of one or more parameters is invalid")]
        InvalidParams = 3,

        [Description("The api_key / api_secret you supplied is either invalid or disabled")]
        InvalidCredentials = 4,

        [Description("An error has occurred in the Nexmo platform whilst processing this message")]
        InternalError = 5,

        [Description("The Nexmo platform was unable to process this message, for example, an un-recognized number prefix or the number is not whitelisted if your account is new")]
        InvalidMessage = 6,

        [Description("The number you are trying to submit to is blacklisted and may not receive messages")]
        NumberBarred = 7,

        [Description("The api_key you supplied is for an account that has been barred from submitting messages")]
        PartnerAccountBarred = 8,

        [Description("Your pre-pay account does not have sufficient credit to process this message")]
        PartnerQuotaExceeded = 9,

        [Description("This account is not provisioned for REST submission, you should use SMPP instead")]
        AccountNotEnabledForREST = 11,

        [Description("Applies to Binary submissions, where the length of the UDH and the message body combined exceed 140 octets")]
        MessageTooLong = 12,

        [Description("Message was not submitted because there was a communication failure")]
        CommunicationFailed = 13,

        [Description("Message was not submitted due to a verification failure in the submitted signature")]
        InvalidSignature = 14,

        [Description("The sender address (from parameter) was not allowed for this message. Restrictions may apply depending on the destination see our FAQs")]
        InvalidSenderAddress = 15,

        [Description("The ttl parameter values is invalid")]
        InvalidTTL = 16,

        [Description("Your request makes use of a facility that is not enabled on your account")]
        FacilityNotAllowed = 19,

        [Description("The message class value supplied was out of range (0 - 3)")]
        InvalidMessageClass = 20
    }
}

/*
client-ref	If you set a custom reference during your request, this will return that value.
remaining-balance	The remaining account balance expressed in EUR
message-price	The price charged (EUR) for the submitted message.
network	Identifier of a mobile network MCCMNC. Wikipedia list here.
error-text
*/