using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAll();
        Task<List<Answer>> GetByPostId(string postId);
        Task<Answer> GetById(string id);
        Task Add(Answer answer);
    }
}
