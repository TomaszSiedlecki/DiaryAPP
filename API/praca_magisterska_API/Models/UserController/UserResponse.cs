using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using praca_magisterska_API.Models.Enums;

namespace praca_magisterska_API.Models.UserController
{
    [DataContract]
    public class UserResponse : BaseResponse
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public DateTime BornDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Role { get; set; }

    }
}
