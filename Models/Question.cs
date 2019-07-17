using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Maker.Models
{
    public class Question
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int questionId { get; set; }
        public string questionContent { get; set; }
        //[ForeignKey("Answers")]
        //public int AnswerFk { get; set; }
        public int answerId { get; set; }
        public Answer answer { get; set; }
        
    }
   



}
