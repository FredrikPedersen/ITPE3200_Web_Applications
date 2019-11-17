using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VyCustomerSupport.Models.DbModels;
using VyCustomerSupport.Models.RepositoryModels;

namespace VyCustomerSupport.DAL.Repositories
{
    public class QaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public QaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<RepositoryQa> GetAllQa()
        {
            return _databaseContext.QandAs
                .Include(c => c.Category)
                .OrderBy(qa => qa.Category.Id)
                .Select(qa => DbToRepositoryQa(qa))
                .ToList();
        }

        public List<RepositoryQa> GetQaWithCategory(string category)
        {
            return _databaseContext.QandAs
                .Include(c => c.Category)
                .Where(qa => qa.Category.CategoryName == category)
                .OrderBy(qa => qa.Id)
                .Select(qa => DbToRepositoryQa(qa))
                .ToList();
        }

        public List<RepositoryCategory> GetAllCategories()
        {
            return _databaseContext.Categories
                .Select(category => DbToRepositoryCategory(category))
                .ToList();
        }

        public bool UpVote(int id)
        {
            try
            {
                var qa = _databaseContext.QandAs.FirstOrDefault(q => q.Id == id);
                if (qa != null) qa.UpVotes += 1;
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DownVote(int id)
        {
            try
            {
                var qa = _databaseContext.QandAs.FirstOrDefault(q => q.Id == id);
                if (qa != null) qa.DownVotes += 1;
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private RepositoryQa DbToRepositoryQa(DbQa dbQa)
        {
            return new RepositoryQa
            {
                Id = dbQa.Id,
                Question = dbQa.Question,
                Answer = dbQa.Answer,
                UpVotes = dbQa.UpVotes,
                DownVotes = dbQa.DownVotes,
                Category = DbToRepositoryCategory(dbQa.Category)
            };
        }

        private RepositoryCategory DbToRepositoryCategory(DbCategory dbCategory)
        {
            return new RepositoryCategory
            {
                Id = dbCategory.Id,
                CategoryName = dbCategory.CategoryName,
            };
        }

    }
}