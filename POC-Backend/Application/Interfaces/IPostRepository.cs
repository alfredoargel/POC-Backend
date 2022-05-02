using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<List<Post>> GetByGroupId(string groupId);
        Task<Post> GetById(string id);
        Task Add(Post post);
    }
}
