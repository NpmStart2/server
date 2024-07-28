using AutoMapper;
using DTO.classes;
using Microsoft.Extensions.Logging;
using DAL.Interfaces;
using DAL.Models;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper mapper;
        private readonly ILogger<string> logger;

        public UserService(IUserRepository UserRepository, IMapper mapper, ILogger<string> logger)
        {
            this.UserRepository = UserRepository;
            this.logger = logger;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.classes.Mapper>();
            });
            this.mapper = config.CreateMapper();
            //this.mapper = mapper;
        }

        public async Task<UserDto> AddNewUserAsync(UserDto e)
        {
            try
            {
                var map = mapper.Map<UserDto, User>(e);
                var answer = await UserRepository.AddAsync(map);
                UserDto v = mapper.Map<User, UserDto>(answer);
                return v;
            }
            catch (Exception ex)
            {
                logger.LogError("faild to add User in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await UserRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to delete User in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            try
            {
                var answer= await UserRepository.GetAllAsync();
                return mapper.Map<List<UserDto>>(answer);    
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get all Users in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            try
            {
                var answer= await UserRepository.GetByIdAsync(id);
                return mapper.Map<UserDto>(answer);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get User in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<UserDto> UpdateAsync(UserDto e)
        {
            try
            {
                var map= mapper.Map<UserDto, User>(e);
                var answer= await UserRepository.UpdateAsync(map);
                return mapper.Map<User, UserDto>(answer);
            }
            catch(Exception ex)
            {
                logger.LogError("faild to update User in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }
    }
}
