using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VyCustomerSupport.BLL;
using VyCustomerSupport.DAL.Repositories;
using VyCustomerSupport.Models.RepositoryModels;

namespace VyCustomerSupport.Controllers
{
    [Route("api/index")]
    [ApiController]
    public class IndexController : Controller
    {
        private readonly QaBll _qaBll;
        private readonly UserQuestionBll _qBll;

        public IndexController(QaBll qaBll, UserQuestionBll qBll)
        {
            _qaBll = qaBll;
            _qBll = qBll;
        }

        [Route("categories")]
        public List<RepositoryCategory> GetCategories()
        {
            return _qaBll.GetAllCategories();
        }

        [Route("qas")]
        public List<RepositoryQa> GetQas()
        {
            return _qaBll.GetAllQa();
        }

        [Route("qaswithcategory")]
        public List<RepositoryQa> GetQaWithCategory(string category)
        {
            return _qaBll.GetQaWithCategory(category);
        }

        [Route("userquestions")]
        public List<RepositoryUserQuestion> GetUserQuestions()
        {
            return _qBll.GetAllUserQuestions();
        }

        [Route("upvote/{id}")]
        public bool PostUpVote(int id)
        {
            return _qaBll.UpVote(id);
        }

        [Route("downvote/{id}")]
        public bool PostDownVote(int id)
        {
            return _qaBll.DownVote(id);
        }

        [Route("sendquestion")]
        public bool PostQuestion([FromBody] RepositoryUserQuestion userQuestion)
        {
            return ModelState.IsValid && _qBll.AddUserQuestion(userQuestion);
        }
        
    }
}