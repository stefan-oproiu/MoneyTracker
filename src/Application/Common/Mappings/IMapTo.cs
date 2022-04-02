﻿using AutoMapper;

namespace Application.Common.Mappings
{
    public interface IMapTo<T>
    {
        void MappingTo(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
