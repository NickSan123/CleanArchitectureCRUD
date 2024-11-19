using Domain.Entities;
using Task = Domain.Entities.Task;
namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Task>> GetAllAsync();
        Task<Task> GetByIdAsync(int id);
        Task<IEnumerable<Task>> GetByNameAsync(string name);
        Task<bool> DeleteByIdAsync(int id);
        Task<Task> CreateAsync(Task task);
        Task<Task> UpdateAsync(Task task);
        Task<bool> MarkAsCompletedAsync(int taskId);
        Task<IEnumerable<Task>> TaskByUser(User user);
    }
}
