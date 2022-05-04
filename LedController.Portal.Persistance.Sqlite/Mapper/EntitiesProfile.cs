using System;
using System.Linq;
using System.Net;

using AutoMapper;

using LedController.Domain.Models;
using LedController.Shared.Mapping;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Entities;



namespace LedController.WebPortal.Persistence.Sqlite.Mapper;

public class EntitiesProfile : Profile
{
	public EntitiesProfile()
	{
		CreateMap<Animation, AnimationEntity>()
		   .ReverseMap();

		CreateMap<EffectFile, EffectFileEntity>()
		   .ReverseMap();

		CreateMap<Effect, EffectEntity>()
		   .ForMember(dest => dest.AssemblyId, opt => opt.MapFrom(src => src.EffectAssembly!.Id.ToString()))
		   .ReverseMap()
		   .ForMember(dest => dest.EffectAssembly,
					  opt => opt.MapFrom(src => new EffectAssembly
					  {
						  Id = src.Id
					  }));

		CreateMap<AnimationEffect, AnimationEffectEntity>()
		   .ForMember(m => m.AnimationId, opt => opt.MapFrom(s => s.Animation!.Id))
		   .ForMember(m => m.Animation, opt => opt.Ignore())
		   .ForMember(m => m.EffectId, opt => opt.MapFrom(s => s.Effect!.Id))
		   .ForMember(m => m.Effect, opt => opt.Ignore())
		   .ReverseMap();

		CreateMap<Controller, ControllerEntity>()
		   .ForMember(m => m.IpAddress, opt => opt.MapFrom(s => s.EndPoint.Address.ToString()))
		   .ForMember(m => m.Port, opt => opt.MapFrom(c => c.EndPoint.Port))
		   .ReverseMap()
		   .ForMember(m => m.EndPoint, opt => opt.MapFrom(s => new IPEndPoint(IPAddress.Parse(s.IpAddress), s.Port)));

		CreateMap<Ledstrip, LedstripEntity>()
		   .ForMember(m => m.SpiBusId, opt => opt.MapFrom(s => s.SpiBus!.Id))
		   .ForMember(m => m.SpiBus, opt => opt.Ignore())
		   .ReverseMap();

		CreateMap<SpiBus, SpiBusEntity>()
		   .ForMember(m => m.ClockSpeed, opt => opt.MapFrom(s => s.Settings!.ClockSpeed))
		   .ForMember(m => m.DataBitLength, opt => opt.MapFrom(s => s.Settings!.DataBitLength))
		   .ForMember(m => m.DataFlow, opt => opt.MapFrom(s => s.Settings!.DataFlow))
		   .ForMember(m => m.Mode, opt => opt.MapFrom(s => s.Settings!.Mode))
		   .ReverseMap()
		   .ForMember(m => m.Settings,
					  opt => opt.MapFrom(s => new SpiBusSettings
					  {
						  ClockSpeed = s.ClockSpeed,
						  DataBitLength = s.DataBitLength,
						  DataFlow = s.DataFlow,
						  Mode = s.Mode
					  }));

		CreateMap<AnimationEffectParameterValue, AnimationEffectParameterEntity>()
		   .ForMember(m => m.SerializedValue, opt => opt.ConvertUsing(new JsonObjectStringValueConverter(), src => src.Value))
		   .ReverseMap()
		   .ForMember(m => m.Value, opt => opt.ConvertUsing(new JsonStringObjectValueConverter(), src => src.SerializedValue));

		CreateMap<EffectParameter, EffectParameterEntity>()
		   .ForMember(m => m.PropertyTypeName, opt => opt.MapFrom(src => src.ParameterType))
		   .ForMember(m => m.DefaultValue, opt => opt.ConvertUsing(new JsonObjectStringValueConverter(), src => src.DefaultValue))
		   .ReverseMap()
		   .ForMember(m => m.DefaultValue, opt => opt.ConvertUsing(new JsonStringObjectValueConverter(), src => src.DefaultValue))
		   .ForMember(m => m.ParameterType, opt => opt.MapFrom(src => src.PropertyTypeName));
	}
}