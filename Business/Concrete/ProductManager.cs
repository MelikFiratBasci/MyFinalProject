using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService 
    //manager gorursen is katmaninin soyut sinifi 
    {
        IProductDal _productDal;//Injection //soyut nesneyle baglanti kur.


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //is kodlari , BIR IS SINIFI BASKA SINIFLARI NEWLEMEZ!!
            //Yetkisi var mi
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(c => c.CategoryId == id);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(c => c.ProductId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(c => max >= c.UnitPrice && c.UnitPrice>=min);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }

    
}
