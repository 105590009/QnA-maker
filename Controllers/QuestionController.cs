using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QnA_Maker.Models;
using QnA_Maker.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace QnA_Maker.Controllers
{
    [Route("api/[Controller]")]
    public class QuestionController : Controller
    {
        private readonly MyDbContext _dbContext;

        public QuestionController(MyDbContext dbContext)
        {
            //var db = from a in dbContext.answers
            //         join q in dbContext.Question on a.Id
            //         equals q.A_Id
            //         select new
            //         {
            //             A_Id = a.Id,
            //             ans=a.Ans
            //         };
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_dbContext.Question);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_dbContext.Question.SingleOrDefault(c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Question entity)
        {
            entity.A_Id =_dbContext.Question.Count()+1;
            if (entity.Questions == null)
            {
                return BadRequest("Questions are not null");
            }
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return Get(entity.Id);

        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Question entity, int id)
        {

            var NewData = _dbContext.Question.SingleOrDefault(c => c.Id == id);
            if (NewData != null)
            {
               // _dbContext.Entry(entity).CurrentValues.SetValues(entity);
                NewData.Id = id;
                NewData.Questions = entity.Questions;
                if (NewData.Questions == null)
                {
                    return BadRequest();
                }
                NewData.A_Id = id;
               
                //oriEmployee.Answer = entity.Answer;

                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
            
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var OldQnA = _dbContext.Question.SingleOrDefault(c => c.Id == id);
            if (OldQnA != null )
            {
                _dbContext.Question.Remove(OldQnA);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
