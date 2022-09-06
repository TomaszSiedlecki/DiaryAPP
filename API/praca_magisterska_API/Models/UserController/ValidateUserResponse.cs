using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace praca_magisterska_API.Models.UserController
{
    [DataContract]
    public class ValidateUserResponse : BaseResponse
    {
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public long ClassID { get; set; }
        [DataMember]
        public long StudentID { get; set; }
    }
}
