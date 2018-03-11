using AutoMapper;
using Hydocs.Areas.AdWorks.Models.DB;

namespace Hydocs.Inrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, Areas.AdWorks.Models.ProductDTO>();
          
        }
    }
}