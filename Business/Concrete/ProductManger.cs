using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
       public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdd);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductUpdate);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetProductList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().OrderByDescending(product => product.AddedDate).ToList())    ;
        }
        public IDataResult<List<HomeDto>> GetHomeList()
        {
            return new SuccessDataResult<List<HomeDto>>(_productDal.GetAllHomeProduct());
        }
        public IDataResult<List<HomeDto>> GetByCateggoryIdProductList(int categoryId)
        {
            return new SuccessDataResult<List<HomeDto>>(_productDal.GetByCategoryId(categoryId));
        }

        public IResult Update(Product product)
        {
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                _productDal.Update(product);
            }
            return new SuccessResult(Messages.ProductUpdate);
        }
    }
}

