using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
             new Product{ProductId=1,CategoryId=1,UnitsInStock=15,UnitPrice=15,ProductName="Bardak" },
             new Product{ProductId=2,CategoryId=1,UnitsInStock=3,UnitPrice=500,ProductName="Kitaplık" },
             new Product{ProductId=3,CategoryId=2,UnitsInStock=2,UnitPrice=1500,ProductName="Mouse" },
             new Product{ProductId=4,CategoryId=2,UnitsInStock=65,UnitPrice=150,ProductName="Bilgisayar" },
             new Product{ProductId=5,CategoryId=2,UnitsInStock=1,UnitPrice=85,ProductName="Klavye" }

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           
           Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün Id'sine sahip olan listedeki Urun Id'sini bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
