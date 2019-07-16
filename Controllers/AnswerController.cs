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
    public class AnswerController : Controller
    {
        private readonly MyDbContext _dbContext;

        public AnswerController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_dbContext.answers);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_dbContext.answers.SingleOrDefault(c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Answer entity)
        {
            _dbContext.Add(entity);
            //if (entity.Ans == null)
            //{
            //    return BadRequest("Answer are not null");
            //}
            _dbContext.SaveChanges();
            return Get(entity.Id);

        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Answer entity, int id)
        {

            var NewAns = _dbContext.answers.SingleOrDefault(c => c.Id == id);
            if (NewAns != null)
            {  
                NewAns.Id = id;
                NewAns.Ans = entity.Ans;
                if (NewAns.Ans == null)
                {
                    return BadRequest();
                }
                _dbContext.SaveChanges();
                
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var OriQnA = _dbContext.answers.SingleOrDefault(c => c.Id == id);
            if (OriQnA != null)
            {
                _dbContext.answers.Remove(OriQnA);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
