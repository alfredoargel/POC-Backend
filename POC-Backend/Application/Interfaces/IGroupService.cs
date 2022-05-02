using POC_Backend.Application.Entities;

namespace POC_Backend.Application.Interfaces
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(string id);
        Task PostAsync(Group group);
    }
}