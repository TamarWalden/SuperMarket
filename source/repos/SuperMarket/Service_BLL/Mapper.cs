using AutoMapper;
using Common_DTO.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository_Dal.Models;

namespace Service_BLL
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<DepartmentDTO, Department>().ReverseMap();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.DepartmentCodeNavigation.Name))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyCodeNavigation.Name));
            CreateMap<PurchaseDetailDTO, PurchaseDetail>().ReverseMap();
            CreateMap<ShoppingDTO, Shopping>().ReverseMap();
        }
    }
}
