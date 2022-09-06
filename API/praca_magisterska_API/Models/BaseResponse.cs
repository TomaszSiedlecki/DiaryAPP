using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace praca_magisterska_API.Models
{
    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public bool IsSuccessfull { get; set; }
    }
}
