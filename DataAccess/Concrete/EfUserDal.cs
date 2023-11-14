using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    // Eğer sınfın özel interfacesinde ek bir metod imazası varsa burada implemente ederek içerisine gerekli kodları yazmamız gerekir 
    public class EfUserDal : EfEntityRepositoryBase<User, DenedinMiContext>, IUserDal
    {
    }
}
