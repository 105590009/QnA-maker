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
        public int Id { get; set; }
        public string Content { get; set; }
        public List<KeyWordList> KeyWord { get; set; }
        //[ForeignKey("Answers")]
        //public int AnswerFk { get; set; }
        public Answer Answers { get; set; }
        
    }
    public class KeyWordList
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
   



}
