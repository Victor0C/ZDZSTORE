using AutoMapper;
using ZDZSTORE.Product.DTO;
using ZDZSTORE.Product.Model;

namespace ZDZSTORE.Product.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, ProductModel>();
            CreateMap<ProductModel, ResponseProductDTO>();
            CreateMap<ProductModel, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, ProductModel>();
        }
    }
}
