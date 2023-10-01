using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.Fabric;
using Entity.DTOs.Foot;
using Entity.DTOs.FootColor;
using Entity.DTOs.Order;
using Entity.DTOs.Product;
using Entity.DTOs.ProductColor;
using Entity.DTOs.Proforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers.AutoMapper
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductColor, ResultProductColorDto>().ReverseMap();
            CreateMap<ProductColor, CreateProductColorDto>().ReverseMap();
            CreateMap<ProductColor, UpdateProductColorDto>().ReverseMap();

            CreateMap<Foot, ResultFootDto>().ReverseMap();
            CreateMap<Foot, CreateFootDto>().ReverseMap();
            CreateMap<Foot, UpdateFootDto>().ReverseMap();

            CreateMap<FootColor, ResultFootColorDto>().ReverseMap();
            CreateMap<FootColor, CreateFootColorDto>().ReverseMap();
            CreateMap<FootColor, UpdateFootColorDto>().ReverseMap();

            CreateMap<Fabric, ResultFabricDto>().ReverseMap();
            CreateMap<Fabric, CreateFabricDto>().ReverseMap();
            CreateMap<Fabric, UpdateFabricDto>().ReverseMap();

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<Proforma, ResultProformaDto>().ReverseMap();
            CreateMap<Proforma, CreateProformaDto>().ReverseMap();
            CreateMap<Proforma, UpdateProformaDto>().ReverseMap();
        }
    }
}
