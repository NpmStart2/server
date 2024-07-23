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
    public class CommentRepository : ICommentRepository
    {
        private readonly IContext context;
        private readonly ILogger<string> logger;
        public CommentRepository(IContext context, ILogger<string> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            try
            {
                var newEntity = await this.context.Comments.AddAsync(entity);
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to add Comment" + ex.Message.ToString());
                return new Comment();
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                context.Comments.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to delete Comment" + ex.Message.ToString());
            }
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            try
            {
                return await context.Comments.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get Comments" + ex.Message.ToString());
                return new List<Comment>();
            }
        }

        public async Task<Comment> GetByIdAsync(int Id)
        {
            try
            {
                var entity = await context.Comments.FirstOrDefaultAsync(p => p.Id == Id);
                if (entity == null)
                {
                    logger.LogError("The Comment is null");
                    return new Comment();
                }
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get Comment" + ex.Message.ToString());
                return new Comment();
            }
        }

        public async Task<Comment> UpdateAsync(Comment entity)
        {
            try
            {
                var CommentToUpdate = await GetByIdAsync(entity.Id);
                if (CommentToUpdate == null)
                {
                    logger.LogError("the Id is not exit");
                    return new Comment();
                }
                await DeleteAsync(entity.Id);
                await AddAsync(entity);
                //CommentToUpdate.Name = entity.Name;
                //CommentToUpdate.DepartmentCode = entity.DepartmentCode;
                //CommentToUpdate.CompanyCode = entity.CompanyCode;
                //CommentToUpdate.Price = entity.Price;
                //CommentToUpdate.Description = entity.Description;
                //CommentToUpdate.Picture = entity.Picture;

                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to update Comment" + ex.Message.ToString());
                return new Comment();
            }
        }
    }
}
