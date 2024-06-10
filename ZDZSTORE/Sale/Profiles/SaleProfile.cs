using AutoMapper;
using ZDZSTORE.Sale.DTO;
using ZDZSTORE.Sale.Model;

namespace ZDZSTORE.Sale.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<CreateSaleDTO, SaleModel>();
            CreateMap<SaleModel, ResponseSaleWithItemsDTO>()
                .ForMember(responseSale => responseSale.items, options => options.MapFrom(saleModel => saleModel.items));

            CreateMap<SaleModel, ResponseSaleDTO>()
                 .ForMember(dest => dest.amountItems, opt => opt.MapFrom(src => src.items.Sum(item => item.amount)));

            CreateMap<CreateItemDTO, ItemModel>();
            CreateMap<ItemModel, ResponseItemDTO>();
        }
    }
}
