﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Models.Enums;

namespace praca_magisterska_API.Models.UserController
{
    [DataContract]
    public class StudentDataRequest
    {
        [DataMember]
        public long StudentID { get; set; }
      
    }
}
