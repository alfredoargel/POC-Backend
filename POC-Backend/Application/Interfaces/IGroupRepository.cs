using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAll();
        Task<Group> GetById(string id);
        Task Add(Group group);
    }
}
