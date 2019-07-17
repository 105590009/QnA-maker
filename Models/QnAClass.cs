using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnA_Maker.Models
{
    public class QnAClass
    {
        public int qId { get; set; }
        public string qContent { get; set; }
        public int aId { get; set; }
        public string aContent { get; set; }
    }
}
