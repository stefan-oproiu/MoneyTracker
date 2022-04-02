using Application.Common.Extensions;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.MoneyCategories.ViewModels
{
    public class MoneyCategoryViewModel : RowVersionViewModel, IMapFrom<MoneyCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public MoneyCategoryType Type { get; set; }

        public void MappingFrom(Profile profile)
        {
            profile.MapToModel<MoneyCategory, MoneyCategoryViewModel>();
        }
    }
}
