using System.Collections.Generic;
using System.Linq;
using BeeFC.Models;

namespace BeeFC.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Gà Rán Truyền Thống", Price = 90000, Description = "Gà rán truyền thống giòn rụm, thơm ngon, chuẩn vị.", CategoryId = 1, ImageUrl = "/images/1.png" },
                new Product { Id = 2, Name = "Gà Rán Cay", Price = 95000, Description = "Gà rán vị cay hấp dẫn, giòn rụm.", CategoryId = 1, ImageUrl = "/images/2.png" },
                new Product { Id = 3, Name = "Burger Bò", Price = 65000, Description = "Burger bò mềm, sốt đặc biệt.", CategoryId = 2, ImageUrl = "/images/3.png" },
                new Product { Id = 4, Name = "Burger Gà", Price = 60000, Description = "Burger gà giòn, rau tươi.", CategoryId = 2, ImageUrl = "/images/4.png" },
                new Product { Id = 5, Name = "Mì Ý Sốt Bò Bằm", Price = 70000, Description = "Mì Ý sốt bò bằm đậm đà.", CategoryId = 3, ImageUrl = "/images/5.png" },
                new Product { Id = 6, Name = "Mì Ý Sốt Kem", Price = 75000, Description = "Mì Ý sốt kem béo ngậy.", CategoryId = 3, ImageUrl = "/images/6.png" },
                new Product { Id = 7, Name = "Kem Tươi", Price = 25000, Description = "Kem tươi mát lạnh, nhiều vị.", CategoryId = 4, ImageUrl = "/images/7.png" },
                new Product { Id = 8, Name = "Bánh Flan", Price = 20000, Description = "Bánh flan mềm mịn, ngọt dịu.", CategoryId = 4, ImageUrl = "/images/8.png" },
                new Product { Id = 9, Name = "Pepsi", Price = 15000, Description = "Nước ngọt Pepsi lon 330ml.", CategoryId = 5, ImageUrl = "/images/9.png" },
                new Product { Id = 10, Name = "Trà Đào", Price = 20000, Description = "Trà đào tươi mát, vị ngọt nhẹ.", CategoryId = 5, ImageUrl = "/images/10.png" },
                new Product { Id = 11, Name = "Gà Sốt Mật Ong", Price = 98000, Description = "Gà rán sốt mật ong ngọt dịu.", CategoryId = 1, ImageUrl = "/images/11.png" },
                new Product { Id = 12, Name = "Gà Sốt Phô Mai", Price = 105000, Description = "Gà rán sốt phô mai béo ngậy.", CategoryId = 1, ImageUrl = "/images/12.png" },
                new Product { Id = 13, Name = "Burger Cá", Price = 65000, Description = "Burger cá chiên xù, sốt tartar.", CategoryId = 2, ImageUrl = "/images/13.png" },
                new Product { Id = 14, Name = "Nước Cam Tươi", Price = 25000, Description = "Nước cam tươi nguyên chất.", CategoryId = 5, ImageUrl = "/images/14.png" }
            };
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product ?? new Product(); // Không trả về null, tránh CS8603
        }

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var idx = _products.FindIndex(p => p.Id == product.Id);
            if (idx != -1) _products[idx] = product;
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) _products.Remove(product);
        }
    }
}
