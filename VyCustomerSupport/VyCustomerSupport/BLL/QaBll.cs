using System.Collections.Generic;
using VyCustomerSupport.DAL.Repositories;
using VyCustomerSupport.Models.RepositoryModels;

namespace VyCustomerSupport.BLL
{
    public class QaBll
    {
        private readonly QaRepository _qaRepository;

        public QaBll(QaRepository qaRepository)
        {
            _qaRepository = qaRepository;
        }

        public List<RepositoryQa> GetAllQa()
        {
            return _qaRepository.GetAllQa();
        }

        public List<RepositoryCategory> GetAllCategories()
        {
            return _qaRepository.GetAllCategories();
        }

        public bool UpVote(int id)
        {
            return _qaRepository.UpVote(id);
        }

        public bool DownVote(int id)
        {
            return _qaRepository.DownVote(id);
        }
    }
}