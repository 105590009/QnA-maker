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
    public class QnAController : Controller
    {
        private readonly MyDbContext _dbContext;

        public QnAController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_dbContext.QnAs);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_dbContext.QnAs.SingleOrDefault(c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] QnA entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return Get(entity.Id);

        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] QnA entity, int id)
        {

            var oriEmployee = _dbContext.QnAs.SingleOrDefault(c => c.Id == id);
            if (oriEmployee != null)
            {
                _dbContext.Entry(entity).CurrentValues.SetValues(entity);
                oriEmployee.Id = entity.Id;
                
                oriEmployee.Question = entity.Question;
                //oriEmployee.Answer = entity.Answer;

                //_dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
            
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var OriQnA = _dbContext.QnAs.SingleOrDefault(c => c.Id == id);
            if (OriQnA != null )
            {
                _dbContext.QnAs.Remove(OriQnA);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
