﻿using AutoMapper;

namespace Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        void MappingFrom(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
