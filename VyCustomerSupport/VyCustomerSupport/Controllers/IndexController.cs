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
        
    }
}