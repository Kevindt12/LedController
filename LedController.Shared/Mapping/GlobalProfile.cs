using System;
using System.Linq;
using System.Net;

using AutoMapper;

using UnitsNet;



namespace LedController.Shared.Mapping;

internal class GlobalProfile : Profile
{
    public GlobalProfile()
    {
        // IP Address type converter 
        CreateMap<IPAddress?, string?>().ConvertUsing<IPAddressStringTypeConverter>();
        CreateMap<string?, IPAddress?>().ConvertUsing<IPAddressStringTypeConverter>();

        // Type type converter
        CreateMap<Type?, string?>().ConvertUsing<TypeStringTypeConverter>();
        CreateMap<string?, Type?>().ConvertUsing<TypeStringTypeConverter>();

        // Frequency
        CreateMap<Frequency, double>().ConvertUsing<FrequencyTypeConverter>();
        CreateMap<double, Frequency>().ConvertUsing<FrequencyTypeConverter>();
    }
}