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
    public class DiscussionService : IDiscussionService
    {
        private readonly IDiscussionRepository DiscussionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<string> logger;

        public DiscussionService(IDiscussionRepository DiscussionRepository, IMapper mapper, ILogger<string> logger)
        {
            this.DiscussionRepository = DiscussionRepository;
            this.logger = logger;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTO.classes.Mapper>();
            });
            this.mapper = config.CreateMapper();
        }

        public async Task<DiscussionDto> AddNewDiscussionAsync(DiscussionDto e)
        {
            try
            {
                var map = mapper.Map<Discussion>(e);
                var answer=await DiscussionRepository.AddAsync(map);
                return mapper.Map<DiscussionDto>(answer);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to add Discussion in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await DiscussionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to delete Discussion in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<List<DiscussionDto>> GetAllDiscussionsAsync()
        {
            try
            {
                var answer= await DiscussionRepository.GetAllAsync();
                return mapper.Map<List<DiscussionDto>>(answer);    
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get all Discussions in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<DiscussionDto> GetByIdAsync(int id)
        {
            try
            {
                var answer= await DiscussionRepository.GetByIdAsync(id);
                return mapper.Map<DiscussionDto>(answer);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get Discussion in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<DiscussionDto> UpdateAsync(DiscussionDto e)
        {
            try
            {
                var map= mapper.Map<Discussion>(e);
                var answer= await DiscussionRepository.UpdateAsync(map);
                return mapper.Map<DiscussionDto>(answer);
            }
            catch(Exception ex)
            {
                logger.LogError("faild to update Discussion in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }
    }
}
