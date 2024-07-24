using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectDto> AddNewSubjectAsync(SubjectDto Subject);
        Task DeleteAsync(int id);
        Task<SubjectDto> GetByIdAsync(int id);
        Task<List<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> UpdateAsync(SubjectDto Subject);
    }
}
