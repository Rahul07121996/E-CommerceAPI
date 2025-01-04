using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data
{
    public class ProductRepositry(StoreContext storeContext) : IProductRepositry
    {
        void IProductRepositry.AddProduct(Product product)
        {
            storeContext.Products.Add(product);
        }

        void IProductRepositry.DeleteProduct(Product product)
        {
            storeContext.Products.Remove(product);
        }

        async Task<IReadOnlyList<Product>> IProductRepositry.GetProductAsyn()
        {
            return await storeContext.Products.ToListAsync();
        }

        async Task<Product?> IProductRepositry.GetProductByIdAsyn(int id)
        {
            return await storeContext.Products.FindAsync(id);
        }

        bool IProductRepositry.Productexists(int Id)
        {
            return storeContext.Products.Any(x => x.Id == Id);
        }

        async Task<bool> IProductRepositry.SaveChangesAsyn()
        {
            return await storeContext.SaveChangesAsync() > 0;
        }

        void IProductRepositry.UpdateProduct(Product product)
        {
            storeContext.Entry(product).State = EntityState.Modified;
        }
    }
}
