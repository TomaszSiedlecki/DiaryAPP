using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Models;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Controllers
{
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpPost("GetStudentGradesForSubject")]
        public Task<StudentGradesResponse> GetStudentGradesForSubject(GradesRequest arguments)
        {
            return _gradeService.GetStudentGradesForSubject(arguments);
        }
        [HttpPost("GetStudentAllGrades")]
        public Task<StudentGradesResponse> GetStudentAllGrades(StudentDataRequest arguments)
        {
            return _gradeService.GetStudentAllGrades(arguments);
        }
        [HttpPost("AddGrade")]
        public Task<BaseResponse> AddGrade(GradeRequest arguments)
        {
            return _gradeService.AddGrade(arguments);
        }
        [HttpPost("DeleteGrade")]
        public Task<BaseResponse> DeleteGrade(GradeRequest arguments)
        {
            return _gradeService.DeleteGrade(arguments);
        }
    }
}
