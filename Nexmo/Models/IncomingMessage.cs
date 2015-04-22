using Newtonsoft.Json;
using System;

namespace Nexmo.Model
{
    /// <summary>
    /// https://docs.nexmo.com/index.php/sms-api/handle-inbound-message
    /// </summary>
    public class IncomingMessage
    {
        // Expected values are: text, unicode (URL encoded, valid for standard GSM, Arabic, Chinese ... characters) or public string binary
        public IncomingMessageType Type;

        // Recipient number (your long virtual number).
        public string To;

        // Optional. Sender ID
        public string MSISDN;

        // Optional. Unique identifier of a mobile network MCCMNC.
        [JsonProperty("network-code")]
        public string NetworkCode;

        // Nexmo Message ID.
        [JsonProperty("network-code")]
        public string MessageId;

        // Time (UTC) when Nexmo started to push the message to your callback URL in the following format YYYY-public string MM-DD HH:MM:SS e.g. 2012-04-05 09:22:57
        [JsonProperty("message-timestamp")]
        public DateTime MessageTimestamp;

        // Content of the message
        public string Text;

        // Set to true if a MO concatenated message is detected
        public bool Concat;

        // Transaction reference, all message parts will share the same transaction reference
        [JsonProperty("concat-ref")]
        public string ConcatRef;

        // The total number of parts in this concatenated message set
        [JsonProperty("concat-total")]
        public string ConcatTotal;

        // The part number of this message within the set (starts at 1)
        [JsonProperty("concat-part")]
        public string ConcatPart;

        public enum IncomingMessageType
        {
            Text,
            Unicode,
            Binary
        };

        public IncomingMessage()
        {
        }
    }
}
