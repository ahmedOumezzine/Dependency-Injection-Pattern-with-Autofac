using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Pattern_Autofac.Core.Repository
{
    public interface TeamRepository : IService<Product>
    {
        Task<List<Product>> GetAllWithIncludeAsync();

        Task<List<Product>> GetBySupplierIdAsync(long supplierId);
    }
}
