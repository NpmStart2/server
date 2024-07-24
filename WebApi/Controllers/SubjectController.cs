using DTO.classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        readonly ISubjectService SubjectService;
        private ILogger<string> logger;
        public SubjectController(ISubjectService service, ILogger<string> logger)
        {
            SubjectService = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<List<SubjectDto>> GetAll()
        {
            try
            {
                return await SubjectService.GetAllSubjectsAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get all "+ex.Message);
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<SubjectDto> GetbyId(int id)
        {
            try
            {
                return await SubjectService.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError($"fail to get Subject with this id {ex.Message}");
                return null;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Add(SubjectDto newSubject)
        {
            try
            {
                await SubjectService.AddNewSubjectAsync(newSubject);
            }
            catch (Exception ex)
            {
                logger.LogError("faild in api to add Subject" + ex.Message);
            }
        }
        [HttpPut]
        public async Task<SubjectDto> Update(SubjectDto e)
        {
            try
            {
                return await SubjectService.UpdateAsync(e);
            }
            catch (Exception ex)
            {
                logger.LogError("failed to update "+ex.Message);
                return null;
            }
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await SubjectService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("failed to delete "+ex.Message);
            }
        }
    }
}
