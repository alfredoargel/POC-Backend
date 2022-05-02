using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            this._groupRepository = groupRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await this._groupRepository.GetAll();
        }

        public async Task<Group> GetByIdAsync(string id)
        {
            return await this._groupRepository.GetById(id: id);
        }

        public async Task PostAsync(Group group)
        {
            await this._groupRepository.Add(group: group);
            await this._unitOfWork.Save();
        }
    }
}
