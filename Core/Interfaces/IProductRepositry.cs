using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepositry
    {
        Task<IReadOnlyList<Product>> GetProductAsyn();

        Task<Product?> GetProductByIdAsyn(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        bool Productexists (int Id);

        Task<bool> SaveChangesAsyn();



    }
}
