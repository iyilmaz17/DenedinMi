using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract;

public interface IProductDal : IRepository<Product>
{
    List<HomeDto> GetAllHomeProduct();
    List<HomeDto> GetByCategoryId(int categoryId);
}