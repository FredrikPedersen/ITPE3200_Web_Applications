using System.Collections.Generic;
using VyCustomerSupport.DAL.Repositories;
using VyCustomerSupport.Models.RepositoryModels;

namespace VyCustomerSupport.BLL
{
    public class UserQuestionBll
    {
        private readonly UserQuestionRepository _qRepository;

        public UserQuestionBll(UserQuestionRepository qRepository)
        {
            _qRepository = qRepository;
        }

        public List<RepositoryUserQuestion> GetAllUserQuestions()
        {
            return _qRepository.GetAllUserQuestions();
        }

        public bool UpVote(int id)
        {
            return _qRepository.UpVote(id);
        }

        public bool DownVote(int id)
        {
            return _qRepository.DownVote(id);
        }
    }
}