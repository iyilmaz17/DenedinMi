using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class EfImageDal : EfEntityRepositoryBase<Image, DenedinMiContext>, IImageDal
{
}