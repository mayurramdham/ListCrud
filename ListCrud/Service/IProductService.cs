using ListCrud.Interface;
using ListCrud.Model;

namespace ListCrud.Service
{
    public class IProductService : IProductInterface
    {
        private static List<Product> _products = new List<Product>();
        public List<Product> ProductsService()
        {
            _products.AddRange(new List<Product>
            {
                new Product { Id = 1, Name = "Mayur", Price = 8585.58M, Quantity = 2 },
                new Product { Id = 2, Name = "Chirag", Price = 8085.58M, Quantity = 5 },
                new Product { Id = 3, Name = "Ajay", Price = 1052.58M, Quantity = 3 },
                new Product { Id = 4, Name = "Atul", Price = 10.58M, Quantity = 4 },
                new Product { Id = 3, Name = "Aditya", Price = 102.58M, Quantity = 6 }
            });
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public Product? getProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void deleteProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
        public List<Product> getAllProducts()
        {
            return _products.ToList();
        }
    
    public void UpdateProduct(int id, Product updateProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
                product.Id = updateProduct.Id;
                product.Name = updateProduct.Name;
                product.Price = updateProduct.Price;
                product.Quantity = updateProduct.Quantity;
        }
        
    }
}
}
