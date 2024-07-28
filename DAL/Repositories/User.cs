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
    public class UserRepository : IUserRepository
    {
        private readonly IContext context;
        private readonly ILogger<string> logger;
        private readonly MyDbContext myDbContext;
        public UserRepository(IContext context, ILogger<string> logger)
        {
            this.context = context;
            //this.context = myDbContext;
            this.logger = logger;
        }

        public async Task<User> AddAsync(User entity)
        {
            try
            {
                var newEntity = await context.Users.AddAsync(entity);
                // השורה הזאת מביאה את השגיאה הבאה:
                    // Microsoft.EntityFrameworkCore.DbUpdateException
                    //  HResult=0x80131500
                    //  Message=An error occurred while saving the entity changes. See the inner exception for details.
                    //  Source=Microsoft.EntityFrameworkCore.Relational
                    //  StackTrace:
                    //   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__50.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.SqlServer.Update.Internal.SqlServerModificationCommandBatch.<ExecuteAsync>d__15.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.<SaveChangesAsync>d__8.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__111.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__115.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__63.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__63.MoveNext()
                    //   at DAL.Repositories.UserRepository.<AddAsync>d__4.MoveNext() in C:\Users\The user\Documents\מסלול\פרויקט עצמאי\server\DAL\Repositories\User.cs:line 30

                    //  This exception was originally thrown at this call stack:
                    //    [External Code]

                    //Inner Exception 1:
                    //SqlException: Invalid object name 'Users'.
                    //Microsoft.EntityFrameworkCore.DbUpdateException
                    //  HResult=0x80131500
                    //  Message=An error occurred while saving the entity changes. See the inner exception for details.
                    //  Source=Microsoft.EntityFrameworkCore.Relational
                    //  StackTrace:
                    //   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.<ExecuteAsync>d__50.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.SqlServer.Update.Internal.SqlServerModificationCommandBatch.<ExecuteAsync>d__15.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.<ExecuteAsync>d__9.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.<SaveChangesAsync>d__8.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__111.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<SaveChangesAsync>d__115.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.<ExecuteAsync>d__7`2.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__63.MoveNext()
                    //   at Microsoft.EntityFrameworkCore.DbContext.<SaveChangesAsync>d__63.MoveNext()
                    //   at DAL.Repositories.UserRepository.<AddAsync>d__4.MoveNext() in C:\Users\The user\Documents\מסלול\פרויקט עצמאי\server\DAL\Repositories\User.cs:line 30

                    //  This exception was originally thrown at this call stack:
                    //    [External Code]

                    //Inner Exception 1:
                    //SqlException: Invalid object name 'Users'.

                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to add User" + ex.Message.ToString());
                //return new User();
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                context.Users.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to delete User" + ex.Message.ToString());
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                //Microsoft.Data.SqlClient.SqlException: 'A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)'

                return await context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get Users" + ex.Message.ToString());
                return new List<User>();
            }
        }

        public async Task<User> GetByIdAsync(int Id)
        {
            try
            {
                var entity = await context.Users.FirstOrDefaultAsync(p => p.Id == Id);
                if (entity == null)
                {
                    logger.LogError("The User is null");
                    //return new User();
                    return null;
                }
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get User" + ex.Message.ToString());
                //return new User();
                return null;
            }
        }

        public async Task<User> UpdateAsync(User entity)
        {
            try
            {
                var UserToUpdate = await GetByIdAsync(entity.Id);
                if (UserToUpdate == null)
                {
                    logger.LogError("the Id is not exit");
                    //return new User();
                    return null;
                }
                await DeleteAsync(entity.Id);
                await AddAsync(entity);
                //UserToUpdate.Name = entity.Name;
                //UserToUpdate.DepartmentCode = entity.DepartmentCode;
                //UserToUpdate.CompanyCode = entity.CompanyCode;
                //UserToUpdate.Price = entity.Price;
                //UserToUpdate.Description = entity.Description;
                //UserToUpdate.Picture = entity.Picture;

                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to update User" + ex.Message.ToString());
                //return new User();
                return null;
            }
        }
    }
}
