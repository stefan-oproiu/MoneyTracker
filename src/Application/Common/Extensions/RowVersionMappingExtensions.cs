using Application.Common.Models;
using AutoMapper;
using Domain.Common;

namespace Application.Common.Extensions
{
    public static class RowVersionMappingExtensions
    {
        public static IMappingExpression<TModel, TEntity> MapToEntity<TModel, TEntity>(this Profile profile)
            where TModel : RowVersionModel
            where TEntity : RowVersionEntity
        {
            return profile.CreateMap<TModel, TEntity>()
                .ForMember(dest => dest.RowVersion, opt => opt.MapFrom(src => Convert.FromBase64String(src.RowVersion)));
        }

        public static IMappingExpression<TEntity, TModel> MapToModel<TEntity, TModel>(this Profile profile)
            where TEntity : RowVersionEntity
            where TModel : RowVersionModel
        {
            return profile.CreateMap<TEntity, TModel>()
                .ForMember(dest => dest.RowVersion, opt => opt.MapFrom(src => Convert.ToBase64String(src.RowVersion)));
        }
    }
}
