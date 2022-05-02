using MongoDB.Driver;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;
using POC_Backend.Infrastructure.Data.Context;

namespace POC_Backend.Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DBContext _context;
        public GroupRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task<List<Group>> GetAll()
        {
            return await this._context.Groups.Find(filter: r => true).ToListAsync();
        }
        public async Task<Group> GetById(string id)
        {
            return await this._context.Groups.Find(filter: g => g.Id == id).FirstOrDefaultAsync();
        }
        public async Task Add(Group group)
        {
            await this._context.Groups.InsertOneAsync(session: this._context.Session, document: group);
        }
    }
}
