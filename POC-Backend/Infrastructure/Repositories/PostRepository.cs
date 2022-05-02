using MongoDB.Driver;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;
using POC_Backend.Infrastructure.Data.Context;

namespace POC_Backend.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DBContext _context;
        public PostRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            return await this._context.Posts.Find(filter: r => true).ToListAsync();
        }

        public async Task<List<Post>> GetByGroupId(string groupId)
        {
            return await this._context.Posts.Find(filter: g => g.GroupId == groupId).ToListAsync();
        }

        public async Task<Post> GetById(string id)
        {
            return await this._context.Posts.Find(filter: g => g.Id == id).FirstOrDefaultAsync();
        }
        public async Task Add(Post post)
        {
            await this._context.Posts.InsertOneAsync(session: this._context.Session, document: post);
        }
    }
}
