using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QnA_Maker.Models;
using QnA_Maker.DataAccessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QnA_Maker.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly MyDbContext _dbContext;

        public QuestionController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_dbContext.questions);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_dbContext.questions.SingleOrDefault(c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] QnA entity)
        {
            
            return Get(entity.Id);
        }
    }
}
