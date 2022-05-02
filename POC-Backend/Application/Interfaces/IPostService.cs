using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<List<Post>> GetByGroupIdAsync(string groupId);
        Task<Post> GetByIdAsync(string id);
        Task PostAsync(Post post);
    }
}