using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using praca_magisterska_API.Models;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Interfaces
{
    public interface IGradeService
    {
        Task<StudentGradesResponse> GetStudentGradesForSubject(GradesRequest arguments);
        Task<StudentGradesResponse> GetStudentAllGrades(StudentDataRequest arguments);
        Task<BaseResponse> AddGrade(GradeRequest arguments);
        Task<BaseResponse> DeleteGrade(GradeRequest arguments);

    }
}