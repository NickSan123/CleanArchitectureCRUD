using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MyDbContext _dbContext;

        public TaskRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Task> CreateAsync(Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task), "A tarefa informada é inválida!");

            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
                return false;

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Task>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Task> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<Task>> GetByNameAsync(string name)
        {
            return await _dbContext.Tasks
                .Where(t => t.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<bool> MarkAsCompletedAsync(int taskId)
        {
            var task = await _dbContext.Tasks.FindAsync(taskId);
            if (task == null)
                return false;

            task.Completed = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Task>> TaskByUser(User user)
        {
            return await _dbContext.Tasks
                .Where(t => t.UserId == user.Id)
                .ToListAsync();
        }

        public async Task<Task> UpdateAsync(Task task)
        {
            var existingTask = await _dbContext.Tasks.FindAsync(task.Id);
            if (existingTask == null)
                return null;
            _dbContext.Tasks.Update(task);
            await _dbContext.SaveChangesAsync();
            return existingTask;
        }
    }
}