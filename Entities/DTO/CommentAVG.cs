using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CommentAVG
    {
        public int ProductId { get; set; }  
        public int AvgStar { get; set; }
        public int UserCount { get; set; }
    }
}
