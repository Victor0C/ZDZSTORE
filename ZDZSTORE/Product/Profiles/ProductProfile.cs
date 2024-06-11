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
            CreateMap<UpdateProductDTO, ProductModel>()
                .ForMember(dest => dest.name, opt =>
                {
                    opt.Condition((src, dest, srcMember) => srcMember != null);
                })
                .ForMember(dest => dest.amount, opt =>
                {
                    opt.Condition((src, dest, srcMember) => srcMember != null);
                    opt.MapFrom((src, dest, destMember, context) => src.amount.HasValue ? src.amount : destMember);
                })
                .ForMember(dest => dest.price, opt =>
                {
                    opt.Condition((src, dest, srcMember) => srcMember != null);
                    opt.MapFrom((src, dest, destMember, context) => src.price.HasValue ? src.price : destMember);
                });
        }
    }
}
