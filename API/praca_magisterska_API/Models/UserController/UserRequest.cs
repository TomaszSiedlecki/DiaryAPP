using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using praca_magisterska_API.Models.Enums;

namespace praca_magisterska_API.Models.UserController
{
    [DataContract]
    public class UserRequest
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string? ClassName { get; set; }
    }
}
