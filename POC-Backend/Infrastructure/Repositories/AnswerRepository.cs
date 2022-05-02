using MongoDB.Driver;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;
using POC_Backend.Infrastructure.Data.Context;

namespace POC_Backend.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly DBContext _context;
        public AnswerRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task<List<Answer>> GetAll()
        {
            return await this._context.Answers.Find(filter: r => true).ToListAsync();
        }

        public async Task<List<Answer>> GetByPostId(string postId)
        {
            return await this._context.Answers.Find(filter: r => r.PostId == postId).ToListAsync();
        }

        public async Task<Answer> GetById(string id)
        {
            return await this._context.Answers.Find(filter: g => g.Id == id).FirstOrDefaultAsync();
        }
        public async Task Add(Answer answer)
        {
            await this._context.Answers.InsertOneAsync(session: this._context.Session, document: answer);
        }
    }
}
