using System.Collections.Generic;
using RiSAT.Eshop.Application.Products.Queries.GetProductsFile;

namespace RiSAT.Eshop.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
