using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IImageProduct
    {
        public Task<int> InsertImageCategory(string path, string alt);
    }
}
