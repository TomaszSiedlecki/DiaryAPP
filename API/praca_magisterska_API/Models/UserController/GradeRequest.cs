using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Models.Enums;

namespace praca_magisterska_API.Models.UserController
{
    [DataContract]
    public class GradeRequest
    {
        [DataMember]
        public long StudentID { get; set; }
        [DataMember]
        public long TeacherID { get; set; }
        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public long SubjectID { get; set; }


    }
}
