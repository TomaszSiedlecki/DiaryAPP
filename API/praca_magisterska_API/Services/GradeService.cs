using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Hubs;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Models;
using praca_magisterska_API.Models.Enums;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Services
{
    public class GradeService : IGradeService
    {
        private readonly DiaryDataSourceContext _context;
        private readonly IHubContext<MessageHub, IClient> _hubContext;


        public GradeService(DiaryDataSourceContext context, IHubContext<MessageHub, IClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<StudentGradesResponse> GetStudentGradesForSubject(GradesRequest arguments)
        {
            var result = new StudentGradesResponse { IsSuccessfull = true };
            var gradesList = new List<KeyValuePair<string, string>>();
            try
            {
                var grades = _context.Grade.Where(c => c.SubjectID == arguments.SubjectID && c.StudentID == arguments.StudentID).ToList();
                if(!grades.Any())
                {
                    result.IsSuccessfull = false;
                    return result;
                }
                foreach(var grade in grades)
                {
                    var subjectDetails = _context.Subjects.Where(c => c.SubjectID == grade.SubjectID).FirstOrDefault();
                    gradesList.Add(new KeyValuePair<string, string>(subjectDetails.Name, grade.Name));
                }
                result.studentGrades = gradesList;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
           
        }
        public async Task<StudentGradesResponse> GetStudentAllGrades(StudentDataRequest arguments)
        {
            var result = new StudentGradesResponse { IsSuccessfull = true };
            try
            {
                var results = new List<KeyValuePair<string, string>>();
                var grades = _context.Grade.Where(c => c.StudentID == arguments.StudentID).ToList();
                if (!grades.Any())
                {
                    result.IsSuccessfull = false;
                    return result;
                }
                foreach (var grade in grades)
                {

                    var subjectDetails = _context.Subjects.Where(c => c.SubjectID == grade.SubjectID).FirstOrDefault();
                    results.Add(new KeyValuePair<string, string>(subjectDetails.Name, grade.Name));
                    
                }
                result.studentGrades = results;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
        public async Task<BaseResponse> AddGrade(GradeRequest arguments)
        {
            var result = new BaseResponse { IsSuccessfull = true };
            try
            {
                _context.Grade.Add(new Grade
                {
                    Name = arguments.Grade,
                    StudentID = arguments.StudentID,
                    TeacherID = arguments.TeacherID,
                    SubjectID = arguments.SubjectID
                });

                _context.SaveChanges();

                var subject = _context.Subjects.Where(c => c.SubjectID == arguments.SubjectID).FirstOrDefault();
                var message = new Message
                {
                    Type = MessageType.Add,
                    Grade = arguments.Grade,
                    Subject = subject.Name

                };
                
                var stringUser = arguments.StudentID.ToString();
                var user = UserHandler.ConnectedIds.Where(c => c.StudentID == stringUser).FirstOrDefault();
                if(user != null)
                {
                    _hubContext.Clients.Client(user.ConnectionID).ReceiveMessage(message);
                }

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
        public async Task<BaseResponse> DeleteGrade(GradeRequest arguments)
        {
            var result = new BaseResponse { IsSuccessfull = true };
            try
            {
                var grade = _context.Grade.Where(c =>
                    c.Name == arguments.Grade &&
                    c.StudentID == arguments.StudentID &&
                    c.TeacherID == arguments.TeacherID &&
                    c.SubjectID == arguments.SubjectID
                ).FirstOrDefault();
                if (grade == null)
                {
                    result.IsSuccessfull = false;
                    return result;
                }
                _context.Grade.Remove(grade);
                _context.SaveChanges();
                
                var subject = _context.Subjects.Where(c => c.SubjectID == arguments.SubjectID).FirstOrDefault();

                var message = new Message
                {
                    Type = MessageType.Delete,
                    Grade = arguments.Grade,
                    Subject = subject.Name

                };

                var stringUser = arguments.StudentID.ToString();
                var user = UserHandler.ConnectedIds.Where(c => c.StudentID == stringUser).FirstOrDefault();
                if(user != null)
                {
                    _hubContext.Clients.Client(user.ConnectionID).ReceiveMessage(message);
                }

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                return result;
            }
        }
    } 
}
