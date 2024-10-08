using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IContext context;
        private readonly ILogger<string> logger;
        public SubjectRepository(IContext context, ILogger<string> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Subject> AddAsync(Subject entity)
        {
            try
            {
                var newEntity = await this.context.Subjects.AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to add Subject" + ex.Message.ToString());
                return new Subject();
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                context.Subjects.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to delete Subject" + ex.Message.ToString());
            }
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            try
            {
                return await context.Subjects.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get Subjects" + ex.Message.ToString());
                //return new List<Subject>();
                throw new Exception("failed in dal.subject "+ex.Message.ToString());
            }
        }

        public async Task<Subject> GetByIdAsync(int Id)
        {
            try
            {
                var entity = await context.Subjects.FirstOrDefaultAsync(p => p.Id == Id);
                if (entity == null)
                {
                    logger.LogError("The Subject is null");
                    return new Subject();
                }
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get Subject" + ex.Message.ToString());
                return new Subject();
            }
        }

        public async Task<Subject> UpdateAsync(Subject entity)
        {
            try
            {
                var SubjectToUpdate = await GetByIdAsync(entity.Id);
                if (SubjectToUpdate == null)
                {
                    logger.LogError("the Id is not exit");
                    return new Subject();
                }
                await DeleteAsync(entity.Id);
                await AddAsync(entity);
                //SubjectToUpdate.Name = entity.Name;
                //SubjectToUpdate.DepartmentCode = entity.DepartmentCode;
                //SubjectToUpdate.CompanyCode = entity.CompanyCode;
                //SubjectToUpdate.Price = entity.Price;
                //SubjectToUpdate.Description = entity.Description;
                //SubjectToUpdate.Picture = entity.Picture;

                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to update Subject" + ex.Message.ToString());
                return new Subject();
            }
        }
    }
}
