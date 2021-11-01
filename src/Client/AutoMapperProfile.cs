using AutoMapper;
using BimKrav.Client.ViewModels;
using BimKrav.Shared.Models;

namespace BimKrav.Client;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Property, PropertyViewModel>();
    }
}