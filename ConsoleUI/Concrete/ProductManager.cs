using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public IEnumerable<object> GetAllByCategoryId { get; internal set; }

        public List<Product> GetAll()
        {
            //is kodlari , BIR IS SINIFI BASKA SINIFLARI NEWLEMEZ!!
            //Yetkis var mi
            return _productDal.GetAll();
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductService.GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
    }

    
}
