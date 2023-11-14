using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract;

// Ayrıca her nesnesinin kendisine özel işlemleri olabileceği için ayrıca birer interfacesi bulunmaktadır.
public interface IUserDal : IRepository<User>
{
}