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

        public IndexController(QaBll qaBll)
        {
            _qaBll = qaBll;
        }

        [Route("qas")]
        public List<RepositoryQa> GetQas()
        {
            return _qaBll.GetAllQa();
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

        //TODO NOT FINISHED! This is just a shell to se if the post request gets through.
        [Route("sendquestion")]
        public bool PostQuestion([FromBody] RepositoryQuestion question)
        {
            Console.WriteLine("POST QUESTION IS CALLED");
            Console.WriteLine("POST QUESTION DATA: " + question);
            Console.WriteLine("POST QUESTION DATA PRINT FINISHED");
            return false;
        }
        
    }
}