﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddQa(RepositoryQa qa)
        {
            var newQa = new DbQa
            {
                Question = qa.Question,
                Answer = qa.Answer
            };

            try
            {
                _databaseContext.QandA.Add(newQa);
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<RepositoryQa> GetAllQa()
        {
            return _databaseContext.QandA
                .Where(qa => qa.Answer != null)
                .OrderBy(qa => qa.Id)
                .Select(qa => DbToRepository(qa))
                .ToList();
        }

        public bool UpVote(int id)
        {
            try
            {
                var qa = _databaseContext.QandA.FirstOrDefault(q => q.Id == id);
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
                var qa = _databaseContext.QandA.FirstOrDefault(q => q.Id == id);
                if (qa != null) qa.DownVotes += 1;
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private RepositoryQa DbToRepository(DbQa dbQa)
        {
            return new RepositoryQa
            {
                Id = dbQa.Id,
                Question = dbQa.Question,
                Answer = dbQa.Answer,
                UpVotes = dbQa.UpVotes,
                DownVotes = dbQa.DownVotes
            };
        }

    }
}