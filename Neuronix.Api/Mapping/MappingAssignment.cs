using AutoMapper;
using Neuronix.Api.Dtos;
using Neuronix.Core.Models;

namespace Neuronix.Api.Mapping;

public class MappingAssignment : Profile
{
    public MappingAssignment()
    {
        // Domain to Resource
        CreateMap<AssignmentCreateDto, Assignment>();
    }
    
}