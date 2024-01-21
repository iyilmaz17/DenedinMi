using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetCommentList();
        IDataResult<List<Comment>> GetAllByProductId(int id);
        IDataResult<Comment> GetById(int commentId);
        IDataResult<Comment> GetByProductId(int productId);
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IDataResult<List<CommentAVG>> GetCommentAvg();
        IDataResult<CommentAVG> GetCommentDetailByProductId(int productId);
        IDataResult<CommentAVG> GetCommentDetailByProductIdWithMaxUserCount();
    }
    
}
