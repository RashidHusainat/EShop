using EShop.BuildingBlocks.Exceptions;

namespace EShop.CatalogAPI.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        //public ProductNotFoundException() : base("Product",0)
        //{
                
        //}

        public ProductNotFoundException(Guid id):base("Product",id)
        {

        }
    }
}
