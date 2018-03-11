using AutoMapper;
using Hydocs.Areas.AdWorks.Models.DB;

namespace Hydocs.Areas.AdWorks.Models
{
    public class ProductDTO
    {
        public int ProductKey { get; set; }
        public string ProductAlternateKey { get; set; }
        public string EnglishProductName { get; set; }
        public decimal? StandardCost { get; set; }
        public string EnglishDescription { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public decimal? ListPrice { get; set; }
        public string Size { get; set; }
        public double? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public decimal? DealerPrice { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ModelName { get; set; }
        //public string EnglishDescription { get; set; }
        public string Status { get; set; }

        //public class Mappings : Profile
        //{
        //    public Mappings()
        //    {
        //        CreateMap<Product, ProductDTO>();
        //    }
        //}
    }
}