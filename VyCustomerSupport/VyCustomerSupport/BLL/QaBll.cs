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
    }
}