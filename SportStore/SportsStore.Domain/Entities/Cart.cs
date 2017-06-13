using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollections = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollections
                .FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
            {
                _lineCollections.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            _lineCollections.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollections.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            _lineCollections.Clear();
        }

        public IEnumerable<CartLine> Lines => _lineCollections;
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}



