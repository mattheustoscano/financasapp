using AutoMapper;
using FinancasApp.Domain.Dtos.Requests;
using FinancasApp.Domain.Dtos.Responses;
using FinancasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Domain.Mappings
{
    /// <summary>
    /// Configuração dos mapeamentos do AutoMapper
    /// </summary>
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<CategoriaRequest, Categoria>();

            CreateMap<MovimentacaoRequest, Movimentacao>()
                .ForMember(dest => dest.Data,
                            opt => opt.MapFrom(src => DateOnly.Parse(src.Data)))
                .ForMember(dest => dest.Tipo,
                            opt => opt.MapFrom(src => (TipoMovimentacao)src.Tipo));

            CreateMap<Categoria, CategoriaResponse>();

            CreateMap<Movimentacao, MovimentacaoResponse>()
                  .ForMember(dest => dest.Data,
                              opt => opt.MapFrom(src => src.Data.HasValue
                                    ? src.Data.Value.ToString("yyyy-MM-dd")
                                    : string.Empty))
                  .ForMember(dest => dest.Tipo,
                              opt => opt.MapFrom(src => src.Tipo.HasValue
                                   ? (int)src.Tipo.Value
                                   : 0));
        }
    }
}
