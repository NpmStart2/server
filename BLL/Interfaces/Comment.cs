using DAL.Models;
using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> AddNewCommentAsync(CommentDto Comment);
        Task DeleteAsync(int id);
        Task<CommentDto> GetByIdAsync(int id);
        Task<List<CommentDto>> GetAllCommentsAsync();
        Task<CommentDto> UpdateAsync(CommentDto Comment);
    }
}
