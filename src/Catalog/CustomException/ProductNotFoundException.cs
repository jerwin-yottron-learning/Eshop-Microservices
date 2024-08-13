using BuildingBlocks.Exceptions;

namespace Catalog.Api.CustomException
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid Id) : base("Product",Id)
        {
        }
    }

}
