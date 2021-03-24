using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Concrete.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    //manager gorursen is katmaninin soyut sinifi 
    {
        IProductDal _productDal;//Injection //soyut nesneyle baglanti kur.
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //eger mevcut kategori sayisi 15 i gectiyse sisteme yeni urun eklenemez
            IResult result = BusinessRules.Run(
                 CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                 CheckIfProductNameExists(product.ProductName),
                 CheckIfCategoryLimitIsExceded()
                 );
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }
        [CasheAspect] //cache'lenmek istenen data key,value,pair ile tutulur,Key cacheye verdigimiz adres ismi
        public IDataResult<List<Product>> GetAll()
        {
            //is kodlari , BIR IS SINIFI BASKA SINIFLARI NEWLEMEZ!!
            //Yetkisi var mi
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>("Sistem Bakimda");
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }


        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(c => c.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => max >= c.UnitPrice && c.UnitPrice >= min));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitIsExceded()
        {
            var result = _categoryService.GetAll().Data.Count;
            if (result <= 15)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CategoryLimitIsExceded);
        }
    }


}
