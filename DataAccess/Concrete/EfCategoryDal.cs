using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class EfCategoryDal : EfEntityRepositoryBase<Category, DenedinMiContext>, ICategoryDal
{
}