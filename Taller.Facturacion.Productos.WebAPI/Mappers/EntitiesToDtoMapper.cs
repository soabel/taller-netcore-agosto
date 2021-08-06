using System;
using Taller.Facturacion.Productos.Application.Dtos;
using Taller.Facturacion.Productos.Domain.Entities;

namespace Taller.Facturacion.Productos.WebAPI.Mappers
{
    public class EntitiesToDtoMapper: AutoMapper.Profile
    {
        public EntitiesToDtoMapper()
        {
            //CreateMap<ProductSizeRequest, ProductSize>();

            //CreateMap<Product, ProductStoreSaveRequest>()
            //    .ForMember(s => s.Colors, c => c.MapFrom(m => m.Colors))
            //    .ForMember(s => s.Sizes, c => c.MapFrom(m => m.Sizes));

            CreateMap<Producto, ProductoDto>()
                .ForMember(destination=> destination.Categoria, source=> source.MapFrom(p=> p.Category.Nombre));

        }
    }
}
