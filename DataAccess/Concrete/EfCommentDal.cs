using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class EfCommentDal : EfEntityRepositoryBase<Comment, DenedinMiContext>, ICommentDal
{
}