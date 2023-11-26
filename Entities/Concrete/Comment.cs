using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float StarCount { get; set; }
        public string CommentDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }

        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}
