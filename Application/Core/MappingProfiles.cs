using System;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ExampleEntity, ExampleEntity>(); //telling automapper that its job is to map one ExampleEntity to another ExampleEntity. For PUTs for example
    }
}