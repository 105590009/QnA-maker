using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Maker.Models
{
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int answerId { get; set; }
        public string answerContent { get; set; }
        //public List<Question> questions { get; set; }
        public ICollection<Question> questions { get; set; }
      

    }
}
