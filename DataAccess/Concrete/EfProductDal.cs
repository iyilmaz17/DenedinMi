using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System.Collections.Concurrent;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfProductDal : EfEntityRepositoryBase<Product, DenedinMiContext>, IProductDal
{
    //public List<HomeDto> GetAllHomeProduct()
    //{
    //    using (DenedinMiContext context = new DenedinMiContext())
    //    {
    //        var result = from p in context.Products
    //                     join i in context.Images on p.Id equals i.ProductId
    //                     join c in context.Comments on p.Id equals c.ProductId
    //                     select new HomeDto
    //                     {
    //                         Id = p.Id,
    //                         Name = p.Name,
    //                         CreatedDate = c.CreatedDate,
    //                         CommentDescription = c.CommentDescription,
    //                         ImageUrl = i.ImageUrl
    //                     };
    //        return result.ToList();
    //    }

    //}


    public List<HomeDto> GetAllHomeProduct()
    {
        using (DenedinMiContext context = new DenedinMiContext())
        {
            // Adım 1: Products ve Images tablolarını birleştir
            var step1 = context.Products
                .Join(
                    context.Images,
                    p => p.Id,
                    i => i.ProductId,
                    (p, i) => new { Product = p, Image = i }
                )
                .ToList();

            // Adım 2: Yorumları ekleyerek birleştir
            var step2 = step1
                .Join(
                    context.Comments,
                    pi => pi.Product.Id,
                    c => c.ProductId,
                    (pi, c) => new
                    {
                        ProductId = pi.Product.Id,
                        ProductName = pi.Product.Name,
                        CommentCreatedDate = c.CreatedDate,
                        CommentDescription = c.CommentDescription,
                        ImageUrl = pi.Image.ImageUrl
                    }
                )
                .ToList();

            // Adım 3: Yorumları tarihe göre sırala ve grupla
            var step3 = step2
                .OrderByDescending(x => x.CommentCreatedDate)
                .GroupBy(x => x.ProductId)
                .Select(group => group.First())
                .ToList();

            // Adım 4: Sonucu HomeDto'ya çevir
            var result = step3
                .Select(x => new HomeDto
                {
                    Id = x.ProductId,
                    Name = x.ProductName,
                    CreatedDate = x.CommentCreatedDate,
                    CommentDescription = x.CommentDescription,
                    ImageUrl = x.ImageUrl
                })
                .ToList();

            return result;
        }


    }




    //public List<HomeDto> GetByCategoryId(int categoryId)
    //{
    //    using (DenedinMiContext context = new DenedinMiContext())
    //    {
    //        var result = from p in context.Products
    //                     join i in context.Images on p.Id equals i.ProductId
    //                     join c in context.Comments on p.Id equals c.ProductId
    //                     where p.CategoryId == categoryId
    //                     select new HomeDto
    //                     {
    //                         Id = p.Id,
    //                         Name = p.Name,
    //                         CreatedDate = c.CreatedDate,
    //                         CommentDescription = c.CommentDescription,
    //                         ImageUrl = i.ImageUrl
    //                     };

    //        return result.ToList();
    //    }

    //}
    public List<HomeDto> GetByCategoryId(int categoryId)
    {
        using (DenedinMiContext context = new DenedinMiContext())
        {
            var result = from p in context.Products
                         join i in context.Images on p.Id equals i.ProductId
                         join c in context.Comments on p.Id equals c.ProductId
                         where p.CategoryId == categoryId
                         group new { p, i, c } by p.Id into grouped
                         select new HomeDto
                         {
                             Id = grouped.Key,
                             Name = grouped.First().p.Name,
                             CreatedDate = grouped.First().c.CreatedDate,
                             CommentDescription = grouped.First().c.CommentDescription,
                             ImageUrl = grouped.First().i.ImageUrl
                         };

            return result.ToList();
        }
    }

}