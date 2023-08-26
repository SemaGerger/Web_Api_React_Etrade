using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Dal;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Repository.Abstract;
using Mvc_Api_Etrade.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Concretes
{
    public class ProductRepos : BaseRepos<Product>, IProduct
    {
        public ProductRepos(PerContext context, GeneralResponse response) : base(context, response)
        {
        }

        public List<ProductsDTO> GetProducts()
        {
            return Set().Select(x => new ProductsDTO
            {
                Id = x.Id,
                Description = x.Description,
                CategoryName = x.Categories.Description,
                SupplierName = x.Suppliers.Description,
                Price = x.UnitPrice,
                PhotoUrl = x.PhotoUrl,
            }).ToList();
        }

        public void AddDefaultProducts()
        {
            if (_context.Products.Any())
            {
                return;
            }

            List<Product> defaultProducts = new List<Product>
    {
        new Product
        {
            Description = "Doğa Fotoğrafı 1",
            CategoryId = 1,
            UnitPrice = 1000,
            VAT = 18,
            SupplierId = 1,
            PhotoUrl = "https://avatars.mds.yandex.net/i?id=1eda17f6a76acbeec1e5893a7aafe2e1e6af2f22-9100837-images-thumbs&n=13"
        },
        new Product
        {
            Description = "Doğa Fotoğrafı 2",
            CategoryId = 1,
            UnitPrice = 1500,
            VAT = 18,
            SupplierId = 1,
            PhotoUrl = "https://avatars.mds.yandex.net/i?id=7d95043921bad4ad4d6c44ab45e2abd497bc3dca-10350639-images-thumbs&n=13"
        },

          new Product
        {
            Description = "Doğa Fotoğrafı 3",
            CategoryId = 1,
            UnitPrice = 1700,
            VAT = 18,
            SupplierId = 1,
            PhotoUrl = "https://i.pinimg.com/originals/e4/ca/c6/e4cac6fc781e736baf4d00fd2bb2e6c6.jpg"
        },
    };

          
            _context.Products.AddRange(defaultProducts);
            _context.SaveChanges();
        }


    }
}

