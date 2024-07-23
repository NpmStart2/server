using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDiscussionService
    {
        Task<DiscussionDto> AddNewDiscussionAsync(DiscussionDto Discussion);
        Task DeleteAsync(int id);
        Task<DiscussionDto> GetByIdAsync(int id);
        Task<List<DiscussionDto>> GetAllDiscussionsAsync();
        Task<DiscussionDto> UpdateAsync(DiscussionDto Discussion);
    }
}
