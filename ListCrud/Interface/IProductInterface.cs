using ListCrud.Model;

namespace ListCrud.Interface
{
    public interface IProductInterface
    {
         List<Product> getAllProducts();
        Product? getProductById(int id);
        void deleteProductById(int id);
        void AddProduct( Product product);
        void UpdateProduct(int id,Product product);
    }
}
