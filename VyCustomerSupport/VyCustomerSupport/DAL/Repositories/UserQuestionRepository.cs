using System.Collections.Generic;
using System.Linq;
using VyCustomerSupport.Models.DbModels;
using VyCustomerSupport.Models.RepositoryModels;

namespace VyCustomerSupport.DAL.Repositories
{
    public class UserQuestionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserQuestionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool AddUserQuestion(RepositoryUserQuestion q)
        {
            var newUserQuestion = new DbUserQuestion
            {
                Username = q.Username,
                Email = q.Email,
                Question = q.Question,
            };
            
            try
            {
                _databaseContext.UserQuestions.Add(newUserQuestion);
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<RepositoryUserQuestion> GetAllUserQuestions()
        {
            return _databaseContext.UserQuestions
                .OrderBy(q => q.Id)
                .Select(q => DbToRepository(q))
                .ToList();
        }
        
        private RepositoryUserQuestion DbToRepository(DbUserQuestion dbQ)
        {
            return new RepositoryUserQuestion
            {
                Id = dbQ.Id,
                Username = dbQ.Username,
                Email = dbQ.Email,
                Question = dbQ.Question
            };
        }

    }
}