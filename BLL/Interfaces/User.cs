using DTO.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> AddNewUserAsync(UserDto User);
        Task DeleteAsync(int id);
        Task<UserDto> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateAsync(UserDto User);
    }
}
