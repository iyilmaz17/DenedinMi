using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DataAccess.Concrete;

public class EfCommentDal : EfEntityRepositoryBase<Comment, DenedinMiContext>, ICommentDal
{
    public List<CommentAVG> GetCommentDetail()
    {
        using (DenedinMiContext context = new DenedinMiContext())
        {
            var query = context.Comments
        .GroupBy(c => c.ProductId)
        .Select(g => new CommentAVG
        {
            ProductId = g.Key,
            AvgStar = (int)Math.Round(g.Sum(c => c.StarCount) / (double)g.Count()),
            UserCount = g.Count()
        })
        .ToList();

            return query;
        }
    }
    public CommentAVG GetCommentDetailByProductId(int productId)
    {
        using (DenedinMiContext context = new DenedinMiContext())
        {
            var query = context.Comments
                .Where(c => c.ProductId == productId)
                .GroupBy(c => c.ProductId)
                .Select(g => new CommentAVG
                {
                    ProductId = g.Key,
                    AvgStar = (int)Math.Round(g.Sum(c => c.StarCount) / (double)g.Count()),
                    UserCount = g.Count()
                }).FirstOrDefault();

            return query;
        }
    }


}