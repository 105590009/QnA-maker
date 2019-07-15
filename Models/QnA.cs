using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Maker.Models
{
    public class QnA
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Question { get; set; }
        public int AId { get; set; }
        public Answer ans { get; set; }
    }
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
<<<<<<< HEAD
        public int Id { get; set; }
        public string Answers { get; set; }
        public List<QnA> Question { get; set; }
=======
        public int  Ans_Id { get; set; }
        public string Answers {get; set; }
>>>>>>> f0ebbc8626e02ae6036a0eba47f554317bc86396
    }


    
}
