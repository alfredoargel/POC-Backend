using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAllAsync();
        Task<List<Answer>> GetByPostIdAsync(string postId);
        Task<Answer> GetByIdAsync(string id);
        Task PostAsync(Answer answer);
    }
}