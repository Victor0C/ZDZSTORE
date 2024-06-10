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
            CreateMap<SaleModel, ResponseSaleDTO>();
            CreateMap<SaleModel, UpdateSaleDTO>();
            CreateMap<UpdateSaleDTO, SaleModel>();
        }
    }
}
