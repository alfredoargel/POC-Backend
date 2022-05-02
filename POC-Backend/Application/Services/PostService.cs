using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await this._postRepository.GetAll();
        }

        public async Task<List<Post>> GetByGroupIdAsync(string groupId)
        {
            return await this._postRepository.GetByGroupId(groupId: groupId);
        }

        public async Task<Post> GetByIdAsync(string id)
        {
            return await this._postRepository.GetById(id: id);
        }

        public async Task PostAsync(Post post)
        {
            await this._postRepository.Add(post: post);
            await this._unitOfWork.Save();
        }
    }
}
