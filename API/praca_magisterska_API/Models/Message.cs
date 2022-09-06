using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using praca_magisterska_API.Models.Enums;

namespace praca_magisterska_API.Models
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public MessageType Type { get; set; }
    }
}
