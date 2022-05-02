using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this._answerRepository = answerRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await this._answerRepository.GetAll();
        }

        public async Task<List<Answer>> GetByPostIdAsync(string postId)
        {
            return await this._answerRepository.GetByPostId(postId: postId);
        }

        public async Task<Answer> GetByIdAsync(string id)
        {
            return await this._answerRepository.GetById(id: id);
        }

        public async Task PostAsync(Answer answer)
        {
            await this._answerRepository.Add(answer: answer);
            await this._unitOfWork.Save();
        }
    }
}
