using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract;

public interface ICommentDal : IRepository<Comment>
{
    List<CommentAVG> GetCommentDetail();
    CommentAVG GetCommentDetailByProductId(int productId);

}